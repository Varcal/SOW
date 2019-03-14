using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SOW.Aplicacao.Interfaces;
using SOW.Aplicacao.ViewModels.Usuarios;

namespace SOW.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioAppServico _usuarioAppServico;
        private IBancoAppServico _bancoAppServico;

        public UsuarioController(IUsuarioAppServico usuarioAppServico, IBancoAppServico bancoAppServico)
        {
            _usuarioAppServico = usuarioAppServico;
            _bancoAppServico = bancoAppServico;
        }

        public ActionResult Index()
        {
            var usuarios = _usuarioAppServico.SelecionarTodos();

            if(usuarios == null) return View();

            return View(usuarios);
        }

        

        public ActionResult Registrar()
        {
            CarregarDropBancos();

            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar(UsuarioRegistrarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                CarregarDropBancos();

                return View(model);
            }

            _usuarioAppServico.Registrar(model);

            return RedirectToAction(nameof(Index));
        }

        private void CarregarDropBancos()
        {
            ViewBag.Bancos = _bancoAppServico.SelecionarTodos().Select(banco => new SelectListItem()
            {
                Text = $"{banco.Numero} - {banco.Nome}",
                Value = banco.Id.ToString()
            }).ToList();
        }
    }
}