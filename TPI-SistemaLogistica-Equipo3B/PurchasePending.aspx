<%@ Page Title="" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="PurchasePending.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.PurchasePending" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link rel="stylesheet" type="text/css" href="Content/PurchasePending.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
     <div class="purchase-pending-container">
        <div class="mensaje-pendiente">
            <h1>Pago pendiente ⏳</h1>
            <p>Estamos esperando la confirmación del pago. Te notificaremos cuando esté procesado.</p>
            <a href="BienvenidoUser.aspx" class="btn-volver">Ir a mis envíos</a>
            <asp:Label ID="lblMensajeError" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
