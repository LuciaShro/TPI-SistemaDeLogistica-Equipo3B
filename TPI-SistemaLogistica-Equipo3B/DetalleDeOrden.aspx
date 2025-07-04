<%@ Page Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="DetalleDeOrden.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.DetalleDeOrden" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Content/CargarOrden.css" rel="stylesheet" />
    <link href="Content/DetalleDeOrden.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <div class="cards-grid">
        <div class="card">
            <h2><strong>Orden #<asp:Label ID="txtIdOrden" runat="server" /></strong></h2>

            <!-- DESTINO -->
            <h4>Transportista</h4>
            <% if (validacionUsuario(Dominio.Usuario.TipoUsuario.admin))
                { %>
            <label>Transportista:</label>
            <div class="form-group">
                <div class="col">
                    <asp:DropDownList runat="server" ID="dllTransportista" CssClass="form-select">
                    </asp:DropDownList>
                </div>
            </div>
            <% }
                else if (validacionUsuario(Dominio.Usuario.TipoUsuario.empleado))
                { %>
            <div class="form-group">
                <asp:TextBox ID="txtTransportista" runat="server" CssClass="form-control" Enabled="false" />
            </div>
            <% } %>
            <div class="form-group">
                <label>Vehiculo asignado:</label>
                <asp:TextBox ID="txtVehiculo" runat="server" CssClass="form-control" Enabled="false" />
            </div>
            <!-- DESTINO -->
            <h4>Ruta</h4>
            <div class="form-group">
                <label>Punto Partida:</label>
                <asp:TextBox ID="TxtPuntoPartida" runat="server" CssClass="form-control" Enabled="false" />
            </div>
            <div class="form-group">
                <label>Punto Destino:</label>
                <asp:TextBox ID="TxtPuntoDestino" runat="server" CssClass="form-control" Enabled="false" />
            </div>


            <h4>Datos del Cliente</h4>
            <div class="form-group">
                <label>Nombre:</label>
                <asp:TextBox ID="txtNombreOrigen" runat="server" CssClass="form-control" Enabled="false" />
            </div>
            <div class="form-group">
                <label>CUIL:</label>
                <asp:TextBox ID="txtCUILOrigen" runat="server" CssClass="form-control" Enabled="false" />
            </div>
            <div class="form-group">
                <label>Email:</label>
                <asp:TextBox ID="txtEmailOrigen" runat="server" CssClass="form-control" Enabled="false" />
            </div>
            <div class="form-group">
                <label>Teléfono:</label>
                <asp:TextBox ID="txtTelefonoOrigen" runat="server" CssClass="form-control" Enabled="false" />
            </div>
        </div>

        <!-- DESTINO -->
        <div class="card">
            <h2><strong>Destinatario</strong></h2>
            <div class="form-group">
                <label>Nombre:</label>
                <asp:TextBox ID="txtNombreDestino" runat="server" CssClass="form-control" Enabled="false" />
            </div>
            <div class="form-group">
                <label>CUIL:</label>
                <asp:TextBox ID="txtCUILDestino" runat="server" CssClass="form-control" Enabled="false" />
            </div>
            <div class="form-group">
                <label>Email:</label>
                <asp:TextBox ID="txtEmailDestino" runat="server" CssClass="form-control" Enabled="false" />
            </div>
            <div class="form-group">
                <label>Teléfono:</label>
                <asp:TextBox ID="txtTelefonoDestino" runat="server" CssClass="form-control" Enabled="false" />
            </div>
            <div class="form-group">
                <label>Direccion:</label>
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" Enabled="false" />
            </div>
            <div class="form-group">
                <label>Piso:</label>
                <asp:TextBox ID="txtPiso" runat="server" CssClass="form-control" Enabled="false" />
            </div>
            <div class="form-group">
                <label>Ciudad:</label>
                <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" Enabled="false" />
            </div>
            <div class="form-group">
                <label>Provincia:</label>
                <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control" Enabled="false" />
            </div>
            <div class="form-group">
                <label>Codigo Postal:</label>
                <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control" Enabled="false" />
            </div>

        </div>

        <!-- PAQUETE -->
        <div class="card">
            <h2><strong>Paquete</strong></h2>
            <div class="form-group">
                <label>Largo:</label>
                <asp:TextBox ID="txtLargo" runat="server" CssClass="form-control" Enabled="false" />
            </div>
            <div class="form-group">
                <label>Ancho:</label>
                <asp:TextBox ID="txtAncho" runat="server" CssClass="form-control" Enabled="false" />
            </div>
            <div class="form-group">
                <label>Alto:</label>
                <asp:TextBox ID="txtAlto" runat="server" CssClass="form-control" Enabled="false" />
            </div>
            <div class="form-group">
                <label>Peso Estimado:</label>
                <asp:TextBox ID="txtPeso" runat="server" CssClass="form-control" Enabled="false" />
            </div>
            <div class="form-group">
                <label>Valor Declarado:</label>
                <asp:TextBox ID="txtValor" runat="server" CssClass="form-control" Enabled="false" />
            </div>
        </div>

        <div class="card w-100">
            <h2><strong>Estado orden</strong></h2>
            <h4>Estado Envio</h4>
            <% if (validacionUsuario(Dominio.Usuario.TipoUsuario.admin))
                { %>
            <div class="form-group">
                <div class="col">
                    <asp:DropDownList runat="server" ID="dllEstado" CssClass="form-select">
                    </asp:DropDownList>
                </div>
            </div>
            <%}
                else if (validacionUsuario(Dominio.Usuario.TipoUsuario.empleado))
                { %>
            <div class="form-group">
                <asp:TextBox ID="TxtEstadoOrden" runat="server" CssClass="form-control" Enabled="false" />
            </div>
            <%} %>
            <h4>Estado Vehiculo</h4>
            <div class="form-group">
                <asp:TextBox ID="txtEstadoVehiculo" runat="server" CssClass="form-control" Enabled="false" />
            </div>
            <% if (validacionUsuario(Dominio.Usuario.TipoUsuario.admin))
                { %>
            <div class="card p-5 w-80 mx-auto mt-3">
                <p>Modificar datos.</p>
                <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-outline-primary" Text="Modificar orden" OnClick="btnModificar_Click" />
            </div>

            <div class="card p-5 w-80 mx-auto mt-3">
                <p>Eliminar datos.</p>
                <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-outline-danger" Text="Eliminar orden" OnClick="btnEliminar_Click" />
            </div>
            <%} %>
        </div>

    </div>




    <div class="card p-5 w-50 mx-auto mt-3">
        <p>Actualizar estado de entrega:</p>
        
        <asp:Button ID="btnEntregado" runat="server" CssClass="btn btn-success mx-2 px-4 py-2" Text="Envío Entregado" OnClick="btnEntregado_Click"/>
        <br />
        <asp:Button ID="btnDemorado" runat="server" CssClass="btn btn-warning mx-2 px-4 py-2" Text="Demorado" OnClick="btnDemorado_Click" />
    </div>
    <div class="card p-5 w-50 mx-auto mt-3">
        <p>Actualizar estado del vehículo:</p>
        <asp:HiddenField ID="hdnIdVehiculo" runat="server" />
           <div class="col">
       <asp:DropDownList runat="server" ID="dllEstadoVehiculo" CssClass="form-select">
       </asp:DropDownList>
               <asp:TextBox ID="ComentarioEstadoVehiculo" runat="server" TextMode="MultiLine" CssClass="form-control mt-2"></asp:TextBox>
            </div>
        <asp:Button ID="btnActualizarVehiculo" runat="server" CssClass="btn btn-info mt-2" Text="Actualizar" OnClick="btnActualizarVehiculo_Click" />
    </div>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="Alerts/Alerts.js"></script>
</asp:Content>

