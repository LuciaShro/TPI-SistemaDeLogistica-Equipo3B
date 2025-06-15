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
    <h5>Detalles</h5> <a href="AgregarTransportista.aspx">Modificar<i class="bi bi-pencil-square"></i></a>
  </div>
  <ul class="list-group list-group-flush">
    <li class="list-group-item">
      <h6>Email</h6>
       <p>Ejemplo@gmail.com</p>
    </li>
    <li class="list-group-item">
      <h6>Nombre</h6>
      <p>Juan</p>
    </li>
    <li class="list-group-item">
      <h6>Apellido</h6>
      <p>Perez</p>
    </li>
    <li class="list-group-item">
      <h6>Teléfono</h6>
      <p>+54 011 11111111</p>
    </li>
    <li class="list-group-item">
      <h6>Licencia</h6>
      <p>C3</p>
    </li>
    <li class="list-group-item">
      <h6>Estado</h6>
      <p>Activo</p>
    </li>
  </ul>
</div>

    <div class="card p-5 w-50 mx-auto mt-3">
    <asp:Button ID="btnDarBajaTransportista" runat="server" Text="Dar de baja" CssClass="btn  btn-outline-danger" OnClientClick="return confirm('Estas seguro que queres dar de baja este usuario? Esta accion es irreversible');" OnClick="btnDarBajaTransportista_Click"/>
    </div> 

</asp:Content>