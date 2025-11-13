using Agenda.Data;
using Agenda.Models;

namespace Agenda.Repositorio
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly BancoContext _context;
        public TarefaRepositorio(BancoContext bancoContext)
        {
            this._context = bancoContext;
        }

        public List<TarefaModel> BuscarTodos()
        {
            return _context.Tarefas.ToList();
        }
        public TarefaModel Adicionar(TarefaModel tarefa)
        {
            //Gravar no banco de dados
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
            return tarefa;
        }

        public TarefaModel ListarPorId(int id)
        {
            return _context.Tarefas.FirstOrDefault(x => x.Id == id);
        }

        public TarefaModel Atualizar(TarefaModel tarefa)
        {
            TarefaModel tarefaDB = ListarPorId(tarefa.Id);

            if(tarefaDB == null) throw new System.Exception("Houve um erro na atualização da tarefa!");

            tarefaDB.NomeTarefa = tarefa.NomeTarefa;
            tarefaDB.Observacao = tarefa.Observacao;
            tarefaDB.Data = tarefa.Data;
            tarefaDB.Hora = tarefa.Hora;
            tarefaDB.Concluida = tarefa.Concluida;
            _context.Tarefas.Update(tarefaDB);
            _context.SaveChanges();

            return tarefaDB;
        }

        public bool Apagar(int id)
        {
            TarefaModel tarefaDB = ListarPorId(id);

            if (tarefaDB == null) throw new System.Exception("Houve um erro ao deletar a tarefa!");

            _context.Tarefas.Remove(tarefaDB);
            _context.SaveChanges();

            return true;
        }
    }
}
