using SOW.Aplicacao.Interfaces;
using SOW.Aplicacao.Servicos.Base;
using SOW.Dominio.Commands.Usuarios;
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

        public void Registrar(UsuarioCriacaoCommand usuarioCriacaoCommand)
        {
            var usuario = CriarUsuario(usuarioCriacaoCommand);
            _usuarioRepositorio.Adicionar(usuario);
            Save();
        }

        private Usuario CriarUsuario(UsuarioCriacaoCommand usuarioCriacaoCommand)
        {
            var nomeCompleto = new NomeCompleto(usuarioCriacaoCommand.Nome, usuarioCriacaoCommand.Sobrenome);
            var banco = _bancoRepositorio.ObterPorId(usuarioCriacaoCommand.BancoId);

            if (banco == null)
            {
                DomainNotification.CriarNotificacao("BancoNaoEncontrado", "Não foi possível localizar o banco informado.");
                return null;                              
            }

            var saldo = new Saldo(usuarioCriacaoCommand.SaldoInicial);
            var conta = new Conta(banco, saldo);

            var usuario = new Usuario(nomeCompleto, conta);
            return usuario;
        }
    }
}
