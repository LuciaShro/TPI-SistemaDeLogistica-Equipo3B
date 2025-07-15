<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.Inicio" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/Inicio.css" />
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="InicioContent" runat="server">
    <h1>¡👋 Hola!</h1>

    <div class="col">
        <div class="card" style="max-width: 500px;">
            <h5 class="card-header">Informe Medios de Pago</h5>
            <div class="card-body">
                <h3>Medios de pagos más utilizados</h3>
                <div style="max-width: 400px; margin: auto;">
                    <canvas id="miGrafico" width="400" height="400" style="background-color: white;"></canvas>
                </div>
            </div>
        </div>

        <div class="card" style="max-width: 500px;">
            <h5 class="card-header">Informe Provincias más elegidas</h5>
            <div class="card-body">
                <h3>Top 5 provincias:</h3>
                <div style="max-width: 400px; margin: auto;">
                    <canvas id="GraficoProvincias" width="400" height="400" style="background-color: white;"></canvas>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        var etiquetasJson = JSON.parse('<%= etiquetasJson %>');
        var valoresJson = JSON.parse('<%= valoresJson %>');

        console.log("Etiquetas:", etiquetasJson);
        console.log("Valores:", valoresJson);
    </script>

    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script src="Content/Inicio.js"></script>

    <%--    <div class="row row-cols-1 row-cols-md-2 g-5">
        <div class="col">
            <div class="card">
                <h5 class="card-header">Informe</h5>
                <div class="card-body">
                    <h5 class="card-title">Resumen rutas mas utilizadas.</h5>
                    <p class="card-text">Ultimos 7 dias.</p>
                </div>
            </div>
        </div>
        <div class="col">
            <div class="card">
                <h5 class="card-header">Informe</h5>
                <div class="card-body">
                    <h5 class="card-title">Envios activos</h5>
                    <p class="card-text">Insertar Grafico aca.</p>
                </div>
            </div>
        </div>
        <div class="col">
            <div class="card">
                <h5 class="card-header">Informe</h5>
                <div class="card-body">
                    <h5 class="card-title">Resumen Inventario</h5>
                    <p class="card-text">Insertar Grafico aca.</p>
                </div>
            </div>
        </div>
    </div>--%>
</asp:Content>

