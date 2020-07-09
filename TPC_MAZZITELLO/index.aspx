<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TPC_MAZZITELLO.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>Prestamos personales MF</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
    <link href="estilos.css" rel="stylesheet" />   
</head>
<body>
    <form id="form1" runat="server">

         <div class="barra">
            <asp:Button runat="server"
                ID="btnIngresar"
                CssClass="btn btn-dark float-right botonIngresar"
                Text="INGRESAR" OnClick="btnIngresar_Click" />
        </div>
        
        <div class="container">
            <div class="jumbotron jumbotron-fluid">
                <div class="container">
                    <h1 class="display-4">MF PRESTAMOS</h1>
                    <p class="lead">Créditos personales. Lider en la zona, confirmado por nuestros mas de 1000 clientes en nuestros 3 años de desempeño.</p>
                </div>
            </div>
        </div>

        <div class="centrar">
            <asp:Image ID="Image1" runat="server" 
                ImageUrl="~/Images/inicio.jpg"/>
        </div>

        <div >
            <div class="item opc recuadro">
                <p>
                    <strong>¿POR QUE SACAR UN CREDITO CON NOSOTROS?</strong>
                    <br />
                    <br />
                    Contamos con 3 años de antigüedad y más de 100 clientes satisfechos, 
                    <br />
                    los cuales suelen recomendarnos.  Lo que genera que nuestra mayor patrimonio
                    <br />
                    actualmente sean ellos, nuestros clientes. Al brindar ciertas facilidades 
                    <br />
                    respecto a sacar un crédito convencional, es mucho mas sencillo acceder 
                    <br />
                    a un crédito, y más rápido, ya que nuestro tiempo de respuesta no es 
                    <br />
                    superior en ningun caso, a las 24 hr.
                    <br />
                </p>
            </div>

            <div class="item opc recuadro">
                <p>
                    <strong>¿COMO TRABAJAMOS?</strong>
                    <br />
                    <br />
                    Tenemos una manera distinta de trabajar, no verificamos riesgo crediticio 
                    <br />
                    ni que estes en el veraz. Pueden acceder al crédito cualquier persona. 
                    <br />
                    Unicamente debes contar con un producto que puedas dejar en garantía hasta 
                    <br />
                    el momento en que abones la última cuota. Los mismos pueden ser electrodomésticos,
                    <br />
                    herramientas, vehículos.
                </p>
            </div>
        </div>

        <%--<div>
            <h4>Contactanos</h4>
        </div>--%>

    </form>
</body>
</html>
