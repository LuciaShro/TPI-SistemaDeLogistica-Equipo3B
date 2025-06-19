<%@ Page Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="DetalleDeOrden.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.DetalleDeOrden" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Content/CargarOrden.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <div class="card full">
       <h2><strong>Orden</strong></h2>

        <!-- DESTINO -->
        <h4>Ruta</h4>
        <div class="form-group">
        <label>Punto Partida:</label>
        <asp:TextBox ID="TxtPuntoPartida" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
        <label>Punto Destino:</label>
        <asp:TextBox ID="TxtPuntoDestino" runat="server" CssClass="form-control" />
        </div>

        
        <h4>Datos del Cliente</h4>
        <div class="form-group">
            <label>Nombre:</label>
            <asp:TextBox ID="txtNombreOrigen" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label>Apellido:</label>
            <asp:TextBox ID="txtApellidoOrigen" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label>CUIL:</label>
            <asp:TextBox ID="txtCUILOrigen" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label>Email:</label>
            <asp:TextBox ID="txtEmailOrigen" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label>Teléfono:</label>
            <asp:TextBox ID="txtTelefonoOrigen" runat="server" CssClass="form-control" />
        </div>

        <!-- DESTINO -->
        <h4>Destinatario</h4>
        <div class="form-group">
            <label>Nombre:</label>
            <asp:TextBox ID="txtNombreDestino" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label>Apellido:</label>
            <asp:TextBox ID="txtApellidoDestino" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label>CUIL:</label>
            <asp:TextBox ID="txtCUILDestino" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label>Email:</label>
            <asp:TextBox ID="txtEmailDestino" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label>Teléfono:</label>
            <asp:TextBox ID="txtTelefonoDestino" runat="server" CssClass="form-control" />
        </div>

        <!-- PAQUETE -->
        <h4>Paquete</h4>
        <div class="form-group">
            <label>Largo:</label>
            <asp:TextBox ID="txtLargo" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label>Ancho:</label>
            <asp:TextBox ID="txtAncho" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label>Alto:</label>
            <asp:TextBox ID="txtAlto" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label>Peso Estimado:</label>
            <asp:TextBox ID="txtPeso" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label>Valor Declarado:</label>
            <asp:TextBox ID="txtValor" runat="server" CssClass="form-control" />
        </div>

        <!-- PAQUETE -->
        <h4>Estado Envio</h4>
           <div class="col">
               <asp:DropDownList runat="server" ID="dllEstado" CssClass="form-select">
               </asp:DropDownList>
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

    </div>
    <div class="card p-5 w-50 mx-auto mt-3">
    <p>Modificar datos. Esta opción es irreversible.</p>
    <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-outline-primary" Text="Modificar orden" OnClick="btnModificar_Click" />
</div>

<div class="card p-5 w-50 mx-auto mt-3">
    <p>Eliminar cuenta y todos sus datos. Esta opción es irreversible.</p>
    <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-outline-danger" Text="Eliminar orden" OnClick="btnEliminar_Click" />
</div>

</asp:Content>

