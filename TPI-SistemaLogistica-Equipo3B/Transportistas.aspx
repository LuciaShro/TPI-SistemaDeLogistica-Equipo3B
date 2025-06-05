<%@ Page Title="Transportistas" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.Inicio" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/Transportistas.css" />
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="InicioContent" runat="server">
    <div class="transportistas-header">
    <h1>Transportistas</h1>
    <asp:Button ID="btnAñadirTransportista" runat="server" Text="＋ Añadir" CssClass="btn-añadirTransportista"/>
    </button>
        </div>

            <div class="transportistas-search">
            <input type="text" placeholder="Buscar..." />
            <span class="search-icon">🔍</span>
        </div>

            <div class="transportistas-tabs">
            <a href="#" class="tab active">Todos</a>
            <a href="#" class="tab">Activos</a>
            <a href="#" class="tab">Inactivos</a>
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
            <img src="https://fcb-abj-pre.s3.amazonaws.com/img/jugadors/MESSI.jpg" class="foto-perfil" alt="FotoPerfil">Lionel Messi</div>
            </div>
            <div class="col">Activo</div>
            <div class="col">Pacheco</div>
            <div class="col">1</div>
            <div class="col">Horario</div>
            <div class="col">Editar<i class="bi bi-pencil-square"></i></div>
        </div>
        <div class="row">
            <div class="col">    <div class="form-check">
            <input class="form-check-input" type="checkbox" value="" id="checkDefault">
            <label class="form-check-label" for="checkDefault">
            </label>
        </div></div>
            <div class="col">
            <div class="perfil">
            <img src="https://fcb-abj-pre.s3.amazonaws.com/img/jugadors/MESSI.jpg" class="foto-perfil" alt="FotoPerfil">Lionel Messi</div>
            </div>
            <div class="col">Activo</div>
            <div class="col">Pacheco</div>
            <div class="col">2</div>
            <div class="col">Horario</div>
            <div class="col">Editar<i class="bi bi-pencil-square"></i></div>
        </div>
        </div>

</asp:Content>