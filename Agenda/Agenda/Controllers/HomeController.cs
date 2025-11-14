using System.Diagnostics;
using Agenda.Models;
using Agenda.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Agenda.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;

        public HomeController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        public IActionResult Index(DateTime? data)
        {
            //Aqui serve para filtrar por data os registros e para o usuário não passar uma data inválida
            DateTime hoje = DateTime.Today;
            DateTime dataSelecionada = data ?? hoje;

            // Converter DateTime para DateOnly pois Data no TarefaModel é do tipo DateOnly
            DateOnly dataFiltro = DateOnly.FromDateTime(dataSelecionada);

            var tarefas = _tarefaRepositorio.BuscarTodos()
           .Where(t => t.Data.HasValue && t.Data.Value == dataFiltro)
           .OrderBy(t => t.Data)
           .ToList();

            ViewBag.DataSelecionada = dataSelecionada;

            return View(tarefas);
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
