Imports System.Data
Imports System.Data.SqlClient

Partial Class ClassYearMast
    Inherits System.Web.UI.Page
    Dim dp As New data_populate

    Protected Sub btnAddClass_Click(sender As Object, e As EventArgs) Handles btnAddClass.Click
        insertupdateClass()
        clearDataClass()
    End Sub
    Sub bindgvClass()
        Dim sql As String
        sql = "select * from ClassMast order by ClassName"
        dp.grid_view(sql, gvClassMast, True)
    End Sub
    Sub insertupdateClass()
        Dim msg = validatesearch()
        If msg <> "" Then
            lblMsgClass.Text = msg
            Exit Sub
        End If
        Dim cmd As New SqlCommand
        cmd.Parameters.AddWithValue("@ClassMastId", hdnClassMastId.Value)
        cmd.Parameters.AddWithValue("@ClassName", txtAddClass.Text)

        lblMsgClass.Text = dp.DMLCommands_para("spClassMast", cmd)
        bindgvClass()

    End Sub
    Function validatesearch() As String
        validatesearch = ""
        Dim gf As New gen_fun
        Dim msg As String = ""
        msg = gf.checkLen(txtAddClass.Text, 10, " Class Name", False)
       


        Return msg
    End Function

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bindgvClass()
            bindgvYear()
        End If
    End Sub

    Protected Sub gvClassMast_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles gvClassMast.RowCancelingEdit
        gvClassMast.EditIndex = -1
        bindgvClass()
    End Sub

    Protected Sub gvClassMast_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles gvClassMast.RowEditing
        gvClassMast.EditIndex = e.NewEditIndex
        bindgvClass()
    End Sub

    Protected Sub gvClassMast_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles gvClassMast.RowUpdating
        hdnClassMastId.Value = e.Keys(0)
        txtAddClass.Text = e.NewValues(0)
        insertupdateClass()
        clearDataClass()
        gvClassMast.EditIndex = -1
        bindgvClass()

    End Sub

    Private Sub clearDataClass()
        txtAddClass.Text = ""
        hdnClassMastId.Value = 0
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------------------
    Protected Sub btnAddYear_Click(sender As Object, e As EventArgs) Handles btnAddYear.Click
        insertupdateYear()
        clearDataYear()
    End Sub

    Sub bindgvYear()
        Dim sql As String
        sql = "select * from YearMast order by YearName"
        dp.grid_view(sql, gvYearMast, True)
    End Sub
    Sub insertupdateYear()
        Dim msg = validatesearch()
        If msg <> "" Then
            lblMsgClass.Text = msg
            Exit Sub
        End If
        Dim cmd As New SqlCommand
        cmd.Parameters.AddWithValue("@YearMastId", hdnYearMastId.Value)
        cmd.Parameters.AddWithValue("@YearName", txtAddYear.Text)

        lblMsgYear.Text = dp.DMLCommands_para("spYearMast", cmd)
        bindgvYear()

    End Sub
    Function validatesearchYear() As String
        validatesearchYear = ""
        Dim gf As New gen_fun
        Dim msg As String = ""
        msg = gf.checkLen(txtAddYear.Text, 50, " Year Name", False)



        Return msg
    End Function

    Protected Sub gvYearMast_RowCancelingEdit(sender As Object, e1 As GridViewCancelEditEventArgs) Handles gvYearMast.RowCancelingEdit
        gvClassMast.EditIndex = -1
        bindgvYear()
    End Sub

    Protected Sub gvYearMast_RowEditing(sender As Object, e1 As GridViewEditEventArgs) Handles gvYearMast.RowEditing
        gvYearMast.EditIndex = e1.NewEditIndex
        bindgvYear()
    End Sub

    Protected Sub gvYearMast_RowUpdating(sender As Object, e1 As GridViewUpdateEventArgs) Handles gvYearMast.RowUpdating
        hdnYearMastId.Value = e1.Keys(0)
        txtAddYear.Text = e1.NewValues(0)
        insertupdateYear()
        clearDataYear()
        gvYearMast.EditIndex = -1
        bindgvYear()

    End Sub

    Private Sub clearDataYear()
        txtAddYear.Text = ""
        hdnYearMastId.Value = 0
    End Sub
End Class
