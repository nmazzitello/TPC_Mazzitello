<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerCuotasPrestamo.aspx.cs" Inherits="TPC_MAZZITELLO.VerCuotasPrestamo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CUOTAS PRESTAMO</title>

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
            CUOTAS PRESTAMO
        </h1>

        <div>
            <section>
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th scope="col">NUMERO CUOTA</th>
                            <th scope="col">VALOR CUOTA</th>
                            <th scope="col">1er VENCIMIENTO</th>
                            <th scope="col">VALOR CUOTA 1er VENCIMIENTO</th>
                            <th scope="col">2do VENCIMIENTO</th>
                            <th scope="col">VALOR CUOTA 2do VENCIMIENTO</th>
                            <th scope="col">FECHA PAGO CLIENTE</th>
                            <th scope="col">OPCION</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="repeaterCuotaPrestamo">
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("numeroCuota")%></td>
                                    <td>$<%#Eval("valorCuota")%></td>
                                    <td><%#Eval("fechaAtrasadaLinda")%></td>
                                    <td>$<%#Eval("valorCuotaAtrasada")%></td>
                                    <td><%#Eval("fechaVencidaLinda")%></td>
                                    <td>$<%#Eval("valorCuotaVencida")%></td>
                                    <td><%#Eval("fechaPagoClienteLinda")%></td>
                                    <td>
                                        <asp:Button runat="server" ID="btnIr"
                                            Text="IR" CommandName="cuotaSeleccionada" CommandArgument='<%#Eval("numeroCuota")%>'
                                            OnClick="btnIr_Click"/>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </section>
        </div>

        <div class=" centrar">
            <asp:Button ID="btnFinalizar" runat="server" 
                Text="FINALIZAR CONTRATO" CssClass="btn btn-primary btn-lg botonn" OnClick="btnFinalizar_Click" Visible="false"/>
        </div>

        <div class=" centrar">
            <asp:Label ID="lblSubt" runat="server" Text="MEDIOS PAGO" CssClass="titulo"></asp:Label><br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="TRANSFERENCIA" CssClass="label"></asp:Label><br />
            <asp:Label ID="Label4" runat="server" Text="Realizar mediante transferencia al CBU Nº:1234567890123456789012" CssClass="label"></asp:Label><br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="PAGO EN EFECTIVO" CssClass="label"></asp:Label><br />
            <asp:Label ID="Label3" runat="server" Text="Comunicarse con el 11-1111-1111 para coordinar el pago en efectivo 
            con uno de nuestros representantes." CssClass="label"></asp:Label><br />
            <br />
        </div>

        <div class="centrar">
            <asp:Label ID="lblConfirmarPago" runat="server" Text="CONFIRMAR PAGO" CssClass="titulo"></asp:Label>
            <div>
                <asp:Button ID="btnTransf" runat="server" 
                Text="TRANSFERENCIA" CssClass="btn btn-secondary btn-lg botonn" OnClick="btnTransf_Click"/>
            <asp:Button ID="btnEfec" runat="server" 
                Text="EFECTIVO" CssClass="btn btn-secondary btn-lg botonn" OnClick="btnEfec_Click"/>
            </div>
            <br />
            
            <asp:Label ID="lblComprobantePago" runat="server" Text="Ingrese" CssClass="label" Visible="false"></asp:Label>
            <asp:TextBox ID="txtComprobantePago" runat="server" CssClass="cajaTexto" Visible="false"></asp:TextBox><br />
            <asp:Button ID="btnConfirmarPago" runat="server" 
                Text="CONFIRMAR" CssClass="btn btn-primary btn-lg botonn" Visible="false" OnClick="btnConfirmarPago_Click"/>
        </div>
        


    </form>
</body>
</html>
