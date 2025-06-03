<%@ Page Title="" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="CargarOrden.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.CargarOrden" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Content/CargarOrden.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <h1>Cargar orden</h1>

    <div class="grid-container">

        <!-- ORIGEN -->
        <div class="card">
            <h2>Origen del Envío (¿Desde Dónde?)</h2>
            <p>
                <strong>Nombre y Apellido / Empresa:</strong><br />
                <asp:TextBox ID="txtNombreOrigen" runat="server" />
            </p>
            <p>
                <strong>Teléfono Celular:</strong><br />
                <asp:TextBox ID="txtTelefonoOrigen" runat="server" />
            </p>
            <p>
                <strong>Email:</strong><br />
                <asp:TextBox ID="txtEmailOrigen" runat="server" />
            </p>
            <p>
                <strong>Dirección:</strong><br />
                <asp:TextBox ID="txtDireccionOrigen" runat="server" />
            </p>
            <p>
                <strong>Piso / Depto / Manzana / Lote:</strong><br />
                <asp:TextBox ID="txtPisoOrigen" runat="server" />
            </p>
            <p>
                <strong>Info Adicional:</strong><br />
                <asp:TextBox ID="txtInfoOrigen" runat="server" TextMode="MultiLine" Rows="3" />
            </p>
        </div>

        <!-- DESTINO -->
        <div class="card">
            <h2>Destino del Envío (¿Hasta Dónde?)</h2>
            <p>
                <strong>Nombre y Apellido:</strong><br />
                <asp:TextBox ID="txtNombreDestino" runat="server" />
            </p>
            <p>
                <strong>Teléfono Celular:</strong><br />
                <asp:TextBox ID="txtTelefonoDestino" runat="server" />
            </p>
            <p>
                <strong>Email:</strong><br />
                <asp:TextBox ID="txtEmailDestino" runat="server" />
            </p>
            <p>
                <strong>Dirección:</strong><br />
                <asp:TextBox ID="txtDireccionDestino" runat="server" />
            </p>
            <p>
                <strong>Piso / Depto / Manzana / Lote:</strong><br />
                <asp:TextBox ID="txtPisoDestino" runat="server" />
            </p>
            <p>
                <strong>Info Adicional:</strong><br />
                <asp:TextBox ID="txtInfoDestino" runat="server" TextMode="MultiLine" Rows="3" />
            </p>
        </div>

        <!-- PAQUETE -->
        <div class="card full">
            <h2>Datos del Paquete</h2>
            <p>
                <strong>Largo (cm):</strong><br />
                <asp:TextBox ID="txtLargo" runat="server" />
            </p>
            <p>
                <strong>Ancho (cm):</strong><br />
                <asp:TextBox ID="txtAncho" runat="server" />
            </p>
            <p>
                <strong>Alto (cm):</strong><br />
                <asp:TextBox ID="txtAlto" runat="server" />
            </p>
            <p>
                <strong>Peso Estimado (kg):</strong><br />
                <asp:TextBox ID="txtPeso" runat="server" />
            </p>
            <p>
                <strong>Valor Declarado:</strong><br />
                <asp:TextBox ID="txtValor" runat="server" />
            </p>
        </div>

        <div class="center-button">
            <asp:Button ID="btnCotizar" runat="server" Text="COTIZAR ENVÍO" CssClass="btn-principal" />
        </div>
    </div>

    <!-- ORDER ITEMS -->
    <div class="card full">
        <h2>Order items</h2>
        <asp:GridView ID="gvItems" runat="server" AutoGenerateColumns="false" CssClass="order-table">
            <Columns>
                <asp:BoundField HeaderText="DESCRIPCIÓN" DataField="Descripcion" />
                <asp:BoundField HeaderText="CATEGORÍA" DataField="Categoria" />
                <asp:BoundField HeaderText="PRECIO" DataField="Precio" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
    </div>

    <div class="total">
        <strong>TOTAL</strong>
        <asp:Label ID="lblTotal" runat="server" CssClass="total-valor" />
    </div>

    <div class="center-button">
        <asp:Button ID="btnCargar" runat="server" Text="CARGAR ORDEN" CssClass="btn-principal" />
    </div>
</asp:Content>
