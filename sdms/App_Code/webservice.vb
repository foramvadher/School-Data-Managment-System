Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class webservice
    Inherits System.Web.Services.WebService
    Dim dp As New data_populate

    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    <WebMethod()> _
    Public Function SearchStaff(ByVal prefixText As String, ByVal count As Integer) As List(Of String)

        Dim sql As String
        sql = "select * from staffmast where staffdispname like '%" & prefixText & "%'"
        Dim Staff As List(Of String) = New List(Of String)
        Dim dt As DataTable
        dt = dp.data_table(sql)
        For Each dr As DataRow In dt.Rows
            Staff.Add(dr("StaffMastId") & "-" & dr("staffdispname"))
        Next
        Return Staff

    End Function

    <WebMethod()> _
    Public Function SearchSub(ByVal prefixText As String, ByVal count As Integer) As List(Of String)

        Dim sql As String
        sql = "select * from SubMast where SubName like '%" & prefixText & "%'"
        Dim Subject As List(Of String) = New List(Of String)
        Dim dt As DataTable
        dt = dp.data_table(sql)
        For Each dr As DataRow In dt.Rows
            Subject.Add(dr("SubMastId") & "-" & dr("SubName"))
        Next
        Return Subject

    End Function

    <WebMethod()> _
    Public Function SearchStud(ByVal prefixText As String, ByVal count As Integer) As List(Of String)

        Dim sql As String
        sql = "select * from StudMast where StudDispName like '%" & prefixText & "%'"
        Dim Student As List(Of String) = New List(Of String)
        Dim dt As DataTable
        dt = dp.data_table(sql)
        For Each dr As DataRow In dt.Rows
            Student.Add(dr("studMastId") & "-" & dr("StudDispName"))
        Next
        Return Student

    End Function

End Class