using System.Collections.Generic;
using System.Linq;
using SOW.Aplicacao.Interfaces;
using SOW.Aplicacao.Servicos.Base;
using SOW.Aplicacao.ViewModels.Bancos;
using SOW.Dominio.Entidades;
using SOW.Dominio.Repositorios;
using SOW.NucleoCompartilhado.Transacacoes;

namespace SOW.Aplicacao.Servicos
{
    public class BancoAppServico : AplicacaoServicoBase, IBancoAppServico
    {
        private readonly IBancoRepositorio _bancoRepositorio;

        public BancoAppServico(IUnitOfWork unitOfWork, IBancoRepositorio bancoRepositorio)
            : base(unitOfWork)
        {
            _bancoRepositorio = bancoRepositorio;
        }

        public void Registrar(BancoRegistrarViewModel bancoViewModel)
        {
            var banco = new Banco(bancoViewModel.Numero, bancoViewModel.Nome);

            _bancoRepositorio.Adicionar(banco);
            Save();
        }

        public IReadOnlyList<BancoListViewModel> SelecionarTodos()
        {
            var bancos = _bancoRepositorio.SelecionarTodos();
            return bancos.Select(banco => new BancoListViewModel(banco)).ToList();
        }

        public BancoEditarViewModel ObterPorId(int id)
        {
            return new BancoEditarViewModel(_bancoRepositorio.ObterPorId(id));
        }

        public void Editar(BancoEditarViewModel model)
        {
            var banco = _bancoRepositorio.ObterPorId(model.Id);
            banco.Alterar(model.Numero, model.Nome);

            Save();
        }
    }
}
