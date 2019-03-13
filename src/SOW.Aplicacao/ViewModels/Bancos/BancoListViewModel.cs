using SOW.Dominio.Entidades;

namespace SOW.Aplicacao.ViewModels.Bancos
{
    public sealed class BancoListViewModel
    {  
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Nome { get; set; }

        public BancoListViewModel(Banco banco)
        {
            Id = banco.Id;
            Numero = banco.Numero;
            Nome = banco.Nome;
        }
    }
}
