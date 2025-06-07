<%@ Page Title="" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="PasarelaDePago.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.PasarelaDePago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/PasarelaDePago.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <div class="pago-wrapper">
        <h2>Escoge tu medio de pago</h2>

        <div class="opciones-pago">

            <asp:LinkButton ID="btnTransferencia" runat="server" CssClass="boton-pago boton-activo"
                OnClick="btnTransferencia_Click">Transferencia</asp:LinkButton>

            <asp:LinkButton ID="btnMercadoPago" runat="server" CssClass="boton-pago"
                OnClick="btnMercadoPago_Click">
            <img src="Imagenes/mercado-pago-logo.png" alt="Mercado Pago" class="img-boton" />
            </asp:LinkButton>
        </div>

        <asp:Panel ID="pnlTransferencia" runat="server" CssClass="panel-transferencia" Visible="true">
            <strong>Transferencia</strong>
            <p>
                Banco: NACION<br />
                Razón social: Logística Express S.A.<br />
                CBU: 0190034550000000228744
            </p>
            <p>
                Por favor, envíe el comprobante de la transferencia a nuestro WhatsApp<br />
                <strong class="whatsapp">+54 1122334455</strong><br />
                indicando su número de pedido (o número de CUIL) para confirmar su pago.
            </p>
        </asp:Panel>

        <div class="pago-resumen">
            <h3>Resumen</h3>
            <p>
                Precio envío: <strong>
                    <asp:Label ID="lblEnvio" runat="server" Text="$300.00" /></strong>
            </p>
            <p>
                Total: <strong>
                    <asp:Label ID="lblTotal" runat="server" Text="$300.00" /></strong>
            </p>

            <p class="condiciones">
                Al completar la compra aceptas estas <a href="#">Condiciones de uso</a>.
            </p>

            <asp:Button ID="btnCompletarPago" runat="server" Text="Completar Pago" CssClass="btn-pago"
                OnClick="btnCompletarPago_Click"/>
        </div>
    </div>

</asp:Content>
