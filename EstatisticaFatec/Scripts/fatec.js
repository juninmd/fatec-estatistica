function formatarInput() {
    var texto = document.getElementById('txtParametros').value;

    texto = texto.allTrim();

    texto = texto.replace(/ /g, ";");

    var tamanho = texto.length -1 ;

    if (texto[tamanho] == ';') {
        texto = texto.substring(0, tamanho);
    }
 
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


