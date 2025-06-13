<%@ Page Title="" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="Ordenes.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.Ordenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/Ordenes.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <div class="ordenes-container">
        <div class="ordenes-header">
            <h1>Ordenes</h1>
            <asp:Button ID="btnAñadir" runat="server" Text="＋ Añadir" CssClass="btn-añadir" OnClick="btnAñadir_Click" />
            </button>
        </div>

        <div class="ordenes-tabs">
            <a href="#" class="tab active">Todos</a>
            <a href="#" class="tab">Canceladas</a>
            <a href="#" class="tab">Completados</a>
            <a href="#" class="tab">Pendientes</a>
            <a href="#" class="tab">Rechazados</a>
        </div>

        <div class="ordenes-search">
            <input type="text" placeholder="Buscar..." />
            <span class="search-icon">🔍</span>
        </div>
    </div>

    <%--<asp:Repeater ID="rptOrdenes" runat="server">
        <ItemTemplate>
            <div class="orden-item">
                <div class="orden-fecha">
                    <span class="mes"><%# Eval("Mes") %></span>
                    <span class="dia"><%# Eval("Dia") %></span>
                </div>
                <div class="orden-info">
                    <div class="orden-codigo"><%# Eval("Codigo") %></div>
                    <div class="orden-total">Total of <%# Eval("Total", "{0:C}") %></div>
                </div>
                <div class="orden-estado <%# Eval("Estado").ToString().ToLower() %>">
                    <%# Eval("Estado") %>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>--%>

    <asp:GridView runat="server" ID="dgvOrdenes"  CssClass="ordenes-grid" AutoGenerateColumns="false">
        <Columns>
        <asp:BoundField HeaderText="ID Orden" DataField="idOrdenEnvio"  />
        <asp:BoundField HeaderText="Cliente" DataField="cliente.Nombre"  />
        <asp:BoundField HeaderText="Transportista" DataField="transportistaAsignado.Nombre"  />
        <asp:BoundField HeaderText="Estado" DataField="estado.DescripcionEstado" />
        <asp:BoundField HeaderText="Fecha Creación" DataField="FechaCreacion" />
        <asp:BoundField HeaderText="Fecha Envío" DataField="FechaEnvio" />
        <asp:BoundField HeaderText="Fecha Estimada" DataField="FechaEstimadaLlegada" />
        <asp:BoundField HeaderText="Fecha Llegada" DataField="FechaDeLlegada" />
        <asp:BoundField HeaderText="Cantidad Enviada" DataField="CantidadTotalEnviada" />
         </Columns>
    </asp:GridView>
</asp:Content>
