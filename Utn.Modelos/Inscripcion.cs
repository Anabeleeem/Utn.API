using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Utn.Modelos
{
    public class Inscripcion
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("FECHAINSCRIPCION")]
        public DateTime FechaInscripcion { get; set; }

        [Column("ESTADO")]
        public string Estado { get; set; } = string.Empty;

        [Column("PARTICIPANTEID")]
        public int ParticipanteId { get; set; }

        [Column("EVENTOID")]
        public int EventoId { get; set; }

        // Relaciones
        [JsonIgnore]
        public Participante? Participante { get; set; }

        [JsonIgnore]
        public Evento? Evento { get; set; }

        [JsonIgnore]
        public List<Pago>? Pagos { get; set; }
    }
}
