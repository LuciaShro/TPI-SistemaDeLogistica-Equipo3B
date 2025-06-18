<%@ Page Title="" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="Ordenes.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.Ordenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/Ordenes.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <div class="ordenes-container">
        <div class="ordenes-header">
            <h1>Ordenes</h1>
            <asp:Button ID="btnAñadir" runat="server" Text="＋ Añadir" CssClass="btn-añadir" OnClick="btnAñadir_Click" />
            </button>
        </div>

        <div class="ordenes-tabs">
            <a href="#" class="tab active">Todos</a>
            <a href="#" class="tab">Canceladas</a>
            <a href="#" class="tab">Completados</a>
            <a href="#" class="tab">Pendientes</a>
            <a href="#" class="tab">Rechazados</a>
        </div>

        <div class="ordenes-search">
            <asp:TextBox runat="server" ID="filtro" AutoPostBack="true" placeholder="Buscar..." OnTextChanged="filtro_TextChanged" />
            <span class="search-icon">🔍</span>
        </div>
    </div>

    <asp:GridView runat="server" ID="dgvOrdenes" DataKeyNames="idOrdenEnvio" OnSelectedIndexChanged="dgvOrdenes_SelectedIndexChanged"  Class="ordenes-grid table-bordered text-center align-middle" AutoGenerateColumns="false">
        <Columns>
        <asp:BoundField HeaderText="ID Orden" DataField="idOrdenEnvio" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
        <asp:BoundField HeaderText="Cliente" DataField="cliente.Apellido"   />
        <asp:BoundField HeaderText="Transportista" DataField="idTransportistaAsignado"  />
        <asp:BoundField HeaderText="Estado" DataField="estado.DescripcionEstado" />
        <asp:BoundField HeaderText="Fecha Creación" DataField="FechaCreacion" />
        <asp:BoundField HeaderText="Fecha Envío" DataField="FechaEnvio" />
        <asp:BoundField HeaderText="Fecha Estimada" DataField="FechaEstimadaLlegada" />
        <asp:BoundField HeaderText="Fecha Llegada" DataField="FechaDeLlegada" />
            <asp:CommandField ShowSelectButton="true" SelectText="Detalles" HeaderText="Accion" />
         </Columns>
    </asp:GridView>
</asp:Content>
