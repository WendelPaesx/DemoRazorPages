using System.ComponentModel.DataAnnotations;

namespace DemoRazorPages.models
{
    public class aluno
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        [DataType (DataType.Date)]

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

       
    }
}
