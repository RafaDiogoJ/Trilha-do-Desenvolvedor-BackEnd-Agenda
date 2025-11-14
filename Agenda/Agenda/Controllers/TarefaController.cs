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
            try
            {
                bool apagado = _tarefaRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Tarefa apagada com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar sua tarefa!";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {

                TempData["MensagemSucesso"] = $"Ops, não conseguimos apagar esta tarefa, detalhes do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(TarefaModel tarefa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _tarefaRepositorio.Adicionar(tarefa);
                    TempData["MensagemSucesso"] = "Tarefa criada com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(tarefa);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemSucesso"] = $"Ops, não conseguimos cadastrar esta tarefa, tente novamente, detalhes do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(TarefaModel tarefa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _tarefaRepositorio.Atualizar(tarefa);
                    TempData["MensagemSucesso"] = "Tarefa alterada com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", tarefa);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemSucesso"] = $"Ops, não conseguimos alterar esta tarefa, tente novamente, detalhes do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult MarcarConcluida(int id, bool concluida)
        {
            var tarefa = _tarefaRepositorio.ListarPorId(id);

            if (tarefa != null)
            {
                tarefa.Concluida = concluida;
                _tarefaRepositorio.Atualizar(tarefa);
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
