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
            <asp:TextBox runat="server" ID="txtFiltro" AutoPostBack="true" placeholder="Buscar..." OnTextChanged="filtro_TextChanged" />
            <span class="search-icon">🔍</span>
        </div>
        <asp:CheckBox Text="FiltroAvanzado" CssClass="" ID="chkAvanzado" runat="server" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" />
        <% if (FiltroAvanzado) { %>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Campo" ID="dllcampo" runat="server" />
                <asp:DropDownList runat="server" CssClass="form-control">
                    <asp:ListItem Text="Cliente" />
                    <asp:ListItem Text="Transportista" />
                    <asp:ListItem Text="Fecha" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Criterio" runat="server" />
                <asp:DropDownList ID="ddlCriterio" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
    <div class="mb-3">
        <asp:Label Text="Filtro" runat="server" />
        <asp:Textbox ID="txtFiltroAvanzado" runat="server" CssClass="form-control">
        </asp:Textbox>
    </div>
</div>
        <div class="col-3">
    <div class="mb-3">
        <asp:Label Text="Estado" runat="server" />
        <asp:DropDownList runat="server" ID="dllEstado" CssClass="form-control">
    <asp:ListItem Text="En camino" />
    <asp:ListItem Text="Pendiente" />
    <asp:ListItem Text="Retraso" />
</asp:DropDownList>
    </div>
</div>
    </div>
        <div class="row">
            <div class="col-3">
    <div class="mb-3">
        <asp:button Text="Buscar" runat="server" cssClass="btn btn-primary" ID="btnBuscar"/>
    </div>
</div>
        </div>
<% } %>
    </div>

    <asp:GridView runat="server" ID="dgvOrdenes" DataKeyNames="idOrdenEnvio" OnSelectedIndexChanged="dgvOrdenes_SelectedIndexChanged" OnPageIndexChanging="dgvOrdenes_PageIndexChanging" AllowPaging="true" PageSize="5" Class="ordenes-grid table-bordered text-center align-middle" AutoGenerateColumns="false">
        <Columns>
        <asp:BoundField HeaderText="ID Orden" DataField="idOrdenEnvio" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
        <asp:BoundField HeaderText="Cliente" DataField="cliente.Apellido"   />
        <asp:BoundField HeaderText="Transportista" DataField="transportista.Nombre"  />
        <asp:BoundField HeaderText="Estado" DataField="estado.DescripcionEstado" />
        <asp:BoundField HeaderText="Fecha Creación" DataField="FechaCreacion" />
        <asp:BoundField HeaderText="Fecha Envío" DataField="FechaEnvio" />
        <asp:BoundField HeaderText="Fecha Estimada" DataField="FechaEstimadaLlegada" />
        <asp:BoundField HeaderText="Fecha Llegada" DataField="FechaDeLlegada" />
            <asp:CommandField ShowSelectButton="true" SelectText="Detalles" HeaderText="Accion" />
         </Columns>
    </asp:GridView>
</asp:Content>
