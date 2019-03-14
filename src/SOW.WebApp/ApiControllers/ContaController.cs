using Microsoft.AspNetCore.Mvc;
using SOW.Aplicacao.Interfaces;

namespace SOW.WebApp.ApiControllers
{
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IUsuarioAppServico _usuarioAppServico;

        public ContaController(IUsuarioAppServico usuarioAppServico)
        {
            _usuarioAppServico = usuarioAppServico;
        }

        [Route("api/conta/{usuarioId}")]
        public IActionResult Get(int usuarioId)
        {
            var conta = _usuarioAppServico.ObterConta(usuarioId);

            if (conta == null)
            {
                return NoContent();
            }

            return Ok(conta);
        }
    }
}