using System.ComponentModel.DataAnnotations;

namespace SOW.Aplicacao.ViewModels.Movimentacoes
{
    public sealed class CreditoViewModel
    {
        public int ContaId { get; set; }

        [Required(ErrorMessage = "Valor do crédito é obrigatório")]
        public decimal Valor { get; set; }
    }
}
