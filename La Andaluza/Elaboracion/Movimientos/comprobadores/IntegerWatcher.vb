﻿Public Class IntegerWatcher
    Inherits Watcher
    Private minimo As Integer
    Private maximo As Integer
    Public Sub New(ByRef control As TextBox, Optional ByVal minimo As Integer = -999999999, Optional ByVal maximo As Integer = 999999999)
        MyBase.New(CType(control, Control))

        Me.filtro = "1234567890"
        Me.minimo = minimo
        Me.maximo = maximo
        AddHandler Me.control.KeyPress, AddressOf comprobar
        AddHandler Me.control.KeyUp, AddressOf comprobarContenido
    End Sub

    Private Sub comprobar(sender As Object, e As KeyPressEventArgs)
        If Not Me.filtro.Contains(e.KeyChar) And Asc(e.KeyChar) <> Keys.Delete And Asc(e.KeyChar) <> 8 Then
            e.Handled = True
            Return
        End If
    End Sub

    Private Sub comprobarContenido(sender As Object, e As KeyEventArgs)

        If control.Text = "" Then
            control.BackColor = Color.Red
            tooltip.SetToolTip(control, "El valor debe estar comprendido entre " & minimo & " y " & maximo)
        ElseIf Convert.ToInt32(control.Text) <= minimo Then
            control.BackColor = Color.Red
            tooltip.SetToolTip(control, "El valor minimo es " & minimo)
        ElseIf Convert.ToInt32(control.Text) >= maximo Then
            control.BackColor = Color.Red
            tooltip.SetToolTip(control, "El valor debe estar comprendido entre " & minimo & " y " & maximo)
        Else
            control.BackColor = backcolor
            tooltip.SetToolTip(control, "valor correcto")
        End If
    End Sub
End Class
