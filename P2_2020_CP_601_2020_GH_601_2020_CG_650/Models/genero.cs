using System.ComponentModel.DataAnnotations;

namespace P2_2020_CP_601_2020_GH_601_2020_CG_650.Models
{
    public class genero
    {
        [Key]
        public int id_genero { get; set; }
        public string? nombre_genero { get; set; }
    }
}
