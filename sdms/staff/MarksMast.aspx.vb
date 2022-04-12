Imports System.Data.SqlClient

Partial Class MarksMast
    Inherits System.Web.UI.Page
    Dim dp As New data_populate

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindDDClass()
            BindDDExam()
        End If
    End Sub

    Protected Sub ddClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddClass.SelectedIndexChanged
        BindDDSub()
    End Sub

    Private Sub BindDDClass()
        Dim sql As String
        sql = "select ClassName+'-'+ section as classSection,ClassCurrInfoId from vwClassCurrInfo order by className,section"
        ddClass.DataTextField = "classSection"
        ddClass.DataValueField = "ClassCurrInfoId"
        dp.drop_down(sql, ddClass)
        ddClass.Items.Insert(0, New ListItem("--SELECT--", ""))
    End Sub
    Private Sub BindDDExam()
        Dim sql As String
        sql = "select * from ExamMast order by ExamName"
        ddExam.DataTextField = "ExamName"
        ddExam.DataValueField = "ExamMastId"
        dp.drop_down(sql, ddExam)
        ddExam.Items.Insert(0, New ListItem("--SELECT--", ""))
    End Sub
    Private Sub BindDDSub()
        Dim sql As String
        sql = "select * from vwClassSub where ClassCurrInfoId = " + ddClass.Text

        ddSub.DataTextField = "SubName"
        ddSub.DataValueField = "SubMastId"
        dp.drop_down(sql, ddSub)
        ddSub.Items.Insert(0, New ListItem("--SELECT--", ""))
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If validation() Then
            hdnClass.Value = ddClass.Text
            hdnExam.Value = ddExam.Text
            hdnSub.Value = ddSub.Text
            Bindgv()
        End If    
    End Sub

    Private Sub Bindgv()
        Dim sql As String
        sql = "select A.*,B.Marks,b.studmarksid from vwStudCurrInfo A left join (select * from vwStudCurrMarks where ExamMastId=" & hdnExam.Value & " and SubMastId=" & hdnSub.Value & " and YearMastId=" & Session("YearMastId") & ") B on A.StudCurrInfoId = B.StudCurrInfoId where A.ClassCurrInfoId =" & hdnClass.Value
        dp.grid_view(sql, gvMarks, True)
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If validation() Then
            InsertMarks()
        End If
    End Sub

    Sub InsertMarks()
        Dim sql As String = ""
        Dim studCurrInfo As Integer
        Dim StudMarksId As String


        For Each dr As GridViewRow In gvMarks.Rows
            Dim txtMarks As TextBox
            txtMarks = dr.FindControl("txtMarks")
            studCurrInfo = gvMarks.DataKeys(dr.RowIndex).Values(0).ToString
            StudMarksId = gvMarks.DataKeys(dr.RowIndex).Values(1).ToString
            If StudMarksId = "" Then
                StudMarksId = 0
            End If
            Dim cmd As New SqlCommand
            cmd.Parameters.AddWithValue("@StudMarksId", StudMarksId)
            cmd.Parameters.AddWithValue("@Marks", txtMarks.Text)
            cmd.Parameters.AddWithValue("@StudCurrInfoId", studCurrInfo)
            cmd.Parameters.AddWithValue("@StaffMastId", Session("StaffMastId"))
            cmd.Parameters.AddWithValue("@SubMastId", hdnSub.Value)
            cmd.Parameters.AddWithValue("@ExamMastId", hdnExam.Value)

            lblMsg.Text = dp.DMLCommands_para("spStudMarks", cmd)
            Bindgv()
        Next
    End Sub
    Function validation() As Boolean
        Dim _validation As Boolean = True
        If ddClass.SelectedIndex = 0 Then
            _validation = False
            lblMsg.Text += "Please Select Class..."
        End If
        If ddExam.SelectedIndex = 0 Then
            _validation = False
            lblMsg.Text += "Please Select Exam..."
        End If
        If ddSub.SelectedIndex = 0 Then
            _validation = False
            lblMsg.Text += "Please Select Subject..."
        End If
        Return _validation

    End Function

End Class
