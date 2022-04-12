Imports System.Data

Partial Class Student_StudInfo
    Inherits System.Web.UI.Page
    Dim dp As New data_populate

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        hdnStudMastId.Value = Session("LoginId")
        BindValues()
    End Sub

    Private Sub BindValues()
        Dim dt As New DataTable
        Dim sql As String
        sql = "Select * from StudMast where StudMastId = " & hdnStudMastId.Value.ToString
        dt = dp.data_table(sql)
        lblStudDispName.Text = dt.Rows(0)("StudDispName")
        lblAadharNo.Text = dt.Rows(0)("AadharNo")
        lblAddress.Text = dt.Rows(0)("Addr")
        lblAdmnDate.Text = dt.Rows(0)("DateOfAdmn")
        lblBG.Text = dt.Rows(0)("BG")
        lblAdmnNo.Text = dt.Rows(0)("AdmnNo")
        lblCategoryId.Text = dt.Rows(0)("CategoryId")
        lblDOB.Text = dt.Rows(0)("DOB")
        lblFatherName.Text = dt.Rows(0)("FatherName")
        lblIdentificationMark.Text = dt.Rows(0)("IdentificationMark")
        lblMailId.Text = dt.Rows(0)("MailId")
        lblMotherName.Text = dt.Rows(0)("MotherName")
        lblPhoneNoLL.Text = dt.Rows(0)("PhNoLL")
        lblPhoneNoMob.Text = dt.Rows(0)("PhNoMob")
        lblStudFirstName.Text = dt.Rows(0)("StudFirstName")
        lblStudLastName.Text = dt.Rows(0)("StudLastName")
        lblStudMidName.Text = dt.Rows(0)("StudMidName")
    End Sub
End Class
