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
            <label for="inputFoto" class="editar-foto-link"><i class="bi bi-pencil-square"></i>Cambiar foto </label>
        </div>

        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Nombre</label>
            <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="form-control" placeholder="Nombre" ReadOnly="true" />
        </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Apellido</label>
            <asp:TextBox ID="txtApellidoCliente" runat="server" CssClass="form-control" placeholder="Apellido" ReadOnly="true" />
        </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">CUIL</label>
            <asp:TextBox ID="txtCuil" runat="server" CssClass="form-control" placeholder="CUIL" ReadOnly="true" />
        </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Correo</label>
            <asp:TextBox ID="txtCorreoCliente" runat="server" CssClass="form-control" placeholder="Correo" ReadOnly="true" />
        </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Telefono</label>
            <asp:TextBox ID="txtTelClietne" runat="server" CssClass="form-control" placeholder="Telefono" ReadOnly="true" />
        </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Calle</label>
            <asp:TextBox ID="txtCalleCliente" runat="server" CssClass="form-control" placeholder="Calle" ReadOnly="true" />
        </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Numero</label>
            <asp:TextBox ID="txtNumeroCliente" runat="server" CssClass="form-control" placeholder="Numero" ReadOnly="true" />
        </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Codigo Postal</label>
            <asp:TextBox ID="txtCPCliente" runat="server" CssClass="form-control" placeholder="CP" ReadOnly="true"/>
        </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Piso</label>
            <asp:TextBox ID="txtPisoCliente" runat="server" CssClass="form-control" placeholder="Piso" ReadOnly="true" />
        </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Ciudad</label>
            <asp:TextBox ID="txtCiudadCliente" runat="server" CssClass="form-control" placeholder="Ciudad" ReadOnly="true"/>
        </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Provincia</label>
            <asp:TextBox ID="txtProvCliente" runat="server" CssClass="form-control" placeholder="Provincia" ReadOnly="true" />
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
            </fieldset>
        </div>
        <asp:Button ID="btnModificarPerfil" runat="server" Text="Modificar" CssClass="btn-purple w-100" OnClick="btnModificarPerfil_Click" />
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn-purple w-100" OnClick="btnGuardar_Click" CssClass="btn btn-success" Visible="false" />
    </div>
    <div class="card p-5 w-50 mx-auto mt-3">
        <p>Eliminar cuenta y todos sus datos. Esta opcion es irreversible.</p>
        <button type="button" class="btn btn-outline-danger">Eliminar cuenta</button>
    </div>
</asp:Content>
