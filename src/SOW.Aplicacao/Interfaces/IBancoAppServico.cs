using System.Collections.Generic;
using SOW.Aplicacao.ViewModels.Bancos;

namespace SOW.Aplicacao.Interfaces
{
    public interface IBancoAppServico
    {
        void Registrar(BancoRegistrarViewModel bancoViewModel);
        IReadOnlyList<BancoListViewModel> SelecionarTodos();
        BancoEditarViewModel ObterPorId(int id);
        void Editar(BancoEditarViewModel model);
    }
}
