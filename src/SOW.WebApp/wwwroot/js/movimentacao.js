$(document).ready(function() {

    $("#conta").hide();


    $("#usuario").change(function () {

        var usuarioId = $("#usuario option:selected")[0].getAttribute("value");

        $.ajax({
            url: "https://localhost:5001/api/conta/" + usuarioId,
            method: "GET",
        }).done(function (data) {

            $("#contaId").val(data.id);
            $("#contaNumero").val(data.numero);
            $("#banco").val(data.banco);
            $("#saldoAtual").val(data.saldoAtual);
            $("#conta").show();
        }).fail(function (data) {
            $("#conta").hide();
        });
    });
});