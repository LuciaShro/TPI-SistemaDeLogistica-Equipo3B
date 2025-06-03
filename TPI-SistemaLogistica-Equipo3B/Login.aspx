<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.Login" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/Login.css" />
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="login-container">
            <div class="login-form">
                <h1>Iniciar Sesión</h1>

                <label for="email">E-mail</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="input-text" placeholder="example@gmail.com" />

                <label for="password">Password</label>
                <div class="password-container">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="input-text" TextMode="Password" Text="@!/*%" />
                </div>

                <div class="options">
                    <label><input type="checkbox" /> Remember me</label>
                    <a href="#">Forgot Password?</a>
                </div>

                <asp:Button ID="btnLogin" runat="server" Text="ACCEDER" CssClass="login-button" />

                <p class="register-link">¿No tenés cuenta? <a href="#">Regístrate gratis</a></p>
            </div>

            <div class="login-image">
                <img src="Imagenes/Login.png" alt="Login Illustration" />
            </div>
        </div>
</asp:Content>

