using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myproductexameple_web_dotnet_service.interfaces;
using myproductexample_web_dotnet.Models;

namespace myproductexample_web_dotnet.Controllers
{
    [Route("[controller]")]
    public class PlanoContasController : Controller
    {
        private readonly ILogger<PlanoContasController> _logger;
        private readonly IPlanoContaService _planoContaService;

        public PlanoContasController(
            ILogger<PlanoContasController> logger,
            IPlanoContaService planoContaService)
        {
            _logger = logger;
            _planoContaService = planoContaService;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            // 1️⃣ Busca entidades do Domain
            var listaPlanoConta = _planoContaService.ListarRegistro();

            // 2️⃣ Mapeia Domain -> ViewModel
            var listaPlanoContaModel = listaPlanoConta?
                .Select(item => new PlanoContaModel
                {
                    Id = item.Id,
                    Descricao = item.Descricao,
                    Tipo = item.Tipo
                })
                .ToList() ?? new List<PlanoContaModel>();

            // 3️⃣ Retorna a View fortemente tipada
            return View(listaPlanoContaModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error");
        }
    }
}
