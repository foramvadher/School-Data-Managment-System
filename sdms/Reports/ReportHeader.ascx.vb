
Partial Class Reports_ReportHeader
    Inherits System.Web.UI.UserControl



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Image1.ImageUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + ResolveUrl("~/") & "images/reportLogo.PNG"
            Image2.ImageUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + ResolveUrl("~/") & "images/SDMSLogo.PNG"
        End If
    End Sub
End Class
