﻿Public Class SpAjusteComercial
   Inherits DataBase

    Public Sub New()
        MyBase.New(Config.Server)
    End Sub

    Public Function devolver_tipos_de_lotes() As DataTable
        Return Me.Consultar("select Lotes.LoteID, Lotes.CodigoLote from " & _
                              " Lotes LEFT OUTER JOIN TiposProductos ON Lotes.TipoProductoID = TiposProductos.TipoProductoID inner join usosProductos on TiposProductos.TipoProductoID = usosproductos.TipoProductoID " & _
                              " where usosProductos.ProcesoID = 8 and CantidadRestante > 0", False)
    End Function

    Public Function devolver_depositos_ocupados() As DataTable
        Return Me.Consultar("devolverDepositosPartidas")
    End Function

    Public Function devolver_depositos() As DataTable
        Return Me.Consultar("devolverDepositosFinales") 'devolverDepositosPartidas
    End Function

    Public Function actualizar(ByVal destino As Integer, ByVal cantidad As Double, ByVal lote As Integer, ByVal id As Integer) As Boolean
        Return Me.ConsultaAlteraciones("update movimientosAbiertos set " & _
                                 "saledepositoid=" & destino.ToString & "," & _
                                 "cantidad=" & cantidad.ToString.Replace(",", ".") & "," & _
                                 "Loteid=" & lote.ToString & _
                                " where movimientoid=" & id.ToString)
    End Function
End Class