$.ajax({
    type: "POST",
    url: "CargarOrden.aspx.cs/GetLocalidades",
    data: JSON.stringify({ provincia: "Buenos Aires" }),
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (response) {
        const localidades = response.d;
        // llenar dropdown
    }
});
