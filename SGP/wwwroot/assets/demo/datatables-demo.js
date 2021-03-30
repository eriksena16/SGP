// Call the dataTables jQuery plugin
$(document).ready(function() {
    $('#dataTable').DataTable({
        languagem: {
            emptyTable: "Nenhum registro encontrado",
            info: "Mostrando de _START_ at� _END_ de _TOTAL_ registros",
            infoEmpty: "Mostrando 0 at� 0 de 0 registros",
            zeroRecords: "Nenhum registro encontrado",
            search: "Pesquisar",
            paginate: {
                next: "Pr�ximo",
                previous: "Anterior",
                first: "Primeiro",
                last: "�ltimo"
            }
        }
    });
});
