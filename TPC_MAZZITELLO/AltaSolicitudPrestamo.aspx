<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaSolicitudPrestamo.aspx.cs" Inherits="TPC_MAZZITELLO.AltaSolicitudPrestamo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>SOLICITAR PRESTAMO</title>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
    <link href="estilos.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="barra">
            <asp:Button runat="server"
                ID="btnInicio"
                CssClass="btn btn-dark float-right botonIngresar"
                Text="Inicio" OnClick="btnInicio_Click" />
        </div>

        <div class="centrar titulo2">
            <asp:Label ID="lblTitulo" Text="SOLICITAR PRESTAMO" runat="server"  />
        </div>
        
        <div class="centrar">
            <asp:Label Text="Monto solicitado:" runat="server" CssClass="label"/>
            <asp:TextBox ID="txtMonto" runat="server" OnTextChanged="txtMonto_TextChanged" MaxLength="5" CssClass="cajaTexto"></asp:TextBox><br /> 
            <br />


           <%-- <asp:Label Text="Gastos administrativos: :" runat="server" CssClass="label"/>
            <asp:DropDownList ID="ddlGastosAdm" runat="server" CssClass="cajaTexto"></asp:DropDownList><br />
            <br />--%>

            <asp:Label Text="Cantidad cuotas:" runat="server" CssClass="label"/>
            <asp:DropDownList ID="ddlCantCuotas" runat="server" CssClass="cajaTexto"></asp:DropDownList><br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Producto en garantia:" CssClass="label"></asp:Label>
            <asp:TextBox ID="txtProducto" runat="server" CssClass="cajaTexto" Enabled="false"></asp:TextBox>
            <asp:Button ID="btnAgregarProducto" runat="server" 
                Text="SELECCIONAR PRODUCTO" OnClick="btnAgregarProducto_Click" CssClass="btn btn-secondary btn-lg"/><br />
            <asp:Button ID="btnAceptar" runat="server" 
                Text="ACEPTAR" OnClick="btnAceptar_Click" CssClass="btn btn-primary btn-lg botonn"/>
            <asp:Button ID="btnConfirmar" runat="server" 
                Text="CONFIRMAR" OnClick="btnConfirmar_Click" CssClass="btn btn-primary btn-lg botonn"/>
            <asp:Button ID="btnRechazar" runat="server" 
                Text="RECHAZAR" OnClick="btnRechazar_Click" CssClass="btn btn-primary btn-lg botonn"/><br />
            <br />
            <asp:Label ID="lblObservaciones" runat="server" Text="OBSERVACIONES:" Visible="false" CssClass="label"></asp:Label><br />
            <asp:TextBox ID="txtObservaciones" runat="server" Visible="false" CssClass="cajaTexto" TextMode="MultiLine"></asp:TextBox><br />
            <asp:Button ID="btnEnviarObs" runat="server" 
                Text="ENVIAR" CssClass="btn btn-primary btn-lg botonn" Visible="false" OnClick="btnEnviarObs_Click"/>
        </div>

    </form>
</body>
</html>
