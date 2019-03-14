using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SOW.Aplicacao.Interfaces;
using SOW.Aplicacao.ViewModels.Movimentacoes;
using SOW.Dominio.Commands.Contas;
using SOW.Dominio.Entidades;

namespace SOW.WebApp.Controllers
{
    public class MovimentacaoController : Controller
    {
        private readonly IUsuarioAppServico _usuarioAppServico;
        private readonly IMovimentacaoAppServico _movimentacaoAppServico;

        public MovimentacaoController(IUsuarioAppServico usuarioAppServico, IMovimentacaoAppServico movimentacaoAppServico)
        {
            _usuarioAppServico = usuarioAppServico;
            _movimentacaoAppServico = movimentacaoAppServico;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Debitar()
        {
            CarregarDropUsuario();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Debitar(DebitoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                CarregarDropUsuario();
                return View(model);
            }

            var debitoCommand = new DebitoCommand(model.ContaId, model.Valor);
            _movimentacaoAppServico.Debitar(debitoCommand);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Creditar()
        {
            CarregarDropUsuario();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Creditar(CreditoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                CarregarDropUsuario();
                return View(model);
            }

            var creditoCommand = new CreditoCommand(model.ContaId, model.Valor);
            _movimentacaoAppServico.Creditar(creditoCommand);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Transferir()
        {
            CarregarDropUsuario();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Transferir(TransferenciaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                CarregarDropUsuario();
                return View(model);
            }

            var transferenciaCommand = new TransferenciaCommand(model.ContaDebitoId, model.ContaCreditoId, model.Valor);
            _movimentacaoAppServico.Transferir(transferenciaCommand);

            return RedirectToAction(nameof(Index), nameof(Usuario));
        }

        private void CarregarDropUsuario()
        {
            ViewBag.Usuarios = _usuarioAppServico.SelecionarTodos().Select(usuario => new SelectListItem()
            {
                Text = usuario.Nome,
                Value = usuario.Id.ToString()
            }).ToList();
        }
    }
}