Imports System.Data
Imports System.Data.OleDb

Public Class WinAsigDignidades
    Private dsDignidades As DataSet
    Dim winPrincipal As New WinPrincipal
    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Dim mainWin As New WinPrincipal
        mainWin.Show()

    End Sub

    Private Sub btn_regresar_Click(sender As Object, e As RoutedEventArgs) Handles btn_regresar.Click
        Dim venMenuAdm As New WinMenuAdm
        venMenuAdm.Owner = Me
        venMenuAdm.Show()
        Me.Hide()
    End Sub

    Private Sub btn_nuevo_Click(sender As Object, e As RoutedEventArgs) Handles btn_nuevo.Click
        txt_nombredig.Text = ""
    End Sub

    Private Sub btn_guardar_Click(sender As Object, e As RoutedEventArgs) Handles btn_guardar.Click
        Dim id = 0
        Try
            id = Me.DataContext.Id()
        Catch ex As Exception

        End Try
        For Each dignidad As DataRow In Me.dsDignidades.Tables("Dignidades").Rows
            If dignidad("NombreDignidad") = txt_nombredig.Text Then
                MessageBox.Show("El nombre de la dignidad ya existe")
                Exit For
            Else
                UpdateDignidad(id, txt_nombredig.Text)
                MessageBox.Show("Se Agrego la dignidad: " & txt_nombredig.Text)
                Exit For
            End If
        Next
    End Sub


    Private Sub WinAsigDignidades_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        conexionDignidad()
    End Sub

    Private Sub conexionDignidad()
        Using conexion As New OleDbConnection(winPrincipal.strConexion)
            Dim consulta As String = "Select * FROM Dignidades;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            dsDignidades = New DataSet("Dignidades")
            adapter.FillSchema(dsDignidades, SchemaType.Source)
            adapter.Fill(dsDignidades, "Dignidades")
        End Using
    End Sub

    Private Sub UpdateDignidad(id As Integer, nombre As String)
        If id = 0 Then
            Me.dsDignidades.Tables("Dignidades").Rows.Add(id, nombre)
        Else
            For Each dignidad As DataRow In Me.dsDignidades.Tables("Dignidades").Rows
                If dignidad("IdDignidad") = id Then
                    dignidad("NombreDignidad") = nombre
                End If
            Next
        End If

        Using conexion As New OleDbConnection(winPrincipal.strConexion)
            Dim consulta As String = "Select * FROM Dignidades;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            Try
                adapter.Update(dsDignidades.Tables("Dignidades"))
            Catch ex As Exception
                MessageBox.Show("Error al guardar")
            End Try

        End Using
    End Sub
End Class
