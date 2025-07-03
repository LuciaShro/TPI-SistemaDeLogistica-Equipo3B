<%@ Page Title="Facturas" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="ResumenFacturas.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.ResumenFacturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Content/ResumenFacturas.css" rel="stylesheet" />
    <script src="scripts/resumenFacturas.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <div class="facturas-container">
        <div class="factura-header">
            <h2>Facturas</h2>
            <div class="factura-total-box">
                <div class="icono-factura">📄</div>
                <div>
                    <div class="total-label">Total</div>
                    <asp:Label ID="lblTotalFacturado" runat="server" CssClass="total-monto" />
                    <br />
                    <asp:Label ID="lblCantidadTotal" runat="server" CssClass="total-detalle" />
                </div>
            </div>
            <a id="canceladasLink" runat="server" ClientIDMode="Static" href="ResumenFacturas.aspx?estado=canceladas" class="canceladas-link">Ver Canceladas</a>
        </div>

        <h4 class="seccion-titulo">Facturas (<asp:Label ID="lblCantidadFacturas" runat="server" />)</h4>

        <asp:Repeater ID="rptFacturas" runat="server">
            <ItemTemplate>
                <div class="factura-item">
                    <%--<div class="factura-avatar"><%# Eval("Iniciales") %></div>--%>
                    <div class="factura-info">
                        <div class="factura-nombre-numero">
                            <%--<strong><%# Eval("NumeroFactura") %></strong><br />--%>
                            <strong><%# "INV-" + ((int)Eval("NumeroFactura")).ToString("D4") %></strong><br />
                            <span><%# Eval("OrdenesEnvio.cliente.Nombre") %></span>
                        </div>
                        <div class="factura-monto">$<%# Eval("Total", "{0:N2}") %></div>
                        <div>
                            Emisión<br />
                            <span class="fecha"><%# Eval("FechaEmision", "{0:dd/MM/yyyy}") %></span>
                        </div>
                        <div>
                            Medio de Pago<br />
                            <span class="Medio de Pago"><%# Eval("formaDePago.medioDePago") %></span>
                        </div>
                        <div class='<%# "estado " + GetClaseEstado(Eval("formaDePago.estadoDePago.nombreEstado").ToString()) %>'>
                            <%# Eval("formaDePago.estadoDePago.nombreEstado").ToString() == "Recibido" ? "PAGADA" : 
                                Eval("formaDePago.estadoDePago.nombreEstado").ToString() == "Cancelar Orden" ? "CANCELADA" :
                                Eval("formaDePago.estadoDePago.nombreEstado").ToString() %>
                        </div>
                        <%--                        <div class="arrow">&rarr;</div>--%>
                        <asp:HyperLink runat="server" NavigateUrl='<%# "Factura.aspx?id=" + Eval("idFactura") %>' CssClass="arrow">
                            &rarr;
                        </asp:HyperLink>

                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>



</asp:Content>

