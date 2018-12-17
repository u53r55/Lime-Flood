Imports System.Net.Sockets

'       │ Author     : NYAN CAT
'       │ Name       : LimeFlood

'       Contact Me   : https://github.com/NYAN-x-CAT

'       This program Is distributed for educational purposes only.

Public Class Form1
    Public AttackStop As Boolean = False

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Not String.IsNullOrWhiteSpace(TextBox1.Text) AndAlso Not String.IsNullOrWhiteSpace(ComboBox1.Text) AndAlso Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
            If ComboBox1.SelectedIndex = 0 Then
                ToolStripStatusLabel1.Text = "njRAT is not yet ready"
            ElseIf ComboBox1.SelectedIndex = 1 Then
                If Test(TextBox1.Text, TextBox2.Text) Then
                    AttackStop = False
                    Dim R As New REV
                    R.F = Me
                    R.Start(TextBox1.Text, TextBox2.Text, TextBox3.Text)
                    Button2.Enabled = False
                    Button1.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AttackStop = True
        Button2.Enabled = True
        Button1.Enabled = False
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 1
    End Sub

    Private Function Test(ByVal H As String, ByVal P As Integer) As Boolean
        Dim C As New TcpClient
        Try
            C.Connect(H, P)
            ToolStripStatusLabel1.Text = "Server Listening, Attacking..."
            Return True
        Catch ex As Exception
            ToolStripStatusLabel1.Text = "Server is not Listening!"
            Return False
        End Try
    End Function

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 1 Then
            TextBox3.Visible = True
            Label4.Visible = True
        Else
            TextBox3.Visible = False
            Label4.Visible = False
        End If
    End Sub
End Class