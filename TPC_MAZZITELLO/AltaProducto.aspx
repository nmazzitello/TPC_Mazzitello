<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaProducto.aspx.cs" Inherits="TPC_MAZZITELLO.AltaProducto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ALTA PRODUCTO</title>

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
            SELECCIONAR PRODUCTO
        </h1>

        <section>
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th scope="col">PRODUCTO</th>
                        <th scope="col">MARCA</th>
                        <th scope="col">MODELO</th>
                        <th scope="col">DETALLES</th>
                        <th scope="col">ESTADO</th>
                        <th scope="col">OPCION</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="repeaterProducto">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("producto")%></td>
                                <td><%#Eval("marca")%></td>
                                <td><%#Eval("modelo")%></td>
                                <td><%#Eval("Detalles")%></td>
                                <td><%#Eval("Estado")%></td>
                                <td>
                                    <asp:Button runat="server" ID="btnSeleccionar"
                                        Text="Seleccionar" CommandName="productoSeleccionado" CommandArgument='<%#Eval("idProducto")%>'
                                        OnClick="btnSeleccionar_Click" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </section>

        <div class="centrar titulo">
            <asp:Label ID="lblTituloAgregarProd" runat="server" Text="AGREGAR PRODUCTO" CssClass="titulo"></asp:Label>
        </div>

        <div>
            <div class="item item2 centrar">
                <asp:Label ID="lblProducto" Text="Producto" runat="server" CssClass="label" />
                <asp:TextBox ID="txtProducto" runat="server" MaxLength="28" CssClass="cajaTexto"></asp:TextBox><br />
                <br />

                <asp:Label ID="lblMarca" Text="Marca" runat="server" CssClass="label" />
                <asp:TextBox ID="txtMarca" runat="server" MaxLength="28" CssClass="cajaTexto"></asp:TextBox><br />
                <br />

                <asp:Label ID="lblModelo" Text="Modelo" runat="server" CssClass="label" />
                <asp:TextBox ID="txtModelo" runat="server" MaxLength="28" CssClass="cajaTexto"></asp:TextBox><br />
                <br />

                <asp:Label ID="lblDetalles" Text="Detalles" runat="server" CssClass="label" />
                <asp:TextBox ID="txtDetalles" runat="server" MaxLength="98" CssClass="cajaTexto"></asp:TextBox><br />
                <br />

                <asp:Label ID="lblEstado" Text="Estado" runat="server" CssClass="label" />
                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="cajaTexto"></asp:DropDownList><br />
                <br />

                <asp:Label ID="lblImagen" Text="Url imagen" runat="server" CssClass="label" />
                <asp:TextBox ID="txtImagen" runat="server" MaxLength="998" CssClass="cajaTexto"></asp:TextBox><br />
                <br />
                 <asp:Button ID="btnAceptar" runat="server"
                Text="AGREGAR" OnClick="btnAceptar_Click" CssClass="btn btn-primary btn-lg botonn" />

            </div>

            <div class="item item3">
                <asp:Image ID="imgProd" runat="server" />
            </div>
        </div>

           

    </form>
</body>
</html>
