<%@ Page Title="" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="DetalleVenta.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.DetalleVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/DetalleVenta.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <div class="container p-4">

        <!-- Encabezado -->
        <h2>Venta #<asp:Label ID="lblVentaID" runat="server" /></h2>
        <div class="d-flex gap-2 mb-4">
            <span class="estado estado-proceso">🧾 Pago en proceso</span>
            <span class="estado estado-proceso">📦 En proceso</span>
        </div>

        <!-- Producto y precio -->
        <div class="card mb-4">
            <div class="card-header"><strong>📦 Precio Envio</strong></div>
            <div class="card-body d-flex justify-content-between">
                <div class="d-flex">
                    <div>
                        <p class="mb-1">
                            <strong>
                                <asp:Label ID="lblCategoria" runat="server" />
                            </strong>
                        </p>
                        <p class="mb-1">
                            Cantidad:
                            <asp:Label ID="lblCantidad" runat="server" />
                        </p>
                        <p class="mb-1">
                            Valor declardo:
                            <asp:Label ID="lblValorDeclarado" runat="server" />
                        </p>
                        <p class="mb-1">
                            Peso:
                            <asp:Label ID="lblPeso" runat="server" />
                        </p>
                        <p class="mb-1">
                            Alto:
                            <asp:Label ID="lblAlto" runat="server" />
                        </p>
                        <p class="mb-1">
                            Ancho:
                            <asp:Label ID="lblAncho" runat="server" />
                        </p>
                        <p class="mb-1">
                            Largo:
                            <asp:Label ID="lblLargo" runat="server" />
                        </p>
                    </div>
                </div>
                <%--<div class="text-end">
                    <p><strong>$<asp:Label ID="lblPrecioEnvio" runat="server" /></strong></p>
                </div>--%>
            </div>
            <div class="card-footer text-end">
                <strong>Subtotal envío:</strong> $<asp:Label ID="lblSubtotal" runat="server" />
            </div>
        </div>

        <!-- Cliente y datos -->
        <div class="row mb-4">
            <div class="col-md-6">
                <div class="card h-100">
                    <div class="card-header"><strong>👤 Cliente</strong></div>
                    <div class="card-body">
                        <p>
                            <strong>Nombre:</strong>
                            <asp:Label ID="lblNombreCliente" runat="server" />
                        </p>
                        <p>
                            <strong>CUIL:</strong>
                            <asp:Label ID="lblCUILCliente" runat="server" />
                        </p>
                        <hr />
                        <p>
                            <strong>Email:</strong>
                            <asp:Label ID="lblEmailCliente" runat="server" />
                        </p>
                        <p>
                            <strong>Telefono:</strong>
                            <asp:Label ID="lblTelefonoCliente" runat="server" />
                        </p>
                        <hr />
                        <p>
                            <strong>Calle:</strong>
                            <asp:Label ID="lblCalleCliente" runat="server" />
                        </p>
                        <p>
                            <strong>Numero:</strong>
                            <asp:Label ID="lblNumeroCliente" runat="server" />
                        </p>
                        <p>
                            <strong>Ciudad:</strong>
                            <asp:Label ID="lblCiudadCliente" runat="server" />
                        </p>
                        <p>
                            <strong>Provincia:</strong>
                            <asp:Label ID="lblProvinciaCliente" runat="server" />
                        </p>
                        <p>
                            <strong>Código postal:</strong>
                            <asp:Label ID="lblCPCliente" runat="server" />
                        </p>
                    </div>
                </div>
            </div>

            <!-- Forma de pago -->
            <div class="col-md-6">
                <div class="card h-100">
                    <div class="card-header"><strong>💳 Forma de pago</strong></div>
                    <div class="card-body">
                        <p><span class="estado estado-proceso">🧾 Pago en proceso</span></p>
                        <p>
                            <strong>Estado:</strong>
                            <asp:Label ID="lblEstadoPago" runat="server" />
                        </p>
                        <p>
                            <strong>Método:</strong>
                            <asp:Label ID="lblMetodoPago" runat="server" />
                        </p>
                        <hr />
                        <p>
                            <strong>Costo de envío:</strong>
                            <asp:Label ID="lblCostoEnvio" runat="server" />
                        </p>
                        <hr />
                        <p class="fw-bold fs-5">Total: $<asp:Label ID="lblTotalFinal" runat="server" /></p>
                    </div>
                </div>
            </div>
        </div>

        <!-- Forma de entrega -->
        <div class="card mb-4">
            <div class="card-header"><strong>🚚 Forma de entrega</strong></div>
            <div class="card-body">
                <p><span class="estado estado-proceso">📦 En proceso</span></p>
                <p>
                    <strong>Estado de envío:</strong>
                    <asp:Label ID="lblEstadoEnvio" runat="server" />
                </p>
                <hr />
                <h5>Datos del destinatario:</h5>
                <p>
                    <strong>Nombre:</strong>
                    <asp:Label ID="lblNombre" runat="server" />
                </p>
                <p>
                    <strong>CUIL:</strong>
                    <asp:Label ID="lblCuil" runat="server" />
                </p>
                <hr />
                <p>
                    <strong>Email:</strong>
                    <asp:Label ID="lblEmailDestino" runat="server" />
                </p>
                <p>
                    <strong>Telefono:</strong>
                    <asp:Label ID="lblTelefonoDestino" runat="server" />
                </p>
                <hr />
                <p>
                    <strong>Calle:</strong>
                    <asp:Label ID="lblCalleDestino" runat="server" />
                </p>
                <p>
                    <strong>Numero:</strong>
                    <asp:Label ID="lblNumeroDestino" runat="server" />
                </p>
                <p>
                    <strong>Ciudad:</strong>
                    <asp:Label ID="lblCiudadDestino" runat="server" />
                </p>
                <p>
                    <strong>Provincia:</strong>
                    <asp:Label ID="lblProvinciaDestino" runat="server" />
                </p>
                <p>
                    <strong>Código postal:</strong>
                    <asp:Label ID="lblCPDestino" runat="server" />
                </p>
            </div>
        </div>

    </div>

</asp:Content>
