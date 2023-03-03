$(document).ready(function () {

    $('#korisnici').DataTable({
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.13.3/i18n/hr.json"
        }
    });  // Korisnici table, most of the customization done in html

    $('#ponude').DataTable({
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.13.3/i18n/hr.json"
        }
    });  // Ponude table, most of the customization done in html

    $('#rezervacije').DataTable({
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.13.3/i18n/hr.json"
        }
    });  // Rezervacije table, most of the customization done in html


    //Confirm submit of deletes
    $('.confirm-submit').submit(function (event) {
        var confirmation = confirm('Da li ste sigurni da želite da obrišete ovu stavku?');
        if (!confirmation) {
            event.preventDefault();
        }
    });

});

