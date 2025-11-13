using Agenda.Models;

namespace Agenda.Repositorio
{
    public interface ITarefaRepositorio
    {
        TarefaModel ListarPorId(int id);
        List<TarefaModel> BuscarTodos();
        TarefaModel Adicionar (TarefaModel tarefa);
        TarefaModel Atualizar(TarefaModel tarefa);
        bool Apagar(int id);
    }
}
