Imports System.Data

Class WinPrincipal
    Public dbPath As String = "C:\Users\Galo\Source\Repos\ProyectoFinal\Proyecto02PWPF\BDVotacion.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Public dsPersonas As DataSet

    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        Dim venLogVot As New WinLogVotante
        venLogVot.Owner = Me
        venLogVot.Show()
        Me.Hide()
    End Sub

    Private Sub WinPrincipal_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles MyBase.Closing, MyBase.Closing
        End
    End Sub
End Class
