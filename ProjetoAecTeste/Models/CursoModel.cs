using System.ComponentModel.DataAnnotations;

namespace ProjetoAecTeste.Models
{
    public class CursoModel
    {

        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Professor { get; set; }
        public string CargaHoraria { get; set; }
        public string Descricao { get; set; }
    }
}

