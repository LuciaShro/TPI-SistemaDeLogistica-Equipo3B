<%@ Page Title="" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="Vehiculos.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/Vehiculos.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <h2>Vehículos</h2>

    <div class="tabs">
        <asp:Button runat="server" ID="btnTodos" Text="Todos" CssClass="tab active" OnClick="btnTodos_Click" />
        <asp:Button runat="server" ID="btnAsignados" Text="Asignados" CssClass="tab" OnClick="btnAsignados_Click" />
        <asp:Button runat="server" ID="btnNoAsignados" Text="No Asignados" CssClass="tab" OnClick="btnNoAsignados_Click"/>
        <asp:Button runat="server" ID="btnAnadir" Text="+ Añadir" CssClass="add-button" OnClick="btnAñadirVehiculo_Click"/>
    </div>

    <asp:GridView ID="gvVehiculos" runat="server" AutoGenerateColumns="False" CssClass="vehiculos-table">
        <Columns>
            <asp:BoundField DataField="idVehiculo" HeaderText="IDVEHICULO" />
            <asp:BoundField DataField="Patente" HeaderText="PATENTE" />
            <asp:BoundField DataField="CapacidadCarga" HeaderText="CAPACIDAD" />
            <asp:TemplateField HeaderText="ESTADO">
            <ItemTemplate>
             <%# Eval("estadoVehiculo.descripcioEstado") %>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ACCIONES">
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/img/edit_icon.png" ToolTip="Editar" OnClick="btnEditar_Click" CommandName="Editar" CommandArgument='<%# Eval("IdVehiculo") %>'/>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>


</asp:Content>
