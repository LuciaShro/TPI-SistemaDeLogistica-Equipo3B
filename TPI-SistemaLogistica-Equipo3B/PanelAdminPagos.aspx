<%@ Page Title="" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="PanelAdminPagos.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.PanelAdminPagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/PanelAdminPagos.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <h1>VENTAS</h1>
    <asp:Label ID="lblMensaje" runat="server" EnableViewState="false" CssClass="alert" />
    <div class="container mt-5">
        <table class="table">
            <thead>
                <tr>
                    <th>Venta</th>
                    <th>Cliente</th>
                    <th>Fecha</th>
                    <th>Detalle</th>
                    <th>Estado del pago</th>
                    <th>Estado del envío</th>
                    <th>Total</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptPedidos" runat="server" OnItemCommand="rptPedidos_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("VentaID") %></td>
                            <td><%# Eval("OrdenesEnvio.cliente.Nombre") %></td>
                            <td><%# Eval("Factura.FechaEmision", "{0:d MMMM}") %></td>
                            <td> <a href='<%# "DetalleVenta.aspx?VentaID=" + Eval("VentaID") %>'>Ver</a></td>
                            <td>
                                <asp:Label ID="lblEstadoPago" runat="server"
                                    Text='<%# "🧾 " + Eval("Factura.formaDePago.estadoDePago.nombreEstado") %>'
                                    CssClass='<%# GetClaseEstadoPago(Eval("Factura.formaDePago.estadoDePago.nombreEstado")) %>'>
                                </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblEstadoEnvio" runat="server"
                                    Text='<%# "📦 " + Eval("OrdenesEnvio.estado.DescripcionEstado") %>'
                                    CssClass='<%# GetClaseEstadoEnvio(Eval("OrdenesEnvio.estado.DescripcionEstado")) %>'>
                                </asp:Label>
                            </td>
                            <td><%# Eval("Factura.Total", "{0:N2}") %></td>
                            <td>
                                <div class="dropdown">
                                    <button class="btn btn-sm" type="button" data-bs-toggle="dropdown">
                                        ⋮
                                    </button>
                                    <ul class="dropdown-menu">
                                        <li>
                                            <asp:LinkButton ID="btnPagoProceso" runat="server" CommandName="PagoProceso" CommandArgument='<%# Eval("VentaID") %>' CssClass="dropdown-item">🧾 Marcar pago como en proceso</asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton ID="btnPagoRecibido" runat="server" CommandName="PagoRecibido" CommandArgument='<%# Eval("VentaID") %>' CssClass="dropdown-item">🧾 Marcar pago como recibido</asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton ID="btnPagoRechazado" runat="server" CommandName="PagoRechazado" CommandArgument='<%# Eval("VentaID") %>' CssClass="dropdown-item">🧾 Marcar pago como rechazado</asp:LinkButton></li>
                                        <li>
                                            <hr class="dropdown-divider" />
                                        </li>
                                        <li>
                                            <asp:LinkButton ID="btnCancelar" runat="server" CommandName="CancelarOrden" CommandArgument='<%# Eval("VentaID") %>' CssClass="dropdown-item text-danger">🗑 Cancelar orden</asp:LinkButton></li>
                                    </ul>
                                    
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>


            </tbody>
        </table>


    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>

</asp:Content>
