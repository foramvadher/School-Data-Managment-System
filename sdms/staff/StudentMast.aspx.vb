Imports System.Data
Imports System.Data.SqlClient

Partial Class StudentMast
    Inherits System.Web.UI.Page
    Dim dp As New data_populate
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        gvStudMast.PageIndex = 0
        bindgv()
        'pnlView.Visible = False

    End Sub
    Sub bindgv()
        Dim msg = validatesearch()
        If msg <> "" Then
            lblMsg.Text = msg
            Exit Sub
        End If
        Dim sql As String = ""
        Dim sql1 As String
        sql1 = "select * from studmast where 1=1 "
        If txtStudDispNameSearch.Text.Trim <> "" Then
            sql += " and StudDispName like '%" & txtStudDispNameSearch.Text.Trim & "%'"
        End If
        If txtAddrSearch.Text.Trim <> "" Then
            sql += " and Addr like '%" & txtAddrSearch.Text.Trim & "%'"
        End If
        If txtAdmnNoSearch.Text.Trim <> "" Then
            sql = " and AdmnNo like '%" & txtAdmnNoSearch.Text.Trim & "%'"
        End If
        sql = sql1 & sql
        dp.grid_view(sql, gvStudMast, True)
        pnlGrid.Visible = True
    End Sub

    Function validatesearch() As String
        validatesearch = ""
        Dim gf As New gen_fun
        Dim msg As String = ""
        msg = gf.checkLen(txtStudDispNameSearch.Text, 150, " Disp Name", False)
        msg += gf.checkLen(txtAddrSearch.Text, 500, " Address ", False)
        msg += gf.IsNumeric(txtAdmnNoSearch.Text, " Admission No ", False)


        Return msg
    End Function
    Protected Sub gvStudMast_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvStudMast.PageIndexChanging
        gvStudMast.PageIndex = e.NewPageIndex
        bindgv()
    End Sub


    Protected Sub gvStudMast_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvStudMast.RowCommand
        If e.CommandName = "edit1" Then
            lblHeaderEdit.Text = "Editing Record..."
            Dim studmastid As Integer = gvStudMast.DataKeys(e.CommandArgument).Values(0)
            bindeditdata(studmastid)
            'pnlView.Visible = False
            hdnStudMastID_ModalPopupExtender.Show()
        End If
        If e.CommandName = "Transfer" Then
            lblHeaderTransfer.Text = "Transfer Details..."
            hdnStudMastID.Value = gvStudMast.DataKeys(e.CommandArgument).Values(0)

            'pnlView.Visible = False
            hdnTransferInfo_ModalPopupExtender.Show()
        End If
    End Sub
    Sub bindeditdata(ByVal studMastId As Integer)
        Dim sql As String
        sql = "select * from StudMast where studmastid = " & studMastId
        Dim dt As DataTable
        dt = dp.data_table(sql)
        If dt.Rows.Count > 0 Then
            hdnStudMastID.Value = studMastId
            txtStudFirstNameEdit.Text = dt.Rows(0)("StudFirstName").ToString
            txtStudMidNameEdit.Text = dt.Rows(0)("StudMidName").ToString
            txtStudLastNameEdit.Text = dt.Rows(0)("StudLastName").ToString
            txtFatherNameEdit.Text = dt.Rows(0)("FatherName").ToString
            txtMotherNameEdit.Text = dt.Rows(0)("MotherName").ToString
            txtDateOfAdmnEdit.Text = dt.Rows(0)("DateOfAdmn").ToString
            txtAdmnNoEdit.Text = dt.Rows(0)("AdmnNo").ToString
            txtAadharNoEdit.Text = dt.Rows(0)("AadharNo").ToString
            txtDOBEdit.Text = dt.Rows(0)("DOB").ToString
            txtBGEdit.Text = dt.Rows(0)("BG").ToString
            txtPhNoLLEdit.Text = dt.Rows(0)("PhNoLL").ToString
            txtPhNoMobEdit.Text = dt.Rows(0)("PhNoMob").ToString
            txtMailIdEdit.Text = dt.Rows(0)("MailId").ToString
            txtAddrEdit.Text = dt.Rows(0)("Addr").ToString
            txtCategoryIdEdit.Text = dt.Rows(0)("CategoryId").ToString
            txtIdentificationMarkEdit.Text = dt.Rows(0)("IdentificationMark").ToString
        End If
    End Sub

    Protected Sub gvStudMast_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvStudMast.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If Not e.Row.Cells(6).Text.ToString.Trim = "" Then
                e.Row.Cells(8).Text = ""
                e.Row.Cells(9).Text = ""

            End If
        End If
    End Sub

    Protected Sub gvStudMast_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvStudMast.SelectedIndexChanged
        bindviewdata(gvStudMast.SelectedDataKey.Values(0).ToString)
        hdnView_ModalPopupExtender.Show()
        'pnlView.Visible = True
    End Sub
    Sub bindviewdata(ByVal studMastId As Integer)
        Dim sql As String
        sql = "select * from StudMast where studmastid = " & studMastId
        Dim dt As DataTable
        dt = dp.data_table(sql)
        If dt.Rows.Count > 0 Then
            lblStudMastIdView.Text = dt.Rows(0)("StudMastId").ToString
            lblStudFirstNameView.Text = dt.Rows(0)("StudFirstName").ToString
            lblStudMidNameView.Text = dt.Rows(0)("StudMidName").ToString
            lblStudLastNameView.Text = dt.Rows(0)("StudLastName").ToString
            lblFatherNameView.Text = dt.Rows(0)("FatherName").ToString
            lblMotherNameView.Text = dt.Rows(0)("MotherName").ToString
            lblDateOfAdmnView.Text = dt.Rows(0)("DateOfAdmn").ToString
            lblAdmnNoView.Text = dt.Rows(0)("AdmnNo").ToString
            lblAadharNoView.Text = dt.Rows(0)("AadharNo").ToString
            lblDOBView.Text = dt.Rows(0)("DOB").ToString
            lblBGView.Text = dt.Rows(0)("BG").ToString
            lblPhNoLLView.Text = dt.Rows(0)("PhNoLL").ToString
            lblPhNoMobView.Text = dt.Rows(0)("PhNoMob").ToString
            lblMailIdView.Text = dt.Rows(0)("MailId").ToString
            lblAddrView.Text = dt.Rows(0)("Addr").ToString
            lblCategoryIdView.Text = dt.Rows(0)("CategoryId").ToString
            lblIdentificationMarkView.Text = dt.Rows(0)("IdentificationMark").ToString
        End If
    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        'pnlView.Visible = False
        lblHeaderEdit.Text = "New Record..."
        pnlGrid.Visible = False
        hdnNew_ModalPopupExtender.Show()
        cleardata()
    End Sub
    Sub cleardata()
        hdnStudMastID.Value = 0
        txtStudFirstNameEdit.Text = ""
        txtStudLastNameEdit.Text = ""
        txtStudMidNameEdit.Text = ""
        txtFatherNameEdit.Text = ""
        txtMotherNameEdit.Text = ""
        txtDateOfAdmnEdit.Text = ""
        txtAdmnNoEdit.Text = ""
        txtAadharNoEdit.Text = ""
        txtDOBEdit.Text = ""
        txtBGEdit.Text = ""
        txtPhNoLLEdit.Text = ""
        txtPhNoMobEdit.Text = ""
        txtMailIdEdit.Text = ""
        txtAddrEdit.Text = ""
        txtCategoryIdEdit.Text = ""
        txtIdentificationMarkEdit.Text = ""
    End Sub
    Sub insertupdate()
        Try
            Dim msg = validatesearch()
            If msg <> "" Then
                lblMsg.Text = msg
                Exit Sub
            End If
            Dim cmd As New SqlCommand

            Dim strPwd As String = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtAdmnNoEdit.Text, "md5")

            cmd.Parameters.AddWithValue("@StudMastID", hdnStudMastID.Value)
            cmd.Parameters.AddWithValue("@StudFirstName", txtStudFirstNameEdit.Text)
            cmd.Parameters.AddWithValue("@StudLastName", txtStudLastNameEdit.Text)
            cmd.Parameters.AddWithValue("@StudMidName", txtStudMidNameEdit.Text)
            cmd.Parameters.AddWithValue("@FatherName", txtFatherNameEdit.Text)
            cmd.Parameters.AddWithValue("@MotherName", txtMotherNameEdit.Text)
            cmd.Parameters.AddWithValue("@DateOfAdmn", txtDateOfAdmnEdit.Text)
            cmd.Parameters.AddWithValue("@AdmnNo", txtAdmnNoEdit.Text)
            cmd.Parameters.AddWithValue("@AadharNo", txtAadharNoEdit.Text)
            cmd.Parameters.AddWithValue("@DOB", txtDOBEdit.Text)
            cmd.Parameters.AddWithValue("@BG", txtBGEdit.Text)
            cmd.Parameters.AddWithValue("@PhNoLL", txtPhNoLLEdit.Text)
            cmd.Parameters.AddWithValue("@PhNoMob", txtPhNoMobEdit.Text)
            cmd.Parameters.AddWithValue("@MailId", txtMailIdEdit.Text)
            cmd.Parameters.AddWithValue("@Addr", txtAddrEdit.Text)
            cmd.Parameters.AddWithValue("@CategoryId", txtCategoryIdEdit.Text)
            cmd.Parameters.AddWithValue("@IdentificationMark", txtIdentificationMarkEdit.Text)
            cmd.Parameters.AddWithValue("@Pass", strPwd)
            lblMsg.Text = dp.DMLCommands_para("spStudMast", cmd)

        Catch ex As Exception
            lblMsg1.Text = ex.Message
            hdnNew_ModalPopupExtender.Show()
        End Try
    End Sub
    Function validatedata()
        validatedata = ""
        Dim gf As New gen_fun
        Dim msg As String = ""
        msg = gf.checkLen(txtStudFirstNameEdit.Text, 50, " First Name", True)
        msg += gf.checkLen(txtStudLastNameEdit.Text, 50, " Last Name ", False)
        msg += gf.checkLen(txtStudMidNameEdit.Text, 50, " Middle Name ", False)
        msg += gf.checkLen(txtStudMidNameEdit.Text, 50, " Middle Name ", False)

        msg += gf.IsNumeric(txtAdmnNoSearch.Text, " Admission No ", False)

        Return msg
    End Function
    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        insertupdate()
    End Sub

    Protected Sub btnSubmitTransfer_Click(sender As Object, e As EventArgs) Handles btnSubmitTransfer.Click
        bindTransferData(hdnStudMastID.Value)
    End Sub

    Sub bindTransferData(ByVal studMastId As Integer)
        Dim sql As String
        sql = "select * from StudMast where studmastid = " & studMastId
        Dim dt As DataTable
        dt = dp.data_table(sql)
        If dt.Rows.Count > 0 Then
            Dim cmd As New SqlCommand
            cmd.Parameters.AddWithValue("@StudMastId", hdnStudMastID.Value)
            cmd.Parameters.AddWithValue("@TransferDate", txtTransferDate.Text)
            cmd.Parameters.AddWithValue("@TransferReason", txtTransferReason.Text)

            lblMsg.Text = dp.DMLCommands_para("spTransferStud", cmd)
        End If
    End Sub
End Class
