<%@ Page Title="" Language="VB" MasterPageFile="~/adm/cabecera.master" AutoEventWireup="false" CodeFile="editando-evento.aspx.vb" Inherits="editando_evento" %>

<%@ Register src="menu_lateral.ascx" tagname="menu_lateral" tagprefix="uc1" %>

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
           
              <h1> Editar Evento</h1> <br />
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
           <div class="contenidoAdm">
              
               Modificar hora
               :&nbsp;&nbsp;
               <asp:TextBox ID="TextHoraMod" runat="server" CssClass="campofecha"></asp:TextBox>
               <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator3" ErrorMessage="*Debe completar todos los campos." ForeColor="#669999" ControltoValidate="TextHoraMod"  Font-Italic="true">
                   </asp:RequiredFieldValidator>
               <br /><br />
           </div>
            <div class="contenidoAdm">
              
                Modificar título
               :&nbsp;
                <asp:TextBox ID="TextTitulo" runat="server" CssClass="campotitulo"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" ErrorMessage="*Debe completar todos los campos." ForeColor="#669999" ControltoValidate="TextTitulo"  Font-Italic="true">
                   </asp:RequiredFieldValidator>
              
           </div>
              <br />
                 <div class="contenidoAdm">
              
                     Modificar foto
               :&nbsp;&nbsp;&nbsp; <asp:FileUpload ID="FileUpload1" runat="server" />
               <br />
                     
           </div>
           <br />
                <div class="contenidoAdm">
                    Modificar descripción :&nbsp;&nbsp;&nbsp;&nbsp;
               
               <asp:TextBox ID="TextDescripcion" runat="server" CssClass="campotitulo" Height="180px" TextMode="MultiLine"></asp:TextBox>
              <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator4" ErrorMessage="*Debe completar todos los campos." ForeColor="#669999" ControltoValidate="TextDescripcion"  Font-Italic="true">
                   </asp:RequiredFieldValidator>
               <br />
                     
           </div><br />
           <div class="titulo-pag"> Valor entradas</div> <br />
           <div class="contenidoAdm">
              
                 Platea baja :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;           <asp:TextBox ID="TextPlateaBaja" runat="server" CssClass="campofecha"></asp:TextBox>
               <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator5" ErrorMessage="*Debe completar todos los campos." ForeColor="#669999" ControltoValidate="TextPlateaBaja"  Font-Italic="true">
                   </asp:RequiredFieldValidator>
               <asp:RegularExpressionValidator runat="server"  ErrorMessage="*Ingrese Valores Numericos"  ForeColor="#669999" Font-Italic="true" ControlToValidate="TextPlateaBaja" ValidationExpression="^[0-9]*"> 
                         </asp:RegularExpressionValidator>
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Descuento :&nbsp;           <asp:TextBox ID="TextPlateaBajaDesc" runat="server" CssClass="campofecha">0</asp:TextBox>
               <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator8" ErrorMessage="*Debe completar todos los campos." ForeColor="#669999" ControltoValidate="TextPlateaBajaDesc"  Font-Italic="true">
                   </asp:RequiredFieldValidator>
               <asp:RegularExpressionValidator runat="server"  ErrorMessage="*Ingrese Valores Numericos"  ForeColor="#669999" Font-Italic="true" ControlToValidate="TextPlateaBajaDesc" ValidationExpression="^[0-9]*"> 
                         </asp:RegularExpressionValidator>
               <br />    
           </div>
           <br />
            <div class="contenidoAdm">
              
                 Platea alta :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;           <asp:TextBox ID="TextPlateaAlta" runat="server" CssClass="campofecha"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator6" ErrorMessage="*Debe completar todos los campos." ForeColor="#669999" ControltoValidate="TextPlateaAlta"  Font-Italic="true">
                   </asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator runat="server"  ErrorMessage="*Ingrese Valores Numericos"  ForeColor="#669999" Font-Italic="true" ControlToValidate="TextPlateaAlta" ValidationExpression="^[0-9]*"> 
                         </asp:RegularExpressionValidator>
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Descuento :           <asp:TextBox ID="TextPlateaAltaDesc" runat="server" CssClass="campofecha">0</asp:TextBox>
                <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator7" ErrorMessage="*Debe completar todos los campos." ForeColor="#669999" ControltoValidate="TextPlateaAltaDesc"  Font-Italic="true">
                   </asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator runat="server"  ErrorMessage="*Ingrese Valores Numericos"  ForeColor="#669999" Font-Italic="true" ControlToValidate="TextPlateaAltaDesc" ValidationExpression="^[0-9]*"> 
                         </asp:RegularExpressionValidator>
               <br />    
           </div><br />
              <br />
           <br />
           <asp:Button ID="ButtonModificar" runat="server" CssClass="botonLogin" Text="Modificar" />
           <script type ="text/javascript">
                           function modificarexito() {
                               alert("EL EVENTO SE HA MODIFICAR CON EXITO!");
                               location.href = ('editar-evento.aspx');
                        }
                           function modificarfallo() {
                               alert("ERROR! EVENTO NO SE HA MODIFICAR");
                        }
                           function subioimagen() {
                               alert("NO HA SUBIDO UNA IMAGEN")
                           }
                  </script>
     </div>
         <uc1:menu_lateral ID="menu_lateral1" runat="server"/>
     </div>
</asp:Content>
