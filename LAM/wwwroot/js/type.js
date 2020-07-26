jQuery.noConflict()(function ($) {
    $(document).ready(function () {
        loadDataTable();
    })
})

var dataTable;

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "LType/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "10%" },
            { "data": "type", "width": "70%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="Admin/LType/AddType/${data}" class="btn btn-primary text-white" style="cursor:pointer; width:40px">
                            <i class="fas fa-edit"></i>
                        </a>
                        &nbsp;
                        <a onclick=Delete("Admin/LType/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:40px">
                            <i class="fas fa-trash-alt"></i>
                        </a>
                    </div>`
                },
                "width": "20%"
            }
        ],
        "language": {
            "emptyTable": "No Record Found!"
        },
        "width": "100%"
    })
}