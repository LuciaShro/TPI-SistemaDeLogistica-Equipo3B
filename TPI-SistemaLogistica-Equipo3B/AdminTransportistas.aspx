<%@ Page Title="Transportistas" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/Transportistas.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <div class="transportistas-header">
    <h1>Transportista</h1>
        </div>
        <div class="foto-perfil-contenedor pt-3 pb-3">
    <img src="https://fcb-abj-pre.s3.amazonaws.com/img/jugadors/MESSI.jpg" class="foto-perfil" alt="FotoPerfil">
    <h3>Nombre Usuario</h3>
    <label for="inputFoto" class="editar-foto-link"> User_ID: 1 </label>
    </div>
            <div class="card p-5 w-50 mx-auto">
  <div class="card-body pb-0">
    <h5>Detalles</h5>
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
      <p>B1</p>
    </li>
    <li class="list-group-item">
      <h6>Estado</h6>
      <p>Activo</p>
    </li>
  </ul>
</div>

</asp:Content>