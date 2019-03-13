using Microsoft.AspNetCore.Mvc;
using SOW.Aplicacao.ViewModels.Movimentacoes;

namespace SOW.WebApp.Controllers
{
    public class MovimentacaoController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Debitar()
        {
            return View();
        }

        public IActionResult Debitar(DebitoViewModel model)
        {
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Creditar()
        {
            return View();
        }

        public IActionResult Creditar(CreditoViewModel model)
        {
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Transferir()
        {
            return View();
        }

        public IActionResult Transferir(TransferenciaViewModel model)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}