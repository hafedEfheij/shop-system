Imports System.Data.SqlClient

Public Class Frmlogin
    Dim con As New SqlConnection("server=DESKTOP-KNP9Q60; database=DB_shop ; integrated security=true")
    Dim adapter As SqlDataAdapter
    Dim dt As New DataTable

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Application.Exit()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtuser.Text = "" Or txtpass.Text = "" Then
            MsgBox("يرجي ادخال اسم المستخدم وكلمة المرور", MsgBoxStyle.Information, "تنبية")
        Else
            Try
                adapter = New SqlDataAdapter("SELECT *FROM Tbl_users where name='" & txtuser.Text & "' and password='" & txtpass.Text & "'", con)
                adapter.Fill(dt)

                If dt.Rows.Count > 0 Then
                    Me.Hide()
                    Frmitems.Show()
                Else
                    MsgBox("يوجد خطا في اسم المستخدم او كلمة المرور يرجى التحقق", MsgBoxStyle.Information, "تنبية")
                    txtuser.Text = ""
                    txtpass.Text = ""
                    txtuser.Focus()


                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Me.Hide()
        Frmorder.Show()

    End Sub
End Class
