Imports System.Drawing
Imports iTextSharp.text
Imports System.IO
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf
Imports System.Data
Imports iTextSharp.tool.xml

Partial Class Reports_RptStaffInfo
    Inherits System.Web.UI.Page
    Dim dp As New data_populate

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        bindstaffCurInfo()
    End Sub
    Sub bindstaffCurInfo()
        Dim sql As String
        sql = "select *  from StaffMast order by StaffDispName"
        dp.grid_view(sql, gvStaffList, True)
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
                Response.AddHeader("content-disposition", "attachment;filename=StaffListExport.pdf")
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
