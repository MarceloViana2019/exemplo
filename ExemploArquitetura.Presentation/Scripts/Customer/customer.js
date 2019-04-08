$(document).ready(function () {
    loadDropDownStates();
})

$('#Address_StateCode').change(function () {
    loadDropDownStates();
});

function loadDropDownStates() {
    var stateCode = $('#Address_StateCode').val();
    $('#Address_CityCode').empty();

    $.ajax({
        type: "POST",
        url: "/Address/GetCities/",
        data: { 'StateCode': stateCode },
        success: function (data) {
            if (data.length > 0) {
                for (var i = 0; i < data.length; i++) {
                    $('#Address_CityCode').append('<option value="' + data[i].Code + '">' + data[i].Name + '</option>');
                }
            }
        }
    }).done(function () {
        selectCityOfCustomer();
    });
}

function selectCityOfCustomer() {
    var cityCode = $('#hiddenCityCode').val();
    $('option[value="' + cityCode + '"]').prop('selected', true);
}