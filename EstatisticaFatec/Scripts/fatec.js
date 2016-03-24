function formatarInput() {
    var textelemento = document.getElementById('txtParametros');

    var texto = textelemento.value.replace(/[^0-9.]/g, ';'),
        formated = [],
        splitText = texto.split(';');

    for (var i in splitText) {
        if (splitText.hasOwnProperty(i)) {
            if (splitText[i].trim() !== '') {
                formated.push(splitText[i]);
            }
        }
    }
    textelemento.value = formated.join(';').replace('.', ',');
}

$(document).ready(function () {
    $("input[checkGrid]").change(function () {
        if ($("input[checkGrid]:checked").length == $("input[checkGrid]").length) {
            $("#chkAll").prop("checked", true);
        } else {
            $("#chkAll").prop("checked", false);

        }
    });

    $("#chkAll").click(function () {
        if ($("#chkAll").prop("checked")) {
            $("input[checkGrid]").prop("checked", true);
        } else {
            $("input[checkGrid]").prop("checked", false);
        }
    });

});

