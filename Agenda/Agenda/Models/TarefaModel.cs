using System.ComponentModel.DataAnnotations;

namespace Agenda.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome da tarefa")]
        public required string  NomeTarefa { get; set; }
        public string? Observacao { get; set; }
        [Required(ErrorMessage = "Selecione a Data da Tarefa")]
        public DateOnly Data { get; set; }
        public TimeOnly? Hora { get; set; }
        public bool Concluida { get; set; }
    }
}
