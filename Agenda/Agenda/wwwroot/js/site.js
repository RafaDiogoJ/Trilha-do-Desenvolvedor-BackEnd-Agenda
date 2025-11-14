// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Código para chamar o DataTable
let table = new DataTable('#table-tarefas', {
    ordering: true,
    paging: true,
    searching: true,

    language: {
        emptyTable: "Nenhum registro encontrado na tabela",
        info: "Mostrar _START_ até _END_ de _TOTAL_ registros",
        infoEmpty: "Mostrar 0 até 0 de 0 registros",
        infoFiltered: "(Filtrado de _MAX_ registros no total)",
        thousands: ".",
        lengthMenu: "Mostrar _MENU_ registros por página",
        loadingRecords: "Carregando...",
        processing: "Processando...",
        zeroRecords: "Nenhum registro encontrado",
        search: "Pesquisar",

        paginate: {
            next: "Próximo",
            previous: "Anterior",
            first: "Primeiro",
            last: "Último"
        },

        aria: {
            sortAscending: ": ativar para ordenar a coluna de forma ascendente",
            sortDescending: ": ativar para ordenar a coluna de forma descendente"
        }
    }
});



//Alerts da pagina inicial (tarefa cadastrada/alterada com sucesso)
$('.close-alert').click(function () {
    $('.alert').hide('hide');
})

