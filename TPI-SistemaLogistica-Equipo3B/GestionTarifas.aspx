<%@ Page Title="" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="GestionTarifas.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.GestionTarifas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
    <link href="Content/GestionTarifas.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <h2 class="page-title">Gestión de Tarifas de Envíos</h2>
    <p class="page-subtitle">Define los precios por kilómetro según el tamaño del paquete.</p>

   
    <div id="Div1" runat="server" clientidmode="Static">
      
    </div>

    <table class="rates-table">
        <thead>
            <tr>
                <th>Categoría de Paquete</th>
                <th>Tarifa por KM (ARS)</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>Pequeño</td>
                <td>
                    <asp:TextBox ID="txtCategoriaPequeno" runat="server" Text="0.00" CssClass="rate-input" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnGuardarPequeno" runat="server" Text="Guardar" CssClass="rate-save-btn" OnClick="btnGuardarPequeno_Click" CommandArgument="pequeno" />
                </td>
            </tr>
            <tr>
                <td>Mediano</td>
                <td>
                    <asp:TextBox ID="txtCategoriaMediano" runat="server" Text="0.00" CssClass="rate-input" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnGuardarMediano" runat="server" Text="Guardar" CssClass="rate-save-btn" OnClick="btnGuardarMediano_Click" CommandArgument="mediano" />
                </td>
            </tr>
            <tr>
                <td>Grande</td>
                <td>
                    <asp:TextBox ID="txtCategoriaGrande" runat="server" Text="0.00" CssClass="rate-input" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnGuardarGrande" runat="server" Text="Guardar" CssClass="rate-save-btn" OnClick="btnGuardarGrande_Click" CommandArgument="grande" />
                </td>
            </tr>
        </tbody>
    </table>

    <div class="simulator-box">
        <h4>Simulador de Costos (Opcional)</h4>
        <div>
            <label for="<%= txtSimDistancia.ClientID %>">Distancia (KM):</label>
            <asp:TextBox ID="txtSimDistancia" runat="server" Text="10" CssClass="simulator-input" TextMode="Number"></asp:TextBox>
        </div>
        <div style="margin-top: 15px;">
            <label for="<%= ddlSimCategoria.ClientID %>">Categoría:</label>
            <asp:DropDownList ID="ddlSimCategoria" runat="server" CssClass="simulator-select">
                <asp:ListItem Text="Pequeño" Value="pequeno"></asp:ListItem>
                <asp:ListItem Text="Mediano" Value="mediano"></asp:ListItem>
                <asp:ListItem Text="Grande" Value="grande"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <strong>Costo Estimado: $ <span id="sim_costo" runat="server" clientidmode="Static">0.00</span> ARS</strong>
    </div>

    <%-- IMPORTANT: The original "Provincia" elements are removed/commented out here. --%>
    <%-- 
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
    --%>
</asp:Content>
