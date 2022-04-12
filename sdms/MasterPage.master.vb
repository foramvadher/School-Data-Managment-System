Imports System.Data

Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Dim dp As New data_populate
    Dim gf As New gen_fun
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblLogName.Text = Session("DispName")

        'If Not IsPostBack Then
        '    Dim screen_name As String = System.IO.Path.GetFileName(HttpContext.Current.Request.FilePath)
        '    Dim test = Me.ChildControlsCreated()
        '    If Session("valid_from_top_master") = True Then
        '        If Not gf.validate_page(screen_name, Session("LoginName")) Then
        '            Response.Write("<center>You are not Autorized to view this Page</center>")
        '            Response.End()
        '        Else
        '            'Label1.Text = Page.Title
        '        End If
        '    End If
        '    Session("valid_from_top_master") = True
        'End If
        create_menu()
    End Sub
    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If IsNothing(Session("YearMastId")) Then
            Response.Redirect("~/setpara.aspx")
        End If
        If IsNothing(Session("LoginId")) Then
            Response.Redirect("~/Default.aspx")
        End If

        Session("StaffMastId") = 1
        Session("GroupID") = 1
        Session("YearMastId") = 1
        Session("LoginId") = 16
        If Session("StaffMastId") Is Nothing Then
            'Response.Redirect("default.aspx?err=1")
        End If
    End Sub
    Sub create_menu()
        Dim strsql As String = ""
        Dim ds As DataSet = New DataSet
        Dim dt1 As DataTable = New DataTable("menu")
        Dim dt2 As DataTable = New DataTable("menu1")
        Dim dt3 As DataTable = New DataTable("Menu1")
        strsql = "select distinct screen_id,parent,page_disp_name,NavigateUrl,target,seq from vwMenu where  mnuLevel  = 0  and (StaffId = 0" & Session("StaffMastId") & " or for_all = 'Y') and group_id =" & Session("GroupID") & " order by seq"
        dt1 = dp.data_table(strsql)
        dt1.TableName = "menu"

        strsql = "select distinct screen_id,parent,page_disp_name,NavigateUrl,target,seq from  vwMenu where mnuLevel  = 1  and (StaffId = 0" & Session("StaffMastId") & " or for_all = 'Y')  and group_id =" & Session("GroupID") & " order by seq"
        dt2 = dp.data_table(strsql)
        dt2.TableName = "menu1"

        strsql = "select distinct screen_id,parent,page_disp_name,NavigateUrl,target,seq from  vwMenu where mnuLevel  = 2  and (StaffId = 0" & Session("StaffMastId") & " or for_all = 'Y') and group_id =" & Session("GroupID") & " order by seq"
        dt3 = dp.data_table(strsql)
        dt3.TableName = "Menu1"
        ds.Tables.Add(dt1)
        ds.Tables.Add(dt2)
        ds.Tables.Add(dt3)
        Dim parentColumn As DataColumn = ds.Tables("menu").Columns("screen_id")
        Dim childColumn As DataColumn = ds.Tables("menu1").Columns("parent")
        Dim relation As DataRelation = New System.Data.DataRelation("Children", parentColumn, childColumn)
        ds.Relations.Add(relation)

        Dim parentColumn1 As DataColumn = ds.Tables("menu1").Columns("screen_id")
        Dim childColumn1 As DataColumn = ds.Tables("Menu1").Columns("parent")
        Dim relation1 As DataRelation = New System.Data.DataRelation("subChildren", parentColumn1, childColumn1)
        ds.Relations.Add(relation1)

        Dim count As Integer = 0
        Menu1.Items.Clear()
        For Each mnRow As DataRow In ds.Tables("menu").Rows
            Dim mNode As New MenuItem(mnRow("page_disp_name"), mnRow("screen_id"), "", mnRow("NavigateUrl"))
            mNode.Target = mnRow("target")
            mNode.ImageUrl = "~/images/doticon.jpg"
            Menu1.Items.Add(mNode)

            Dim subCatRows() As DataRow = mnRow.GetChildRows("Children")
            Dim count2 As Integer = 0
            For Each row As DataRow In subCatRows
                Dim subCatItems As New MenuItem(row("page_disp_name"), row("screen_id"), "", row("NavigateUrl"))
                subCatItems.Target = row("target")
                Menu1.Items(count).ChildItems.Add(subCatItems)
                Dim mnuLast As MenuItem = Menu1.Items(count).ChildItems(count2)
                Dim subCat2Rows() As DataRow = row.GetChildRows("subChildren")
                For Each row2 As DataRow In subCat2Rows
                    Dim subCat2Items As New MenuItem(row2("page_disp_name"), row2("screen_id"), "", row2("NavigateUrl"))
                    subCat2Items.Target = row2("target").ToString
                    mnuLast.ChildItems.Add(subCat2Items)
                Next
                count2 += 1
            Next
            count = count + 1
        Next

    End Sub

    Protected Sub Menu1_MenuItemClick(sender As Object, e As MenuEventArgs) Handles Menu1.MenuItemClick

    End Sub
End Class

