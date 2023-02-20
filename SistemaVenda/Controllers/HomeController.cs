﻿using Microsoft.AspNetCore.Mvc;
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
            Categoria objCategoria = Repositorio.Categoria.Where(x => x.Codigo == 1).FirstOrDefault();

            objCategoria.Descricao = "Bebidas";

            Repositorio.Entry(objCategoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

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