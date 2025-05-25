using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Utn.Modelos
{
    public class Participante
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NOMBRE")]
        public string Nombre { get; set; } = string.Empty;

        [Column("CORREO")]
        public string Correo { get; set; } = string.Empty;

        [Column("TELEFONO")]
        public string Telefono { get; set; } = string.Empty;

        [Column("DOCUMENTOIDENTIDAD")]
        public string DocumentoIdentidad { get; set; } = string.Empty;

        // Relación con Inscripciones
        [JsonIgnore]
        public List<Inscripcion>? Inscripciones { get; set; }
    }
}
