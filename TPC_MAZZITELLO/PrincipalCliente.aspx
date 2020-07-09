<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrincipalCliente.aspx.cs" Inherits="TPC_MAZZITELLO.PrincipalCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>USUARIO</title>

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
                ID="btnCerrar"
                CssClass="btn btn-dark float-right botonIngresar"
                Text="CERRAR SESION" OnClick="btnCerrar_Click" />
        </div>

            <h1 class="centrar titulo2">
                PRESTAMOS MF
            </h1>
        
        <div>
            <h2 class="sesionDe">
                <asp:Label ID="lblUser" runat="server" ></asp:Label>
            </h2>
        </div>
        
        <div class="opcionesAdm">
            <div class="item item1">
                <asp:Button ID="btnDatos" runat="server" CssClass="btn btn-primary btn-lg"
                    Text="AGREGAR/MODIFICAR DATOS" OnClick="btnDatos_Click" Width="300px"/><br />
                <br />

                <asp:Button ID="btnPrestamo" runat="server" CssClass="btn btn-primary btn-lg"
                    Text="SOLICITAR PRESTAMO" OnClick="btnPrestamo_Click" Width="300px" /><br />
                <br />

                <asp:Button ID="btnVerSolicitud" runat="server" CssClass="btn btn-primary btn-lg"
                    Text="VER SOLICITUD" OnClick="btnVerSolicitud_Click" Width="300px"/><br />
                <br />

                <asp:Button ID="btnVerPrestamos" runat="server" CssClass="btn btn-primary btn-lg"
                    Text="VER PRESTAMOS" OnClick="btnVerPrestamos_Click" Width="300px"/><br />
                <br />

                <asp:Button ID="btnVerProductos" runat="server" CssClass="btn btn-primary btn-lg"
                    Text="VER/AGREGAR PRODUCTOS" OnClick="btnVerProductos_Click" Width="300px"/><br />
                <br />

                <asp:Button ID="btnSimular" runat="server" CssClass="btn btn-primary btn-lg"
                    Text="SIMULAR CREDITO" OnClick="btnSimular_Click" Width="300px"/><br />
                <br />
            </div>
            
            <div class="item item2">
                <asp:Image ID="Image1" runat="server" CssClass="float-right"
                    ImageUrl="~/Images/fondoCliente.png" Width="1200px" Height="500px"/>
            </div>
        </div>

    </form>
</body>
</html>

