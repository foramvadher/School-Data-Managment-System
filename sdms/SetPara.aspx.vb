Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Partial Class SetPara
    Inherits System.Web.UI.Page
    Dim dp As New data_populate

    Protected Sub Upload(sender As Object, e As EventArgs)
        If Not FileUpload1.HasFile Then
            Exit Sub
        End If
        If ValidateImg() = True Then
            SaveImg()
            Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream)
            Dim height As Integer = img.Height
            Dim width As Integer = img.Width
            Dim size As Decimal = Math.Round((CDec(FileUpload1.PostedFile.ContentLength) / CDec(1024)), 2)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", "alert('Size: " & size.ToString() & "KB\nHeight: " & height.ToString() + "\nWidth: " & width.ToString() & "');", True)
        End If
        
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindYearValues()
            BindtxtValues()
        End If
      
    End Sub


    Sub SaveImg()
        Dim folderPath As String = Server.MapPath("~/images/")

        'Check whether Directory (Folder) exists.
        If Not Directory.Exists(folderPath) Then
            'If Directory (Folder) does not exists. Create it.
            Directory.CreateDirectory(folderPath)
        End If

        'Save the File to the Directory (Folder).
        Dim fileName As String = "SchoolLogo"
        FileUpload1.PostedFile.SaveAs(folderPath + fileName + ".png")

        'Display the success message.
        lblMsg.Text += Path.GetFileName(FileUpload1.FileName) + " has been uploaded."

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim msg = validatesearch()
        If msg <> "" Then
            lblMsg.Text += msg
            Exit Sub
        End If
        Upload(sender, e)
        InsertUpdate()

        Response.Redirect("~/staff/home.aspx")
    End Sub

    Private Sub BindYearValues()
        Dim dt As New DataTable
        Dim sql As String = "Select * from YearMast;"
        dt = dp.data_table(sql)
        If (dt.Rows.Count = 0) Then
            hdnFirstEntry.Value = True
            txtCurrYear.Visible = True
        Else
            hdnFirstEntry.Value = False
            ddCurrYear.DataTextField = "YearName"
            ddCurrYear.DataValueField = "YearMastId"
            dp.drop_down(sql, ddCurrYear)
            ddCurrYear.Items.Insert(0, New ListItem("--Select--", ""))
            ddCurrYear.Visible = True
        End If
    End Sub


    Function validatesearch() As String
        validatesearch = ""
        Dim gf As New gen_fun
        Dim msg As String = ""
        msg = gf.IsNumeric(txtCurrYear.Text, "YearMastId", False)
        msg += gf.checkLen(txtSchoolAddr.Text, 150, " Address ", False)
        msg += gf.checkLen(txtSchoolName.Text, 50, "School Name", False)


        Return msg
    End Function

    Private Sub BindtxtValues()
        Dim dt As New DataTable
        Dim sql As String = "Select * from GenCodeMast;"
        dt = dp.data_table(sql)
        If (dt.Rows.Count > 3) Then
            txtSchoolName.Text = dt.Rows(1)("para1")
            txtSchoolAddr.Text = dt.Rows(2)("para1")
            txtContactNo1.Text = dt.Rows(3)("para1")
            txtContactNo2.Text = dt.Rows(3)("para2")
            Session("YearMastId") = dt.Rows(0)("para1")
        End If
    End Sub

    Private Sub InsertUpdate()

        Dim cmd As New SqlCommand
        If hdnFirstEntry.Value = False Then
            cmd.Parameters.AddWithValue("@YearMastId", ddCurrYear.Text)
            Session("YearMastId") = ddCurrYear.Text
        Else
            Dim cmd1 As New SqlCommand
            cmd1.Parameters.AddWithValue("@YearMastId", "0")
            cmd1.Parameters.AddWithValue("@YearName", txtCurrYear.Text)
            Dim YearMastId As String
            YearMastId = dp.DMLCommands_para("spYearMast", cmd1)
            lblMsg.Text += YearMastId
            Dim dt As New DataTable
            Dim sql As String = "Select * from YearMast;"
            dt = dp.data_table(sql)
            cmd.Parameters.AddWithValue("YearMastId", dt.Rows(0)("YearMastId"))
            Session("YearMastId") = YearMastId

        End If

        cmd.Parameters.AddWithValue("@SchoolName", txtSchoolName.Text)
        cmd.Parameters.AddWithValue("@SchoolAddr", txtSchoolAddr.Text)
        cmd.Parameters.AddWithValue("@ContactNo1", txtContactNo1.Text)
        cmd.Parameters.AddWithValue("@ContactNo2", txtContactNo2.Text)

        lblMsg.Text += dp.DMLCommands_para("spGenCodeMast", cmd)
    End Sub

    Private Function ValidateImg() As Boolean
        Dim validFileTypes As String() = {"png"}
        Dim ext As String = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower
        Dim isValidFile As Boolean = False
        For i As Integer = 0 To validFileTypes.Length - 1
            If ext = "." & validFileTypes(i) Then
                isValidFile = True
                Exit For
            End If
        Next
        Dim size As Decimal = Math.Round((CDec(FileUpload1.PostedFile.ContentLength) / CDec(1024)), 2)
        If size > 100 Then
            MsgBox("File size must not exceed 100 KB.")
            lblMsg.ForeColor = System.Drawing.Color.Red
            lblMsg.Text = "Invalid File!!! Upload Failed "
            Return False
            'CustomValidator1.ErrorMessage = "File size must not exceed 100 KB."
        End If
        If Not isValidFile Then
            lblMsg.ForeColor = System.Drawing.Color.Red
            lblMsg.Text = "Invalid File. Please upload a File with extension " & _
                          String.Join(",", validFileTypes)
        Else
            lblMsg.ForeColor = System.Drawing.Color.Green
            lblMsg.Text = "File uploaded successfully."
            Return True
        End If
        
        Return False
    End Function

End Class
