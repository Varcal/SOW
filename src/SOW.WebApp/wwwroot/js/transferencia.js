$(document).ready(function () {

    $("#contaDebito").hide();

    $("#usuarioCreditoSlct").hide();
    $("#contaCredito").hide();
    $("#valor").hide();


    $("#usuarioDebitoSlct").change(function () {

        var usuarioId = $("#usuarioDebitoSlct option:selected")[0].getAttribute("value");

        $.ajax({
            url: "https://localhost:5001/api/conta/" + usuarioId,
            method: "GET",
        }).done(function (data) {

            $("#contaDebitoId").val(data.id);
            $("#contaDebitoNumero").val(data.numero);
            $("#bancoDebito").val(data.banco);
            $("#saldoDebitoAtual").val(data.saldoAtual);
            $("#contaDebito").show();
            $("#usuarioCreditoSlct").show();

        }).fail(function (data) {
            $("#contaDebito").hide();
        });
    });

    $("#usuarioCreditoSlct").change(function () {

        var usuarioId = $("#usuarioCreditoSlct option:selected")[0].getAttribute("value");

        $.ajax({
            url: "https://localhost:5001/api/conta/" + usuarioId,
            method: "GET",
        }).done(function (data) {

            $("#contaCreditoId").val(data.id);
            $("#contaCreditoNumero").val(data.numero);
            $("#bancoCredito").val(data.banco);
            $("#saldoCreditoAtual").val(data.saldoAtual);
            $("#contaCredito").show();
            $("#valor").show();
        }).fail(function (data) {
            $("#contaCredito").hide();
        });
    });
});