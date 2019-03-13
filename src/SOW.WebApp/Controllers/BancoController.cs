using Microsoft.AspNetCore.Mvc;
using SOW.Aplicacao.Interfaces;
using SOW.Aplicacao.ViewModels.Bancos;

namespace SOW.WebApp.Controllers
{
    public class BancoController : Controller
    {
        private readonly IBancoAppServico _bancoAppServico;

        public BancoController(IBancoAppServico bancoAppServico)
        {
            _bancoAppServico = bancoAppServico;
        }

        public ActionResult Index()
        {
            var bancos = _bancoAppServico.SelecionarTodos();

            return bancos == null ? View() : View(bancos);
        }       

        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar(BancoRegistrarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _bancoAppServico.Registrar(model);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Editar(int id)
        {
            BancoEditarViewModel banco = _bancoAppServico.ObterPorId(id);

            return View(banco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, BancoEditarViewModel model)
        {
            if(!ModelState.IsValid) return View(model);

            _bancoAppServico.Editar(model);
            return RedirectToAction(nameof(Index));
        }
    }
}