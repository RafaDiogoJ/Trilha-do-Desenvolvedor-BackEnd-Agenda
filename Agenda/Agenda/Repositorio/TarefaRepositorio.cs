using Agenda.Data;
using Agenda.Models;

namespace Agenda.Repositorio
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly BancoContext _bancoContext;
        public TarefaRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<TarefaModel> BuscarTodos()
        {
            return _bancoContext.Tarefas.ToList();
        }
        public TarefaModel Adicionar(TarefaModel tarefa)
        {
            //Gravar no banco de dados
            _bancoContext.Tarefas.Add(tarefa);
            _bancoContext.SaveChanges();
            return tarefa;
        }
    }
}
