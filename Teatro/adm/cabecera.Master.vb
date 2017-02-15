Public Class cabecera
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub lbsalir_Click(sender As Object, e As EventArgs) Handles lbsalir.Click
        'VOLVER AL LOGIN
        If Request.Cookies("contraseña") IsNot Nothing Then
            Response.Cookies("contraseña").Expires = DateTime.Now.AddDays(-30)
        End If
        Session.Clear()
        Session.Abandon()
        Session.RemoveAll()
        Response.Redirect("Login.aspx")
    End Sub
    Protected Sub lbhome_Click(sender As Object, e As EventArgs) Handles lbhome.Click
        'VOLVER AL LOGIN
        If Request.Cookies("contraseña") IsNot Nothing Then
            Response.Cookies("contraseña").Expires = DateTime.Now.AddDays(-30)
        End If
        Session.Clear()
        Session.Abandon()
        Session.RemoveAll()
        Response.Redirect("Login.aspx")

    End Sub
End Class