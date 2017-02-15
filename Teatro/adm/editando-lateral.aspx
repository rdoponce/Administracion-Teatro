<%@ Page Title="" Language="VB" MasterPageFile="~/adm/cabecera.master" AutoEventWireup="false" CodeFile="editando-lateral.aspx.vb" Inherits="editando_lateral"%>

<%@ Register Src="~/adm/menu_lateral.ascx" TagPrefix="uc1" TagName="menu_lateral" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <meta name="nombre" content="Teatro Municipal de Valparaíso" />
    <link href="css/estilo-general.css" type="text/css" rel="Stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Droid+Sans' rel='stylesheet' type='text/css' />
    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../js/script3.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="cuerpo3">
         
         <div class="usuario">Bienvenido <asp:Label runat="server" ID="lblusuario"></asp:Label></div> 
        <div class="contenido">
           
           <h1> Modificar Evento Lateral</h1> <br />
           <div class="contenidoAdm">
              
               Modificar fecha
               :
               <asp:TextBox ID="TextFechaMod" runat="server" CssClass="campofecha"></asp:TextBox>
               <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" ErrorMessage="*Debe completar todos los campos." ForeColor="#669999" ControltoValidate="TextFechaMod"  Font-Italic="true">
                   </asp:RequiredFieldValidator>
               <asp:RegularExpressionValidator   runat="server" ErrorMessage="*Fecha Inválida."  ForeColor="#669999" Font-Italic="true" ControlToValidate="TextFechaMod" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])-(0[1-9]|1[0-2])-((19|20)\d\d))$">
                    </asp:RegularExpressionValidator>
               <br />
           </div><br />
            <br />
                 <div class="contenidoAdm">
              
                     Modificar foto
               :&nbsp;&nbsp;&nbsp; <asp:FileUpload ID="FileUpload1" runat="server" />
               &nbsp;(miniatura de 250px como maximo)<br />
                     
           </div>
           <br />
                <div class="contenidoAdm">
                    Modificar descripción :&nbsp;&nbsp;&nbsp;&nbsp;(máximo x caracteres)
               
               <asp:TextBox ID="TextDescripcion" runat="server" CssClass="campotitulo" Height="100px" TextMode="MultiLine"></asp:TextBox>
              <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator4" ErrorMessage="*Debe completar todos los campos." ForeColor="#669999" ControltoValidate="TextDescripcion"  Font-Italic="true">
                   </asp:RequiredFieldValidator>
               <br />
                     
           </div><br />
           <br />
           <br />
           <asp:Button ID="ButtonModificar" runat="server" CssClass="botonLogin" Text="Modificar" />
           <script type ="text/javascript">
                           function modificarexito() {
                               alert("EL EVENTO LATERAL SE HA MODIFICAR CON EXITO!");
                               location.href = ('editar-lateral.aspx');
                        }
                           function modificarfallo() {
                               alert("ERROR! EVENTO LATERAL NO SE HA MODIFICAR");
                        }
                           function subioimagen() {
                               alert("NO HA SUBIDO UNA IMAGEN")
                           }
                  </script>
     </div>
          <uc1:menu_lateral runat="server" ID="menu_lateral" />
        </div>
</asp:Content>