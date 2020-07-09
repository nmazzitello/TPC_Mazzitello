<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarValorCuotas.aspx.cs" Inherits="TPC_MAZZITELLO.AgregarValorCuotas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>VALOR CUOTAS</title>

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

        <div class="centrar titulo">
            <h1>AGREGAR PRECIO CUOTAS</h1>
            <asp:Label ID="lbl1" runat="server" Text="Cuota 1, en termino (entre el dia 1 y 10 -inclusive- del mes): $" CssClass="label"></asp:Label>
            <asp:TextBox ID="txtCuotaUno" runat="server" Enabled="false" CssClass="cajaTexto"></asp:TextBox><br />

            <asp:Label ID="lbl2" runat="server" Text="Cuota 1 atrasada, entre el dia 11 y 20 -inclusive- del mes: $" CssClass="label"></asp:Label>
            <asp:TextBox ID="txtCuotaUnoAtrasada" runat="server" Enabled="false" CssClass="cajaTexto"></asp:TextBox><br />

            <asp:Label ID="lbl3" runat="server" Text="Cuota 1 vencida, entre el dia 21 y ultimo dia calendario del mes: $" CssClass="label"></asp:Label>
            <asp:TextBox ID="txtCuotaUnoVencida" runat="server" Enabled="false" CssClass="cajaTexto"></asp:TextBox><br />

            <asp:Label ID="lbl4" runat="server" Text="Cuota 2 en termino (entre el dia 1 y 10 -inclusive- del mes): $" CssClass="label"></asp:Label>
            <asp:TextBox ID="txtCuotaDos" runat="server" Enabled="false" CssClass="cajaTexto"></asp:TextBox><br />

            <asp:Label ID="lbl5" runat="server" Text="Cuota 2 atrasada, entre el dia 11 y 20 -inclusive- del mes: $" CssClass="label"></asp:Label>
            <asp:TextBox ID="txtCuotaDosAtrasada" runat="server" Enabled="false" CssClass="cajaTexto"></asp:TextBox><br />

            <asp:Label ID="lbl6" runat="server" Text="Cuota 2 vencida, entre el dia 21 y ultimo dia calendario del mes: $" CssClass="label"></asp:Label>
            <asp:TextBox ID="txtCuotaDosVencida" runat="server" Enabled="false" CssClass="cajaTexto"></asp:TextBox><br />

            <asp:Label ID="lbl7" runat="server" Text="Cuota 3, en termino (entre el dia 1 y 10 -inclusive- del mes): $" CssClass="label"></asp:Label>
            <asp:TextBox ID="txtCuotaTres" runat="server" Enabled="false" CssClass="cajaTexto"></asp:TextBox><br />

            <asp:Label ID="lbl8" runat="server" Text="Cuota 3 atrasada, entre el dia 11 y 20 -inclusive- del mes: $" CssClass="label"></asp:Label>
            <asp:TextBox ID="txtCuotaTresAtrasada" runat="server" Enabled="false" CssClass="cajaTexto"></asp:TextBox><br />

            <asp:Label ID="lbl9" runat="server" Text="Cuota 3 vencida, entre el dia 21 y ultimo dia calendario del mes: $" CssClass="label"></asp:Label>
            <asp:TextBox ID="txtCuotaTresVencida" runat="server" Enabled="false" CssClass="cajaTexto"></asp:TextBox><br /><br />

            <asp:Button ID="btnCargar" runat="server" 
                Text="CARGAR" OnClick="btnCargar_Click" CssClass="btn btn-primary btn-lg botonn"/>
        </div>
    </form>
</body>
</html>
