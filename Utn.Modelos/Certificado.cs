using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Utn.Modelos
{
    [Table("CERTIFICADOS")] 
    public class Certificado
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("CODIGO")]
        public string Codigo { get; set; } = string.Empty;

        [Required]
        [Column("FECHAEMISION")]
        public DateTime FechaEmision { get; set; }

        [Required]
        [Column("INSCRIPCIONID")]
        public int InscripcionId { get; set; }

        [JsonIgnore]
        public Inscripcion? Inscripcion { get; set; }
    }
}
