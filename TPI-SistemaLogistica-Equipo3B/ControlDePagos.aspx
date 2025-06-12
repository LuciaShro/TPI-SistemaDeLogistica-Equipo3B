<%@ Page Title="" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="ControlDePagos.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.ControlDePagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Content/ControlDePagos.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <h1>Gestión de Pagos</h1>
    <%--<asp:GridView ID="gvVentas" runat="server" AutoGenerateColumns="False" CssClass="table" ShowHeader="true">
        <Columns>
            <asp:TemplateField HeaderText="Venta">
                <ItemTemplate>
                    <span>#<%# Eval("VentaId") %></span>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Cliente">
                <ItemTemplate>
                    <%# Eval("Cliente") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Fecha">
                <ItemTemplate>
                    <%# Eval("Fecha", "{0:dd MMMM}") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Productos">
                <ItemTemplate>
                    <a href="#">Ver ▼</a>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Estado del pago">
                <ItemTemplate>
                    <span class="estado-pago">💳 <%# Eval("EstadoPago") %></span>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Estado del envío">
                <ItemTemplate>
                    <span class="estado-envio">📦 <%# Eval("EstadoEnvio") %></span>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Total">
                <ItemTemplate>
                    $<%# Eval("Total", "{0:N2}") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <div style="position: relative;">
                        <asp:LinkButton ID="btnAcciones" runat="server" Text="⋮"
                            CommandName="MostrarAcciones"
                            CommandArgument='<%# Eval("VentaId") %>'
                            CssClass="btn-mas" />

                        <asp:Panel ID="pnlAcciones" runat="server" CssClass="acciones-menu" Visible="false">
                            <asp:LinkButton ID="btnMarcarEnProceso" runat="server" Text="💳 Marcar pago como en proceso" CommandName="PagoEnProceso" />
                            <asp:LinkButton ID="btnMarcarRecibido" runat="server" Text="💳 Marcar pago como recibido" CommandName="PagoRecibido" />
                            <asp:LinkButton ID="btnMarcarRechazado" runat="server" Text="💳 Marcar pago como rechazado" CommandName="PagoRechazado" />
                            <asp:LinkButton ID="btnCancelar" runat="server" Text="🗑 Cancelar orden" CssClass="cancelar" CommandName="CancelarOrden" />
                        </asp:Panel>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>--%>

    <table class="table" style="width: 100%; border-collapse: collapse;">
        <thead>
            <tr>
                <th>Venta</th>
                <th>Cliente</th>
                <th>Fecha</th>
                <th>Productos</th>
                <th>Estado del pago</th>
                <th>Estado del envío</th>
                <th>Total</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>#1</td>
                <td>PRUEBA</td>
                <td>9 junio</td>
                <td><a href="#">Ver ▼</a></td>
                <td><span class="estado-pago">💳 Pago en proceso</span></td>
                <td><span class="estado-envio">📦 En proceso</span></td>
                <td>$35.000,00</td>
                <td style="position: relative;">
                    <button class="btn-mas">⋮</button>
                    <div class="acciones-menu">
                        <div>💳 Marcar pago como en proceso</div>
                        <div>💳 Marcar pago como recibido</div>
                        <div>💳 Marcar pago como rechazado</div>
                        <div class="cancelar">🗑 Cancelar orden</div>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>

</asp:Content>
