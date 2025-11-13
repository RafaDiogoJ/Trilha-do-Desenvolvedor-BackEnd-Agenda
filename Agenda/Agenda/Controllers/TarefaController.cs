using Microsoft.AspNetCore.Mvc;
using Agenda.Models;
using Agenda.Repositorio;

namespace Agenda.Controllers
{
    public class TarefaController : Controller
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;
        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        public IActionResult Index()
        {
            List<TarefaModel> tarefas = _tarefaRepositorio.BuscarTodos();
            return View(tarefas);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            TarefaModel tarefa = _tarefaRepositorio.ListarPorId(id);
            return View(tarefa);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            TarefaModel tarefa = _tarefaRepositorio.ListarPorId(id);
            return View(tarefa);
        }

        public IActionResult Apagar(int id)
        {
            _tarefaRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar (TarefaModel tarefa)
        {
            if (ModelState.IsValid)
            {
                _tarefaRepositorio.Adicionar(tarefa);
                return RedirectToAction("Index");
            }

            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Alterar(TarefaModel tarefa)
        {
            _tarefaRepositorio.Atualizar(tarefa);
            return RedirectToAction("Index");
        }
    }
}
