Imports System.Data.SqlClient

Public Class Frmitems

    Dim con As New SqlConnection("server=DESKTOP-KNP9Q60; database=DB_shop ; integrated security=true")
    Private Sub reset()
        txtname.Text = ""
        txtprice.Text = ""
        txtqty.Text = ""
        cmbcat.SelectedIndex = -1
    End Sub

    Private Sub fillcat()
        con.Open()
        Dim cmd = New SqlCommand("select * from Tbl_category", con)
        Dim adapter = New SqlDataAdapter(cmd)
        Dim dt = New DataTable()
        adapter.Fill(dt)
        cmbcat.DataSource = dt
        cmbcat.DisplayMember = "catname"
        cmbcat.ValueMember = "catid"
        con.Close()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtcat.Text = "" Then
            MsgBox("يرجي اضافة صنف ", MsgBoxStyle.Information, "تنوية")
        Else
            Try
                con.Open()
                Dim insquery = "insert into Tbl_category  values('" & txtcat.Text & "')"
                Dim cmd As New SqlCommand(insquery, con)
                cmd.ExecuteNonQuery()
                MsgBox("تمت عملية اضافة الصنف بنجاح", MsgBoxStyle.Information, "تاكيد")
                txtcat.Text = ""

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                con.Close()
                fillcat()
            End Try

        End If


    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Application.Exit()

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Me.Hide()
        Frmlogin.Show()

    End Sub

    Private Sub Btnreset_Click(sender As Object, e As EventArgs) Handles btnreset.Click
        reset()
    End Sub

    Private Sub Frmitems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillcat()
    End Sub

    Private Sub Btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        If txtname.Text = "" Or txtprice.Text = "" Or txtqty.Text = "" Or cmbcat.SelectedIndex = -1 Then
            MsgBox("يرجي ملء جميع الخانات ", MsgBoxStyle.Information, "تنوية")
        Else
            Try
                con.Open()
                Dim insquery = "insert into Tbl_items  values('" & txtname.Text & "', '" & cmbcat.SelectedValue & "','" & txtprice.Text & "', '" & txtqty.Text & "')"
                Dim cmd As New SqlCommand(insquery, con)
                cmd.ExecuteNonQuery()
                MsgBox("تمت عملية اضافة المنتج بنجاح", MsgBoxStyle.Information, "تاكيد")


            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                con.Close()
                reset()
            End Try

        End If
    End Sub
End Class