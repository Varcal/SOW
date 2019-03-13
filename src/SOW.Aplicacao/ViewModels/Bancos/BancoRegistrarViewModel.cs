using System.ComponentModel.DataAnnotations;

namespace SOW.Aplicacao.ViewModels.Bancos
{
    public class BancoRegistrarViewModel
    {
        [Required]
        public string Numero { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
