using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utn.Modelos
{
    public class Ponente
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NOMBRE")]
        public string Nombre { get; set; } = string.Empty;

        [Column("ESPECIALIDAD")]
        public string Especialidad { get; set; } = string.Empty;

        [Column("CORREO")]
        public string Correo { get; set; } = string.Empty;

        [Column("TELEFONO")]
        public string Telefono { get; set; } = string.Empty;

        // Relación muchos a muchos
        public List<EventoPonente>? EventoPonentes { get; set; }
    }
}
