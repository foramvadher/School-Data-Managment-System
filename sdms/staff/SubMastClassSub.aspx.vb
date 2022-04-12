Imports System.Data.SqlClient
Imports System.Data

Partial Class staff_SubMastClassSub
    Inherits System.Web.UI.Page
    Dim dp As New data_populate


    Sub bindgvClassSub()
        Dim msg = validatesearch()
        If msg <> "" Then
            lblMsgClassSub.Text = msg
            Exit Sub
        End If
        Dim sql As String = ""
        sql += "select * from vwClassSub where 1=1 "
        If ddClassNameSearch.Text.Trim <> "" Then
            sql += " and ClassCurrInfoId =" & ddClassNameSearch.Text.Trim & ";"
        End If

        dp.grid_view(sql, gvViewClassSub, True)

    End Sub

    Function validatesearch() As String
        validatesearch = ""
        Dim gf As New gen_fun
        Dim msg As String = ""
        msg = gf.checkLen(txtAddSub.Text, 150, " Disp Name", False)

        Return msg
    End Function

    Sub BindDD()

        Dim sql As String
        sql = "select ClassName+'-'+ section as classSection,ClassCurrInfoId from vwClassCurrInfo order by className,section"
        ddClassNameSearch.DataTextField = "classSection"
        ddClassNameSearch.DataValueField = "ClassCurrInfoId"
        dp.drop_down(sql, ddClassNameSearch)
        ddClassNameSearch.Items.Insert(0, New ListItem("Select", ""))

    End Sub


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindDD()
        End If
    End Sub


    Protected Sub btnAddClassSub_Click(sender As Object, e As EventArgs) Handles btnAddClassSub.Click
        hdnEditClassSub_ModalPopupExtender.Show()
    End Sub
    Sub insertupdate()
        Dim msg = validatesearch()
        If msg <> "" Then
            lblMsgClassSub.Text = msg
            Exit Sub
        End If
        Dim cmd As New SqlCommand

        Dim SubId() As String = txtAddSub.Text.Split("-")
        cmd.Parameters.AddWithValue("@ClassSubId", hdnClassSubId.Value)
        cmd.Parameters.AddWithValue("@ClassCurrInfoId", ddClassNameSearch.Text)
        cmd.Parameters.AddWithValue("@SubMastId", SubId(0))

        lblMsgClassSub.Text = dp.DMLCommands_para("spClassSub", cmd)
        bindgvClassSub()
        clearDataClassSub()
    End Sub
    Sub clearDataClassSub()
        hdnClassSubId.Value = 0
        txtAddSub.Text = ""
    End Sub


    Protected Sub gvViewClassSub_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvViewClassSub.RowCommand
        If e.CommandName = "Edit1" Then
            Dim ClassSubId As Integer = gvViewClassSub.DataKeys(e.CommandArgument).Values(0)
            bindPnlValues(ClassSubId)
            hdnEditClassSub_ModalPopupExtender.Show()
        End If
        If e.CommandName = "Delete1" Then
            Dim ClassSubId As Integer = gvViewClassSub.DataKeys(e.CommandArgument).Values(0)
            hdnConfirmClassSub_ModalPopupExtender.Show()
            hdnClassSubId.Value = ClassSubId
        End If

    End Sub



    Private Sub bindPnlValues(ByVal ClassSubId As Integer)
        Dim sql As String
        sql = "select * from vwClassSub where ClassSubId = " & ClassSubId
        Dim dt As DataTable
        dt = dp.data_table(sql)
        If dt.Rows.Count > 0 Then
            hdnClassSubId.Value = ClassSubId
            ddClassNameSearch.Text = dt.Rows(0)("ClassCurrInfoId")
            txtAddSub.Text = dt.Rows(0)("SubName").ToString


        End If

    End Sub

    Protected Sub btnSubmitClassSub_Click(sender As Object, e As EventArgs) Handles btnSubmitClassSub.Click
        insertupdate()
    End Sub

    Protected Sub ddClassNameSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddClassNameSearch.SelectedIndexChanged
        bindgvClassSub()
    End Sub
    '--------------------------------------------------------------------------------------------------------------------------------------------------

    Protected Sub btnSearchSubMast_Click(sender As Object, e As EventArgs) Handles btnSearchSubMast.Click
        bindgvSubMast()

    End Sub

    Sub bindgvSubMast()
        Dim msg = validatesearch()
        If msg <> "" Then
            lblMsgClassSub.Text = msg
            Exit Sub
        End If
        Dim SubId As String
        SubId = txtSubNameSearch.Text.Trim
        SubId.Split("-")
        Dim sql As String = ""
        sql += "select * from SubMast where 1=1 "
        If txtSubNameSearch.Text.Trim <> "" Then
            sql += " and SubMastId =" & SubId(0) & ";"
        End If

        dp.grid_view(sql, gvViewSubMast, True)

    End Sub

    Function validatesearchSub() As String
        validatesearchSub = ""
        Dim gf As New gen_fun
        Dim msg As String = ""
        msg = gf.checkLen(txtSubName.Text, 150, " Disp Name", False)

        Return msg
    End Function

    Sub insertupdateSub()
        Dim msg = validatesearch()
        If msg <> "" Then
            lblMsgClassSub.Text = msg
            Exit Sub
        End If
        Dim cmd As New SqlCommand

        cmd.Parameters.AddWithValue("@SubMastId", hdnSubMastId.Value)
        cmd.Parameters.AddWithValue("@SubName", txtSubName.Text)
        cmd.Parameters.AddWithValue("@SubDescription", txtSubDescription.Text)

        lblMsgSubMast.Text = dp.DMLCommands_para("spSubMast", cmd)
        bindgvSubMast()
        clearDataSubMast()
    End Sub
    Sub clearDataSubMast()
        hdnSubMastId.Value = 0
        txtSubName.Text = ""
        txtSubDescription.Text = ""
        txtSubNameSearch.Text = ""
    End Sub


    Protected Sub btnSubmitSubMast_Click(sender As Object, e As EventArgs) Handles btnSubmitSubMast.Click
        insertupdateSub()
    End Sub


    Protected Sub btnAddSubMast_Click(sender As Object, e As EventArgs) Handles btnAddSubMast.Click
        hdnEditSubMast_ModalPopupExtender.Show()
    End Sub

    Protected Sub btnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click
        Dim sql As String = ""
        sql = "delete from ClassSub where ClassSubId = " + hdnClassSubId.Value + ";"
        dp.data_table(sql)
        bindgvClassSub()

    End Sub

End Class
