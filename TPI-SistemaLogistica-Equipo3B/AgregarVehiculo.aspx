<%@ Page Title="Agregar vehiculo" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="AgregarVehiculo.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.AgregarVehiculo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/CargarOrden.css" />
    <link rel="stylesheet" type="text/css" href="Content/AdminTransportistas.css" />
    <link rel="stylesheet" type="text/css" href="Content/Perfil.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
        <h1>Agregar Vehiculo</h1>
    <a href="Vehiculos.aspx"><i class="bi bi-arrow-left" ></i> Volver</a>

    <div class="card">
        <h2>Datos</h2>

        <div class="form-group">
            <label for="txtPatente">Patente:</label>
            <asp:TextBox ID="txtPatente" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
        <label for="txtCapacidadCarga">Capacidad de carga:</label>
        <asp:TextBox ID="txtCapacidadCarga" runat="server" CssClass="form-control" />
        </div>

    <div class="center-button">
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar datos" CssClass="btn-principal" OnClick="btnGuardar_Click" />
</div>
        <asp:Label ID="lblMensajePantalla" runat="server" Text="" CssClass="btn-principal"></asp:Label>
        </div>

</asp:Content>
