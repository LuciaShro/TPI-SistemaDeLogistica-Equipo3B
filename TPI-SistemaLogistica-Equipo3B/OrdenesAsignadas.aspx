<%@ Page Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="OrdenesAsignadas.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.OrdenesAsignadas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/Ordenes.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <div class="ordenes-container">
        <div class="ordenes-header">
            <h1>Ordenes Asignadas</h1>
        </div>

        <div class="ordenes-tabs">
            <a href="#" class="tab active">Todos</a>
            <a href="#" class="tab">Completados</a>
            <a href="#" class="tab">Retrasadas</a>
            <a href="#" class="tab">Pendientes</a>
        </div>

        <asp:Button ID="btnComenzarViaje" runat="server" CssClass="btn btn-primary mx-2 px-4 py-2" Text="Comenzar viaje" OnClick="btnComenzarViaje_Click" />

        <div class="ordenes-search">
            <input type="text" placeholder="Buscar..." />
            <span class="search-icon">🔍</span>
        </div>
    </div>

        <asp:GridView runat="server" ID="dgvOrdenesAsignadas" DataKeyNames="idOrdenEnvio" OnSelectedIndexChanged="dgvOrdenesAsignadas_SelectedIndexChanged" OnPageIndexChanging="dgvOrdenesAsignadas_PageIndexChanging" AllowPaging="true" PageSize="5" Class="ordenes-grid table-bordered text-center align-middle" AutoGenerateColumns="false">
        <Columns>
        <asp:BoundField HeaderText="ID Orden" DataField="idOrdenEnvio" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
        <asp:BoundField HeaderText="Destinatario" DataField="destinatario.Nombre"   />
        <asp:BoundField HeaderText="Estado" DataField="estado.DescripcionEstado" />
        <asp:BoundField HeaderText="Fecha Creación" DataField="FechaCreacion" />
        <asp:BoundField HeaderText="Fecha Envío" DataField="FechaEnvio" />
        <asp:BoundField HeaderText="Fecha Estimada" DataField="FechaEstimadaLlegada" />
        <asp:BoundField HeaderText="Fecha Llegada" DataField="FechaDeLlegada" />
            <asp:CommandField ShowSelectButton="true" SelectText="Detalles" HeaderText="Accion" />
         </Columns>
    </asp:GridView>

</asp:Content>

