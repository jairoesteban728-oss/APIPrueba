using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPrueba.Models
{
    [Table("proyectos")]
    public class proyectos
    {
        [Key]
        [Column("idProyectos")]
        public int idProyectos { get; set; }

        [Column("NombreProyecto")]
        public string? NombreProyecto { get; set; }

        [Column("Ubicacion")]
        public string? Ubicacion { get; set; }

        [Column("FechaInicio")]
        public DateTime? FechaInicio { get; set; }

        [Column("FechaFin")]
        public DateTime? FechaFin { get; set; }

        [Column("Activo")]
        public int? Activo { get; set; }
    }
}
