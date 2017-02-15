<%@ Page Title="" Language="VB" MasterPageFile="~/adm/cabecera.master" AutoEventWireup="false" CodeFile="home.aspx.vb"Inherits="home" %>

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
              <h1> Ingresar Programación</h1> <br />
               <div class="titulo-pag"> Seleccione sección donde aparecerá</div>
           <br />
           <div class="contenidoAdm">
               <asp:CheckBoxList runat="server" ID="checkbox" RepeatLayout="Flow"  RepeatDirection="Horizontal"  >
                   <asp:ListItem Text="Home Pequeño" Value="1" onclick="MutExChkList(this);"  ></asp:ListItem>
                   <asp:ListItem Text="Home Grande" Value="2" onclick="MutExChkList(this);"  ></asp:ListItem>
                   <asp:ListItem Text="Listado" Value="3" onclick="MutExChkList(this);"  ></asp:ListItem>
                   <asp:ListItem Text="Evento" Value="4" onclick="MutExChkList(this);"  ></asp:ListItem>
               </asp:CheckBoxList>
                <asp:CustomValidator ID="CustomValidator1" ErrorMessage="Seleccione una Seccion."
                 ForeColor="#669999" ClientValidationFunction="ValidateCheckBoxList" runat="server" />
           </div><br /> 
            <div class="titulo-pag"> Ingrese datos del evento programado</div><br />
           <div class="contenidoAdm">
              
              ingresar fecha (dd-mm-yyyy)
               :
               <asp:TextBox ID="TextFechaIng" runat="server" CssClass="campofecha"   ></asp:TextBox>
               <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" ErrorMessage="*Debe completar todos los campos." ForeColor="#669999" ControltoValidate="TextFechaIng"  Font-Italic="true">
                   </asp:RequiredFieldValidator>
               <asp:RegularExpressionValidator   runat="server" ErrorMessage="*Fecha Inválida."  ForeColor="#669999" Font-Italic="true" ControlToValidate="TextFechaIng" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])-(0[1-9]|1[0-2])-((19|20)\d\d))$">
                    </asp:RegularExpressionValidator>
               <br />
           </div><br />
           <div class="contenidoAdm">
              
               ingresar hora
               :&nbsp;&nbsp;
               <asp:TextBox ID="TextHoraIng" runat="server" CssClass="campofecha"></asp:TextBox>
               <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator3" ErrorMessage="*Debe completar todos los campos." ForeColor="#669999" ControltoValidate="TextHoraIng"  Font-Italic="true">
                   </asp:RequiredFieldValidator>
              
           </div><br />
            <div class="contenidoAdm">
              
              ingresar título
               :&nbsp;
               <asp:TextBox ID="TextTitulo" runat="server" CssClass="campotitulo"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" ErrorMessage="*Debe completar todos los campos." ForeColor="#669999" ControltoValidate="TextTitulo"  Font-Italic="true">
                   </asp:RequiredFieldValidator>
              
           </div> <br />
                 <div class="contenidoAdm">
              
              ingresar foto
               :&nbsp;&nbsp;&nbsp; <asp:FileUpload ID="FileUpload1" runat="server" />
               &nbsp;<br /><span class="txtnota">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; La imagen debe ser horizontal y debe medir como mínimo de 550 px horizontales.</span></div> <br />
           <div class="contenidoAdm">
                    Descripción :&nbsp;&nbsp;&nbsp;&nbsp;
               
               <asp:TextBox ID="TextDescripcion" runat="server" CssClass="campotitulo" Height="180px" TextMode="MultiLine" TabIndex="5"></asp:TextBox>
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
                 <br />
           </div>
           <br />
            <div class="contenidoAdm">
              
                 Platea alta :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;           <asp:TextBox ID="TextPlateaAlta" runat="server" CssClass="campofecha"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator6" ErrorMessage="*Debe completar todos los campos." ForeColor="#669999" ControltoValidate="TextPlateaAlta"  Font-Italic="true">
                   </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server"  ErrorMessage="*Ingrese Valores Numericos"  ForeColor="#669999" Font-Italic="true" ControlToValidate="TextPlateaAlta" ValidationExpression="^[0-9]*"> 
                         </asp:RegularExpressionValidator>
           <br />    
           </div><br />
         <div class="contenidoAdm">
              
                 Galería :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;           <asp:TextBox ID="TextGaleria" runat="server" CssClass="campofecha"></asp:TextBox>
             <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator7" ErrorMessage="*Debe completar todos los campos." ForeColor="#669999" ControltoValidate="TextGaleria"  Font-Italic="true">
                   </asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator runat="server"  ErrorMessage="*Ingrese Valores Numericos"  ForeColor="#669999" Font-Italic="true" ControlToValidate="TextGaleria" ValidationExpression="^[0-9]*"> 
                         </asp:RegularExpressionValidator>
           <br />    
           </div><br />
             
           <br />
           <asp:Button ID="ButtonSubir" runat="server" CssClass="botonLogin" Text="Subir" />
           <script type ="text/javascript">
                           function ingresoexito() {
                               alert("LA PROGRAMACIÓN SE HA INGRESADO CON EXITO!");
                        }
                           function ingresofallo() {
                               alert("ERROR! PROGRAMACIÓN NO INGRESADA");
                        }
                           function subioimagen() {
                               alert("NO HA SUBIDO UNA IMAGEN")
                           }
                           function MutExChkList(chk) {
                               var chkList = chk.parentNode.parentNode.parentNode;
                               var chks = chkList.getElementsByTagName("input");
                               for (var i = 0; i < chks.length; i++) {
                                   if (chks[i] != chk && chk.checked) {
                                       chks[i].checked = false;
                                   }
                               }
                            }
                           function ValidateCheckBoxList(sender, args) {
                           var checkBoxList = document.getElementById("<%=checkbox.ClientID %>");
                           var checkboxes = checkBoxList.getElementsByTagName("input");
                           
                           for (var i = 0; i < checkboxes.length; i++) {
                                  if (checkboxes[i].checked) {
                                      args.isValid = true;
                                  return;
                               }
                            }
                           args.IsValid = false;
                           alert("NO HA SELECCIONADO UNA SECCIÓN")
                       }
                  </script>

     </div>
         <uc1:menu_lateral ID="menu_lateral1" runat="server" class="menu_lateral1"/> 
     </div>
</asp:Content>

