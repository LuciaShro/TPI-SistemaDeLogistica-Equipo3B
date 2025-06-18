<%@ Page Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="OrdenesAsignadas.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.OrdenesAsignadas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/Ordenes.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <div class="ordenes-container">
        <div class="ordenes-header">
            <h1>Ordenes Asignadas</h1>
        </div>

        <div class="ordenes-tabs">
            <a href="#" class="tab active">Todos</a>
            <a href="#" class="tab">Completados</a>
            <a href="#" class="tab">Retrasadas</a>
            <a href="#" class="tab">Pendientes</a>
        </div>

        <div class="ordenes-search">
            <input type="text" placeholder="Buscar..." />
            <span class="search-icon">🔍</span>
        </div>
    </div>

    <asp:Repeater ID="rptOrdenes" runat="server">
        <ItemTemplate>
            <div class="card mb-3" style="width: 50%;">
                <div class="card-body">
                    <h5 class="card-title"><strong>Orden#<%#Eval ("idOrdenEnvio")%></strong></h5>
                    <p class="card-text">Destinatario: <%#Eval ("Destinatario")%></p>
                    <p class="card-text">Salida: <%#Eval ("ruta.PuntoPartida")%></p>
                    <p class="card-text">Destino: <%#Eval ("ruta.PuntoDestino")%></p>
                    <p class="card-text">Fecha envio: <%#Eval ("FechaEnvio")%></p>
                    <p class="card-text">Fecha estimada llegada: <%#Eval ("FechaEstimadaLlegada")%></p>
                    <p class="card-text">Estado: <%#Eval ("estado.DescripcionEstado")%></p>
                    <a href="DetalleDeOrden.aspx?id=<%#Eval ("idOrdenEnvio") %>" class="btn btn-primary">Ver detalle</a>
                </div>
</div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

