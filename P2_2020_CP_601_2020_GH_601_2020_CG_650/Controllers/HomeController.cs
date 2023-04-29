using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using P2_2020_CP_601_2020_GH_601_2020_CG_650.Models;
using System.Diagnostics;

namespace P2_2020_CP_601_2020_GH_601_2020_CG_650.Controllers
{
    public class HomeController : Controller
    {
        private readonly covidContext _covidContext;

        public HomeController (covidContext covidContext)
        {
            _covidContext = covidContext;
        }
        private readonly ILogger<HomeController> _logger;

        public IActionResult Index()
        {
            var listaDepartamentos = (from d in _covidContext.departamentos
                                   select d).ToList();
            ViewData["listaDepartamentos"] = new SelectList(listaDepartamentos, "id_departamentos", "nombre_departamento");

            var listaGeneros = (from g in _covidContext.genero
                                      select g).ToList();
            ViewData["listaGeneros"] = new SelectList(listaGeneros, "id_genero", "nombre_genero");

            var listaCaos = (from c in _covidContext.casos
                                   join
                                   d in _covidContext.departamentos on c.id_departamento equals d.id_departamentos
                                   join g in _covidContext.genero on c.id_genero equals g.id_genero
                                   select new
                                   {
                                       departamento = d.nombre_departamento,
                                       genero = g.nombre_genero,
                                       confirmados = c.casos_confirmados,
                                       recuperados = c.casos_recuperados,
                                       fallecidos = c.casos_fallecidos
                                   }).ToList();
            ViewData["listaCaos"] = listaCaos;

            return View();
        }

        public IActionResult crearCaso(casos nuevoCaso)
        {
            _covidContext.Add(nuevoCaso);
            _covidContext.SaveChanges();
            return RedirectToAction("Index");
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