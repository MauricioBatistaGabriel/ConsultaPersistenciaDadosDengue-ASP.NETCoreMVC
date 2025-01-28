using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaPersistenciaDadosDengue.Models
{
    public class DadosDengueModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public int se { get; set; }
        public double casos_est { get; set; }
        public int casos { get; set; }
        public int nivel { get; set; }
    }
}
