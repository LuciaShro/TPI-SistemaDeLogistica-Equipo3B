<%@ Page Title="Transportistas" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="Transportistas.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.Transportistas" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/Transportistas.css" />
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="InicioContent" runat="server">
    <div class="transportistas-header">
    <h1>Transportistas</h1>
    <asp:Button ID="btnAñadirTransportista" runat="server" Text="＋ Añadir" CssClass="btn-añadirTransportista" OnClick="btnAñadirTransportista_Click"/>
    
        </div>

            <div class="transportistas-search">
            <input type="text" placeholder="Buscar..." />
            <span class="search-icon">🔍</span>
        </div>
            
            <div class="transportistas-tabs">
                <asp:LinkButton ID="btnTodos" runat="server" CssClass="tab active" OnClick="btnTodos_Click">Todos</asp:LinkButton>
                <asp:LinkButton ID="btnActivo" runat="server" CssClass="tab" OnClick="btnActivo_Click">Activos</asp:LinkButton>
                <asp:LinkButton ID="btnInactivo" runat="server" CssClass="tab" OnClick="btnInactivo_Click">Inactivos</asp:LinkButton>
        </div>

        <div class="container text-center mt-4">
        <div class="row-top">
        <div class="row">
    <div class="col">
        <div class="form-check">
    <input class="form-check-input" type="checkbox" value="" id="checkDefault">
       <label class="form-check-label" for="checkDefault">
    </label>
         </div>
    </div>
    <div class="col">Nombre</div>
    <div class="col">Estado</div>
    <div class="col">Ubicacion</div>
    <div class="col">Orden</div>
    <div class="col">Horario</div>
    <div class="col">Accion</div>
</div>
            </div>
        <div class="row">
            <div class="col">
                <div class="form-check">
            <input class="form-check-input" type="checkbox" value="" id="checkDefault">
               <label class="form-check-label" for="checkDefault">
            </label>
                 </div>
            </div>
            <div class="col">
            <div class="perfil">
            <img src="https://preview.redd.it/is-there-a-sniper-default-pfp-that-someone-made-v0-78az45pd9f6c1.jpg?width=396&format=pjpg&auto=webp&s=5be4618605b25e0546d72dff52a7b897c3d4e1d4" class="foto-perfil" alt="FotoPerfil">Nombre Usuario</div>
            </div>
            <div class="col">Activo</div>
            <div class="col">Pacheco</div>
            <div class="col">1</div>
            <div class="col">Horario</div>
            <div class="col"><a href="AdminTransportistas.aspx">Detalle<i class="bi bi-pencil-square"></i></a></div>
        </div>
        <div class="row">
            <div class="col">    <div class="form-check">
            <input class="form-check-input" type="checkbox" value="" id="checkDefault">
            <label class="form-check-label" for="checkDefault">
            </label>
        </div></div>
            <div class="col">
            <div class="perfil">
            <img src="https://preview.redd.it/is-there-a-sniper-default-pfp-that-someone-made-v0-78az45pd9f6c1.jpg?width=396&format=pjpg&auto=webp&s=5be4618605b25e0546d72dff52a7b897c3d4e1d4" class="foto-perfil" alt="FotoPerfil">Nombre Usuario</div>
            </div>
            <div class="col">Activo</div>
            <div class="col">Pacheco</div>
            <div class="col">2</div>
            <div class="col">Horario</div>
            <div class="col"><a href="AdminTransportistas.aspx">Detalle<i class="bi bi-pencil-square"></i></a></div>
        </div>
        </div>

</asp:Content>