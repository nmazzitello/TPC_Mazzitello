<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iniciarSesion.aspx.cs" Inherits="TPC_MAZZITELLO.iniciarSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>INGRESAR CUENTA</title>

     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
    <link href="estillosFormulario.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    
        <div class="login-page">
            <div class="formu">
                <form class="login-form">
                    <asp:TextBox ID="txtUsuario" runat="server"
                        CssClass="entra" MaxLength="28"  placeholder="Usuario"></asp:TextBox>
                    <asp:TextBox ID="txtContra" runat="server"
                        CssClass="entra" MaxLength="28" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                    <asp:Button CssClass="botonazo" ID="btnEntrar" runat="server" Text="ENTRAR" OnClick="btnEntrar_Click"/>
                    <p class="message">No estas registrado? <a href="RegistroUsuario.aspx">CREAR CUENTA</a></p>
                </form>
            </div>
        </div>


    </form>
</body>
</html>
