<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Teatro Municipal de Valparaíso</title>
     <link href="../css/estilo-general.css" type="text/css" rel="Stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Droid+Sans' rel='stylesheet' type='text/css' />

    
</head>
<body>
    <form id="form1" runat="server">
        <div class="loginContainer">

            <asp:Image ID="Image1" runat="server" ImageUrl="~/img/logo_teatro-login.png" />


            <div class="login">
                <p class="titlogin">Ingresa a tu cuenta</p>
                <div class="fileteLogin">
                    <img alt="" class="auto-style1" src="../img/filete.png" />
                </div>
                <div class="campo">
                    <asp:TextBox ID="TextUsuario" runat="server" CssClass="campoLogin"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" ErrorMessage="*Ingrese su Usuario." ForeColor="#669999" ControltoValidate="TextUsuario"  Font-Italic="true">
                   </asp:RequiredFieldValidator>
                    <br />
                </div>
                <div class="campo2">
                    <asp:TextBox ID="TextContraseña" runat="server" CssClass="campoLogin2" TextMode="Password"  ></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" ErrorMessage="*Ingrese su Contraseña." ForeColor="#669999" ControltoValidate="TextContraseña"  Font-Italic="true" >
                   </asp:RequiredFieldValidator>
                </div>
                <div class="campo3">
                    <asp:CheckBox ID="CheckRecordar" runat="server" />
                    <span class="textoLogin">recordarme</span>
                </div>
                <div class="campo4">
                    <asp:Button ID="ButtonIngresar" runat="server" Text="ingresar" CssClass="botonLogin" />
                    <script type ="text/javascript">
                        function ingresofallo() {
                            alert("ERROR! USUARIO O CONTRASEÑA INCORRECTA!");
                        }
                  </script> 
                </div>
            </div><br /><br /><br /><br />
            <div class="pieLogin">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/img/pieLogin.png" />
            </div>
        </div>
    </form>
</body>
</html>
