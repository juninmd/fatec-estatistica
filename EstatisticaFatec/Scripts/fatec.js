function formatarInput() {
    var texto = document.getElementById('txtParametros');
    while (texto.contains(/  /g)) {
        texto = texto.replace(/  /g, " ");
    }
    return texto.replace(/ /g, ",");
}