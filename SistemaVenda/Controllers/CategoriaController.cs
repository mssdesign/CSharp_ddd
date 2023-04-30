using Microsoft.AspNetCore.Mvc;
using SistemaVenda.DAL;
using SistemaVenda.Entidades;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers
{
    public class CategoriaController : Controller
    {
        protected ApplicationDbContext mContext;

        public CategoriaController(ApplicationDbContext context)
        {
            mContext = context; //injeção de dependência
        }

        public IActionResult Index()
        {
            IEnumerable<Categoria> lista = mContext.Categoria.ToList();
            mContext.Dispose(); //Liberando memória
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            CategoriaViewModel viewModel = new CategoriaViewModel();
            return View(viewModel);
        }
    }
}
