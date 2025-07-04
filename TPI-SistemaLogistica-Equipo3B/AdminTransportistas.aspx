<%@ Page Title="Detalle transportista" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="AdminTransportistas.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.AdminTransportistas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/AdminTransportistas.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <div class="transportistas-header">
    <h1>Detalle transportista</h1>
    <a href="Transportistas.aspx"><i class="bi bi-arrow-left" ></i> Volver</a>
        </div>
        <div class="foto-perfil-contenedor pt-3 pb-3">
    <img src="https://preview.redd.it/is-there-a-sniper-default-pfp-that-someone-made-v0-78az45pd9f6c1.jpg?width=396&format=pjpg&auto=webp&s=5be4618605b25e0546d72dff52a7b897c3d4e1d4" class="foto-perfil" alt="FotoPerfil">
    <h3>Nombre Usuario</h3>
    <label for="inputFoto" class="editar-foto-link"> User_ID: 1 </label>
    </div>
            <div class="card p-5 w-50 mx-auto">
  <div class="card-body pb-0">
    <h5>Detalles</h5> 
    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-outline-primary" OnClick="btnModificar_Click" Visible="true" />
  </div>
  <ul class="list-group list-group-flush">
    <li class="list-group-item">
      <h6>Email</h6>
      <asp:Label ID="lblEmail" runat="server" Text="--"></asp:Label>
      <asp:TextBox ID="txtEmail" runat="server" Visible="false"></asp:TextBox>
        <asp:RequiredFieldValidator ErrorMessage="El Email es requerido" ControlToValidate="txtEmail" runat="server"  EnableClientScript="true" Display="Dynamic" ValidationGroup="transportista" ></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ErrorMessage=" Solo se pueden ingresar formato de email" ControlToValidate="txtEmail" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" runat="server" EnableClientScript="true" Display="Dynamic" ValidationGroup="transportista"></asp:RegularExpressionValidator>
    </li>
    <li class="list-group-item">
      <h6>Nombre</h6>
        <asp:Label ID="lblNombre" runat="server" Text="--"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server" Visible="false"></asp:TextBox>
        <asp:RequiredFieldValidator ErrorMessage="El Nombre es requerido" ControlToValidate="txtNombre" runat="server"  EnableClientScript="true" Display="Dynamic" ValidationGroup="transportista" ></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ErrorMessage=" Solo se pueden ingresar caracteres" ControlToValidate="txtNombre" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" runat="server" EnableClientScript="true" Display="Dynamic" ValidationGroup="transportista"></asp:RegularExpressionValidator>
    </li>
    <li class="list-group-item">
      <h6>Apellido</h6>
        <asp:Label ID="lblApellido" runat="server" Text="--"></asp:Label>
        <asp:TextBox ID="txtApellido" runat="server" Visible="false"></asp:TextBox>
        <asp:RequiredFieldValidator ErrorMessage="El Apellido es requerido" ControlToValidate="txtApellido" runat="server"  EnableClientScript="true" Display="Dynamic" ValidationGroup="transportista" ></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ErrorMessage=" Solo se pueden ingresar caracteres" ControlToValidate="txtApellido" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" runat="server" EnableClientScript="true" Display="Dynamic" ValidationGroup="transportista"></asp:RegularExpressionValidator>
    </li>
       <li class="list-group-item">
    <h6>Cuil</h6>
     <asp:Label ID="lblCuil" runat="server" Text="--"></asp:Label>
     <asp:TextBox ID="txtCuil" runat="server" Visible="false"></asp:TextBox>
     <asp:RequiredFieldValidator ErrorMessage="El Cuil es requerido" ControlToValidate="txtCuil" runat="server"  EnableClientScript="true" Display="Dynamic" ValidationGroup="transportista" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ErrorMessage=" El cuil debe tener 11 digitos" ControlToValidate="txtCuil" ValidationExpression="^\d{11}$" runat="server" EnableClientScript="true" Display="Dynamic" ValidationGroup="transportista"></asp:RegularExpressionValidator>
    </li>
    <li class="list-group-item">
      <h6>Teléfono</h6>
        <asp:Label ID="lblTelefono" runat="server" Text="--"></asp:Label>
        <asp:TextBox ID="txtTelefono" runat="server" Visible="false"></asp:TextBox>
        <asp:RequiredFieldValidator ErrorMessage="El Telefono es requerido" ControlToValidate="txtTelefono" runat="server"  EnableClientScript="true" Display="Dynamic" ValidationGroup="transportista" ></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ErrorMessage=" El telefono debe tener 10 digitos" ControlToValidate="txtTelefono" ValidationExpression="^\d{10}$" runat="server" EnableClientScript="true" Display="Dynamic" ValidationGroup="transportista"></asp:RegularExpressionValidator>
    </li>
    <li class="list-group-item">
      <h6>Licencia</h6>
        <asp:Label ID="lblLicencia" runat="server" Text="--"></asp:Label>
        <asp:TextBox ID="txtLicencia" runat="server" Visible="false"></asp:TextBox>
    </li>
    <li class="list-group-item">
      <h6>Estado</h6>
      <asp:Label ID="lblEstado" runat="server" Text="--"></asp:Label>
    </li>
      <li class="list-group-item">
     <h6>Horario Inicio</h6>
    <asp:Label ID="lblHorarioInicio" runat="server" Text="--" />
    <asp:TextBox ID="txtHorarioInicio" runat="server" Visible="false"></asp:TextBox>
    </li>
    <li class="list-group-item">
    <h6>Horario Fin</h6>
    <asp:Label ID="lblHorarioFin" runat="server" Text="--" />
    <asp:TextBox ID="txtHorarioFin" runat="server" Visible="false"></asp:TextBox>
</li>
  </ul>
</div>


    <div class="card p-5 w-50 mx-auto mt-3">
    <asp:Button ID="btnDarBajaTransportista" runat="server" Text="Dar de baja" CssClass="btn  btn-outline-danger" OnClientClick="return confirm('Estas seguro que queres dar de baja este usuario? Esta accion es irreversible');" OnClick="btnDarBajaTransportista_Click" Visible="false" ValidationGroup="transportista"/>
    <asp:Button ID="btnReactivarTransportista" runat="server" Text="Reactivar transportista" CssClass="btn btn-outline-danger" OnClientClick="return confirm('Estas seguro que queres dar de baja este usuario? Esta accion es irreversible');" OnClick ="btnReactivarTransportista_Click" Visible="false"/>
    </div> 
    <asp:Button ID="btnGuardarCambios" runat="server" Text="Guardar cambios" CssClass="btn btn-outline-primary" Visible="false" OnClick="btnGuardarCambios_Click"/>
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-outline-primary" OnClick="btnCancelar_Click" Visible="false"/>
    <asp:Label ID="lblMensajePantalla" runat="server" Text="" CssClass="text-danger"></asp:Label>
</asp:Content>