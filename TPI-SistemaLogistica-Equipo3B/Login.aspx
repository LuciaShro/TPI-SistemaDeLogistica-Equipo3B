<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.Contact" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="/Content/Login.css">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="login-container">
        <div class="login-form-section">
            <h1 class="login-title">Iniciar Sesión</h1>

            <div class="form-group">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-input" Placeholder="example@gmail.com" TextMode="Email" />
            </div>

            <div class="form-group">
                <label for="password">Password</label>
                <div class="password-input-wrapper">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-input" Placeholder="@@**%" TextMode="Password" />
                </div>
            </div>

            <div class="form-options">
                <label class="checkbox-container">
                    <input type="checkbox" id="rememberMe" />
                    <span class="checkmark"></span>
                    Recordarme
               
                </label>
                <a href="#" class="forgot-password">Olvidaste tu contraseña?</a>
            </div>

            <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary login-button" Text="ACCEDER"/>

            <p class="signup-text">¿No tienes cuenta? <a href="#" class="signup-link">Regístrate gratis</a></p>
        </div>

        <div class="login-illustration-section">
            <img src="~/Images/Login.png" alt="Login illustration" class="login-illustration">
        </div>
    </div>
</asp:Content>

