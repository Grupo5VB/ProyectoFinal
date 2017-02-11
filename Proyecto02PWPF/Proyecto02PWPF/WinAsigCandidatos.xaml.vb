Imports System.Data
Imports System.Data.OleDb
Public Class WinAsigCandidatos
    Private dsUsuarios As DataSet
    Dim winPrincipal As New WinPrincipal
    Private dsCandidatos As DataSet
    Private dsDignidades As DataSet
    Private dsListas As DataSet

    Private Sub btn_guardar_Click(sender As Object, e As RoutedEventArgs) Handles btn_guardar.Click
        Dim id = 0
        Try
            id = Me.DataContext.Id()
        Catch ex As Exception

        End Try
        For Each usuario As DataRow In Me.dsDignidades.Tables("Usuarios").Rows
            If usuario("Nombre") = txt_nombre.Text Then
                MessageBox.Show("El nombre del candidato ya existe")
                Exit For
            Else
                UpdateUsuario(id, txt_nombre.Text, txt_usuario.Text, txt_contraseña.Text)
                MessageBox.Show("Se Agrego la Candidato: " & txt_nombre.Text)
                Exit For
            End If
        Next
    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As RoutedEventArgs) Handles btn_cancelar.Click
        txt_nombre.Text = ""
        txt_usuario.Text = ""
        txt_contraseña.Text = ""
    End Sub

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

    Public Sub UpdateUsuario(id As Integer, nombre As String, usuario As String, contraseña As String)
        If id = 0 Then
            Me.dsUsuarios.Tables("Usuarios").Rows.Add(id, nombre, usuario, contraseña)
        Else
            For Each persona As DataRow In Me.dsUsuarios.Tables("Usuarios").Rows
                If persona("IdUsuario") = id Then
                    persona("Nombre") = nombre
                    persona("Usuario") = usuario
                    persona("Contraseña") = contraseña
                End If
            Next
        End If

        Using conexion As New OleDbConnection(winPrincipal.strConexion)
            Dim consulta As String = "Select * FROM Usuarios;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            Try
                adapter.Update(dsUsuarios.Tables("Usuarios"))
            Catch ex As Exception
                MessageBox.Show("Error al guardar")
            End Try

        End Using
    End Sub

    Public Sub updateDignidad(id As Integer, nombre As String)
        If id = 0 Then
            Me.dsDignidades.Tables("Dignidades").Rows.Add(id, nombre)
        Else
            For Each dignidades As DataRow In Me.dsDignidades.Tables("Dignidades").Rows
                If dignidades("IdUsuario") = id Then
                    dignidades("NombreDignidad") = nombre
                End If
            Next
        End If

        Using conexion As New OleDbConnection(winPrincipal.strConexion)
            Dim consulta As String = "Select * FROM Dignidades;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            Try
                adapter.Update(dsUsuarios.Tables("Dignidades"))
            Catch ex As Exception
                MessageBox.Show("Error al guardar")
            End Try

        End Using
    End Sub

    Private Sub WinAsigCandidatos_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Using conexion As New OleDbConnection(winPrincipal.strConexion)
            Dim consulta As String = "Select * FROM Usuarios;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            dsUsuarios = New DataSet("Usuarios")
            'adapter.FillSchema(dsUsuarios, SchemaType.Source)
            adapter.Fill(dsUsuarios, "Usuarios")

            '//conexion para candidatos
            Dim consulta2 As String = "Select * FROM Candidatos;"
            Dim adapter2 As New OleDbDataAdapter(New OleDbCommand(consulta2, conexion))
            Dim personaCmdBuilder2 = New OleDbCommandBuilder(adapter2)
            dsCandidatos = New DataSet("Candidatos")
            'adapter2.FillSchema(dsCandidatos, SchemaType.Source)
            adapter2.Fill(dsCandidatos, "Candidatos")

            '//conexion para Listas
            Dim consulta3 As String = "Select * FROM Listas;"
            Dim adapter3 As New OleDbDataAdapter(New OleDbCommand(consulta3, conexion))
            Dim personaCmdBuilder3 = New OleDbCommandBuilder(adapter3)
            dsListas = New DataSet("Listas")
            'adapter3.FillSchema(dsListas, SchemaType.Source)
            adapter3.Fill(dsListas, "Listas")

            '//conexion para Dignidades
            Dim consulta4 As String = "Select * FROM Dignidades;"
            Dim adapter4 As New OleDbDataAdapter(New OleDbCommand(consulta4, conexion))
            Dim personaCmdBuilder4 = New OleDbCommandBuilder(adapter4)
            dsDignidades = New DataSet("Dignidades")
            'adapter4.FillSchema(dsDignidades, SchemaType.Source)
            adapter4.Fill(dsDignidades, "Dignidades")
        End Using
    End Sub

    Private Sub cbx_dignidad_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cbx_dignidad.SelectionChanged
        cargarcombo1()
        Select Case cbx_dignidad.SelectedIndex
            Case 1
                txt_Dignidad.Text = cbx_dignidad.Text
            Case 2
                txt_Dignidad.Text = cbx_dignidad.Text
            Case 3
                txt_Dignidad.Text = cbx_dignidad.Text
        End Select


    End Sub

    Private Sub cbx_lista_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cbx_lista.SelectionChanged
        cargarcombo2()
    End Sub

    Private Sub cargarcombo1()
        Using conexion As New OleDbConnection(winPrincipal.strConexion)
            Dim consulta4 As String = "Select * FROM Dignidades;"
            Dim adapter4 As New OleDbDataAdapter(New OleDbCommand(consulta4, conexion))
            dsDignidades = New DataSet("Dignidades")
            adapter4.Fill(dsDignidades, "Dignidades")
            Dim dignidad As String
            For Each d As DataRow In dsDignidades.Tables("Dignidades").Rows
                dignidad = d("NombreDignidad")
                cbx_dignidad.Items.Add(dignidad)
                'cbx_dignidad.Items.Add(d("NombreDignidad")
            Next
        End Using

    End Sub

    Private Sub cargarcombo2()
        Using conexion As New OleDbConnection(winPrincipal.strConexion)
            Dim consulta3 As String = "Select * FROM Listas;"
            Dim adapter3 As New OleDbDataAdapter(New OleDbCommand(consulta3, conexion))
            Dim personaCmdBuilder3 = New OleDbCommandBuilder(adapter3)
            dsListas = New DataSet("Listas")
            adapter3.FillSchema(dsListas, SchemaType.Source)
            adapter3.Fill(dsListas, "Listas")
            'Dim lista As String
            For Each l As DataRow In dsListas.Tables("Listas").Rows
                'lista = l("NombreLista")
                'cbx_lista.Items.Add(lista)
                cbx_lista.Items.Add(l("NombreLista"))
            Next
        End Using
    End Sub
End Class
