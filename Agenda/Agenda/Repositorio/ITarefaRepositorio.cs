using Agenda.Models;

namespace Agenda.Repositorio
{
    public interface ITarefaRepositorio
    {
        List<TarefaModel> BuscarTodos();
        TarefaModel Adicionar (TarefaModel tarefa);
    }
}
