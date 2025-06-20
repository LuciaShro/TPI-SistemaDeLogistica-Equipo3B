<%@ Page Title="Transportistas" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="Transportistas.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.Transportistas" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/Transportistas.css" />
    <link rel="stylesheet" type="text/css" href="Content/Ordenes.css" />
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
                <asp:LinkButton ID="btnActivo" runat="server" CssClass="tab active" OnClick="btnActivo_Click">Activos</asp:LinkButton>
                <asp:LinkButton ID="btnInactivo" runat="server" CssClass="tab active" OnClick="btnInactivo_Click">Inactivos</asp:LinkButton>
        </div>

    <asp:GridView runat="server" ID="dgvTransportistas" DataKeyNames="idTransportista" OnSelectedIndexChanged="dgvTransportistas_SelectedIndexChanged" OnPageIndexChanging="dgvTransportistas_PageIndexChanging" AllowPaging="true" PageSize="5" Class="transportistas-grid table-bordered text-center align-middle" AutoGenerateColumns="false">
    <Columns>
    <asp:BoundField HeaderText="ID Transportista" DataField="IdTransportista" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
    <asp:BoundField HeaderText="Nombre" DataField="Nombre"   />
        <asp:BoundField HeaderText="Apellido" DataField="Apellido"   />
        <asp:BoundField HeaderText="Licencia" DataField="Licencia"   />
    <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
    <asp:BoundField HeaderText="Horario Inicio" DataField="HoraInicio" />
        <asp:BoundField HeaderText="Horario Fin" DataField="HoraFin" />
        <asp:CommandField ShowSelectButton="true" SelectText="Detalles" HeaderText="Accion" />
     </Columns>
</asp:GridView>

</asp:Content>