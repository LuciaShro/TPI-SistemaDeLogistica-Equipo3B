<%@ Page Title="Factura" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.Factura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Content/Factura.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <div class="invoice-container">
        <div class="invoice-header">
            <div class="company-logo">
                <img src="logo.png" alt="Logo" />
            </div>
            <div class="invoice-actions">
                <asp:Label ID="lblEstadoPago" runat="server" CssClass="status-paid" Text="PAGADO" />
                <asp:Button ID="btnDownload" runat="server" CssClass="btn-download" Text="Descargar" />
            </div>
        </div>

        <div class="invoice-info">
            <div>
                <strong>www.FlashShip.com</strong><br />
                 AV. 9 de Julio, 175<br />
                 Buenos Aires, ARG
            </div>
            <div>
                <asp:Label ID="lblRazonSocial" runat="server" />
                <asp:Label ID="lblCUilEmisor" runat="server" />
                flashship@gmail.com<br />
                (+54) 011 2239 6672
            </div>
        </div>

        <div class="invoice-dates">
            <div>
                <strong>Fecha de emisión:</strong><br />
                <asp:Label ID="lblFechaEmision" runat="server" />
            </div>
            <div>
                <strong>Fecha de vencimiento:</strong><br />
                <asp:Label ID="lblFechaVencimiento" runat="server" />
            </div>
            <div>
                <strong>Número de factura #:</strong><br />
                <asp:Label ID="lblNumeroFactura" runat="server" />
            </div>
        </div>

        <div class="billed-to">
            <strong>Facturado a</strong><br />
            <asp:Label ID="lblNombreCliente" runat="server" /><br />
            <asp:Label ID="lblCuil" runat="server" /><br />
            <asp:Label ID="lblDireccionCliente" runat="server" />
            <asp:Label ID="lblCPCDCliente" runat="server" />
            <asp:Label ID="lblProvCliente" runat="server" />
        </div>

        <table class="invoice-table">
            <thead>
                <tr>
                    <th>#</th>
                    <th>DESCRIPCIÓN</th>
                    <th>PRECIO ENVÍO</th>
                    <th>TOTAL</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptItems" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Container.ItemIndex + 1 %></td>
                            <td><%# Eval("Categoria") %></td>
                            <td><%# Eval("Precio", "{0:C}") %></td>
                            <td><%# Eval("Total", "{0:C}") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>

        <div class="invoice-summary">
            <div>Subtotal: <span>
                <asp:Label ID="lblSubtotal" runat="server" /></span></div>
            <div class="total">Total: <span>
                <asp:Label ID="lblTotal" runat="server" /></span></div>
        </div>
    </div>

</asp:Content>

