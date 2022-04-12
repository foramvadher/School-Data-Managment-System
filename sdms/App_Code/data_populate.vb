Imports System.Data
Imports System.Data.SqlClient
Imports System.Net
Imports System.Configuration
Imports System.Web.UI.WebControls

Public Class data_populate
    Dim lbl As Label
    Public strConn As String = ConfigurationSettings.AppSettings("sqlcon")
    Dim WithEvents con As New SqlConnection(ConfigurationManager.AppSettings("sqlcon").ToString())
    Dim msg As String = ""

    Function grid_view(ByVal strsql As String, ByVal gv As GridView, Optional ByVal showrowcount As Boolean = False) As Integer
        Dim sqlcon As New SqlConnection(strConn)
        Dim comm As New SqlCommand(strsql, sqlcon)
        sqlcon.Open()
        comm.CommandText = strsql
        Dim myDataAdapter As SqlDataAdapter = New SqlDataAdapter(strsql, sqlcon)
        Dim myDataSet As DataSet = New DataSet
        myDataAdapter.Fill(myDataSet, "emptbl")
        Dim RcdCount As Integer
        RcdCount = myDataSet.Tables("emptbl").Rows.Count.ToString()
        gv.DataSource = myDataSet
        gv.DataBind()
        sqlcon.Close()
        If showrowcount Then
            If RcdCount = 0 Then
                gv.Caption = "<table border='1' width='100%' cellpadding='3' cellspacing='0' bordercolor='#000000' bgcolor='#99CCFF' style='border-collapse: collapse'><tr><td><font face='Arial' size='2' color='darkblue' ><b>There is no result to Your Search</b></font></td></tr></table>"
            Else
                gv.Caption = "<table border='1' width='100%' cellpadding='3' cellspacing='0' bordercolor='#000000' bgcolor='#99CCFF' style='border-collapse: collapse'><tr><td><font face='Arial' size='2' color='#800000' ><b>Total Records : " & RcdCount & "</b></font></td></tr></table>"
            End If
        End If
        gv.Visible = True
        Return RcdCount
    End Function

    Function data_reader(ByVal strsql As String) As SqlDataReader
        Dim sqlcon As New SqlConnection(strConn)
        Dim myReader As SqlDataReader
        sqlcon.Open()
        Dim mycom As New SqlCommand(strsql, sqlcon)
        myReader = mycom.ExecuteReader(CommandBehavior.CloseConnection)
        data_reader = myReader
    End Function

    Function data_table(ByVal strsql As String) As DataTable
        Dim sqlcon As New SqlConnection(strConn)
        Dim dt As New DataTable
        Dim myReader As SqlDataReader
        sqlcon.Open()
        Dim mycom As New SqlCommand(strsql, sqlcon)
        myReader = mycom.ExecuteReader()
        dt.Load(myReader)
        data_table = dt
        myReader.Close()
        sqlcon.Close()
    End Function

    Public Function data_table_para(ByVal sp As String, ByRef cmd As SqlCommand) As DataTable
        Dim dt As New DataTable
        cmd.Connection = con
        cmd.CommandText = sp
        cmd.CommandType = CommandType.StoredProcedure
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim myReader As SqlDataReader
            myReader = cmd.ExecuteReader()
            dt.Load(myReader)
            data_table_para = dt
            myReader.Close()

        Catch ex As Exception
            msg = ex.Message
        Finally
            con.Close()
        End Try
        Return dt
    End Function

    Sub grid_msg(ByVal rcdcount As Integer, ByRef lbl As Label)
        If rcdcount = 0 Then
            lbl.Text = "There is no Record"
            lbl.Visible = True
        Else
            lbl.Text = ""
            lbl.Visible = False
        End If
    End Sub

    Function save_sql(ByVal strsql As String, Optional ByVal msg As String = "Record Saved Sucessfully") As String
        Dim sqlcon As New SqlConnection(strConn)
        Dim comm As New SqlCommand(strsql, sqlcon)
        Dim aRow As String
        Try
            sqlcon.Open()
            aRow = comm.ExecuteNonQuery()
            If msg = "rows" Then
                save_sql = aRow
            Else
                save_sql = msg
            End If
        Catch ex As Exception
            save_sql = ex.Message
            'sqlcon.BeginTransaction.Rollback()
        End Try
        sqlcon.Close()
    End Function

    Public Function DMLCommands_para(ByVal sp As String, ByRef cmd As SqlCommand) As String
        cmd.Connection = con
        'AddHandler con.InfoMessage, New SqlInfoMessageEventHandler(AddressOf con_InfoMessage)
        AddHandler con.InfoMessage, Function(sender, e) con_InfoMessage(sender, e)

        ' con.InfoMessage += Sub(sender As Object, e As SqlInfoMessageEventArgs) msg = e.Message
        cmd.CommandText = sp
        cmd.CommandType = CommandType.StoredProcedure
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            msg = ex.Message
        Finally

            con.Close()
        End Try
        Return msg
    End Function

    Public Function DMLCmdComanasTxt(sp As String, cmd As SqlCommand) As String
        cmd.Connection = con
        AddHandler con.InfoMessage, Function(sender, e) con_InfoMessage(sender, e)

        cmd.CommandText = sp
        cmd.CommandType = CommandType.Text
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        cmd.ExecuteNonQuery()
        con.Close()
        Return msg
    End Function

    Private Function con_InfoMessage(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlInfoMessageEventArgs) As Boolean
        msg = e.Message
        Return True
    End Function

    Function drop_down(ByVal strsql As String, ByVal dd As DropDownList) As Integer
        Dim sqlcon As New SqlConnection(strConn)
        Dim comm As New SqlCommand(strsql, sqlcon)
        Dim myReader As SqlDataReader
        sqlcon.Open()
        comm.CommandText = strsql
        myReader = comm.ExecuteReader(CommandBehavior.CloseConnection)
        dd.DataSource = myReader
        dd.DataBind()
        sqlcon.Close()
    End Function

    Function list_box(ByVal strsql As String, ByVal ls As ListBox) As Integer
        Dim sqlcon As New SqlConnection(strConn)
        Dim comm As New SqlCommand(strsql, sqlcon)
        Dim myReader As SqlDataReader
        sqlcon.Open()
        comm.CommandText = strsql
        myReader = comm.ExecuteReader(CommandBehavior.CloseConnection)
        ls.DataSource = myReader
        ls.DataBind()
        sqlcon.Close()
    End Function




End Class
