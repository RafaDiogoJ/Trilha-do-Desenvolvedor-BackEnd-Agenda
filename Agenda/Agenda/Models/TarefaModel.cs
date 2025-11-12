namespace Agenda.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public required string NomeTarefa { get; set; }
        public string Observacao { get; set; }
        public DateOnly Data { get; set; }
        public TimeOnly Hora { get; set; }
        public bool Concluida { get; set; }
    }
}
