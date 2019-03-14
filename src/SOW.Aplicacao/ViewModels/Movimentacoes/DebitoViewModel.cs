using System.ComponentModel.DataAnnotations;

namespace SOW.Aplicacao.ViewModels.Movimentacoes
{
    public sealed class DebitoViewModel
    {
        
        public int ContaId { get; set; }

        [Required(ErrorMessage = "Valor do débito é obrigatório")]
        public decimal Valor { get; set; }
    }
}
