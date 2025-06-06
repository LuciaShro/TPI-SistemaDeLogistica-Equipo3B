﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="CargarOrden.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.CargarOrden" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Content/CargarOrden.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <h1>Cargar orden</h1>

    <div class="card">
        <h2>Origen del Envío (¿Desde Dónde?)</h2>

        <div class="form-group">
            <label for="txtNombreOrigen">Nombre y Apellido / Empresa:</label>
            <asp:TextBox ID="txtNombreOrigen" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtTelefonoOrigen">Teléfono Celular:</label>
            <asp:TextBox ID="txtTelefonoOrigen" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtEmailOrigen">Email:</label>
            <asp:TextBox ID="txtEmailOrigen" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtDireccionOrigen">Calle:</label>
            <asp:TextBox ID="txtDireccionOrigen" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtCalleOrigen">Número:</label>
            <asp:TextBox ID="txtCalleOrigen" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtCPOrigen">Código Postal:</label>
            <asp:TextBox ID="txtCPOrigen" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtLocalidadOrigen">Ciudad / Localidad / Partido:</label>
            <asp:TextBox ID="txtLocalidadOrigen" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtProvinciaOrigen">Provincia:</label>
            <asp:TextBox ID="txtProvinciaOrigen" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtPisoOrigen">Piso / Depto / Manzana / Lote:</label>
            <asp:TextBox ID="txtPisoOrigen" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtInfoOrigen">Info Adicional:</label>
            <asp:TextBox ID="txtInfoOrigen" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" />
        </div>
    </div>


    <!-- DESTINO -->
    <div class="card">
        <h2>Destino del Envío (¿Hasta Dónde?)</h2>

        <div class="form-group">
            <label for="txtNombreDestino">Nombre y Apellido:</label>
            <asp:TextBox ID="txtNombreDestino" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtTelefonoDestino">Teléfono Celular:</label>
            <asp:TextBox ID="txtTelefonoDestino" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtEmailDestino">Email:</label>
            <asp:TextBox ID="txtEmailDestino" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtCalleDestino">Calle:</label>
            <asp:TextBox ID="txtCalleDestino" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtNumeroDestino">Número:</label>
            <asp:TextBox ID="txtNumeroDestino" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtCPDestino">Código Postal:</label>
            <asp:TextBox ID="txtCPDestino" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtLocalidadDestino">Ciudad / Localidad / Partido:</label>
            <asp:TextBox ID="txtLocalidadDestino" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtProvinciaDesino">Provincia:</label>
            <asp:TextBox ID="txtProvinciaDesino" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtPisoDestino">Piso / Depto / Manzana / Lote:</label>
            <asp:TextBox ID="txtPisoDestino" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtInfoDestino">Info Adicional:</label>
            <asp:TextBox ID="txtInfoDestino" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" />
        </div>
    </div>


    <!-- PAQUETE -->
    <div class="card full">
        <h2>Datos del Paquete</h2>

        <div class="form-group">
            <label for="txtLargo">Largo (cm):</label>
            <asp:TextBox ID="txtLargo" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtAncho">Ancho (cm):</label>
            <asp:TextBox ID="txtAncho" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtAlto">Alto (cm):</label>
            <asp:TextBox ID="txtAlto" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtPeso">Peso Estimado (kg):</label>
            <asp:TextBox ID="txtPeso" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtValor">Valor Declarado:</label>
            <asp:TextBox ID="txtValor" runat="server" CssClass="form-control" />
        </div>
    </div>

    <div class="center-button">
        <asp:Button ID="btnCotizar" runat="server" Text="COTIZAR ENVÍO" CssClass="btn-principal" />
    </div>

    <!-- ORDER ITEMS -->
    <div class="card full">
        <h2>Items de la Orden</h2>
        <asp:GridView ID="gvItems" runat="server" AutoGenerateColumns="false" CssClass="order-table">
            <Columns>
                <asp:BoundField HeaderText="DESCRIPCIÓN" DataField="Descripcion" />
                <asp:BoundField HeaderText="CATEGORÍA" DataField="Categoria" />
                <asp:BoundField HeaderText="PRECIO" DataField="Precio" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
    </div>

    <div class="total">
        <strong>TOTAL:</strong>
        <asp:Label ID="lblTotal" runat="server" CssClass="total-valor" />
    </div>

    <div class="center-button">
        <asp:Button ID="btnCargar" runat="server" Text="CARGAR ORDEN" CssClass="btn-principal" />
    </div>

</asp:Content>
