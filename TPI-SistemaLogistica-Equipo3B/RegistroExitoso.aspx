<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroExitoso.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.RegistroExitoso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <link rel="stylesheet" type="text/css" href="Content/RegistroExitoso.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="registro-exitoso-container">
    <div class="mensaje-exito">
        <h1>¡Registro exitoso! ✅</h1>
        <p>Ya sos parte de <strong>FlashShip</strong>. 🎉</p>
        <a href="Login.aspx" class="btn-volver">Iniciar sesión</a>
    </div>
</div>
</asp:Content>
