Imports System.Data
Imports System.Data.OleDb

Public Class WinCandidatoLista
    Private dsContVotos As DataSet


    Private Sub btnVerificar_Click(sender As Object, e As RoutedEventArgs) Handles btnVerificar.Click
        Dim winPrincipal As New WinPrincipal
        Dim encontrado As Boolean = False
        Dim sumaVotos As Integer = 0
        Dim resultBinomio As Integer
        Dim resultConcejal As Integer
        Dim resultAlcalde As Integer


        If cmbBoxLis.Text = "PSC - 6" Then
            Dim uri As Uri = New Uri("Resources/lista6.jpg", UriKind.Relative)
            imgLis.Source = New BitmapImage(uri)
        End If

        If cmbBoxLis.Text = "CREO 21 -23" Then
            Dim uri As Uri = New Uri("Resources/Lista_21.png", UriKind.Relative)
            imgLis.Source = New BitmapImage(uri)
        End If

        If cmbBoxLis.Text = "FE - 10" Then
            Dim uri As Uri = New Uri("Resources/lista10.jpg", UriKind.Relative)
            imgLis.Source = New BitmapImage(uri)
        End If

        If cmbBoxLis.Text = "ALIANZA PAIS - 35" Then
            Dim uri As Uri = New Uri("Resources/lista35.png", UriKind.Relative)
            imgLis.Source = New BitmapImage(uri)
        End If


        Using conexion As New OleDbConnection(winPrincipal.strConexion)
            Dim consultaContV As String = "Select * FROM ContadorVotos;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consultaContV, conexion))
            dsContVotos = New DataSet("Base")
            adapter.Fill(dsContVotos, "ContadorVotos")
        End Using

        For Each u As DataRow In dsContVotos.Tables("ContadorVotos").Rows

            If cmbBoxLis.Text = "PSC - 6" And u("IdLista") = 1 Then
                Select Case u("idDignidad")
                    Case 1
                        sumaVotos += u("TotalVotos")
                        resultBinomio = sumaVotos / 100
                        progbarBin.Value = resultBinomio  'Se carga el valor de los resultados de los votos
                    Case 2
                        sumaVotos += u("TotalVotos")
                        resultConcejal = sumaVotos / 100
                        progbarConc.Value = resultBinomio  'Se carga el valor de los resultados de los votos
                    Case 3
                        sumaVotos += u("TotalVotos")
                        resultAlcalde = sumaVotos / 100
                        progbarAlc.Value = resultAlcalde 'Se carga el valor de los resultados de los votos
                    Case Else
                        Debug.WriteLine("Not between 1 and 10, inclusive")
                End Select

            End If
            If cmbBoxLis.Text = "CREO 21 -23" And u("IdLista") = 2 Then
                Select Case u("idDignidad")
                    Case 1
                        sumaVotos += u("TotalVotos")
                        resultBinomio = sumaVotos / 100
                        progbarBin.Value = resultBinomio  'Se carga el valor de los resultados de los votos
                    Case 2
                        sumaVotos += u("TotalVotos")
                        resultConcejal = sumaVotos / 100
                        progbarConc.Value = resultBinomio  'Se carga el valor de los resultados de los votos
                    Case 3
                        sumaVotos += u("TotalVotos")
                        resultAlcalde = sumaVotos / 100
                        progbarAlc.Value = resultAlcalde 'Se carga el valor de los resultados de los votos
                    Case Else
                        Debug.WriteLine("Not between 1 and 10, inclusive")
                End Select

            End If

            If cmbBoxLis.Text = "FE - 10" And u("IdLista") = 3 Then
                Select Case u("idDignidad")
                    Case 1
                        sumaVotos += u("TotalVotos")
                        resultBinomio = sumaVotos / 100
                        progbarBin.Value = resultBinomio  'Se carga el valor de los resultados de los votos
                    Case 2
                        sumaVotos += u("TotalVotos")
                        resultConcejal = sumaVotos / 100
                        progbarConc.Value = resultBinomio  'Se carga el valor de los resultados de los votos
                    Case 3
                        sumaVotos += u("TotalVotos")
                        resultAlcalde = sumaVotos / 100
                        progbarAlc.Value = resultAlcalde 'Se carga el valor de los resultados de los votos
                    Case Else
                        Debug.WriteLine("Not between 1 and 10, inclusive")
                End Select

            End If
            If cmbBoxLis.Text = "ALIANZA PAIS - 35" And u("IdLista") = 4 Then
                Select Case u("idDignidad")
                    Case 1
                        sumaVotos += u("TotalVotos")
                        resultBinomio = sumaVotos / 100
                        progbarBin.Value = resultBinomio  'Se carga el valor de los resultados de los votos
                    Case 2
                        sumaVotos += u("TotalVotos")
                        resultConcejal = sumaVotos / 100
                        progbarConc.Value = resultBinomio  'Se carga el valor de los resultados de los votos
                    Case 3
                        sumaVotos += u("TotalVotos")
                        resultAlcalde = sumaVotos / 100
                        progbarAlc.Value = resultAlcalde 'Se carga el valor de los resultados de los votos
                    Case Else
                        Debug.WriteLine("Not between 1 and 10, inclusive")
                End Select

            End If

        Next

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As RoutedEventArgs) Handles btnSalir.Click
        Dim inicio As New WinMenuCandidato
        inicio.Owner = Me
        inicio.Show()

        Dim padre As WinCandidatoLista
        padre = Me
        padre.Hide()
    End Sub


    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Dim inicio As New WinMenuCandidato
        inicio = Me.Owner
        inicio.Show()

        Me.Hide()


    End Sub
End Class
