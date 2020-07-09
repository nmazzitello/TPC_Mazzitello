<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaPrestamo.aspx.cs" Inherits="TPC_MAZZITELLO.AltaPrestamo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>NUEVO PRESTAMO</title>

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

        <h2 class="centrar titulo2">
            CREAR PRESTAMO
        </h2>
        
        <div class="centrar">
            <asp:Label ID="lblCli" runat="server" Text="Número cliente:" CssClass="label"></asp:Label>
            <asp:Button ID="btnSelCliente" runat="server"
                Text="Seleccionar" OnClick="btnSelCliente_Click" CssClass="btn btn-secondary btn-lg" /><br />
            <br />

            <asp:Label ID="lblProGar" runat="server" Text="Producto en garantía:" CssClass="label"></asp:Label>
            <asp:Button ID="btnProd" runat="server"
                Text="Agregar" OnClick="btnProd_Click" CssClass="btn btn-secondary btn-lg" /><br />
            <br />

            <asp:Label ID="lblGasAdm" runat="server" Text="Gastos administrativos:" CssClass="label"></asp:Label>
            <asp:Button ID="btnGastosAdm" runat="server"
                Text="Agregar" OnClick="btnGastosAdm_Click" CssClass="btn btn-secondary btn-lg" /><br />
            <br />

            <asp:Label ID="lblMon" runat="server" Text="Monto:" CssClass="label"></asp:Label>
            <asp:TextBox ID="txtMonto" runat="server" OnTextChanged="txtMonto_TextChanged"  MaxLength="5" CssClass="cajaTexto"></asp:TextBox><br />
            <br />

            <asp:Label ID="lblCuotas" runat="server" Text="Cantidad de cuotas:" CssClass="label"></asp:Label>
            <asp:DropDownList ID="ddlCantidadCuotas" runat="server" CssClass="cajaTexto"></asp:DropDownList><br />
            <br />

            <asp:Label ID="lblValCuo" runat="server" Text="Valor cuota/s:" CssClass="label"></asp:Label>
            <asp:Button ID="btnValorCuo" runat="server"
                Text="Agregar" OnClick="btnValorCuo_Click" CssClass="btn btn-secondary btn-lg" /><br />
            <br />

            <asp:Button ID="btnCargar" runat="server"
                Text="CARGAR" OnClick="btnCargar_Click" CssClass="btn btn-primary btn-lg" />
        </div>

    </form>
</body>
</html>
