using System.Collections.Generic;
using SOW.Aplicacao.ApiModels;
using SOW.Aplicacao.ViewModels.Usuarios;

namespace SOW.Aplicacao.Interfaces
{
    public interface IUsuarioAppServico
    {
        void Registrar(UsuarioRegistrarViewModel usuarioRegistrarViewModel);
        IReadOnlyList<UsuarioListViewModel> SelecionarTodos();
        ContaApiModel ObterConta(int usuarioId);
    }
}
