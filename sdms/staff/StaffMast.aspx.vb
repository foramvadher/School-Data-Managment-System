Imports System.Data.SqlClient
Imports System.Data

Partial Class StaffMast
    Inherits System.Web.UI.Page

    Dim dp As New data_populate

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        gvStaffMast.PageIndex = 0
        bindgv()
    End Sub

    Sub bindgv()
        Dim msg = validatesearch()
        If msg <> "" Then
            lblMsg.Text = msg
            Exit Sub
        End If
        Dim sql As String = ""
        Dim sql1 As String
        sql1 = "select * from Staffmast where 1=1 "
        If txtStaffDispNameSearch.Text.Trim <> "" Then
            sql += " and StaffDispName like '%" & txtStaffDispNameSearch.Text.Trim & "%'"
        End If
        If txtAddrSearch.Text.Trim <> "" Then
            sql += " and Addr like '%" & txtAddrSearch.Text.Trim & "%'"
        End If
        If txtAadharNoSearch.Text.Trim <> "" Then
            sql += " and AadharNo like '%" & txtAadharNoSearch.Text.Trim & "%'"
        End If

        sql = sql1 & sql
        dp.grid_view(sql, gvStaffMast, True)
        pnlGrid.Visible = True
    End Sub

    Function validatesearch() As String
        validatesearch = ""
        Dim gf As New gen_fun
        Dim msg As String = ""
        msg = gf.checkLen(txtStaffDispNameSearch.Text, 150, " Disp Name", False)
        msg += gf.checkLen(txtAddrSearch.Text, 500, " Address ", False)
        msg += gf.IsNumeric(txtAadharNoSearch.Text, " Aadhar No. ", False)


        Return msg
    End Function

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        pnlGrid.Visible = False
        hdnNew_ModalPopupExtender.Show()
        cleardata()
    End Sub

    Sub cleardata()
        hdnStaffMastID.Value = 0
        txtStaffFirstNameEdit.Text = ""
        txtStaffLastNameEdit.Text = ""
        txtStaffMidNameEdit.Text = ""
        txtAadharNoEdit.Text = ""
        txtDOBEdit.Text = ""
        txtBGEdit.Text = ""
        txtPhNoLLEdit.Text = ""
        txtPhNoMobEdit.Text = ""
        txtMailIdEdit.Text = ""
        txtAddrEdit.Text = ""
        txtQualificationEdit.Text = ""
        txtCategoryIdEdit.Text = ""
        txtDesigIdEdit.Text = ""
        txtIdentificationMarkEdit.Text = ""
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        insertupdate()
    End Sub

    Sub insertupdate()
        Dim msg = validatesearch()
        If msg <> "" Then
            lblMsg.Text = msg
            Exit Sub
        End If
        Dim cmd As New SqlCommand
        cmd.Parameters.AddWithValue("@StaffMastID", hdnStaffMastID.Value)
        cmd.Parameters.AddWithValue("@StaffFirstName", txtStaffFirstNameEdit.Text)
        cmd.Parameters.AddWithValue("@StaffLastName", txtStaffLastNameEdit.Text)
        cmd.Parameters.AddWithValue("@StaffMidName", txtStaffMidNameEdit.Text)
        cmd.Parameters.AddWithValue("@AadharNo", txtAadharNoEdit.Text)
        cmd.Parameters.AddWithValue("@DOB", txtDOBEdit.Text)
        cmd.Parameters.AddWithValue("@BG", txtBGEdit.Text)
        cmd.Parameters.AddWithValue("@PhNoLL", txtPhNoLLEdit.Text)
        cmd.Parameters.AddWithValue("@PhNoMob", txtPhNoMobEdit.Text)
        cmd.Parameters.AddWithValue("@MailId", txtMailIdEdit.Text)
        cmd.Parameters.AddWithValue("@Addr", txtAddrEdit.Text)
        cmd.Parameters.AddWithValue("@Qualification", txtQualificationEdit.Text)
        cmd.Parameters.AddWithValue("@CategoryId", txtCategoryIdEdit.Text)
        cmd.Parameters.AddWithValue("@DesigId", txtDesigIdEdit.Text)
        cmd.Parameters.AddWithValue("@IdentificationMark", txtIdentificationMarkEdit.Text)

        lblMsg.Text = dp.DMLCommands_para("spStaffMast", cmd)

    End Sub

    Protected Sub gvStaffMast_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvStaffMast.SelectedIndexChanged
        bindviewdata(gvStaffMast.SelectedDataKey.Values(0).ToString)
        hdnView_ModalPopupExtender.Show()
    End Sub

    Sub bindviewdata(ByVal StaffMastId As Integer)
        Dim sql As String
        sql = "select * from StaffMast where Staffmastid = " & StaffMastId
        Dim dt As DataTable
        dt = dp.data_table(sql)
        If dt.Rows.Count > 0 Then
            lblStaffMastIdView.Text = dt.Rows(0)("StaffMastId").ToString
            lblStaffFirstNameView.Text = dt.Rows(0)("StaffFirstName").ToString
            lblStaffMidNameView.Text = dt.Rows(0)("StaffMidName").ToString
            lblStaffLastNameView.Text = dt.Rows(0)("StaffLastName").ToString
            lblAadharNoView.Text = dt.Rows(0)("AadharNo").ToString
            lblDOBView.Text = dt.Rows(0)("DOB").ToString
            lblBGView.Text = dt.Rows(0)("BG").ToString
            lblPhNoLLView.Text = dt.Rows(0)("PhNoLL").ToString
            lblPhNoMobView.Text = dt.Rows(0)("PhNoMob").ToString
            lblMailIdView.Text = dt.Rows(0)("MailId").ToString
            lblAddrView.Text = dt.Rows(0)("Addr").ToString
            lblQualificationView.Text = dt.Rows(0)("Qualification").ToString
            lblCategoryIdView.Text = dt.Rows(0)("CategoryId").ToString
            lblDesigIdView.Text = dt.Rows(0)("DesigId").ToString
            lblIdentificationMarkView.Text = dt.Rows(0)("IdentificationMark").ToString
        End If
    End Sub

    Protected Sub gvStaffMast_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvStaffMast.RowCommand
        If e.CommandName = "edit1" Then
            Dim Staffmastid As Integer = gvStaffMast.DataKeys(e.CommandArgument).Values(0)
            bindeditdata(Staffmastid)
            'pnlView.Visible = False
            hdnStaffMastID_ModalPopupExtender.Show()
        End If
        If e.CommandName = "Transfer" Then
            lblHeaderTransfer.Text = "Transfer Details..."
            hdnStaffMastID.Value = gvStaffMast.DataKeys(e.CommandArgument).Values(0)

            'pnlView.Visible = False
            hdnTransferInfo_ModalPopupExtender.Show()
        End If
    End Sub

    Sub bindeditdata(ByVal StaffMastId As Integer)
        Dim sql As String
        sql = "select * from StaffMast where Staffmastid = " & StaffMastId
        Dim dt As DataTable
        dt = dp.data_table(sql)
        If dt.Rows.Count > 0 Then
            hdnStaffMastID.Value = StaffMastId
            txtStaffFirstNameEdit.Text = dt.Rows(0)("StaffFirstName").ToString
            txtStaffMidNameEdit.Text = dt.Rows(0)("StaffMidName").ToString
            txtStaffLastNameEdit.Text = dt.Rows(0)("StaffLastName").ToString
            txtAadharNoEdit.Text = dt.Rows(0)("AadharNo").ToString
            txtDOBEdit.Text = dt.Rows(0)("DOB").ToString
            txtBGEdit.Text = dt.Rows(0)("BG").ToString
            txtPhNoLLEdit.Text = dt.Rows(0)("PhNoLL").ToString
            txtPhNoMobEdit.Text = dt.Rows(0)("PhNoMob").ToString
            txtMailIdEdit.Text = dt.Rows(0)("MailId").ToString
            txtAddrEdit.Text = dt.Rows(0)("Addr").ToString
            txtQualificationEdit.Text = dt.Rows(0)("Qualification").ToString
            txtCategoryIdEdit.Text = dt.Rows(0)("CategoryId").ToString
            txtDesigIdEdit.Text = dt.Rows(0)("DesigId").ToString
            txtIdentificationMarkEdit.Text = dt.Rows(0)("IdentificationMark").ToString
        End If
    End Sub
    Protected Sub btnSubmitTransfer_Click(sender As Object, e As EventArgs) Handles btnSubmitTransfer.Click
        bindTransferData(hdnStaffMastID.Value)
    End Sub

    Sub bindTransferData(ByVal studMastId As Integer)
        Dim sql As String
        sql = "select * from StudMast where studmastid = " & studMastId
        Dim dt As DataTable
        dt = dp.data_table(sql)
        If dt.Rows.Count > 0 Then
            Dim cmd As New SqlCommand
            cmd.Parameters.AddWithValue("@StaffMastId", hdnStaffMastID.Value)
            cmd.Parameters.AddWithValue("@TransferDate", txtTransferDate.Text)
            cmd.Parameters.AddWithValue("@TransferReason", txtTransferReason.Text)

            lblMsg.Text = dp.DMLCommands_para("spTransferStaff", cmd)
        End If
    End Sub
End Class
