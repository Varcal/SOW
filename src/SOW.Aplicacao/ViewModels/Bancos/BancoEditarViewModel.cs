using System.ComponentModel.DataAnnotations;
using SOW.Dominio.Entidades;

namespace SOW.Aplicacao.ViewModels.Bancos
{
    public class BancoEditarViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Número do banco deve conter 3 caractéres")]
        [MaxLength(3, ErrorMessage = "Número do banco deve conter 3 caractéres")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "Nome deve conter no maximo 100 caractéres")]
        public string Nome { get; set; }

        public BancoEditarViewModel()
        {
            
        }

        public BancoEditarViewModel(Banco banco)
        {
            Id = banco.Id;
            Numero = banco.Numero;
            Nome = banco.Nome;
        }
    }
}
