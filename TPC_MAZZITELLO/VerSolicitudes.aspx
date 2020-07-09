<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerSolicitudes.aspx.cs" Inherits="TPC_MAZZITELLO.VerSolicitudes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>VER SOLICITUDES</title>

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

        <div>
            <h1 class="centrar titulo2">SOLICITUDES DE PRESTAMO</h1>
            <section>
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th scope="col">FECHA SOLICITUD</th>
                             <th scope="col">ESTADO</th>
                            <th scope="col">NUMERO CLIENTE</th>
                            <th scope="col">APELLIDO</th>
                            <th scope="col">NOMBRE</th>
                            <th scope="col">OPCION</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="repeaterSolicitud">
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("fecha")%></td>
                                    <td><%#Eval("estadoLindo")%></td>
                                    <td><%#Eval("cliente.idCliente")%></td>
                                    <td><%#Eval("cliente.apellido")%></td>
                                    <td><%#Eval("cliente.nombre")%></td>
                                    <td>
                                        <asp:Button runat="server" ID="btnCheck"
                                            Text="Chequear" CommandName="solicitudSeleccionada" CommandArgument='<%#Eval("idSolicitud")%>'
                                            OnClick="btnCheck_Click"/>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </section>
        </div>

    </form>
</body>
</html>
