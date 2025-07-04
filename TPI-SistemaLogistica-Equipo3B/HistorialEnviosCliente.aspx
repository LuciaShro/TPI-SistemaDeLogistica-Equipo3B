<%@ Page Title="" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="HistorialEnviosCliente.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.HistorialEnviosCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link rel="stylesheet" type="text/css" href="Content/HistorialEnviosCliente.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <asp:Repeater ID="rptEnvios" runat="server">
    <HeaderTemplate>
        <div class="tracking-container">
            <h2>Mis envíos</h2>
            <table class="tracking-table">
                <thead>
                    <tr>
                        <th>Código de Seguimiento</th>
                        <th>Estado</th>
                        <th>Detalle</th>
                    </tr>
                </thead>
                <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class='<%# Container.ItemIndex % 2 == 0 ? "even" : "odd" %>'>
            <td>
                <div class="codigo">
                    <strong><%# "#" + Eval("Codigo") %></strong><br />
                    <span class="fecha"><%# Eval("FechaEnvio", "{0:dd/MM/yy}") %></span>
                </div>
            </td>
            <td>
                <div class="estado-box">
                    <span class="estado-icono" style='<%# "background-color:" + Eval("ColorEstado") %>'></span>
                    <span class="estado-texto"><%# Eval("NombreEstado") %></span>
                </div>
                <td class="detalle-texto"><%# Eval("DetalleEstado") %></td>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
                </tbody>
            </table>
        </div>
    </FooterTemplate>     
</asp:Repeater>
<%-- <asp:Label ID="lblDebug" runat="server" ForeColor="Red" />--%>
</asp:Content>
