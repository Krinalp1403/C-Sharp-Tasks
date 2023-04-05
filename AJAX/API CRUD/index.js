$(document).ready(function () {


    $('#myModal').on('shown.bs.modal', function () {

        $('#etitle').val('');
        $('#sdate').val('');
        $('#edate').val('');
        $('#edescription').val('');
        $('#epriority').val('');
  
        $('#myModal .modal-footer button.btn-success').off().on('click', function () {
          debugger
          const url = "https://demosatva.azurewebsites.net/v1/api/Events";

          var eventDescription = $("#edescription").val();
          var eventPriority = $("#epriority").val();
            
            let data = {
              "eventTitle": $("#etitle").val(),
              "startDate": $("#sdate").val(),
              "endDate": $("#edate").val(),
              "eventDescription": eventDescription,
              "eventPriority": eventPriority
          };
  
            console.log(data);    
  
            $.ajax({
                type: 'POST',
                url: url,
                contentType: 'application/json',
                data: JSON.stringify(data),
                success: function (data) {
                    console.log('Event added successfully:', data);
                },
                error: function (xhr, status, error) {
                    console.log('Error:', error);
                }
            });
        
            $('#myModal').modal('hide');
        });
    });
  
   
});


$("#getdata").click(function(){
    const url = "https://demosatva.azurewebsites.net/v1/api/Events";


    $.ajax({
        type: 'GET',
        url: url,
        contentType: 'application/json',
        success: function (data) {
console.log(data);
            $.each(data.document.records, function (index, item) {

                var row = $("<tr>");

                $("<td>").text(item.eventTitle).appendTo(row);
                $("<td>").text(item.startDate).appendTo(row);
                $("<td>").text(item.endDate).appendTo(row);
                $("<td>").text(item.eventDescription).appendTo(row);
                $("<td>").text(item.eventPriority).appendTo(row);

                row.appendTo("#eventTable tbody");
            });
        },
        error: function (xhr, status, error) {
            console.log('Error:', error);
        }
    });
  });