<%@ Page Title="" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="PurchaseFailure.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.PurchaseFailure" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/PurchaseFailure.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <div class="purchase-failure-container">
        <div class="mensaje-fallo">
            <h1>Pago fallido ❌</h1>
            <p>Hubo un problema al procesar tu pago. Por favor, intentá nuevamente.</p>
            <a href="PasarelaDePago.aspx" class="btn-reintentar">Reintentar pago</a>
        </div>
    </div>
</asp:Content>
