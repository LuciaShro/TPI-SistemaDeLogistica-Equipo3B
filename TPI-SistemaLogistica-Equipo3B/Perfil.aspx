<%@ Page Title="Perfil" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.Perfil" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/Perfil.css" />
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="InicioContent" runat="server">
    <h1>Perfil</h1>
    <hr />
    <div class="card p-5 w-50 mx-auto">
    <div class="foto-perfil-contenedor">
    <img src="https://preview.redd.it/is-there-a-sniper-default-pfp-that-someone-made-v0-78az45pd9f6c1.jpg?width=396&format=pjpg&auto=webp&s=5be4618605b25e0546d72dff52a7b897c3d4e1d4" class="foto-perfil" alt="FotoPerfil">
    <label for="inputFoto" class="editar-foto-link"><i class="bi bi-pencil-square"></i> Cambiar foto </label>
    </div>
    <form>
  <div class="mb-3">
    <label for="exampleInputEmail1" class="form-label">Nombre y apellido</label>
    <input type="name" class="form-control" id="exampleInputName" placeholder="Nombre completo">
  </div>
        <div class="mb-3">
         <fieldset disabled>
      <label for="disabledTextInput" class="form-label">Correo</label>
      <input type="text" id="disabledTextInput" class="form-control" placeholder="corre@ejemplo.com">
    </div>
         <div class="mb-3">
         <fieldset disabled>
             <label for="disabledTextInput" class="form-label">Rol</label>
      <select class="form-select" aria-label="Default select example">
  <option selected>Tipo</option>
  <option value="1">Administrador</option>
  <option value="2">Transportista</option>
  <option value="3">Cliente</option>
</select>
    </div>  
</form>
  <asp:Button ID="btnModificarPerfil" runat="server" Text="Modificar" CssClass="btn-purple w-100" />
</div>
    <div class="card p-5 w-50 mx-auto mt-3">
        <p>Eliminar cuenta y todos sus datos. Esta opcion es irreversible.</p>
        <button type="button" class="btn btn-outline-danger">Eliminar cuenta</button>
        </div>
</asp:Content>
