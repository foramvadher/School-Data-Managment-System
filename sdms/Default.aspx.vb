Imports System.Data
Imports System.Data.SqlClient

Partial Class _Default
    Inherits System.Web.UI.Page
    Dim dp As New data_populate
    Dim err As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If Request.QueryString("err") Is Nothing Then
            err = "0"
        Else
            err = Request.QueryString("err")
        End If
        If Not IsPostBack Then
            errhandle()
            bindlogintype()
        End If
    End Sub
    Sub errhandle()
        If err = "1" Then
            lblMsg.Text = "Session Time Out"
        ElseIf err = "2" Then
            Session.Abandon()
            Session.RemoveAll()
        End If
    End Sub
    Sub bindlogintype()
        Dim sql As String
        sql = "select * from logintype"
        ddUserType.DataTextField = "LoginTypeName"
        ddUserType.DataValueField = "LoginTypeId"
        dp.drop_down(sql, ddUserType)
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim cmd As New SqlCommand
        cmd.Parameters.AddWithValue("@uid", txtUser.Text)
        cmd.Parameters.AddWithValue("@Passcode", txtPass.Text)
        cmd.Parameters.AddWithValue("@LoginTypeID", ddUserType.Text)
        Dim dt As DataTable
        dt = dp.data_table_para("spLogin", cmd)
        If dt.Rows.Count > 0 Then
            setsessionpara()
            If ddUserType.Text = "1" Then
                Session("DispName") = dt.Rows(0)("StaffDispName").ToString
                Session("StaffMastId") = dt.Rows(0)("StaffMastId").ToString
                Session("LoginId") = Session("StaffMastId").ToString

                If IsNothing(Session("YearMastId")) Then
                    Response.Redirect("~/setpara.aspx")
                End If
                Response.Redirect("~/Staff/home.aspx")
            Else
                Session("DispName") = dt.Rows(0)("StudDispName").ToString
                Session("StudMastId") = dt.Rows(0)("StudMastId").ToString
                Session("LoginId") = Session("StudMastId").ToString
                Session("GroupID") = 5
                Response.Redirect("~/student/StudentHome.aspx")
            End If

            lblMsg.Text = "sucess"
        Else
            lblMsg.Text = "Invalid Username or Password"
        End If

    End Sub
    Sub setsessionpara()
        Dim dt As DataTable
        Dim sql As String
        sql = "select * from GenCodeMast where fieldname like 'YearMastId'"
        dt = dp.data_table(sql)
        If dt.Rows.Count = 1 Then
            Session("YearMastId") = dt.Rows(0)("para1").ToString
        End If
    End Sub
End Class
