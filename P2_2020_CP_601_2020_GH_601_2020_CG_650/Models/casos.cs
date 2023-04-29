using System.ComponentModel.DataAnnotations;

namespace P2_2020_CP_601_2020_GH_601_2020_CG_650.Models
{
    public class casos
    {
        [Key]
        public int id_casos { get; set; }
        public int? id_departamento { get; set; }
        public int? id_genero { get; set; }
        public int? casos_confirmados { get; set; }
        public int? casos_recuperados { get; set; }
        public int? casos_fallecidos { get; set; }

    }
}
