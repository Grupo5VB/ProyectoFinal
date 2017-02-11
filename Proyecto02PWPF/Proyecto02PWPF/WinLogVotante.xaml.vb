Imports System.Data
Imports System.Data.OleDb

Public Class WinLogVotante
    Private dsVotantes As DataSet
    Dim winPrincipal As New WinPrincipal
    Dim encontrado As Boolean = False
    Public cedVotante As String = ""

    Private Sub WinLogVotante1_Loaded(sender As Object, e As RoutedEventArgs) Handles MyBase.Loaded, MyBase.Loaded

    End Sub

    Private Sub btnIngresar_Click(sender As Object, e As RoutedEventArgs) Handles btnIngresar.Click

        Using conexion As New OleDbConnection(winPrincipal.strConexion)
            Dim consulta As String = "Select * FROM Votantes;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim dsVotantes = New DataSet("Base")
            adapter.Fill(dsVotantes, "Votantes")
            For Each u As DataRow In dsVotantes.Tables("Votantes").Rows
                If u("Cédula") = txtId.Text Then
                    If u("EstadoVoto") = False Then
                        MessageBox.Show("Bienvenido " + u("Nombre"))
                        encontrado = True
                        Dim winRegVotos As New WinPapeletasVotos()
                        winRegVotos.cedVotante = u("Cédula")
                        winRegVotos.Owner = Me
                        winRegVotos.DataContext = winPrincipal.dbPath
                        winRegVotos.Show()
                        Me.Hide()
                        Exit For
                    Else
                        encontrado = True
                        MessageBox.Show("Votante ya sufragó")
                        Me.Close()
                        winPrincipal.Show()
                        Exit For
                    End If
                Else
                    Continue For
                End If
            Next
            If encontrado = False Then
                MessageBox.Show("Votante no registrado")
                txtId.Text = ""
            End If
        End Using
    End Sub

    Private Sub WinLogVotante1_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles MyBase.Closing, MyBase.Closing
        winPrincipal.Show()
    End Sub
End Class
