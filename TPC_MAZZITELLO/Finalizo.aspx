<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Finalizo.aspx.cs" Inherits="TPC_MAZZITELLO.Finalizo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>FINALIZO</title>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
    <link href="estilos.css" rel="stylesheet" />
</head>
<body style=" background:#8fb9a1">
    <form id="form1" runat="server">
        
        <div class="centrar">
                <asp:Image ID="imgConf" runat="server"
                    ImageUrl="~/Images/finalizo.jpg" Width="750px" Height="600px"/>
            </div>

            <div class="centrar titulo">
                <asp:Label ID="lblAdm" runat="server"
                    Text="¡¡¡ PRESTAMO FINALIZADO !!!" ></asp:Label>
            </div>

            <div class="centrar2">
                <asp:Button ID="btnContinuar" runat="server" 
                    Text="CONTINUAR"  OnClick="btnContinuar_Click" CssClass="btn btn-primary btn-lg"/>
            </div>

    </form>
</body>
</html>
