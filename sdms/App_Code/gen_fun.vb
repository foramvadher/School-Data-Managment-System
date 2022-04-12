Imports System.Data
Imports System.Data.SqlClient
Imports System.Text


Public Class gen_fun
    Dim dp As New data_populate
    Public Function GetFieldValue(ByVal myreader As SqlDataReader, ByVal FieldName As String) As String
        If IsDBNull(myreader(FieldName)) = True Then
            Return ""
        Else
            Return CStr(myreader(FieldName))
        End If
    End Function
    
    
    Public Function validate_page(ByVal screen_name As String, ByVal emp_no As Integer, Optional ByVal apps As String = "itams") As Boolean
        Dim strConn = System.Configuration.ConfigurationManager.AppSettings("connectionstring")
        Dim sqlcon As New SqlConnection(strConn)
        Dim strsql As String
        Dim ans As Boolean = False
        strsql = "SELECT screen_id  FROM vwMenu where emp_no = " & emp_no & " and navigateurl = '" & screen_name & "' union select screen_id from adm_screen_mast where apps = '" & apps & "'  and for_all = 'Y' and navigateurl = '" & screen_name & "'"
        Dim comm As New SqlCommand
        comm.CommandText = strsql
        comm.Connection = sqlcon
        Dim myReader As SqlDataReader
        sqlcon.Open()
        myReader = comm.ExecuteReader
        myReader.Read()
        If myReader.HasRows Then
            ans = True
        Else
            ans = False
        End If
        sqlcon.Close()
        Return ans
    End Function

    Public Function val_page_sid(ByVal sid As String)
        Dim mr As SqlDataReader
        Dim strsql = "select * from general.dbo.sso_session where session_id  = '" & sid & "'"

        mr = dp.data_reader(strsql)
        If mr.Read Then
            val_page_sid = mr("emp_no")
        Else
            val_page_sid = 0
        End If
    End Function
    Public Function sql_date(ByVal dt As String) As String
        Dim dt1 As Date = dt
        sql_date = String.Format("{0:MM/dd/yyyy}", dt1)
    End Function
    Public Function cnvt_chk(ByVal checkbox1 As CheckBox) As Integer
        If checkbox1.Checked = True Then
            cnvt_chk = 1
        Else
            cnvt_chk = 0
        End If
    End Function
    Public Function WeekOfMonth(ByVal dteInputDate As Date) As Integer
        Dim intDate As Integer
        intDate = Day(dteInputDate)
        WeekOfMonth = (intDate \ 7) + 1 + (intDate Mod 7 = 0)
    End Function
    Public Function num_to_null(ByVal txt As TextBox) As String
        If txt.Text = "" Then
            num_to_null = "null"
        Else
            num_to_null = txt.Text
        End If
    End Function
    Function get_prev_date(ByVal wkday As String, Optional ByVal no_of_week As Integer = 0)
        Dim wd As Integer
        Select Case wkday
            Case "Monday"
                wd = 1
            Case "Tuesday"
                wd = 2
            Case "Wednesday"
                wd = 3
            Case "Thrusday"
                wd = 4
            Case "Friday"
                wd = 5
            Case "Saturday"
                wd = 6
            Case "Sunday"
                wd = 7
        End Select
        Dim ret_date As Date
        wd = (wd - Today.DayOfWeek)
        If wd > 0 Then wd = wd - 7
        wd = wd - (no_of_week * 7)
        ret_date = DateAdd(DateInterval.Day, wd, Today)
        Return ret_date
    End Function
    Function sendmail(ByVal txt_to As String, ByVal subj As String, ByVal txtbody As String) As Boolean
        sendmail = False
        Dim addrFrom As System.Net.Mail.MailAddress = New System.Net.Mail.MailAddress("itadmin_kaps@npcil.co.in")
        Dim addto(0) As String
        addto(0) = txt_to 'txtmail.Text.Split(New Char() {","})
        Dim msg1 As New System.Net.Mail.MailMessage
        For Each s As String In addto
            msg1.To.Add(s)
        Next
        msg1.From = addrFrom
        msg1.Subject = subj
        msg1.IsBodyHtml = True
        msg1.Body = txtbody

        Dim mailClient As New System.Net.Mail.SmtpClient()
        Dim basicAuthenticationInfo As New System.Net.NetworkCredential("itadmin_kaps", "kingfisher@123")
        'Put your own, or your ISPs, mail server name onthis next line
        mailClient.Host = "10.30.3.121"
        mailClient.UseDefaultCredentials = False
        mailClient.Credentials = basicAuthenticationInfo
        Try
            mailClient.Send(msg1)
            sendmail = True
        Catch ex As Exception
            sendmail = False
        End Try
    End Function
    Public Function IsNumeric(str As String, nameoffield As String, Optional Mandatory As Boolean = True) As String
        Dim msg As String = ""
        nameoffield = "<span style = 'color:Maroon;font-weight:bold'>" & nameoffield & "</span>"
        If str.Trim = "" And Mandatory Then
            msg = nameoffield & "<span style = 'color:red'> cannot be blank</span>"
            Return msg
            Exit Function
        End If
        Dim num As Double
        If str.Trim <> "" Then
            If Not Double.TryParse(str, num) Then
                msg = nameoffield & "<span style = 'color:red'> not a Numeric value</span>"
            End If
        End If
        Return msg
    End Function

    'validationn for the format dd/MM/yyyy only
    Public Function checkDate(ByVal str As String, nameoffield As String, Optional Mandatory As Boolean = True) As String
        Dim msg As String = ""
        nameoffield = "<span style = 'color:Maroon;font-weight:bold'>" & nameoffield & "</span>"
        If str.Trim = "" And Mandatory Then
            msg = nameoffield & "<span style = 'color:red'> cannot be blank</span>"
            Return msg
            Exit Function
        End If
        Dim m As Date
        If str.Trim <> "" Then
            If Not Date.TryParse(str, m) Then
                msg = nameoffield & "<span style = 'color:red'> not a Valid Date</span>"
            End If
        End If
        Return msg
    End Function

    Public Function datevalidate(ByVal pres_date As String, nameoffield As String, Optional Mandatory As Boolean = True) As Boolean
        Dim s As String
        Dim splited_date(3) As String
        Dim date_pre As String
        Dim month As String
        Dim year As String

        If (Len(Trim(pres_date))) = 0 Or pres_date.Length > 10 Then
            Return False
            Exit Function
        Else
            Dim pos As Integer
            pos = InStr(1, Trim(pres_date), "/")
            If InStr(pos + 1, Trim(pres_date), "/") <> 0 Then
                Try
                    s = Trim(pres_date)
                    splited_date = s.Split("/")
                    date_pre = splited_date(0)
                    month = splited_date(1)
                    year = splited_date(2)
                    Dim d As New Date(Right(s, 4), Mid(s, 4, 2), Left(s, 2))
                    If d > Today() Then
                        pres_date = ""
                        Return False

                        Exit Function
                    End If
                Catch ex As Exception
                    pres_date = ""
                    Return False
                    Exit Function
                End Try
            Else
                pres_date = ""
                Return False
                Exit Function
            End If
        End If
        Return True
    End Function

    Public Function charvalidation(str As [String]) As Boolean
        Dim charactersDisallowed As String = "1234567890"
        Dim Letter As String
        For x As Integer = 0 To str.Length - 1
            Letter = str.Substring(x, 1)
            If charactersDisallowed.Contains(Letter) Then
                Return False
                Exit Function
            End If
        Next
        Return True
    End Function

    Public Function checkLen(str As String, len As Integer, nameoffield As String, Optional Mandatory As Boolean = False) As String
        Dim msg As String = ""
        nameoffield = "<span style = 'color:Maroon;font-weight:bold'>" & nameoffield & "</span>"

        If Mandatory And str.Trim.Length = 0 Then
            msg = nameoffield & " cannot be blank"
            Return msg
            Exit Function
        End If
        If str.Length > len Then
            msg = "Length of " & nameoffield & " cannot be greater then " & len
            Return msg
            Exit Function
        End If
        msg = textvalidation(str)
        Return msg
    End Function

    Public Function textvalidation(str As String) As String
        Dim charactersDisallowed As String = "'"
        Dim msg As String = ""
        Dim Letter As String
        For x As Integer = 0 To str.Length - 1
            Letter = str.Substring(x, 1)
            If charactersDisallowed.Contains(Letter) Then
                msg = "Special character like ' are now allowed"
                Return msg
                Exit Function
            End If
        Next
        If str.Contains("--") Then
            msg = "Special character like -- are now allowed"
            Return msg
            Exit Function
        End If
        If str.Contains("script") Then
            msg = "Scripts are not allowed"
            Return msg
            Exit Function
        End If
        Return msg
    End Function

    Public Function checkDDSelect(selIndex As Integer, nameoffield As String) As String
        Dim msg As String = ""
        nameoffield = "<span style = 'color:Maroon;font-weight:bold'>" & nameoffield & "</span>"

        If selIndex = 0 Then
            msg = " Value not selected for " & nameoffield
            Return msg
            Exit Function
        End If

        Return msg
    End Function

    Public Sub HandleError(ex As Exception)
        MsgBox("Some Error Occured!!!", MsgBoxStyle.Exclamation)
        Dim objWriter As New System.IO.StreamWriter("E:/sdms/ErrorFile.txt")
        objWriter.WriteLine(ex.Message)
    End Sub

End Class
