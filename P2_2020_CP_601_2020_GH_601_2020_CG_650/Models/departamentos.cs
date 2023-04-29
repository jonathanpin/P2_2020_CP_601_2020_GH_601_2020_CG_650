using System.ComponentModel.DataAnnotations;

namespace P2_2020_CP_601_2020_GH_601_2020_CG_650.Models
{
    public class departamentos
    {
        [Key]
        public int id_departamentos { get; set; }
        public string? nombre_departamento { get; set; }
    }
}
