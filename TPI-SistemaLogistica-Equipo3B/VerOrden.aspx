<%@ Page Title="" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="VerOrden.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.VerOrden" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Content/VerOrden.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <div class="container">
        <div class="header">
            <h1>
                <asp:Label ID="lblFactura" runat="server" Text="DEV-103"></asp:Label></h1>
            <p>Placed on <span class="date">
                <asp:Label ID="lblFechaPedido" runat="server" /></span></p>
        </div>

        <div class="section">
            <h2>Info</h2>
            <div class="info-grid">
                <div>
                    <strong>Transportista:</strong><br />
                    <asp:Label ID="lblTransportista" runat="server" /><br />
                    <asp:Label ID="lblDireccion" runat="server" /><br />
                    <asp:Label ID="lblCiudad" runat="server" /><br />
                    <asp:Label ID="lblPais" runat="server" />
                </div>
                <div><strong>ID envío:</strong><br />
                    <asp:Label ID="lblEnvio" runat="server" /></div>
                <div><strong>Factura:</strong><br />
                    <asp:Label ID="lblNumFactura" runat="server" /></div>
                <div><strong>Fecha:</strong><br />
                    <asp:Label ID="lblFechaEnvio" runat="server" /></div>
                <div><strong>Partida:</strong><br />
                    <asp:Label ID="lblOrigen" runat="server" /></div>
                <div><strong>Destino:</strong><br />
                    <asp:Label ID="lblDestino" runat="server" /></div>
                <div class="estado">
                    <label><strong>Estado:</strong></label><br />
                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="estado-dropdown" />
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="guardar-btn"/>
                </div>
            </div>
        </div>

        <div class="section">
            <h2>Order Items</h2>
            <asp:Repeater ID="rptItems" runat="server">
                <HeaderTemplate>
                    <table>
                        <thead>
                            <tr>
                                <th>DESCRIPCIÓN</th>
                                <th>CATEGORÍA</th>
                                <th>PRECIO</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Descripcion") %></td>
                        <td><%# Eval("Categoria") %></td>
                        <td><%# Eval("Precio", "{0:C}") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <div class="total">
                <strong>TOTAL</strong>
                <span>
                    <asp:Label ID="lblTotal" runat="server" /></span>
            </div>
        </div>
    </div>
</asp:Content>
