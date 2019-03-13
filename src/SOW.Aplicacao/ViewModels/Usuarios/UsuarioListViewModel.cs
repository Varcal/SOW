

using System.Linq;
using SOW.Dominio.Entidades;

namespace SOW.Aplicacao.ViewModels.Usuarios
{
    public class UsuarioListViewModel
    {

       
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Banco { get; set; }
        public string Conta { get; set; }
        public decimal Saldo { get; set; }

        public UsuarioListViewModel(Usuario usuario)
        {
            Id = usuario.Id;
            Nome = usuario.Nome.Value;
            Banco = usuario.Contas.FirstOrDefault()?.Banco.Nome;
            Conta = usuario.Contas.FirstOrDefault()?.ContaCorrente.Numero;
            Saldo = usuario.Contas.First().Saldo.Valor;
        }
    }
}
