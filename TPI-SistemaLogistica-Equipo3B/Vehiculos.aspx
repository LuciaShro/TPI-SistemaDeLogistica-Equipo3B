<%@ Page Title="" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="Vehiculos.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/Vehiculos.css" />
    <link rel="stylesheet" type="text/css" href="Content/Ordenes.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <h2>Vehículos</h2>

        <div class="ordenes-search">
    <input type="text" placeholder="Buscar..." />
    <span class="search-icon">🔍</span>
</div>

    <div class="tabs">
        <asp:Button runat="server" ID="btnTodos" Text="Todos" CssClass="tab active" OnClick="btnTodos_Click" />
        <asp:Button runat="server" ID="btnAsignados" Text="Asignados" CssClass="tab" OnClick="btnAsignados_Click" />
        <asp:Button runat="server" ID="btnNoAsignados" Text="No Asignados" CssClass="tab" OnClick="btnNoAsignados_Click"/>
        <asp:Button runat="server" ID="btnAnadir" Text="+ Añadir" CssClass="add-button" OnClick="btnAñadirVehiculo_Click"/>
    </div>

    <asp:GridView ID="dgvVehiculos" runat="server" DataKeyNames="idVehiculo" AutoGenerateColumns="False" OnSelectedIndexChanged="dgvVehiculos_SelectedIndexChanged" OnPageIndexChanging="dgvVehiculos_PageIndexChanging" AllowPaging="true" PageSize="5" Class="ordenes-grid table-bordered text-center align-middle">
        <Columns>
            <asp:BoundField DataField="idVehiculo" HeaderText="IDVehiculo" />
            <asp:BoundField DataField="Patente" HeaderText="Patente" />
            <asp:BoundField DataField="CapacidadCarga" HeaderText="Capacidad" />
            <asp:TemplateField HeaderText="Estado">
            <ItemTemplate>
             <%# Eval("estadoVehiculo.descripcioEstado") %>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Comentario" HeaderText="Comentario" />
           <asp:CommandField ShowSelectButton="true" SelectText="Detalles" HeaderText="Accion" />
        </Columns>
    </asp:GridView>


</asp:Content>
