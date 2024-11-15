function CreateCar() {

    var formDataSerialize = getFormData($("#createCar"));

    //console.log(formDataSerialize);
    //console.log(JSON.stringify(formDataSerialize));

    var jsonData = JSON.stringify(formDataSerialize);

    var token = $("#_token").val();

    $.ajax({
        url: "https://localhost:7247/api/Cars",
        headers: {'Authorization':'Bearer' + token},
        method: "POST",
        data: jsonData,
        contentType: "application/json",

        success: function (data, statusText) {
            console.log(data);
        },
        error: function (xhr, textStatus, errorThrown) {

        }
    });
}

function getFormData($form) {
    var unindexed_array = $form.serializeArray();
    var indexed_array = {};

    $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });

    return indexed_array;
}