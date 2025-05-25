using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Utn.Modelos
{
    public class Pago
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("MONTO", TypeName = "NUMBER(10,2)")]
        public decimal Monto { get; set; }

        [Column("FECHAPAGO")]
        public DateTime FechaPago { get; set; }

        [Column("MEDIOPAGO")]
        public string MedioPago { get; set; } = string.Empty;

        [Column("INSCRIPCIONID")]
        public int InscripcionId { get; set; }

        [JsonIgnore]
        public Inscripcion? Inscripcion { get; set; }
    }
}
