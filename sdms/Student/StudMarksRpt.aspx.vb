Imports System.Data.SqlClient
Imports System.Data

Partial Class Student_StudMarksRpt
    Inherits System.Web.UI.Page
    Dim dp As New data_populate
    Dim ExamMastID() As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindDDClass()
        End If
    End Sub
    Sub bindgv()
        Dim sql As String
        Dim cmd As New SqlCommand
        cmd.Parameters.AddWithValue("@StudCurrInfoID", 9)
        sql = "spMarksSelect"
        Dim dt As DataTable
        dt = dp.data_table_para(sql, cmd)
        dt.Columns.Add("Total")

        gvStudMarks.DataSource = dt
        gvStudMarks.DataBind()

    End Sub
    Private Sub BindDDClass()
        Dim sql As String
        sql = "select ClassName+'-'+ section as classSection,ClassCurrInfoId from vwClassCurrInfo order by className,section"
        ddClass.DataTextField = "classSection"
        ddClass.DataValueField = "ClassCurrInfoId"
        dp.drop_down(sql, ddClass)
        ddClass.Items.Insert(0, New ListItem("--SELECT--", ""))
    End Sub


    Protected Sub ddClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddClass.SelectedIndexChanged
        bindgv()
    End Sub

    Protected Sub gvStudMarks_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvStudMarks.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then
            Dim I As Integer = 0
            Dim dt As DataTable
            Dim dc As DataControlFieldHeaderCell
            For Each dc In e.Row.Cells
                If Not (I = 0 Or I = 1 Or I = e.Row.Cells.Count - 1) Then
                    ReDim Preserve ExamMastID(I + 1)
                    ExamMastID(I) = dc.Text
                    dt = dp.data_table("select * from exammast left join examtypemast on exammast.ExamTypeMastID = examtypemast.ExamTypeMastID where ExamMastID = " & ExamMastID(I))
                    dc.Text = dt.Rows(0)("ExamName").ToString & dt.Rows(0)("ExamTypeName").ToString
                End If
                I += 1
            Next
        End If
    End Sub
End Class
