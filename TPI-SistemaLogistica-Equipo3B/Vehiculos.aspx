<%@ Page Title="" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="Vehiculos.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/Vehiculos.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <h2>Vehículos</h2>

    <div class="tabs">
        <asp:Button runat="server" ID="btnTodos" Text="Todos" CssClass="tab active" />
        <asp:Button runat="server" ID="btnActivos" Text="Activos" CssClass="tab" />
        <asp:Button runat="server" ID="btnInactivos" Text="Inactivos" CssClass="tab"/>
        <asp:Button runat="server" ID="btnAnadir" Text="+ Añadir" CssClass="add-button" OnClick="btnAñadirVehiculo_Click"/>
    </div>

    <asp:GridView ID="gvVehiculos" runat="server" AutoGenerateColumns="False" CssClass="vehiculos-table">
        <Columns>
            <asp:BoundField DataField="IdVehiculo" HeaderText="IDVEHICULO" />
            <asp:TemplateField HeaderText="TRANSPORTISTA">
                <ItemTemplate>
                    <b><%# Eval("NombreTransportista") %></b><br />
                    <span><%# Eval("EmailTransportista") %></span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Patente" HeaderText="PATENTE" />
            <asp:BoundField DataField="Estado" HeaderText="ESTADO" />
            <asp:BoundField DataField="Capacidad" HeaderText="CAPACIDAD" />
            <asp:TemplateField HeaderText="ACCIONES">
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/img/edit_icon.png" ToolTip="Editar" CommandName="Editar" CommandArgument='<%# Eval("IdVehiculo") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
