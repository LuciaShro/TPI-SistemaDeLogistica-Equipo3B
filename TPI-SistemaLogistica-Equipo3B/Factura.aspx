<%@ Page Title="Factura" Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.Factura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Content/Factura.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <div class="invoice-container">
        <div class="invoice-header">
            <div class="company-logo">
                <img src="logo.png" alt="Logo" />
            </div>
            <div class="invoice-actions">
                <span class="status-paid">PAGADO</span>
                <asp:Button runat="server" CssClass="btn-download" Text="Download" />
            </div>
        </div>

        <div class="invoice-info">
            <div>
                <strong>www.FlashShip.com</strong><br />
                Street King William, 123<br />
                Level 2, C, 442456<br />
                San Francisco, CA, USA
            </div>
            <div>
                Company No. 4675933<br />
                EU VAT No. 949 67545 45<br />
                accounts@devias.io<br />
                (+40) 652 3456 23
            </div>
        </div>

        <div class="invoice-dates">
            <div>
                <strong>Date of issue:</strong><br />
                01 Feb 2024
            </div>
            <div>
                <strong>Due date:</strong><br />
                06 Feb 2024
            </div>
            <div>
                <strong>Invoice #:</strong><br />
                INV-0019
            </div>
        </div>

        <div class="billed-to">
            <strong>Billed to</strong><br />
            ACME SRL<br />
            Countdown Grey Lynn<br />
            6934656854231<br />
            271 Richmond Rd, Grey Lynn, Auckland 1022, New Zealand
        </div>

        <table class="invoice-table">
            <thead>
                <tr>
                    <th>#</th>
                    <th>DESCRIPTION</th>
                    <th>QTY</th>
                    <th>PRECIO ENVIO</th>
                    <th>TOTAL</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>1</td>
                    <td>Freelancer Subscription (12/05/2019 - 11/06/2019)</td>
                    <td>1</td>
                    <td>$55.50</td>
                    <td>$55.50</td>
                </tr>
            </tbody>
        </table>

        <div class="invoice-summary">
            <div>Subtotal: <span>$50.00</span></div>
            <div>Impuestos: <span>$5.50</span></div>
            <div class="total">Total: <span>$55.50</span></div>
        </div>
    </div>
</asp:Content>

