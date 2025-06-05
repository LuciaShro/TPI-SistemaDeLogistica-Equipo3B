<%@ Page Title="" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="Envios.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.Logistica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/Envios.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <!-- DASHBOARD DE LOGÍSTICA - VISUAL MODERNA -->
    <div class="dashboard">
        <!-- Encabezado -->
        <h1>Logística</h1>

        <!-- Resumen de estado de vehículos -->
        <div class="status-cards">
            <div class="status-card red">
                <div class="number">38</div>
                <div class="label">Vehículos en ruta</div>
            </div>
            <div class="status-card alert">
                <div class="number">2</div>
                <div class="label">Vehículos con problemas</div>
            </div>
            <div class="status-card warning">
                <div class="number">1</div>
                <div class="label">Vehículos desviados de la ruta</div>
            </div>
            <div class="status-card purple">
                <div class="number">2</div>
                <div class="label">Vehículos tarde</div>
            </div>
        </div>

        <!-- Condición de los paquetes -->
        <div class="cards-group">
            <div class="card donut-card blue">
                <h3>Entregados</h3>
                <div class="donut-chart" data-percent="83"></div>
                <div class="count">181 Cantidad</div>
            </div>
            <div class="card donut-card orange">
                <h3>Pendientes</h3>
                <div class="donut-chart" data-percent="11"></div>
                <div class="count">24 Cantidad</div>
            </div>
            <div class="card donut-card red">
                <h3>Sin asignar</h3>
                <div class="donut-chart" data-percent="6"></div>
                <div class="count">12 Cantidad</div>
            </div>
        </div>

        <!-- Tabla de vehículos en ruta -->
        <div class="card full">
            <h2>Vehículos en Ruta</h2>
            <p class="subtitle">Condición</p>
            <table class="data-table">
                <thead>
                    <tr>
                        <th>Ubicación</th>
                        <th>Destino</th>
                        <th>Inicio de Ruta</th>
                        <th>Estado</th>
                    </tr>
                </thead>
                <tbody>
                    <!-- Estos datos deben ser generados dinámicamente con datos de la base -->
                    <tr>
                        <td><i class="icon-truck"></i>VOL-653CD1</td>
                        <td>Cleveland, Ohio, USA</td>
                        <td>Cleveland, Ohio, USA</td>
                        <td><span class="status delivered">ENTREGADO</span></td>
                    </tr>
                    <tr>
                        <td><i class="icon-truck"></i>VOL-653CD2</td>
                        <td>Cleveland, Ohio, USA</td>
                        <td>Cleveland, Ohio, USA</td>
                        <td><span class="status pending">PENDIENTE</span></td>
                    </tr>
                    <tr>
                        <td><i class="icon-truck"></i>VOL-653CD3</td>
                        <td>Cleveland, Ohio, USA</td>
                        <td>Cleveland, Ohio, USA</td>
                        <td><span class="status pending">PENDIENTE</span></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

</asp:Content>
