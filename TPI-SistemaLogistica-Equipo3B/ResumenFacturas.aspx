<%@ Page Title="Facturas" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="ResumenFacturas.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.ResumenFacturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Content/ResumenFacturas.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <div class="facturas-container">
        <div class="header-bar">
            <h2>Facturas</h2>
            <div>
                <asp:Button runat="server" Text="Nuevo" CssClass="btn-nuevo" />
            </div>
        </div>

        <div class="factura-total-card">
            <div class="circle-avatar">A</div>
            <div>
                <h3>$5,300.00</h3>
                <span>de 12 facturas</span>
            </div>
        </div>

        <!-- enviados -->
        <h4>Enviados (3)</h4>
        <div class="factura-list">
            <%-- repetir este bloque por cada factura enviada --%>
            <div class="factura-item">
                <div class="circle-avatar">AS</div>
                <div class="factura-info">
                    <div><strong>INV-0019</strong><br />ACME SRL</div>
                    <div>$55.50</div>
                    <div>
                        Enviado<br />
                        <span class="small">01/02/2024</span>
                    </div>
                    <div>
                        Entregado<br />
                        <span class="small">06/02/2024</span>
                    </div>
                    <div class="estado entregado">ENTREGADO</div>
                    <div class="arrow">&rarr;</div>
                </div>
            </div>
            
        </div>

        <!-- pendientes -->
        <h4>Pendientes (2)</h4>
        <div class="factura-list">
            <div class="factura-item">
                <div class="circle-avatar">MJ</div>
                <div class="factura-info">
                    <div><strong>INV-0020</strong><br />Matt Jason</div>
                    <div>$253.76</div>
                    <div>
                        Enviado<br />
                        <span class="small">30/01/2024</span>
                    </div>
                    <div>
                        Entregado<br />
                        <span class="small">-</span>
                    </div>
                    <div class="estado pendiente">PENDIENTE</div>
                    <div class="arrow">&rarr;</div>
                </div>
            </div>
        </div>

        <!-- cancelados -->
        <h4>Cancelados (0)</h4>
        <div class="factura-list empty">
            <span>No hay facturas canceladas.</span>
        </div>
    </div>
</asp:Content>

