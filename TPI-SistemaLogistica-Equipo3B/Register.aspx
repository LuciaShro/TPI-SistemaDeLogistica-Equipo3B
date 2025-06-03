<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro | FlashShip</title>
    
    
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />

    
    <link href="Content/Register.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="form-container">
                <div class="text-center form-title">Regístrate</div>

                <div class="mb-3">
                    <label class="form-label">Nombre de usuario</label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="example@gmail.com" />
                </div>

                <div class="mb-3">
                    <label class="form-label">E-mail</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="example@gmail.com" TextMode="Email" />
                </div>

                <div class="mb-3 form-group">
                    <label class="form-label">Contraseña</label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
                </div>

                <div class="mb-3 form-group">
                    <label class="form-label">Confirmar contraseña</label>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" />
                </div>

                <asp:Button ID="btnRegister" runat="server" Text="COMENZAR" CssClass="btn btn-purple w-100 mb-3" />

                <div class="text-center">o continúa con</div>
                <div class="text-center mt-2 social-btns">
                    <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/google/google-original.svg" alt="Google" />
                    <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/github/github-original.svg" alt="GitHub" />
                    <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/facebook/facebook-original.svg" alt="Facebook" />
                </div>

                <div class="text-center mt-3">
                    ¿Ya estás registrado?
                    <a href="Login.aspx" class="link-login">Inicia sesión</a>
                </div>
            </div>
        </div>
    </form>

   
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>

