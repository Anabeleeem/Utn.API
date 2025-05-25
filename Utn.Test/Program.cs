using Utn.Api.Consumer;
using System;
using Newtonsoft.Json;
using Utn.Modelos;

namespace EventosUniversitarios.Consumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProbarEventos();
            
            Console.ReadLine();
        }

        private static void ProbarEventos()
        {
            Crud<Evento>.EndPoint = "https://localhost:7152/api/Eventos";

            // Crear un nuevo evento
            var nuevoEvento = Crud<Evento>.Create(new Evento
            {
                Nombre = "Conferencia de .NET Core",
                Fecha = DateTime.Now.AddDays(30),
                Lugar = "Aula Magna",
                Tipo = "Conferencia",
                Descripcion = "Evento sobre las novedades de .NET Core"
            });

            // Actualizar el evento
            nuevoEvento.Descripcion = "Evento actualizado sobre .NET 8";
            Crud<Evento>.Update(nuevoEvento.Id, nuevoEvento);

            // Listar todos los eventos
            var eventos = Crud<Evento>.GetAll();
            foreach (var e in eventos)
            {
                Console.WriteLine($"ID: {e.Id}, Nombre: {e.Nombre}, Fecha: {e.Fecha.ToShortDateString()}, Lugar: {e.Lugar}");
            }
        }

        private static void ProbarParticipantes()
        {
            Crud<Participante>.EndPoint = "https://localhost:7152/api/Participantes";

            var participante = Crud<Participante>.Create(new Participante
            {
                Nombre = "Juan Pérez",
                Correo = "juan@email.com",
                Telefono = "123456789",
                DocumentoIdentidad = "12345678A"
            });

            participante.Correo = "juan.actualizado@email.com";
            Crud<Participante>.Update(participante.Id, participante);

            var participantes = Crud<Participante>.GetAll();
            foreach (var p in participantes)
            {
                Console.WriteLine($"ID: {p.Id}, Nombre: {p.Nombre}, Documento: {p.DocumentoIdentidad}");
            }
        }

        private static void ProbarPonentes()
        {
            Crud<Ponente>.EndPoint = "https://localhost:7152/api/Ponentes";

            var ponente = Crud<Ponente>.Create(new Ponente
            {
                Nombre = "María García",
                Especialidad = "Desarrollo .NET",
                Correo = "maria@email.com",
                Telefono = "987654321"
            });

            ponente.Especialidad = "Desarrollo .NET Core";
            Crud<Ponente>.Update(ponente.Id, ponente);

            var ponentes = Crud<Ponente>.GetAll();
            foreach (var p in ponentes)
            {
                Console.WriteLine($"ID: {p.Id}, Nombre: {p.Nombre}, Especialidad: {p.Especialidad}");
            }
        }

        private static void ProbarInscripciones()
        {
            Crud<Inscripcion>.EndPoint = "https://localhost:7152/api/Inscripciones";

            // Asumimos que ya existen Evento (ID=1) y Participante (ID=1)
            var inscripcion = Crud<Inscripcion>.Create(new Inscripcion
            {
                FechaInscripcion = DateTime.Now,
                Estado = "Confirmada",
                ParticipanteId = 1,
                EventoId = 1
            });

            inscripcion.Estado = "Pagada";
            Crud<Inscripcion>.Update(inscripcion.Id, inscripcion);

            var inscripciones = Crud<Inscripcion>.GetAll();
            foreach (var i in inscripciones)
            {
                Console.WriteLine($"ID: {i.Id}, Evento: {i.Evento.Nombre}, Participante: {i.Participante.Nombre}, Estado: {i.Estado}");
            }
        }

        private static void ProbarPagos()
        {
            Crud<Pago>.EndPoint = "https://localhost:7152/api/Pagos";

            // Asumimos que ya existe Inscripcion (ID=1)
            var pago = Crud<Pago>.Create(new Pago
            {
                Monto = 150.50m,
                FechaPago = DateTime.Now,
                MedioPago = "Tarjeta",
                InscripcionId = 1
            });

            pago.MedioPago = "Transferencia";
            Crud<Pago>.Update(pago.Id, pago);

            var pagos = Crud<Pago>.GetAll();
            foreach (var p in pagos)
            {
                Console.WriteLine($"ID: {p.Id}, Monto: {p.Monto}, Inscripción: {p.Inscripcion.Id}");
            }
        }

        private static void ProbarCertificados()
        {
            Crud<Certificado>.EndPoint = "https://localhost:7152/api/Certificados";

            // Asumimos que ya existe Inscripcion (ID=1)
            var certificado = Crud<Certificado>.Create(new Certificado
            {
                Codigo = Guid.NewGuid().ToString(),
                FechaEmision = DateTime.Now,
                InscripcionId = 1
            });

            certificado.Codigo = "CERT-" + certificado.Codigo;
            Crud<Certificado>.Update(certificado.Id, certificado);

            var certificados = Crud<Certificado>.GetAll();
            foreach (var c in certificados)
            {
                Console.WriteLine($"ID: {c.Id}, Código: {c.Codigo}, Inscripción: {c.Inscripcion.Id}");
            }
        }

        private static void ProbarEventoPonentes()
        {
            // No usamos Crud directo porque es una relación muchos-a-muchos
            // Necesitamos un endpoint especial

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7041/api/");

            // Asignar ponente (ID=1) a evento (ID=1)
            var response = client.PostAsync($"EventoPonente/1/asignar/1", null).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Ponente asignado correctamente al evento");

                // Obtener ponentes del evento 1
                var ponentes = client.GetAsync("Eventos/1/ponentes").Result;
                if (ponentes.IsSuccessStatusCode)
                {
                    var json = ponentes.Content.ReadAsStringAsync().Result;
                    var listaPonentes = JsonConvert.DeserializeObject<List<Ponente>>(json);

                    foreach (var p in listaPonentes)
                    {
                        Console.WriteLine($"Ponente: {p.Nombre}");
                    }
                }
            }
        }
    }
}