function sendrequest() {
    const userID = 1;
    $.ajax({
        type: 'GET',
        url: '/api/GetPersonModel?userID='+userID,
        contentType: 'application/json; charset=utf-8',
        datatype: 'json',
        data: JSON.stringify(),
        success: function (result) {
            alert(result);
            console.log(result);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        failure: function () {
            alert('Failure');
        },
        complete: function (jqXHR, status) {
            alert("complete: " + status + "\n\nResponse: " + jqXHR.responseText)
        }
    });
}