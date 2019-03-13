using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SOW.Aplicacao.ViewModels.Usuarios
{
    public sealed class UsuarioRegistrarViewModel
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [DisplayName("Bancos")]
        [Required(ErrorMessage = "Banco é obrigatório")]
        public int BancoId { get; set; }

        [DisplayName("Saldo Inicial")]
        [Required(ErrorMessage = "Saldo Inicial é obrigatório")]
        public decimal SaldoInicial { get; set; }
    }
}
