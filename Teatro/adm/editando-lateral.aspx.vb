Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class editando_lateral
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'VALIDAR DATOS DE USUARIO
            If Session("nombre_usuario") IsNot Nothing And Session("contraseña_usuario") IsNot Nothing Then
                Dim usuario As String = Session("nombre_usuario").ToString
                Dim contraseña As String = Session("contraseña_usuario").ToString
                lblusuario.Text = usuario
                'RESCATA VALOR DE ID ENVIADO POR URL
                Dim idlat As String = Request.QueryString("IdLateral").ToString
                'CONEXIÓN A LA BASE DE DATOS
                Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DesarrolloConnectionString").ToString)
                    con.Open()
                    Dim query As String = "SELECT fecha, foto, descripcion FROM evento_lateral  WHERE id_evento_lateral=@id_evento_lateral"
                    Dim cmd As SqlCommand = New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@id_evento_lateral", idlat)
                    Dim Reader As SqlDataReader = cmd.ExecuteReader()
                    'LLENAR FORMULARIO CON LOS DATOS DEL REGISTRO
                    If Reader.Read() Then
                        TextFechaMod.Text = Reader.GetValue(0).ToString
                        TextDescripcion.Text = Reader.GetValue(2).ToString
                    End If
                End Using
            Else
                Response.Redirect("Login.aspx")
            End If
        End If
    End Sub

    Protected Sub ButtonModificar_Click(sender As Object, e As EventArgs) Handles ButtonModificar.Click
        'RESCATAR VALOR ID POR URL
        Dim reqlat As String = Request.QueryString("IdLateral").ToString
        'RESCATAR VALORES DE LOS TEXTBOX
        Dim fecha As String = TextFechaMod.Text
        Dim descripcion As String = TextDescripcion.Text
        Dim imagen As String

        'VERIFICAR SI HA SUBIDO UNA IMAGEN
        If FileUpload1.HasFile Then
            imagen = Path.Combine(Path.Combine(Server.MapPath("~/images/")), FileUpload1.FileName)

            'CONEXIÓN A LA BASE DE DATOS
            FileUpload1.SaveAs(imagen)
            imagen = "/images/" + FileUpload1.FileName
            'ACTUALIZAR DATOS DEL REGISTRO
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DesarrolloConnectionString").ToString)
                con.Open()
                'ACTUALIZAR DATOS DEL REGISTRO
                Dim query As String = "UPDATE evento_lateral SET fecha=@fecha, foto=@foto, descripcion=@descripcion WHERE id_evento_lateral=@id_evento_lateral"
                Dim cmd As SqlCommand = New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@fecha", fecha)
                cmd.Parameters.AddWithValue("@descripcion", descripcion)
                cmd.Parameters.AddWithValue("@foto", imagen)
                cmd.Parameters.AddWithValue("@id_evento_lateral", reqlat)
                'Ejecutar query
                Try
                    cmd.ExecuteNonQuery()
                    ScriptManager.RegisterStartupScript(ButtonModificar, [GetType], "modificarexito", "modificarexito();", True)
                    TextFechaMod.Text = ""
                    TextDescripcion.Text = ""
                Catch ex As System.Data.SqlClient.SqlException
                    ScriptManager.RegisterStartupScript(ButtonModificar, [GetType], "modificarfallo", "modificarfallo();", True)
                End Try
                con.Close()

            End Using
        Else
            ScriptManager.RegisterStartupScript(ButtonModificar, [GetType], "subioimagen", "subioimagen();", True)
        End If
    End Sub
End Class