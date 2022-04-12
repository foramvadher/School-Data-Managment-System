Imports System.Data.SqlClient
Imports System.Data

Partial Class staff_ExamMast
    Inherits System.Web.UI.Page
    Dim dp As New data_populate
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        bindGV()
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

            BindDD()
        End If
    End Sub

    Sub BindDD()
        Dim sql As String
        sql = "Select * from ExamTypeMast order by ExamTypeName; "
        ddExamTypeAdd.DataValueField = "ExamTypeMastId"
        ddExamTypeAdd.DataTextField = "ExamTypeName"
        dp.drop_down(sql, ddExamTypeAdd)

    End Sub

    Sub bindGV()
        Dim sql As String
        sql = "select * from vwExamMast where 1=1"

        If txtExamNameSearch.Text.Trim <> "" Then
            sql += " and ExamName like '%" & txtExamNameSearch.Text.Trim & "%'"
        End If
        dp.grid_view(sql, gvExamMast, True)
    End Sub


    Private Sub clearData()
        txtExamNameAdd.Text = ""
        hdnExamMastId.Value = 0
    End Sub
    Sub insertupdate()
        Dim msg = validatesearch()
        If msg <> "" Then
            lblMsg.Text = msg
            Exit Sub
        End If
        Dim cmd As New SqlCommand
        cmd.Parameters.AddWithValue("@ExamMastId", hdnExamMastId.Value)
        cmd.Parameters.AddWithValue("@ExamName", txtExamNameAdd.Text)
        cmd.Parameters.AddWithValue("@ExamTypeMastId", ddExamTypeAdd.Text)
        cmd.Parameters.AddWithValue("@TotalMarks", txtTotalMarksAdd.Text)
        cmd.Parameters.AddWithValue("@PassingMarks", txtPassingMarksAdd.Text)
        cmd.Parameters.AddWithValue("@ConsiderForFinal", chbConsiderForFinal.Checked)
        cmd.Parameters.AddWithValue("@Weightage", txtWeightage.Text)
        lblMsg.Text = dp.DMLCommands_para("spExamMast", cmd)
        bindGV()

    End Sub
    Function validatesearch() As String
        validatesearch = ""
        Dim gf As New gen_fun
        Dim msg As String = ""
        msg = gf.checkLen(txtExamNameAdd.Text, 50, " Exam Name", False)

        If CInt(txtPassingMarksAdd.Text) > CInt(txtTotalMarksAdd.Text) Then
            msg += "Inappropriate Passing Marks..."
        End If
        If chbConsiderForFinal.Checked = True Then
            If txtWeightage.Text = 0 Or txtWeightage.Text = 100 Then
                msg += "Inappropriate Weightage..."
            End If
        Else

        End If


        Return msg
    End Function

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        insertupdate()
        clearData()
    End Sub

    Protected Sub gvStaffMast_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvExamMast.RowCommand
        If e.CommandName = "Edit1" Then
            Dim ExamMastId As Integer = gvExamMast.DataKeys(e.CommandArgument).Values(0)
            bindPnlValues(ExamMastId)
            hdnEdit_ModalPopupExtender.Show()
        End If

    End Sub

    Private Sub bindPnlValues(ByVal ExamMastId As Integer)
        Dim sql As String
        sql = "select * from ExamMast where ExamMastId = " & ExamMastId
        Dim dt As DataTable
        dt = dp.data_table(sql)
        If dt.Rows.Count > 0 Then
            hdnExamMastId.Value = ExamMastId
            txtExamNameAdd.Text = dt.Rows(0)("ExamName").ToString
            txtPassingMarksAdd.Text = dt.Rows(0)("PassingMarks").ToString
            txtTotalMarksAdd.Text = dt.Rows(0)("TotalMarks").ToString
            chbConsiderForFinal.Text = dt.Rows(0)("ConsiderForFinal").ToString
            txtWeightage.Text = dt.Rows(0)("Weightage").ToString
        End If

    End Sub

    Protected Sub chbConsiderForFinal_CheckedChanged(sender As Object, e As EventArgs) Handles chbConsiderForFinal.CheckedChanged
        If chbConsiderForFinal.Checked Then
            txtWeightage.Visible = True
            lblWeightage.Visible = True
        Else
            txtWeightage.Visible = False
            lblWeightage.Visible = False
        End If
        btnAddExam_ModalPopupExtender.Show()
    End Sub
End Class
