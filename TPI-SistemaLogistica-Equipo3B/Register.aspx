<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.Register" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/Register.css" />
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row align-items-center min-vh-100">
            <!-- formulario -->
            <div class="col-md-6">
                <div class="form-container mx-auto">
                    <h2 class="form-title">Regístrate</h2>

                    <div class="mb-3">
                        <label for="txtUsername" class="form-label">Nombre de usuario</label>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" Placeholder="example@gmail.com"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label for="txtEmail" class="form-label">E-mail</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="example@gmail.com"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label for="txtPassword" class="form-label">Contraseña</label>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" Placeholder="@#*%"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label for="txtConfirmPassword" class="form-label">Confirmar contraseña</label>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control" Placeholder="@#*%"></asp:TextBox>
                    </div>

                    <asp:Button ID="btnRegister" runat="server" Text="COMENZAR" CssClass="btn btn-purple w-100" />

                    <div class="text-center mt-3">
                        <small>¿Ya estás registrado? <a href="Login.aspx" class="link-login">Inicia Sesión</a></small>
                    </div>
                </div>
            </div>

            <!-- imagen -->
            <div class="col-md-6 d-none d-md-block text-center">
                <img src="Imagenes/Registro.png" alt="Registro" class="img-fluid" style="max-height: 500px;" />
            </div>
        </div>
    </div>
</asp:Content>


