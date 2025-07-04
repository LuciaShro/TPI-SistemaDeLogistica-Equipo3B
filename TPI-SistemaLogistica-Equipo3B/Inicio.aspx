<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.Inicio" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/Inicio.css" />
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="InicioContent" runat="server">
    <h1>¡👋 Hola!</h1>
    <div class="row row-cols-1 row-cols-md-2 g-5">
    <div class="col">
    <div class="card">
  <h5 class="card-header">Informe</h5>
  <div class="card-body">
    <h5 class="card-title">Resumen rutas mas utilizadas.</h5>
    <p class="card-text">Ultimos 7 dias.</p>
  </div>
        </div>
</div>
    <div class="col">
    <div class="card">
  <h5 class="card-header">Informe</h5>
  <div class="card-body">
    <h5 class="card-title">Envios activos</h5>
    <p class="card-text">Insertar Grafico aca.</p>  </div>
</div>
        </div>
        <div class="col">
    <div class="card">
  <h5 class="card-header">Informe</h5>
  <div class="card-body">
      <h5 class="card-title">Resumen Inventario</h5>
    <p class="card-text">Insertar Grafico aca.</p>  </div>
</div>
       </div>
        </div>
</asp:Content>

