<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.Register" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/Register.css" />
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row align-items-center min-vh-100">
            
            <div class="col-md-6">
                <div class="form-container mx-auto">
                    <h2 class="form-title text-center">Regístrate</h2>

                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label for="txtNombre" class="form-label">Nombre</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                        </div>

                        <div class="col-md-6 mb-3">
                            <label for="txtApellido" class="form-label">Apellido</label>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
                        </div>

                        <div class="col-md-6 mb-3">
                            <label for="txtCuil" class="form-label">CUIL</label>
                            <asp:TextBox ID="txtCuil" runat="server" CssClass="form-control" />
                        </div>

                        <div class="col-md-6 mb-3">
                            <label for="txtTelefono" class="form-label">Teléfono</label>
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
                        </div>

                        <div class="col-md-6 mb-3">
                            <label for="txtUsername" class="form-label">Nombre de usuario</label>
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
                        </div>

                        <div class="col-md-6 mb-3">
                            <label for="txtEmail" class="form-label">E-mail</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                        </div>

                        <div class="col-md-6 mb-3">
                            <label for="txtCalle" class="form-label">Calle</label>
                            <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control" />
                        </div>

                        <div class="col-md-6 mb-3">
                            <label for="txtNumero" class="form-label">Número</label>
                            <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" />
                        </div>

                        <div class="col-md-6 mb-3">
                            <label for="txtPiso" class="form-label">Piso</label>
                            <asp:TextBox ID="txtPiso" runat="server" CssClass="form-control" />
                        </div>

                        <div class="col-md-6 mb-3">
                            <label for="txtCP" class="form-label">Código Postal</label>
                            <asp:TextBox ID="txtCP" runat="server" CssClass="form-control" />
                        </div>

                        <div class="col-md-6 mb-3">
                            <label for="txtProvincia" class="form-label">Provincia</label>
                            <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control" />
                        </div>

                        <div class="col-md-6 mb-3">
                            <label for="txtCiudad" class="form-label">Ciudad</label>
                            <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control"  />
                        </div>

                        <div class="col-md-6 mb-3">
                            <label for="txtPassword" class="form-label">Contraseña</label>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
                        </div>

                        <div class="col-md-6 mb-3">
                            <label for="txtConfirmPassword" class="form-label">Confirmar contraseña</label>
                            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control" />
                        </div>
                    </div>

                    <asp:Button ID="btnRegister" runat="server" Text="COMENZAR" CssClass="btn btn-purple w-100 mt-3" OnClick="btnRegister_Click" />
                    <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="text-danger mt-2 d-block"></asp:Label>
                    <div class="text-center mt-3">
                        <small>¿Ya estás registrado? <a href="Login.aspx" class="link-login">Inicia Sesión</a></small>
                    </div>
                </div>
            </div>

            
            <div class="col-md-6 d-none d-md-block text-center">
                <img src="Imagenes/Registro.png" alt="Registro" class="img-fluid" style="max-height: 500px;" />
            </div>
        </div>
    </div>
</asp:Content>




