<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetallesGastosAdministrativos.aspx.cs" Inherits="TPC_MAZZITELLO.DetallesGastosAdministrativos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CAMBIAR GASTOS ADMINISTRATIVOS</title>

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
             MODIFICAR GASTOS ADMINISTRATIVOS
         </h1>

        <div>
            <section>
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th scope="col">MONTO</th>
                            <th scope="col">MESES</th>
                            <th scope="col">DETALLES</th>
                            <th scope="col">OPCION</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="repeaterGastosAdm">
                            <ItemTemplate>
                                <tr>
                                    <td>$<%#Eval("monto")%></td>
                                    <td><%#Eval("meses")%></td>
                                    <td><%#Eval("detalles")%></td>
                                    <td>
                                        <asp:Button runat="server" ID="btnModificar"
                                            Text="Seleccionar" CommandName="gastosSeleccionado" CommandArgument='<%#Eval("idGastosAdm")%>'
                                            OnClick="btnModificar_Click" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </section>

            <div class="centrar">
                <asp:Label ID="lblSubt" runat="server" Text="AGREGAR OPCION NUEVA" CssClass=" titulo2"></asp:Label><br /><br />
                
                <asp:Label ID="lblMonto" runat="server" Text="Monto:" CssClass="label"></asp:Label>
                <asp:TextBox ID="txtMonto" runat="server" MaxLength="5" CssClass="cajaTexto"></asp:TextBox><br /><br />
                <asp:Label ID="lblMeses" runat="server" Text="Meses:" CssClass="label"></asp:Label>
                <asp:TextBox ID="txtMeses" runat="server" TextMode="Number" MaxLength="2" CssClass="cajaTexto"></asp:TextBox><br /><br />
                <asp:Label ID="lblDetalles" runat="server" Text="Detalles:" CssClass="label"></asp:Label>
                <asp:TextBox ID="txtDetalles" runat="server" MaxLength="48" CssClass="cajaTexto"></asp:TextBox><br /><br />
                <asp:Button ID="btnAceptar" runat="server"
                    Text="ACEPTAR" OnClick="btnAceptar_Click" CssClass="btn btn-primary btn-lg botonn "/>
            </div>

        </div>
    </form>
</body>
</html>
