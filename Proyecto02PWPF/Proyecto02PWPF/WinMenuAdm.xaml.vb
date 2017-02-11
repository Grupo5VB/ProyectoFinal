Public Class WinMenuAdm
    Private Sub btn_asig_dig_Click(sender As Object, e As RoutedEventArgs) Handles btn_asig_dig.Click
        Dim menAsigDig As New WinAsigDignidades
        menAsigDig.Owner = Me
        menAsigDig.Show()
        Me.Hide()
    End Sub

    Private Sub btn_asig_cand_Click(sender As Object, e As RoutedEventArgs) Handles btn_asig_cand.Click
        Dim menAsigCand As New WinAsigCandidatos
        menAsigCand.Owner = Me
        menAsigCand.Show()
        Me.Hide()
    End Sub

    Private Sub btn_salir_Click(sender As Object, e As RoutedEventArgs) Handles btn_salir.Click
        Dim winPrincipal As New WinPrincipal
        winPrincipal.Owner = Me
        winPrincipal.Show()
        Me.Hide()
    End Sub

    Private Sub btn_mostrar_result_Click(sender As Object, e As RoutedEventArgs) Handles btn_mostrar_result.Click
        Dim winMostarDatos As New WinMostrarDatos
        winMostarDatos.Owner = Me
        winMostarDatos.Show()
    End Sub
End Class
