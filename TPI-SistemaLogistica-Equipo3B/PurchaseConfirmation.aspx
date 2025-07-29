<%@ Page Title="" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="PurchaseConfirmation.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.PurchaseConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

     <link rel="stylesheet" type="text/css" href="Content/PurchaseConfirmation.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <div class="purchase-confirmation-container">
        <div class="mensaje-pago">
            <h1>¡Pago confirmado! 💳</h1>
            <p>Tu orden fue procesada exitosamente. Gracias por elegir <strong>FlashShip</strong>. 🚚</p>
            <a href="MisEnvios.aspx" class="btn-mis-envios">Ver mis envíos</a>
        </div>
    </div>
</asp:Content>
