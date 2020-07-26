jQuery.noConflict()(function ($) {
    $(document).ready(function () {
        loadDataTable();
    })
})

var dataTable;

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "Leave/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "10%" },
            { "data": "lType", "width": "20%" },
            { "data": "sDate", "width": "20%" },
            { "data": "eDate", "width": "20%" },
            { "data": "Status", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="Employee/Leave/Detail/${data}" class="btn btn-primary text-white" style="cursor:pointer; width:40px">
                            <i class="fas fa-eye"></i>
                        </a>
                    </div>`
                },
                "width": "15%"
            }
        ],
        "language": {
            "emptyTable": "No Record Found!"
        },
        "width": "100%"
    })
}