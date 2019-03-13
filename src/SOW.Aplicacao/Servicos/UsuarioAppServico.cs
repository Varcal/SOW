using System.Collections.Generic;
using System.Linq;
using SOW.Aplicacao.Interfaces;
using SOW.Aplicacao.Servicos.Base;
using SOW.Aplicacao.ViewModels.Usuarios;
using SOW.Dominio.Entidades;
using SOW.Dominio.ObjetosDeValor;
using SOW.Dominio.Repositorios;
using SOW.NucleoCompartilhado.DomainEvents.Notifications;
using SOW.NucleoCompartilhado.Transacacoes;

namespace SOW.Aplicacao.Servicos
{
    public class UsuarioAppServico:AplicacaoServicoBase, IUsuarioAppServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IBancoRepositorio _bancoRepositorio;

        public UsuarioAppServico(IUnitOfWork uow, IUsuarioRepositorio usuarioRepositorio, IBancoRepositorio bancoRepositorio) 
            : base(uow)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _bancoRepositorio = bancoRepositorio;
        }

        public void Registrar(UsuarioRegistrarViewModel usuarioRegistrarViewModel)
        {
            var usuario = CriarUsuario(usuarioRegistrarViewModel);
            _usuarioRepositorio.Adicionar(usuario);
            Save();
        }

   
        private Usuario CriarUsuario(UsuarioRegistrarViewModel usuarioRegistrarViewModel)
        {
            var nomeCompleto = new Nome(usuarioRegistrarViewModel.Nome);
            var banco = _bancoRepositorio.ObterPorId(usuarioRegistrarViewModel.BancoId);

            if (banco == null)
            {
                DomainNotification.CriarNotificacao("BancoNaoEncontrado", "Não foi possível localizar o banco informado.");
                return null;                              
            }

            var saldo = new Saldo(usuarioRegistrarViewModel.SaldoInicial);
            var conta = new Conta(banco, saldo);

            var usuario = new Usuario(nomeCompleto, conta);
            return usuario;
        }

        public IReadOnlyList<UsuarioListViewModel> SelecionarTodos()
        {
            var usuarios = _usuarioRepositorio.SelecionarTodos();
            return usuarios.Select(usuario => new UsuarioListViewModel(usuario)).ToList();
        }
    }
}
