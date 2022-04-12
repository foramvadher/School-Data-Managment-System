Imports System.Data.SqlClient

Partial Class ClassCurrInfo
    Inherits System.Web.UI.Page

    Dim dp As New data_populate

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bindgvClass()
            bindClassDropDown()
        End If

    End Sub
    Sub bindgvClass()
        Dim sql As String
        sql = "select * from vwClassCurrInfo order by ClassName"
        dp.grid_view(sql, gvClassCurrInfo, True)
    End Sub
    Protected Sub btnAddClass_Click(sender As Object, e As EventArgs) Handles btnAddClassInfo.Click
        insertupdate()

    End Sub
    Sub insertupdate()
        Dim msg = validatesearch()
        If msg <> "" Then
            lblMsgClass.Text = msg
            Exit Sub
        End If
        Dim cmd As New SqlCommand
        Dim StaffInfo As String
        StaffInfo = txtClassTeacher.Text
        StaffInfo.Split("-")
        cmd.Parameters.AddWithValue("@ClassCurrInfoId",hdnClassCurrInfoId.Value)
        cmd.Parameters.AddWithValue("@ClassId", ddClass.Text)
        cmd.Parameters.AddWithValue("@Section", txtSection.Text)
        cmd.Parameters.AddWithValue("@StaffId", StaffInfo(0).ToString)
        cmd.Parameters.AddWithValue("@YearMastId", Session("YearMastId"))
        lblMsgClass.Text = dp.DMLCommands_para("spClassCurrInfo", cmd)
        bindgvClass()
        clearData()
    End Sub
    Function validatesearch() As String
        validatesearch = ""
        Dim gf As New gen_fun
        Dim msg As String = ""
        msg = gf.checkLen(txtSection.Text, 10, " Section", False)

        Return msg
    End Function
    Sub bindClassDropDown()
        Dim sql As String
        sql = "select * from ClassMast"
        ddClass.DataTextField = "ClassName"
        ddClass.DataValueField = "ClassMastId"
        dp.drop_down(sql, ddClass)
    End Sub
    Sub clearData()
        txtClassTeacher.Text = ""
        'ddClass.Text = ""
        txtSection.Text = ""
    End Sub
    Protected Sub gvClassMast_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles gvClassCurrInfo.RowCancelingEdit
        gvClassCurrInfo.EditIndex = 0
        bindgvClass()
    End Sub

    Protected Sub gvClassMast_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles gvClassCurrInfo.RowEditing
        gvClassCurrInfo.EditIndex = e.NewEditIndex
        bindgvClass()
    End Sub

    Protected Sub gvClassMast_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles gvClassCurrInfo.RowUpdating
        hdnClassCurrInfoId.Value = e.Keys(0)
        txtClassTeacher.Text = e.NewValues(0)
        insertupdate()
        clearData()
        gvClassCurrInfo.EditIndex = -1
        bindgvClass()

    End Sub
End Class
