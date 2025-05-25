using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // IMPORTANTE
using System.Text.Json.Serialization;

namespace Utn.Modelos
{
    public class Evento
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NOMBRE")]
        public string Nombre { get; set; }

        [Column("FECHA")]
        public DateTime Fecha { get; set; }

        [Column("LUGAR")]
        public string Lugar { get; set; }

        [Column("TIPO")]
        public string Tipo { get; set; }

        [Column("DESCRIPCION")]
        public string Descripcion { get; set; }

        // Relaciones
        [JsonIgnore]
        public List<Sesion>? Sesiones { get; set; }

        [JsonIgnore]
        public List<EventoPonente>? EventoPonentes { get; set; }

        [JsonIgnore]
        public List<Inscripcion>? Inscripciones { get; set; }
    }
}
