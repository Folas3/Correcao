using System.ComponentModel.DataAnnotations;

namespace Correcao.Models
{
    public class Jogador
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required]
        [RegularExpression(@"^\d{11}$",
            ErrorMessage = "O CPF deve possuir 11 dígitos.")]
        public string CPF { get; set; }

        [Required]
        [StringLength(500)]
        public string Descricao { get; set; }

        [Required]
        [RegularExpression(
            "^(GL|ZA|LD|LE|VO|MD|AT)$",
            ErrorMessage = "Posição inválida. Use GL, ZA, LD, LE, VO, MD ou AT."
        )]
        public string Posicao { get; set; }

        public bool? Aprovado { get; set; }
    }
}