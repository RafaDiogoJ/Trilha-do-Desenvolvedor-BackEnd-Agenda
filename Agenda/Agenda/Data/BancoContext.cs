using Microsoft.EntityFrameworkCore;
using Agenda.Models;

namespace Agenda.Data

{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<TarefaModel> Tarefas { get; set; }
    }
}
