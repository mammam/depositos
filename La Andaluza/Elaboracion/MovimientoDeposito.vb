﻿Public Class MovimientoDeposito
    Inherits Connection.DataBase

    Public trazabilidad As Boolean 'si el movimiento posee trazabilidad
    Public MovimientoID As Integer 'id del movimiento a eliminar    
    Public movimientoReflexivo As Boolean 'movimiento sobre si mismo
    Public movimientoReflexivoEntreDepositos As Boolean ' movimientos sobre si mismo a diferente deposito
    Public eliminarDestino As Boolean
    Public lotePartida As MovimientoDeposito.Lote ' lote del que suge el movimiento
    Public lotePartida2 As MovimientoDeposito.Lote  ' segundo lote del que sale el movimiento, para volcados sobre depositos ocupados
    Public loteDestino As MovimientoDeposito.Lote   ' lote que recibe el movimiento
    Public cantidad As Double
    Public cantidadSecundaria As Double

    Public Sub New()
        MyBase.New(Config.Server)
        lotePartida = New MovimientoDeposito.Lote
        lotePartida2 = New MovimientoDeposito.Lote
        loteDestino = New MovimientoDeposito.Lote


        trazabilidad = False
        MovimientoID = 0
        movimientoReflexivo = False
        movimientoReflexivoEntreDepositos = False
        eliminarDestino = False
        cantidad = 0
        cantidadSecundaria = 0
    End Sub

    Public Function devolverDepositos() As DataTable
        Return Consultar("SELECT Depositos.DepositoID, Depositos.Codigo FROM  Depositos WHERE (Depositos.BotaID IS NULL) ", False)
    End Function

    Public Function tieneTrazabilidad(ByVal movimientoid As Integer) As Boolean
        Dim dt As DataTable = Consultar("select count(*) from compuestoPor where movimientoid = " & movimientoid, False)

        If dt Is Nothing Then Return False

        If Convert.ToInt32(dt.Rows(0).Item(0)) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function tieneTrazabilidadLote(ByVal loteID As Integer, ByVal movimientoid As Integer) As Boolean
        Dim dt As DataTable = Consultar("select count(*) from compuestoPor where (loteFinal = " & loteID & " and movimientoid<>" & movimientoid & ") or (lotePArtida=" & loteID & ")", False)

        If dt Is Nothing Then Return False

        If Convert.ToInt32(dt.Rows(0).Item(0)) > 0 Then            
            Return True
        Else
            dt = Consultar("select count(*) from movimientos where loteid = " & loteID & " and movimientoid<>" & movimientoid)
            If dt Is Nothing Then Return False

            If Convert.ToInt32(dt.Rows(0).Item(0)) > 0 Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Public Function tieneTrazabilidadMultiLote(ByVal movimientoid As Integer) As Boolean
        Dim dt As DataTable = Consultar("select count(*) from compuestoPor where movimientoid = " & movimientoid, False)

        If dt Is Nothing Then Return False

        If Convert.ToInt32(dt.Rows(0).Item(0)) > 1 Then
            Return True
        Else
            Return False
        End If
    End Function


    Public Function estaOcupado(ByVal depositoID As Integer) As Boolean
        Dim dt As DataTable = Consultar("select count(*) from lotes where depositoid = " & depositoID, False)


        If Convert.ToInt32(dt.Rows(0).Item(0)) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function esReflexivo(ByVal movimientoid As Integer) As Boolean
        Dim dt As DataTable = Consultar("select count(*) from compuestopor where lotefinal = lotePartida and movimientoid= " & movimientoid, False)


        If Convert.ToInt32(dt.Rows(0).Item(0)) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function recuperarCantidadMovimiento(ByVal movimientoid As Integer) As Double
        Dim dt As DataTable = Consultar("select isnull(cantidad,0) from movimientos where movimientoid =" & movimientoid, False)

        Return Convert.ToDouble(dt.Rows(0).Item(0))
    End Function

    Public Function recuperarCantidadTrazabilidad(ByVal movimientoid As Integer, ByVal lotepartida As Integer) As Double
        Dim dt As DataTable = Consultar("select isnull(cantidad,0) from compuestopor where movimientoid =" & movimientoid & " and lotepartida=" & lotepartida, False)

        Return Convert.ToDouble(dt.Rows(0).Item(0))
    End Function
    Public Function recuperarLoteMovimiento(ByVal movimientoId As Integer) As Integer
        Dim dt As DataTable = Consultar("select loteid from movimientos where movimientoid = " & movimientoId, False)

        If dt Is Nothing Then Return 0
        If dt.Rows(0).Item(0) Is Convert.DBNull Then Return 0

        Return Convert.ToInt32(dt.Rows(0).Item(0))
    End Function

    Public Function recuperarLoteTrazabilidad(ByVal movimientoId As Integer) As Integer
        Dim dt As DataTable = Consultar("select loteFinal from compuestopor where movimientoid = " & movimientoId, False)

        If dt Is Nothing Then Return 0
        If dt.Rows(0).Item(0) Is Convert.DBNull Then Return 0

        Return Convert.ToInt32(dt.Rows(0).Item(0))
    End Function

    Public Function recuperarLotePartidaTrazabilidad(ByVal movimientoId As Integer) As Integer
        Dim dt As DataTable = Consultar("select top 1 lotePartida from compuestopor where movimientoid = " & movimientoId & " order by lotePartida", False)

        If dt Is Nothing Then Return 0
        If dt.Rows(0).Item(0) Is Convert.DBNull Then Return 0

        Return Convert.ToInt32(dt.Rows(0).Item(0))
    End Function

    Public Function recuperarCodigoLoteMovimiento(ByVal movimientoId As Integer) As String
        Dim dt As DataTable = Consultar("select top 1 codigolote from movimientos, lotes where lotes.loteid = movimientos.loteid and movimientoid = " & movimientoId & " order by lotepartida", False)

        If dt Is Nothing Then Return "-"
        If dt.Rows(0).Item(0) Is Convert.DBNull Then Return "-"

        Return Convert.ToString(dt.Rows(0).Item(0))
    End Function

    Public Function recuperarSegundoLotePartidaTrazabilidad(ByVal movimientoId As Integer) As Integer
        Dim dt As DataTable = Consultar("select top 1 lotePartida from compuestopor where movimientoid = " & movimientoId & " order by lotePartida desc", False)

        If dt Is Nothing Then Return 0
        If dt.Rows(0).Item(0) Is Convert.DBNull Then Return 0

        Return Convert.ToInt32(dt.Rows(0).Item(0))
    End Function

    Public Function recuperarSegundoCodigoLotePartidaTrazabilidad(ByVal movimientoId As Integer) As String
        Dim dt As DataTable = Consultar("select top 1 codigolote from compuestopor, lotes where lotepartida = loteid and movimientoid = " & movimientoId & " order by lotePartida desc", False)

        If dt Is Nothing Then Return "-"
        If dt.Rows(0).Item(0) Is Convert.DBNull Then Return "-"

        Return Convert.ToString(dt.Rows(0).Item(0))
    End Function

    Public Function recuperarCodigoLoteTrazabilidad(ByVal movimientoId As Integer) As String
        Dim dt As DataTable = Consultar("select codigolote from compuestopor, lotes where lotefinal = loteid and movimientoid = " & movimientoId, False)

        If dt Is Nothing Then Return "-"
        If dt.Rows(0).Item(0) Is Convert.DBNull Then Return "-"

        Return Convert.ToString(dt.Rows(0).Item(0))
    End Function

    Public Function recuperarCodigoLotePartidaTrazabilidad(ByVal movimientoId As Integer) As String
        Dim dt As DataTable = Consultar("select codigolote from compuestopor, lotes where lotepartida = loteid and movimientoid = " & movimientoId, False)

        If dt Is Nothing Then Return "-"
        If dt.Rows(0).Item(0) Is Convert.DBNull Then Return "-"

        Return Convert.ToString(dt.Rows(0).Item(0))
    End Function
    Public Function actualizarValoresLote(ByVal loteid As Integer, ByVal cantidadMovimiento As Double, Optional restar As Boolean = False) As Boolean
        If Not Me.actualizarCantidadLote(loteid, cantidadMovimiento, restar) Then
            Return False
        End If

        If Not Me.actualizarDepositoLote(loteid) Then
            Return False
        End If

        If Not Me.actualizarDepositoPrevioLote(loteid) Then
            Return False
        End If

        Return True
    End Function

    Public Function actualizarDepositoLote(ByVal loteid As Integer) As Boolean
        If Not ConsultaAlteraciones("update lotes set depositoid = depositoprevioid where loteid=" & loteid) Then
            Return False
        End If

        Return True
    End Function
    Public Function actualizarCantidadLote(ByVal loteid As Integer, ByVal cantidadmovimiento As Double, Optional ByVal restar As Boolean = False) As Boolean
        If restar Then
            If Not ConsultaAlteraciones("update lotes set cantidadrestante = isnull(cantidadrestante,0)-" & cantidadmovimiento.ToString.Replace(",", ".") & " where loteid=" & loteid) Then
                Return False
            End If
        Else
            If Not ConsultaAlteraciones("update lotes set cantidadrestante = isnull(cantidadrestante,0)+ " & cantidadmovimiento.ToString.Replace(",", ".") & " where loteid=" & loteid) Then
                Return False
            End If
        End If

        Return True
    End Function

    'Public Function actualizarCantidadLoteTrazabilidadMulti(ByVal loteid As Integer, ByVal cantidadEnTrazabilidad As Double, Optional ByVal restar As Boolean = False) As Boolean
    '    If restar Then
    '        If Not ConsultaAlteraciones("update lotes set cantidadrestante= isnull(cantidadrestante,0)-" & cantidadEnTrazabilidad & " and lotepartida=" & lotePartida & ") where loteid=" & loteid) Then
    '            Return False
    '        End If
    '    Else
    '        If Not ConsultaAlteraciones("update lotes set cantidadrestante = isnull(cantidadrestante,0)+(select cantidad from compuestopor where movimientoid = " & MovimientoID & " and lotepartida=" & lotePartida & ") where loteid=" & loteid) Then
    '            Return False
    '        End If
    '    End If

    '    Return True
    'End Function

    Public Function actualizarDepositoPrevioLote(ByVal loteid As Integer) As Boolean
        If Not ConsultaAlteraciones("update lotes set depositoprevioid =null where loteid=" & loteid) Then
            Return False
        End If

        Return True
    End Function
    Public Function borrarMovimiento(ByVal movimientoid As Integer) As Boolean
        If Not ConsultaAlteraciones("delete from movimientos where movimientoid=" & movimientoid) Then
            Return False
        End If

        Return True
    End Function

    Public Function borrarLote(ByVal loteID As Integer) As Boolean

        'analiticas
        If Not ConsultaAlteraciones("delete from AnaliticasExternas where analiticaid in (select analiticaid from analiticas where loteid = " & loteID & ")") Then
            Return False
        End If

        If Not ConsultaAlteraciones("delete from AnaliticasValores where analiticaid in (select analiticaid from analiticas where loteid = " & loteID & " )") Then
            Return False
        End If

        If Not ConsultaAlteraciones("delete from Analiticas where loteId = " & loteID) Then
            Return False
        End If

        'elaboraciones
        If Not ConsultaAlteraciones("delete from elaboraciones_ingredientes where id_elaboracion in (select id from elaboraciones where id_elaboracion_final in(select id from elaboraciones_finales where id_lote_terminado = " & loteID & " ))") Then
            Return False
        End If

        If Not ConsultaAlteraciones("delete from elaboraciones where id_elaboracion_final in(select id from elaboraciones_finales where id_lote_terminado = " & loteID & ")") Then
            Return False
        End If

        If Not ConsultaAlteraciones("delete from elaboraciones_finales where id_lote_terminado = " & loteID) Then
            Return False
        End If

        If Not ConsultaAlteraciones("delete from elaboraciones_ingredientes where id_elaboracion in (select id from elaboraciones where id_lote =" & loteID & " )  ") Then
            Return False
        End If


        If Not ConsultaAlteraciones("delete from elaboraciones where id_lote = " & loteID) Then
            Return False
        End If

        If Not ConsultaAlteraciones("delete from elaboraciones_finales where id not in (select id_elaboracion_final from elaboraciones)") Then
            Return False
        End If

        If Not ConsultaAlteraciones("update movimientos set loteid=null where movimientoid=" & MovimientoID) Then
            Return False
        End If

        If Not ConsultaAlteraciones("delete from lotes where loteid=" & loteID) Then
            Return False
        End If

        Return True
    End Function

    Public Function borrarTrazabilidad(ByVal loteDestino As Integer, ByVal movimientoid As Integer) As Boolean
        If Not ConsultaAlteraciones("delete from compuestopor where movimientoid=" & movimientoid & " and lotePartida=" & loteDestino) Then
            Return False
        End If

        Return True
    End Function

    Public Function seleccionarDepositoActual(ByVal loteid As Integer) As Integer
        Dim dt As DataTable = Consultar("select isnull(depositoid,0) from lotes where loteid = " & loteid.ToString, False)

        If dt Is Nothing Then Return 0

        Return Convert.ToInt32(dt.Rows(0).Item(0))
    End Function

    Public Function seleccionarDepositoPrevio(ByVal loteid As Integer) As Integer
        Dim dt As DataTable = Consultar("select isnull(depositoPrevioid,0) from lotes where loteid = " & loteid.ToString, False)

        If dt Is Nothing Then Return 0

        Return Convert.ToInt32(dt.Rows(0).Item(0))
    End Function

    Public Class Lote
        Public Id As Integer
        Public codigoLote As String
        Public deposito As Integer
        Public depositoPrevio As Integer
        Public trazabilidadLote As Boolean
        Public revertirDepositos As Boolean
        Public depositoOcupado As Boolean 'deposito previo del lote partida ocupado
        Public eliminable As Boolean 'si el lote final se puede eliminar por no ser el de partida y no contener trazabilidad

        Public Sub New()
            Id = 0
            codigoLote = ""
            deposito = 0
            depositoPrevio = 0
            trazabilidadLote = False
            revertirDepositos = False
            depositoOcupado = True
            eliminable = False
        End Sub

    End Class

End Class
