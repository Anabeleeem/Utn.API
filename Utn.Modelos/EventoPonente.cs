using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Utn.Modelos
{
    public class EventoPonente
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("EVENTOID")]
        public int EventoId { get; set; }

        [Column("PONENTEID")]
        public int PonenteId { get; set; }

        [JsonIgnore]
        public Evento? Evento { get; set; }

        [JsonIgnore]
        public Ponente? Ponente { get; set; }
    }
}
