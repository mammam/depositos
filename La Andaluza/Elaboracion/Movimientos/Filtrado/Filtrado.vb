﻿Namespace Movimientos

    Public Class Filtrado
        Inherits Movimientos.MovimientoBasico

        Public lotePartida As Lote
        Public loteFinal As Lote
        Public Abreviatura As String
        Public filtro As Integer

        Public Sub New(ByVal proceso As Integer)
            Me.proceso = proceso

            Me.lotePartida = New Lote()
            Me.loteFinal = New Lote()
        End Sub

        Public Function validar() As String
            Dim ch As New DecimalChecker
            ch.check_decimal("cantidad", cantidad, 0)

            Return ch.mensaje & loteFinal.validar & lotePartida.validar
        End Function

        'Public Class Deposito
        '    Public numero As String
        '    Public codigo_lote As String
        '    Public descripcion As String
        '    Public capacidad As Double
        '    Public cantidad As Double
        '    Public producto As Trasiego.Producto
        '    Public id As Integer
        'End Class

        Public Class Lote
            Public codigo_lote As String
            Public id As Integer
            Public descripcion As String
            Public cantidad_restante As Double
            Public producto As Integer
            Public tipo As Integer
            Public deposito As Integer
            Public muestra As Boolean

            Public Sub New(Optional ByVal tipo As Integer = 0)
                Me.tipo = tipo
                Me.muestra = False
                codigo_lote = ""
            End Sub
            Public Function validar() As String
                Dim msg As String = ""

                If tipo <= 0 Then
                    msg = "El tipo del lote no es valido"
                End If

                If producto <= 0 Then
                    msg &= "El producto no es valido"
                End If

                Return msg
            End Function
        End Class

        'Public Class TipoLote
        '    Public nombre As String
        '    Public id As Integer
        '    Public abreviatura As String

        '    Public Function validar() As String
        '        Return ""
        '    End Function
        'End Class

        'Public Class Producto
        '    Public nombre As String
        '    Public id As Integer

        '    Public Function validar() As String
        '        Return ""
        '    End Function
        'End Class


    End Class

End Namespace

