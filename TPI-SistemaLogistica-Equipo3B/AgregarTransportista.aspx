<%@ Page Title="Agregar transportista" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="AgregarTransportista.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.AgregarTransportista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/CargarOrden.css" />
    <link rel="stylesheet" type="text/css" href="Content/AdminTransportistas.css" />
    <link rel="stylesheet" type="text/css" href="Content/Perfil.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
        <h1>Agregar transportista</h1>
    <a href="AdminTransportistas.aspx"><i class="bi bi-arrow-left" ></i> Volver</a>

    <div class="card">
        <h2>Datos</h2>

        <div class="foto-perfil-contenedor">
        <img src="https://preview.redd.it/is-there-a-sniper-default-pfp-that-someone-made-v0-78az45pd9f6c1.jpg?width=396&format=pjpg&auto=webp&s=5be4618605b25e0546d72dff52a7b897c3d4e1d4" class="foto-perfil" alt="FotoPerfil">
        <label for="inputFoto" class="editar-foto-link"><i class="bi bi-pencil-square"></i> Agregar foto </label>
        </div>

        <div class="form-group">
            <label for="txtNombreTransportista">Nombre</label>
            <asp:TextBox ID="txtNombreTransportista" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
        <label for="txtApellidoTranportista">Apellido</label>
        <asp:TextBox ID="txtApellidoTranportista" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label for="txtTelefonoTransportista">Teléfono Celular:</label>
            <asp:TextBox ID="txtTelefonoTransportista" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtEmailTransportista">Email:</label>
            <asp:TextBox ID="txtEmailTransportista" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtLicenciaTransportista">Licencia:</label>
            <asp:TextBox ID="txtLicenciaTransportista" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtEstadoTransportista">Estado:</label>
            <asp:TextBox ID="txtEstadoTransportista" runat="server" CssClass="form-control" />
        </div>
    </div>

    <div class="center-button">
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar datos" CssClass="btn-principal" />
</div>

</asp:Content>
