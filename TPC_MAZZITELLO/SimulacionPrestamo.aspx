<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SimulacionPrestamo.aspx.cs" Inherits="TPC_MAZZITELLO.SimulacionPrestamo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>SIMULACION</title>

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

        <h1 class="centrar titulo2">
            SIMULAR CREDITO
        </h1>

        <div class="centrar2">
            <asp:Label ID="lblMonto" runat="server" Text="Ingrese el monto solicitado:" CssClass="label"></asp:Label>
            <asp:TextBox ID="txtMonto" runat="server" CssClass="cajaTexto"></asp:TextBox><br /><br />
            <asp:Label ID="Label1" runat="server" Text="Seleccione la cantidad cuotas:" CssClass="label"></asp:Label>
            <asp:DropDownList ID="ddlCantCuot" runat="server" CssClass="label"></asp:DropDownList><br /><br />
            <asp:Label ID="Label2" runat="server" Text="Seleccione gastos administrativos:" CssClass="label"></asp:Label>
            <asp:DropDownList ID="ddlGastosAdm" runat="server" CssClass="label"></asp:DropDownList><br /><br />
            <asp:Button ID="btnCalcular" runat="server" Text="CALCULAR" OnClick="btnCalcular_Click" CssClass="btn btn-primary btn-lg"/><br /><br />

            <asp:Label ID="lblPagar" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
