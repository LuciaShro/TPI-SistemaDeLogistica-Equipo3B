<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SeguimientoPedido.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.SeguimientoPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Content/SeguimientoPedido.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="box-principal">
        <h1>¡Seguí tu pedido acá!</h1>
        <h3>Completá tu código de seguimiento.</h3>
        <div class="box-codigo">
            <h4>Ingrese el código de seguimiento:</h4>
            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" placeholder="Ejemplo: ABC123" />
            <div class="button">
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn-principal" />
            </div>
        </div>
    </div>

</asp:Content>

<%--OnClientClick="return validarDestinatario();" OnClick="btnCargar_Click"--%>