<%@ Page Title="" Language="VB" MasterPageFile="~/adm/cabecera.master" AutoEventWireup="false" CodeFile="listado-editar-programacion.aspx.vb" Inherits="listado_editar_programacion" %>

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
          <br />
<br />
         
       <div class="contenido">
           
           <h1> Editar o eliminar Programación</h1> <br />
           <div class="contenidoAdm2">


               <asp:ListView runat="server" ID="lvprog" DataSourceID="SqlDataSource1" >
                   <ItemTemplate>
                       <div class="contenidoAdm2">
                           <asp:Label ID="id_programacionLabel" runat="server" Text='<%# Eval("id_programacion") %>' Visible="false" />
                           <asp:Label ID="tituloLabel" runat="server" Text='<%# Eval("titulo") %>' />
                           <asp:LinkButton runat="server" ID="lbeliminar" OnClientClick="return confirm('Desea eliminar este registro?');"><img src="/img/ico-eliminar.png" class="icono-editar" /></asp:LinkButton>
                           <asp:LinkButton runat="server" ID="lb" ><img src="/img/1326.png" class="icono-editar" /></asp:LinkButton>
                        </div> <br />
                   </ItemTemplate>
                   <LayoutTemplate>
                           <div id="itemPlaceholderContainer" runat="server" border="0" style="" >
                               <div id="itemPlaceholder" runat="server">
                                </div>
                           </div>
                       <div class="col-sm-12 text-center">
                          <asp:DataPager ID="DataPager1" runat="server" PageSize="10" >
                              <Fields>
                                  <asp:NextPreviousPagerField ButtonType="Link" ShowPreviousPageButton="true" PreviousPageText="Anterior"  ShowNextPageButton="false"/>
                                  <asp:NumericPagerField ButtonType="Link" NextPreviousButtonCssClass="pagination" />
                                  <asp:NextPreviousPagerField ButtonType="Link" NextPageText="Siguiente"  ShowNextPageButton="true" ShowPreviousPageButton="false"/>
                              </Fields>
                          </asp:DataPager>
                          </div>
                   </LayoutTemplate>

               </asp:ListView>

              
               <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DesarrolloConnectionString %>" SelectCommand="SELECT [id_programacion], [titulo] FROM [programacion] ORDER BY [titulo]"></asp:SqlDataSource>

     </div>
     </div>
         <uc1:menu_lateral ID="menu_lateral1" runat="server" class="menu_lateral1"/> 
     </div>
</asp:Content>

