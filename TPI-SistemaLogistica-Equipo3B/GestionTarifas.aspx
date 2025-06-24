<%@ Page Title="" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="GestionTarifas.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.GestionTarifas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <h2>Gestión de tarifas</h2>

    <div class="tabs">
        <div class="tab active">Provincia</div>
        <div class="tab">Paquetes</div>
    </div>

    <asp:Button ID="btnAgregarProvincia" runat="server" CssClass="add-btn" Text="+ Añadir provincia" />

    <asp:GridView ID="gvTarifas" runat="server" AutoGenerateColumns="False" CssClass="gridview">
        <Columns>
            <asp:BoundField DataField="Provincia" HeaderText="Provincia" />
            <asp:BoundField DataField="Localidad" HeaderText="Localidad" />
            <asp:BoundField DataField="PrecioBase" HeaderText="Precios base" />
            <asp:BoundField DataField="PrecioPorKm" HeaderText="Precio por km" />
            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <span class="status"><%# Eval("Estado") %></span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <span class="icon">✏️</span>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
