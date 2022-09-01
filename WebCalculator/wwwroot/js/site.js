function setExpression(buttonValue) {
    var v = document.getElementById('Expression').value;
    document.getElementById('Expression').value = v + buttonValue;
}

function clearExpression() {
    document.getElementById('Expression').value = "";
}

function calculate() {
    var expression = document.getElementById('Expression').value;
    var integerValues = document.getElementById("IntegerValues").checked;
    $.ajax({
        url: "Home/Calculate",
        type: "POST",
        data: { expression: expression, isIntegerOnly: integerValues },
        success: function (response) {
            if (response != null && response.success) {
                document.getElementById('Expression').value = response.response;
                refreshHistory(response.history);
            } else {
                alert("Something goes wrong.");
            }
        },
        error: function (exception) {
            alert('Exeption:' + exception);
        }
    });
}


function refreshHistory(historyList) {
    $("div.calculatorHistory").find('table tbody tr').each(function () {
        $(this).remove()
    })

    historyList.forEach(function (item) {
        $("div.calculatorHistory").find('table tbody').append(`<tr> <td>${item}</td> </tr>`);
    });
}