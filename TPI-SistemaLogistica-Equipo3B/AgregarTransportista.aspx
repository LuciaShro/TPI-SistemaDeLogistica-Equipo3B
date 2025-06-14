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
        <asp:Image ID="imgPreview" runat="server" CssClass="foto-perfil" ImageUrl="https://via.placeholder.com/150" />

        <asp:FileUpload ID="fileUploadFoto" runat="server" CssClass="form-control" />

        <asp:Button ID="btnCargarFoto" runat="server" Text="CargarFoto" CssClass="btn btn-secondary" OnClick="btnCargarFoto_Click" />
        </div>

        <div class="form-group">
            <label for="txtNombreTransportista">Nombre:</label>
            <asp:TextBox ID="txtNombreTransportista" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
        <label for="txtApellidoTranportista">Apellido:</label>
        <asp:TextBox ID="txtApellidoTranportista" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
        <label for="txtCuilTransportista">Cuil:</label>
        <asp:TextBox ID="txtCuilTransportista" runat="server" CssClass="form-control"></asp:TextBox>
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
            <label for="txtInicioJornadaLaboral">Horario Inicio Jornada laboral:</label>
            <asp:TextBox ID="txtInicioJornadaLaboral" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtFinJornadaLaboral">Horario Final Jornada Laboral:</label>
            <asp:TextBox ID="txtFinJornadaLaboral" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtUsuarioTransportista">Usuario:</label>
            <asp:TextBox ID="txtUsuarioTransportista" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtContraseñaTransportista">Contraseña:</label>
            <asp:TextBox ID="txtContraseñaTransportista" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <!--
        <div class="form-group">
            <label for="txtListaVehiculosDisponibles">Vehiculos disponibles:</label>
            <asp:DropDownList ID="ddlVehiculosDisponibles" runat="server" CssClass="form-control"></asp:DropDownList>
        </div> -->
    </div>

    <div class="center-button">
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar datos" CssClass="btn-principal" OnClick="btnGuardar_Click" />
    <asp:Label ID="lblMensajeEnPantalla" runat="server" Text="" CssClass="text-danger mt-2 d-block"></asp:Label>
</div>


   

</asp:Content>
