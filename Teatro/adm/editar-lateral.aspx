<%@ Page Title="" Language="VB" MasterPageFile="~/adm/cabecera.master" AutoEventWireup="false" CodeFile="editar-lateral.aspx.vb" Inherits="editar_lateral" %>

<%@ Register Src="~/adm/menu_lateral.ascx" TagPrefix="uc1" TagName="menu_lateral" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta name="nombre" content="Teatro Municipal de Valparaíso" />
    <link href="css/estilo-general.css" type="text/css" rel="Stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Droid+Sans' rel='stylesheet' type='text/css' />
    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../js/script3.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="cuerpo3">
        <div class="usuario">Bienvenido
            <asp:Label runat="server" ID="lblusuario"></asp:Label></div>
        <br />
        <div class="contenido">

            <h1>Modificar o eliminar evento lateral</h1>
            <br />
            <div class="contenidoAdm2">

                <asp:ListView runat="server" ID="lvlat" DataSourceID="SqlDataSource1">
                    <ItemTemplate>
                        <div class="contenidoAdm2">
                            <asp:Label ID="id_evento_lateralLabel" runat="server" Text='<%# Eval("id_evento_lateral") %>' Visible="false" />
                            <asp:Label ID="fechaLabel" runat="server" Text='<%# Eval("fecha") %>' />
                            <asp:Label ID="descripcionLabel" runat="server" Text='<%# Eval("descripcion") %>' />
                            <asp:LinkButton runat="server" ID="lbeliminar" OnClientClick="return confirm('Desea eliminar este registro?');"><img src="/img/ico-eliminar.png" class="icono-editar" /></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="lb"><img src="/img/1326.png" class="icono-editar" /></asp:LinkButton>
                        </div>
                        <br />
                    </ItemTemplate>
                    <LayoutTemplate>
                        <div id="itemPlaceholderContainer" runat="server" border="0" style="">
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

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DesarrolloConnectionString %>" SelectCommand="SELECT [id_evento_lateral], [fecha], [descripcion] FROM [evento_lateral] ORDER BY [fecha]"></asp:SqlDataSource>
            </div>

        </div>
        <uc1:menu_lateral ID="menu_lateral1" runat="server" class="menu_lateral1" />
    </div>
</asp:Content>

