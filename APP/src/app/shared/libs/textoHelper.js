String.prototype.apenasNumeros = function () {
    return this.replace(/[^\d]+/g, '');
};

String.prototype.semAcentos = function () {
    return this.replace(/á/g, 'a')
        .replace(/Á/g, 'A')
        .replace(/ã/g, 'a')
        .replace(/Ã/g, 'A')
        .replace(/â/g, 'a')
        .replace(/Â/g, 'A')
        .replace(/é/g, 'e')
        .replace(/É/g, 'E')
        .replace(/ê/g, 'e')
        .replace(/Ê/g, 'E')
        .replace(/è/g, 'e')
        .replace(/È/g, 'E')
        .replace(/í/g, 'i')
        .replace(/Í/g, 'I')
        .replace(/î/g, 'i')
        .replace(/Î/g, 'I')
        .replace(/ì/g, 'i')
        .replace(/Ì/g, 'I')
        .replace(/ό/g, 'ο')
        .replace(/Ó/g, 'O')
        .replace(/ô/g, 'o')
        .replace(/Ô/g, 'O')
        .replace(/õ/g, 'o')
        .replace(/Õ/g, 'O')
        .replace(/ú/g, 'u')
        .replace(/Ú/g, 'U')
        .replace(/ü/g, 'u')
        .replace(/Ü/g, 'U')
        .replace(/û/g, 'u')
        .replace(/Û/g, 'U')
        .replace(/ç/g, 'c')
        .replace(/Ç/g, 'C')
        .replace(/\n/g, ' ')
        .replace(/[^A-Za-z0-9]/g, '');
};

String.prototype.semAcentos2 = function () {
    return this.replace(/á/g, 'a')
        .replace(/Á/g, 'A')
        .replace(/ã/g, 'a')
        .replace(/Ã/g, 'A')
        .replace(/â/g, 'a')
        .replace(/Â/g, 'A')
        .replace(/é/g, 'e')
        .replace(/É/g, 'E')
        .replace(/ê/g, 'e')
        .replace(/Ê/g, 'E')
        .replace(/è/g, 'e')
        .replace(/È/g, 'E')
        .replace(/í/g, 'i')
        .replace(/Í/g, 'I')
        .replace(/î/g, 'i')
        .replace(/Î/g, 'I')
        .replace(/ì/g, 'i')
        .replace(/Ì/g, 'I')
        .replace(/ό/g, 'ο')
        .replace(/Ó/g, 'O')
        .replace(/ô/g, 'o')
        .replace(/Ô/g, 'O')
        .replace(/õ/g, 'o')
        .replace(/Õ/g, 'O')
        .replace(/ú/g, 'u')
        .replace(/Ú/g, 'U')
        .replace(/ü/g, 'u')
        .replace(/Ü/g, 'U')
        .replace(/û/g, 'u')
        .replace(/Û/g, 'U')
        .replace(/ç/g, 'c')
        .replace(/Ç/g, 'C');
};

String.prototype.textoNormalizado = function () {
    return this.semAcentos().toLowerCase();
};

String.prototype.isJson = function () {
    try {
        JSON.parse(this);
    } catch (e) {
        return false;
    }
    return true;
};
