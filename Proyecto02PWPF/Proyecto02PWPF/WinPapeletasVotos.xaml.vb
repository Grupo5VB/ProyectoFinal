Imports System.Data
Imports System.Data.OleDb

Public Class WinPapeletasVotos
    Private dsCandidatos As DataSet
    Dim winPrincipal As New WinPrincipal
    Dim winLogV As New WinLogVotante

    Dim LabelsBi As New List(Of Label)
    Dim LabelsConc As New List(Of Label)
    Dim LabelsAlc As New List(Of Label)

    Dim i As Integer = 0
    Dim j As Integer = 0
    Dim x As Integer = 0

    Dim votoBin As Integer
    Dim votoConc As Integer
    Dim votoAlc As Integer

    Public cedVotante As String = ""

    Public Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

        LabelsBi.Add((lblBin1))
        LabelsBi.Add(lblBin2)
        LabelsBi.Add(lblBin3)
        LabelsBi.Add(lblBin4)

        LabelsConc.Add(lblConc1)
        LabelsConc.Add(lblConc2)
        LabelsConc.Add(lblConc3)
        LabelsConc.Add(lblConc4)

        LabelsAlc.Add(lblAlc1)
        LabelsAlc.Add(lblAlc2)
        LabelsAlc.Add(lblAlc3)
        LabelsAlc.Add(lblAlc4)


        Using conexion As New OleDbConnection(winPrincipal.strConexion)
            Dim consulta As String = "Select * FROM Usuarios;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            dsCandidatos = New DataSet("Base")
            adapter.Fill(dsCandidatos, "Usuarios")
            For Each u As DataRow In dsCandidatos.Tables("Usuarios").Rows
                If u("Usuario") = "binom" Then
                    LabelsBi(i).Content = u("Nombre")
                    i += 1
                ElseIf u("Usuario") = "concejal" Then
                    LabelsConc(j).Content = u("Nombre")
                    j += 1
                ElseIf u("Usuario") = "alcalde" Then
                    LabelsAlc(x).Content = u("Nombre")
                    x += 1
                End If
            Next
        End Using
    End Sub

    Private Sub btnVotar1_Click(sender As Object, e As RoutedEventArgs) Handles btnVotar1.Click
        votoBin = 1
        DeshabilitarBotones(btnVotar2, btnVotar3, btnVotar4, btnVotar5, btnVotar6)
    End Sub

    Private Sub btnVotar2_Click(sender As Object, e As RoutedEventArgs) Handles btnVotar2.Click
        votoBin = 2
        DeshabilitarBotones(btnVotar1, btnVotar3, btnVotar4, btnVotar5, btnVotar6)
    End Sub

    Private Sub btnVotar3_Click(sender As Object, e As RoutedEventArgs) Handles btnVotar3.Click
        votoBin = 3
        DeshabilitarBotones(btnVotar2, btnVotar1, btnVotar4, btnVotar5, btnVotar6)
    End Sub

    Private Sub btnVotar4_Click(sender As Object, e As RoutedEventArgs) Handles btnVotar4.Click
        votoBin = 4
        DeshabilitarBotones(btnVotar2, btnVotar3, btnVotar1, btnVotar5, btnVotar6)
    End Sub

    Private Sub btnVotar5_Click(sender As Object, e As RoutedEventArgs) Handles btnVotar5.Click
        votoBin = 5
        DeshabilitarBotones(btnVotar2, btnVotar3, btnVotar4, btnVotar1, btnVotar6)
    End Sub

    Private Sub btnVotar6_Click(sender As Object, e As RoutedEventArgs) Handles btnVotar6.Click
        votoBin = 6
        DeshabilitarBotones(btnVotar2, btnVotar3, btnVotar4, btnVotar5, btnVotar1)
    End Sub

    Private Sub btnCancelar1_Click(sender As Object, e As RoutedEventArgs) Handles btnCancelar1.Click
        HabilitarBotones(btnVotar1, btnVotar2, btnVotar3, btnVotar4, btnVotar5, btnVotar6)
    End Sub

    Private Sub btnSiguiente1_Click(sender As Object, e As RoutedEventArgs) Handles btnSiguiente1.Click
        TabConcejal.IsSelected = True
    End Sub

    Private Sub btnVotarC1_Click(sender As Object, e As RoutedEventArgs) Handles btnVotarC1.Click
        votoConc = 1
        DeshabilitarBotones(btnVotarC2, btnVotarC3, btnVotarC4, btnVotarC5, btnVotarC6)
    End Sub

    Private Sub btnVotarC2_Click(sender As Object, e As RoutedEventArgs) Handles btnVotarC2.Click
        votoConc = 2
        DeshabilitarBotones(btnVotarC1, btnVotarC3, btnVotarC4, btnVotarC5, btnVotarC6)
    End Sub

    Private Sub btnVotarC3_Click(sender As Object, e As RoutedEventArgs) Handles btnVotarC3.Click
        votoConc = 3
        DeshabilitarBotones(btnVotarC2, btnVotarC1, btnVotarC4, btnVotarC5, btnVotarC6)
    End Sub

    Private Sub btnVotarC4_Click(sender As Object, e As RoutedEventArgs) Handles btnVotarC4.Click
        votoConc = 4
        DeshabilitarBotones(btnVotarC2, btnVotarC3, btnVotarC1, btnVotarC5, btnVotarC6)

    End Sub

    Private Sub btnVotarC5_Click(sender As Object, e As RoutedEventArgs) Handles btnVotarC5.Click
        votoConc = 5
        DeshabilitarBotones(btnVotarC2, btnVotarC3, btnVotarC4, btnVotarC1, btnVotarC6)
    End Sub

    Private Sub btnVotarC6_Click(sender As Object, e As RoutedEventArgs) Handles btnVotarC6.Click
        votoConc = 6
        DeshabilitarBotones(btnVotarC2, btnVotarC3, btnVotarC4, btnVotarC5, btnVotarC1)
    End Sub

    Private Sub btnCancelar2_Click(sender As Object, e As RoutedEventArgs) Handles btnCancelar2.Click
        HabilitarBotones(btnVotarC1, btnVotarC2, btnVotarC3, btnVotarC4, btnVotarC5, btnVotarC6)
    End Sub

    Private Sub btnSiguiente2_Click(sender As Object, e As RoutedEventArgs) Handles btnSiguiente2.Click
        TabAlcalde.IsSelected = True
    End Sub

    Private Sub btnVotarA1_Click(sender As Object, e As RoutedEventArgs) Handles btnVotarA1.Click
        votoAlc = 1
        DeshabilitarBotones(btnVotarA2, btnVotarA3, btnVotarA4, btnVotarA5, btnVotarA6)
    End Sub

    Private Sub btnVotarA2_Click(sender As Object, e As RoutedEventArgs) Handles btnVotarA2.Click
        votoAlc = 2
        DeshabilitarBotones(btnVotarA1, btnVotarA3, btnVotarA4, btnVotarA5, btnVotarA6)
    End Sub

    Private Sub btnVotarA3_Click(sender As Object, e As RoutedEventArgs) Handles btnVotarA3.Click
        votoAlc = 3
        DeshabilitarBotones(btnVotarA2, btnVotarA1, btnVotarA4, btnVotarA5, btnVotarA6)
    End Sub

    Private Sub btnVotarA4_Click(sender As Object, e As RoutedEventArgs) Handles btnVotarA4.Click
        votoAlc = 4
        DeshabilitarBotones(btnVotarA2, btnVotarA3, btnVotarA1, btnVotarA5, btnVotarA6)
    End Sub

    Private Sub btnVotarA5_Click(sender As Object, e As RoutedEventArgs) Handles btnVotarA5.Click
        votoAlc = 5
        DeshabilitarBotones(btnVotarA2, btnVotarA3, btnVotarA4, btnVotarA1, btnVotarA6)
    End Sub

    Private Sub btnVotarA6_Click(sender As Object, e As RoutedEventArgs) Handles btnVotarA6.Click
        votoAlc = 6
        DeshabilitarBotones(btnVotarA2, btnVotarA3, btnVotarA4, btnVotarA5, btnVotarA1)
    End Sub

    Public Sub btnCancelar3_Click(sender As Object, e As RoutedEventArgs) Handles btnCancelar3.Click
        HabilitarBotones(btnVotarA1, btnVotarA2, btnVotarA3, btnVotarA4, btnVotarA5, btnVotarA6)
    End Sub

    Private Sub btnFinalizar_Click(sender As Object, e As RoutedEventArgs) Handles btnFinalizar.Click
        Dim Pregunta As Integer
        Pregunta = MsgBox("Se procederá a guardar sus votos." & vbCrLf & vbCrLf & "¿SUS VOTOS SON CORRECTOS?.", vbYesNo, "Mensaje de Confirmación")

        If Pregunta = vbYes Then

            Using conexion As New OleDbConnection(winPrincipal.strConexion)
                Dim consulta As String = "Select * FROM ContadorVotos;"
                Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
                dsCandidatos = New DataSet("Votos")
                adapter.Fill(dsCandidatos, "ContadorVotos")
                For Each v As DataRow In dsCandidatos.Tables("ContadorVotos").Rows
                    Select Case v("IdDignidad")
                        Case "1"
                            If v("IdLista") = CStr(votoBin) Then
                                v("TotalVotos") += 1
                            End If
                        Case "2"
                            If v("IdLista") = CStr(votoConc) Then
                                v("TotalVotos") += 1
                            End If
                        Case "3"
                            If v("IdLista") = CStr(votoAlc) Then
                                v("TotalVotos") += 1
                            End If
                    End Select
                Next
                Dim votoCmdBuilder = New OleDbCommandBuilder(adapter)
                Try
                    adapter.Update(dsCandidatos.Tables("ContadorVotos"))
                Catch ex As Exception
                    MessageBox.Show("Error al guardar los votos")
                End Try
            End Using

            Using conexion As New OleDbConnection(winPrincipal.strConexion)
                Dim consultaV As String = "Select * FROM Votantes;"
                Dim adapterV As New OleDbDataAdapter(New OleDbCommand(consultaV, conexion))
                Dim dsYaVoto = New DataSet("Sufragio")
                adapterV.Fill(dsYaVoto, "Votantes")
                For Each v As DataRow In dsYaVoto.Tables("Votantes").Rows
                    If cedVotante = v("Cédula") Then
                        v("EstadoVoto") = True
                        Exit For
                    Else
                        Continue For
                    End If
                Next
                Dim estadoCmdBuilder = New OleDbCommandBuilder(adapterV)
                Try
                    adapterV.Update(dsYaVoto.Tables("Votantes"))
                Catch ex As Exception
                    MessageBox.Show("Error al guardar estado del Votante")
                End Try
            End Using
            MessageBox.Show("Sus votos han sido guardados exitosamente." & vbCrLf & vbCrLf & "Gracias por cumplir con su deber ciudadano!!", "Mensaje de Salida")
            Me.Close()
            winPrincipal.Show()
        Else
            votoBin = 0
            votoConc = 0
            votoAlc = 0
            btnCancelar1_Click(sender, e)
            btnCancelar2_Click(sender, e)
            btnCancelar3_Click(sender, e)
            TabBinomio.IsSelected = True
        End If
    End Sub

    Public Sub HabilitarBotones(btn1 As Button, btn2 As Button, btn3 As Button, btn4 As Button, btn5 As Button, btn6 As Button)
        btn1.IsEnabled = True
        btn2.IsEnabled = True
        btn3.IsEnabled = True
        btn4.IsEnabled = True
        btn5.IsEnabled = True
        btn6.IsEnabled = True
    End Sub

    Public Sub DeshabilitarBotones(btn1 As Button, btn2 As Button, btn3 As Button, btn4 As Button, btn5 As Button)
        btn1.IsEnabled = False
        btn2.IsEnabled = False
        btn3.IsEnabled = False
        btn4.IsEnabled = False
        btn5.IsEnabled = False
    End Sub

    Private Sub WinPapeletasVotos_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles MyBase.Closing, MyBase.Closing
        winPrincipal.Show()
    End Sub
End Class
