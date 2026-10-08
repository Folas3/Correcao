using System.ComponentModel.DataAnnotations;

namespace Correcao.Models
{
    public class ResultadoPeneira
    {
        [Required]
        [RegularExpression(@"^\d{11}$",
            ErrorMessage = "O CPF deve possuir 11 dígitos.")]
        public string CPF { get; set; }

        [Required]
        public bool Aprovado { get; set; }
    }
}