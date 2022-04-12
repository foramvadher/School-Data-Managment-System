Imports System.Drawing
Imports iTextSharp.text
Imports System.IO
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf
Imports System.Data
Imports iTextSharp.tool.xml
Partial Class Reports_RptStudCurrInfo
    Inherits System.Web.UI.Page
    Dim dp As New data_populate

   
    Protected Sub ddClassSection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddClassSection.SelectedIndexChanged
        bindstudCurInfo()
        lblClass.Text = gvStudClassMap.DataKeys(0).Values(0).ToString & "-" & gvStudClassMap.DataKeys(1).Values(1).ToString
        lblClassTeacher.Text = gvStudClassMap.DataKeys(0).Values(2).ToString

    End Sub
    Sub bindstudCurInfo()
        Dim sql As String
        sql = "select *  from vwClassList where ClassCurrInfoID = 0" & ddClassSection.Text
        dp.grid_view(sql, gvStudClassMap, True)
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindDD()
        End If
    End Sub

    Sub BindDD()

        Dim sql As String
        sql = "select ClassName+'-'+ section as classSection,ClassCurrInfoId from vwClassCurrInfo order by className,section"
        ddClassSection.DataTextField = "classSection"
        ddClassSection.DataValueField = "ClassCurrInfoId"
        dp.drop_down(sql, ddClassSection)
        ddClassSection.Items.Insert(0, New System.Web.UI.WebControls.ListItem("--Select--", ""))

    End Sub

    Protected Sub btnExportPDF_Click(sender As Object, e As EventArgs) Handles btnExportPDF.Click
        Using sw As New StringWriter()
            Using hw As New HtmlTextWriter(sw)
                pnlPrint.RenderControl(hw)
                Dim sr As New StringReader(sw.ToString())
                Dim pdfDoc As New Document(PageSize.A4, 10.0F, 10.0F, 10.0F, 0.0F)
                Dim writer As PdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream)
                pdfDoc.Open()
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr)
                pdfDoc.Close()
                Response.ContentType = "application/pdf"
                Response.AddHeader("content-disposition", "attachment;filename=StudentListExport.pdf")
                Response.Cache.SetCacheability(HttpCacheability.NoCache)
                Response.Write(pdfDoc)
                Response.End()
            End Using
        End Using
    End Sub


    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        Exit Sub
    End Sub

End Class
