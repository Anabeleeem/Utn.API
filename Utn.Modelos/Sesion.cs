using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Utn.Modelos
{
    public class Sesion
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NOMBRE")]
        public string Nombre { get; set; } = string.Empty;

        [Column("FECHAHORAINICIO")]
        public DateTime FechaHoraInicio { get; set; }

        [Column("FECHAHORAFIN")]
        public DateTime FechaHoraFin { get; set; }

        [Column("SALA")]
        public string Sala { get; set; } = string.Empty;

        // Clave foránea
        [Column("EVENTOID")]
        public int EventoId { get; set; }

        // Navegación
        [JsonIgnore]
        public Evento? Evento { get; set; }
    }
}
