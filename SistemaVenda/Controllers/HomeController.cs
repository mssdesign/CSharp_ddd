using Microsoft.AspNetCore.Mvc;
using SistemaVenda.DAL;
using SistemaVenda.Entidades;
using SistemaVenda.Models;
using System.Diagnostics;

namespace SistemaVenda.Controllers
{
    public class HomeController : Controller
    {
        protected ApplicationDbContext Repositorio;

        public HomeController(ApplicationDbContext repositorio)
        {
            Repositorio= repositorio;
        }

        public IActionResult Index()
        {
            //Adicionando
            //Repositorio.Categoria.Add(new Categoria
            //{
            //    Descricao = "Bolinhos",
            //});

            Categoria objCategoria = Repositorio.Categoria.Where(x => x.Codigo == 2).FirstOrDefault();

            //Alterando
            //objCategoria.Descricao = "Bebidas";
            //Repositorio.Entry(objCategoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            //Excluindo
            Repositorio.Attach(objCategoria);
            Repositorio.Remove(objCategoria);

            Repositorio.SaveChanges();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}