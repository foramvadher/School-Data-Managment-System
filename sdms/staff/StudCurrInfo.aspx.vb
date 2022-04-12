Imports System.Data.SqlClient

Partial Class staff_StudCurrInfo
    Inherits System.Web.UI.Page
    Dim dp As New data_populate

    Protected Sub btnOrganize_Click(sender As Object, e As EventArgs) Handles btnOrganize.Click
        UpdateRoll()
    End Sub

    Sub insertupdate()
        Dim msg = validatesearch()
        If msg <> "" Then
            lblMsg.Text = msg
            Exit Sub
        End If
        Dim StudentId() As String = txtStudent.Text.Split("-")

        Dim cmd As New SqlCommand
        cmd.Parameters.AddWithValue("@StudCurrInfoId", hdnStudCurrInfoId.Value)
        cmd.Parameters.AddWithValue("@StudMastId", StudentId(0))
        cmd.Parameters.AddWithValue("@ClassCurrInfoId", ddClassSection.Text)
        cmd.Parameters.AddWithValue("@YearMastId", Session("YearMastId"))
        cmd.Parameters.AddWithValue("@RollNo", txtRollNo.Text)

        lblMsg.Text = dp.DMLCommands_para("spStudCurrInfo", cmd)
        bindgvStudCurinfo()

    End Sub
    Function validatesearch() As String
        validatesearch = ""
        Dim gf As New gen_fun
        Dim msg As String = ""
        msg = gf.IsNumeric(txtRollNo.Text, "Roll No.", True)

        Return msg
    End Function

    Private Sub clearData()
        txtRollNo.Text = ""
        'txtStudent = ""
        hdnStudCurrInfoId.Value = 0
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        insertupdate()
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            binddd()
            'bindgvStudCurinfo()
        End If
    End Sub
    Sub binddd()
        Dim sql As String
        sql = "select ClassName+'-'+ section as classSection,ClassCurrInfoId from vwClassCurrInfo order by className,section"
        ddClassSection.DataTextField = "ClassSection"
        ddClassSection.DataValueField = "ClassCurrInfoId"
        dp.drop_down(sql, ddClassSection)
    End Sub
    Sub bindgvStudCurinfo()
        Dim sql As String
        Dim class1() As String = ddClassSection.SelectedItem.Text.Split("-")
        sql = "select * from vwStudClassMap where classname = '" & class1(0) & "' and  section = '" & class1(1) & "'  order by StudDispName"
        dp.grid_view(sql, gvStudClassMap)

    End Sub

    Private Sub UpdateRoll()
        Dim cmd As New SqlCommand
        cmd.Parameters.AddWithValue("@ClassCurrInfoID", ddClassSection.Text)

        lblMsg.Text = dp.DMLCommands_para("spStudRollNo", cmd)
        bindgvStudCurinfo()
    End Sub

    Protected Sub ddClassSection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddClassSection.SelectedIndexChanged
        bindgvStudCurinfo()

    End Sub
End Class
