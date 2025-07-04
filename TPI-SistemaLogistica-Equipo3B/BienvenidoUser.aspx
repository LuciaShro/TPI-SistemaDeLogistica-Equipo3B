<%@ Page Title="" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="BienvenidoUser.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.BienvenidoUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="/Content/BienvenidoUser.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <div class="gracias-contenedor">
        <div class="gracias-titulo">
            ¡Bienvenido/a!
        </div>
        <div class="gracias-subtitulo">Nos alegra verte nuevamente!</div>
        <div class="gracias-texto">
            Desde aca podés  gestionar tus envíos y consultar sus estados 😊
        </div>
    </div>
</asp:Content>
