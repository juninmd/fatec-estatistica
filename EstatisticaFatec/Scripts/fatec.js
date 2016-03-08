function formatarInput(contador) {
    if (contador == null)
        contador = 0;

    var texto = document.getElementById('txtParametros').value;

    texto = texto.allTrim();

    var pattern = /,,/g;
    var myArray = texto.match(pattern);

    while (myArray != null) {
        texto = texto.replace(/,,/g, ",");
        myArray = texto.match(pattern);
    }

    pattern = /,/g;
    myArray = texto.match(pattern);

    while (myArray != null) {
        texto = texto.replace(/,/g, ";");
        myArray = texto.match(pattern);
    }

    pattern = /;;/g;
    myArray = texto.match(pattern);

    while (myArray != null) {
        texto = texto.replace(/;;/g, ";");
        myArray = texto.match(pattern);
    }

    pattern = / /g;
    myArray = texto.match(pattern);

    while (myArray != null) {
        texto = texto.replace(/ /g, "");
        myArray = texto.match(pattern);
    }

    if (contador == 0)
        formatarInput(1);

    document.getElementById('txtParametros').value = texto.replace(/ /g, ";");
}
String.prototype.allTrim = String.prototype.allTrim ||
     function () {
         return this.replace(/\s+/g, ' ')
                    .replace(/^\s+|\s+$/, '');

     };

String.prototype.removeDuplicates = String.prototype.removeDuplicates ||
     function () {
         return this.replace(/;+/g, ' ')
                    .replace(/^\s+|\s+$/, '');

     };