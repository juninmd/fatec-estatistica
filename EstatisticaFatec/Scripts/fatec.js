//function formatarInput() {
//    var texto = document.getElementById('txtParametros').value;

//    texto = texto.allTrim();

//    texto = texto.replace(/ /g, ";");

function formatarInput() {
    var textelemento = document.getElementById('txtParametros');

    var texto = textelemento.value.replace(/[^0-9.]/g, ';'),
        formated = [],
        splitText = texto.split(';');

    for (var i in splitText) {
        if (splitText[i].trim() !== '') {
            formated.push(splitText[i]);
        }
    }
    textelemento.value = formated.join(';').replace('.',',');
}


