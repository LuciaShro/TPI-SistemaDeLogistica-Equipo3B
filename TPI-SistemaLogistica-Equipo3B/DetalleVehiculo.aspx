<%@ Page Language="C#" MasterPageFile="~/SideBar.Master" AutoEventWireup="true" CodeBehind="DetalleVehiculo.aspx.cs" Inherits="TPI_SistemaLogistica_Equipo3B.DetalleVehiculo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/AdminTransportistas.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="InicioContent" runat="server">
    <div class="vehiculos-header">
    <h1>Detalle vehiculo</h1>
    <a href="Vehiculos.aspx"><i class="bi bi-arrow-left" ></i> Volver</a>
        </div>

            <div class="card p-5 w-50 mx-auto">
  <div class="card-body pb-0">
    <h5>Detalles</h5> 
    <asp:Button ID="btnModificarVehiculo" runat="server" Text="Modificar" CssClass="btn btn-outline-primary" OnClick="btnModificarVehiculo_Click" Visible="true" />
  </div>
  <ul class="list-group list-group-flush">
    <li class="list-group-item">
      <h6>Patente</h6>
      <asp:Label ID="lblPatente" runat="server" Text="--"></asp:Label>
      <asp:TextBox ID="txtPatente" runat="server" Visible="false"></asp:TextBox>
      <asp:RequiredFieldValidator ErrorMessage="La patente es requerida" ControlToValidate= "txtPatente" runat="server" EnableClientScript="true" Display="Dynamic" ValidationGroup="vehiculo"></asp:RequiredFieldValidator>
    </li>
    <li class="list-group-item">
      <h6>Capacidad de carga</h6>
        <asp:Label ID="lblCapacidadCarga" runat="server" Text="--"></asp:Label>
        <asp:TextBox ID="txtCapacidadCarga" runat="server" Visible="false"></asp:TextBox>
        <asp:RequiredFieldValidator ErrorMessage="La capacidad es requerida" ControlToValidate="txtCapacidadCarga" runat="server"  EnableClientScript="true" Display="Dynamic" ValidationGroup="vehiculo" ></asp:RequiredFieldValidator>
        <asp:RangeValidator ErrorMessage="La capacidad no puede tener ese tamanio." ControlToValidate="txtCapacidadCarga" Type="Integer" MinimumValue="10" MaximumValue="10000" runat="server" EnableClientScript="true" Display="Dynamic" ValidationGroup="vehiculo"></asp:RangeValidator>
        <asp:RegularExpressionValidator ErrorMessage=" Solo se pueden ingresar numeros" ControlToValidate="txtCapacidadCarga" ValidationExpression="^[0-9]+$" runat="server" EnableClientScript="true" Display="Dynamic" ValidationGroup="vehiculo"></asp:RegularExpressionValidator>
    </li>
    <li class="list-group-item">
      <h6>Disponibilidad</h6>
        <asp:Label ID="lblDisponibilidad" runat="server" Text="--"></asp:Label>
        <asp:DropDownList ID="ddlDisponibilidad" runat="server" Visible="false" CssClass="form-control">
        <asp:ListItem Text="Disponible" Value="true" />
        <asp:ListItem Text="No disponible" Value="false" />
</asp:DropDownList>
    </li>
       <li class="list-group-item">
    <h6>Comentario</h6>
     <asp:Label ID="lblComentario" runat="server" Text="--"></asp:Label>
     <asp:TextBox ID="txtComentario" runat="server" Visible="false" TextMode="MultiLine" CssClass="form-control mt-2"></asp:TextBox>
    </li>
    <li class="list-group-item">
      <h6>Estado</h6>
        <asp:Label ID="lblEstado" runat="server" Text="--"></asp:Label>
        <asp:DropDownList ID="ddlEstadoVehiculo" runat="server" Visible="false" CssClass="form-control"></asp:DropDownList>
    </li>
  </ul>
</div>


    <div class="card p-5 w-50 mx-auto mt-3">
    <asp:Button ID="btnDarBajaVehiculo" runat="server" Text="Dar de baja" CssClass="btn  btn-outline-danger" OnClientClick="return confirm('Estas seguro que queres dar de baja este usuario? Esta accion es irreversible');" OnClick="btnDarBajaVehiculo_Click" Visible="false"/>
    <asp:Button ID="btnReactivarVehiculo" runat="server" Text="Reactivar vehiculo" CssClass="btn btn-outline-danger" OnClientClick="return confirm('Estas seguro que queres dar de baja este usuario? Esta accion es irreversible');" OnClick ="btnReactivarVehiculo_Click" Visible="false"/>
    </div> 
    <asp:Button ID="btnGuardarCambiosVehiculo" runat="server" Text="Guardar cambios" CssClass="btn btn-outline-primary" Visible="false" OnClick="btnGuardarCambiosVehiculo_Click" ValidationGroup="vehiculo"/>
    <asp:Button ID="btnCancelarVehiculo" runat="server" Text="Cancelar" CssClass="btn btn-outline-primary" OnClick="btnCancelarVehiculo_Click" Visible="false"/>
    <asp:Label ID="lblMensajePantallaVehiculo" runat="server" Text="" CssClass="text-danger"></asp:Label>
</asp:Content>
