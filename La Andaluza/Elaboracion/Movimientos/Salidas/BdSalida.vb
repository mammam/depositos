﻿Namespace Movimientos
    Public Class BdSalida
        Inherits Connection.DataBase

        Private query As String
        Public Sub New()
            MyBase.New(Config.Server)
        End Sub


        Public Function seleccionar_lote_por_codigo(ByVal codigo As String) As DataTable
            query = "select loteid, codigolote, descripcion, cantidadRestante, tipoproductoid, depositoid from lotes where codigoLote = @codigoLote"
            PrepararConsulta(query)
            AñadirParametroConsulta("@codigoLote", codigo)
            Return Consultar()
        End Function

        Public Function seleccionar_lote(ByVal id As Integer) As DataTable
            query = "select loteid, codigolote, descripcion, cantidadRestante, tipoproductoid, depositoid from lotes where loteid = @id"
            PrepararConsulta(query)
            AñadirParametroConsulta("@id", id)
            Return Consultar()
        End Function


        Public Function crear_lote(ByVal nuevoCodigo As String, ByVal depositoDestino As Integer, ByVal cantidad As Double, ByVal tlote As Integer, ByVal producto As Integer) As Boolean

            query = "INSERT INTO [dbo].[Lotes] " & _
                                               "([Fecha] " & _
                                               ",[CantidadRestante] " & _
                                               ",[TipoLoteID] " & _
                                               ",[TipoProductoID] " & _
                                               ",[CodigoLote] " & _
                                               ",[DepositoID] " & _
                                               ",[Revisar] " & _
                                               ",[FechaModificacion] " & _
                                               ",[UsuarioModificacion]) " & _
                                            "VALUES( " & _
                                                "CURRENT_TIMESTAMP " & _
                                                ", @cantidad    " & _
                                                ", @tlote " & _
                                                ", @producto " & _
                                                ", @nuevoCodigo " & _
                                                ", @depositoDestino " & _
                                                ",'True' " & _
                                                ",CURRENT_TIMESTAMP " & _
                                                ",17 " & _
                                            ")"

            PrepararConsulta(query)
            AñadirParametroConsulta("@cantidad", cantidad)
            AñadirParametroConsulta("@tlote", tlote)
            AñadirParametroConsulta("@producto", producto)
            AñadirParametroConsulta("@nuevoCodigo", nuevoCodigo)
            If depositoDestino = 0 Then
                AñadirParametroConsulta("@depositoDestino", Convert.DBNull)
            Else
                AñadirParametroConsulta("@depositoDestino", depositoDestino)
            End If

            Return Consultar(True)

        End Function


        Public Function actualizar_lote(ByVal codigoLote As String, ByVal cantidad As Double) As Boolean
            query = "update lotes set cantidadRestante=cantidadRestante+@cantidad where codigolote= @codigoLote"
            PrepararConsulta(query)
            AñadirParametroConsulta("@cantidad", cantidad)
            AñadirParametroConsulta("@codigoLote", codigoLote)

            Return Consultar(True)


        End Function

        Public Function sacar_lote(ByVal codigoLote As String) As Boolean
            query = "update lotes set depositoprevioid=depositoid, depositoid=null where codigolote= @codigoLote"

            PrepararConsulta(query)
            AñadirParametroConsulta("@codigoLote", codigoLote)

            Return Consultar(True)


        End Function

        Public Function calcular_codigo_lote(ByVal codigoSinLetra As String) As String
            query = "LotesSelectUltimoCodigo @codigoSinLetra"
            PrepararConsulta(query)
            AñadirParametroConsulta("@codigoSinLetra", codigoSinLetra)
            Dim dt As DataTable = Consultar()

            If dt.Rows.Count = 0 Then
                Return codigoSinLetra & "1"
            End If

            If dt.Rows(0).Item(0) Is Convert.DBNull Then
                Return codigoSinLetra & "1"
            End If

            Dim row As String = dt.Rows(0).Item(0).ToString
            Dim extra As String
            Dim ascii As Integer

            If row.Length > 14 Then
                extra = row.Substring(14, 1)
                ascii = Asc(extra) + 1

                If ascii = 58 Then
                    ascii = 65
                ElseIf ascii = 90 Then
                    ascii = 97
                End If


                Return codigoSinLetra & Chr(ascii)
            Else
                Return codigoSinLetra & "1"
            End If
        End Function


        ''*****************************************************************************************
        ''                         funciones de transicubas
        ''*****************************************************************************************  
        Public Function listar_transicubas_activas() As DataTable
            query = "select Depositos.TransicubaID,Depositos.Codigo from " & _
                              "Depositos INNER JOIN Transicubas ON Depositos.TransicubaID = Transicubas.TransicubaID where " & _
                              "(Transicubas.Estado = 'True')  and Depositos.DepositoID not in (SELECT DISTINCT Depositos.DepositoID FROM Depositos INNER JOIN Transicubas ON Depositos.TransicubaID = Transicubas.TransicubaID INNER JOIN Lotes ON Depositos.DepositoID = Lotes.DepositoID WHERE (Transicubas.Estado = 'True')) order by Depositos.Codigo"

            PrepararConsulta(query)
            Return Consultar()
        End Function

        ''*****************************************************************************************
        ''                         funciones de productos
        ''*****************************************************************************************        
        Public Function seleccionar_detalles_producto(ByVal id As Integer) As DataTable
            query = "select TipoProductoID, Descripcion, Abreviatura from TiposProductos where TipoProductoID=@id"
            PrepararConsulta(query)
            AñadirParametroConsulta("@id", id)
            Return Consultar()
        End Function

        Public Function listar_productos() As DataTable
            query = "select TipoProductoID, Descripcion, Abreviatura from TiposProductos order by descripcion"
            PrepararConsulta(query)

            Return Consultar()
        End Function


        ''*****************************************************************************************
        ''                         funciones de tiposLotes
        ''*****************************************************************************************       

        Public Function listar_tlotes() As DataTable
            query = "select TipoLoteID, Descripcion, Abreviatura from TiposLotes order by descripcion"
            PrepararConsulta(query)
            Return Consultar()
        End Function

        Public Function seleccionar_detalles_tlote(ByVal id As Integer) As DataTable
            query = "select TipoLoteID, Descripcion, Abreviatura from TiposLotes where TipoLoteid=@id"
            PrepararConsulta(query)
            AñadirParametroConsulta("@id", id)
            Return Consultar()
        End Function

        ''*****************************************************************************************
        ''                         funciones de procesos
        ''*****************************************************************************************
        Public Function seleccionar_muestra_pro_proceso(ByVal proceso As Integer) As DataTable
            query = "select isnull(conmuestra, 'false') from procesos where procesoid= @id"
            PrepararConsulta(query)
            AñadirParametroConsulta("@id", proceso)
            Return Consultar()
        End Function

        Public Function seleccionar_tlote_por_proceso(ByVal proceso As Integer) As DataTable
            query = "select isnull(TipoLoteID, 0) from procesos where procesoid= @id"
            PrepararConsulta(query)
            AñadirParametroConsulta("@id", proceso)
            Return Consultar()
        End Function

        ''*****************************************************************************************
        ''                         funciones de procesos
        ''*****************************************************************************************
        Public Function listar_recipientes() As DataTable
            query = "RecipiesntesSalidasCbo"
            PrepararConsulta(query)
            Return Consultar()
        End Function

        ''*****************************************************************************************
        ''                         funciones de depositos
        ''*****************************************************************************************

        Public Function seleccionar_detalles_deposito(ByVal id_deposito As Integer) As DataTable
            query = "select " & _
                        "Depositos.Codigo,   " & _
                        "Lotes.CodigoLote,  " & _
                        "CASE  " & _
                        "        WHEN CodigoLote is NULL THEN dbo.DepositoLavado(Depositos.DepositoID)  " & _
                        "        ELSE Lotes.Descripcion  " & _
                        "END AS Descripcion, " & _
                        "Depositos.Capacidad,  " & _
                        "Lotes.CantidadRestante, " & _
                        "Depositos.depositoID, " & _
                        "Depositos.Listado,   " & _
                        "Lotes.TipoLoteID, " & _
                        "Lotes.TipoProductoID, " & _
                        "TiposProductos.descripcion producto " & _
                    "from " & _
                        "TiposProductos " & _
                        "RIGHT OUTER JOIN Lotes  " & _
                        "ON Lotes.TipoProductoID = TiposProductos.TipoProductoID " & _
                        "RIGHT OUTER JOIN  Depositos  " & _
                        "ON Lotes.DepositoID = Depositos.DepositoID " & _
                    "where " & _
                        "Depositos.BotaID Is NULL  " & _
                        "and  " & _
                        "Depositos.Listado = 'TRUE' " & _
                        "and " & _
                        "depositos.depositoid = @id_deposito " & _
                    "ORDER BY " & _
                        "Depositos.Codigo "

            PrepararConsulta(query)
            AñadirParametroConsulta("@id_deposito", id_deposito)
            Return Consultar()
        End Function


        Public Function devolver_depositos_ocupados() As DataTable
            query = "select " & _
                           "Depositos.Codigo,   " & _
                           "Lotes.CodigoLote,  " & _
                           "CASE  " & _
                           "        WHEN CodigoLote is NULL THEN dbo.DepositoLavado(Depositos.DepositoID)  " & _
                                   "ELSE Lotes.Descripcion  " & _
                           "END AS Descripcion, " & _
                           "Depositos.Capacidad,  " & _
                           "Lotes.CantidadRestante,     " & _
                           "Depositos.depositoID, " & _
                           "Depositos.Listado,   " & _
                           "Lotes.TipoLoteID,  " & _
                           "Lotes.TipoProductoID, " & _
                           "TiposProductos.descripcion producto, " & _
                           "Lotes.loteid " & _
                   "from  " & _
                           "TiposProductos " & _
                           "RIGHT OUTER JOIN Lotes  " & _
                           "ON Lotes.TipoProductoID = TiposProductos.TipoProductoID " & _
                           "inner JOIN  Depositos  " & _
                           "ON Lotes.DepositoID = Depositos.DepositoID " & _
                   "where " & _
                           "Depositos.BotaID Is NULL  " & _
                           "and  " & _
                           "Depositos.Listado = 'TRUE' " & _
                           "ORDER BY " & _
                           "Depositos.Codigo "

            PrepararConsulta(query) '"devolverDepositosPartidas")
            Return Me.Consultar()
        End Function

        Public Function devolver_depositos_excepto(ByVal codigo As String) As DataTable
            query = "select " & _
                           "Depositos.Codigo,   " & _
                           "Lotes.CodigoLote,  " & _
                           "CASE  " & _
                           "        WHEN CodigoLote is NULL THEN dbo.DepositoLavado(Depositos.DepositoID)  " & _
                                   "ELSE Lotes.Descripcion  " & _
                           "END AS Descripcion, " & _
                           "Depositos.Capacidad,  " & _
                           "Lotes.CantidadRestante,     " & _
                           "Depositos.depositoID, " & _
                           "Depositos.Listado,   " & _
                           "Lotes.TipoLoteID,  " & _
                           "Lotes.TipoProductoID, " & _
                           "TiposProductos.descripcion producto, " & _
                           "Lotes.loteid " & _
                   "from  " & _
                           "TiposProductos " & _
                           "RIGHT OUTER JOIN Lotes  " & _
                           "ON Lotes.TipoProductoID = TiposProductos.TipoProductoID " & _
                           "right JOIN  Depositos  " & _
                           "ON Lotes.DepositoID = Depositos.DepositoID " & _
                   "where " & _
                           "Depositos.BotaID Is NULL  " & _
                           "and  Depositos.Codigo <> @cod and " & _
                           "Depositos.Listado = 'TRUE' " & _
                           "ORDER BY " & _
                           "Depositos.Codigo "

            PrepararConsulta(query)
            AñadirParametroConsulta("@cod", codigo)
            Return Me.Consultar()
        End Function

        ''*****************************************************************************************
        ''                         funciones de movimientos
        ''*****************************************************************************************
        Public Function guardar_movimiento(ByVal id_deposito_origen As Integer, ByVal id_deposito_destino As Integer, ByVal cantidad As Double, ByVal proceso As Integer) As Boolean
            query = "insert into movimientos(entraDepositoID, saleDepositoId, cantidad, procesoid, fecha) " & _
                            "values( @id_deposito_destino, " & _
                                    "@id_deposito_origen, " & _
            "@cantidad, @proc, CURRENT_TIMESTAMP)"

            PrepararConsulta(query)
            AñadirParametroConsulta("@id_deposito_destino", If(id_deposito_destino = 0, Convert.DBNull, id_deposito_destino))
            AñadirParametroConsulta("@id_deposito_origen", If(id_deposito_origen = 0, Convert.DBNull, id_deposito_origen))
            AñadirParametroConsulta("@cantidad", cantidad)
            AñadirParametroConsulta("@proc", proceso)

            Return Consultar(True)


        End Function

        Public Function guardar_trazabilidad(ByVal codigoDestino As String, ByVal codigoOrigen As String, ByVal cantidad As Double) As Boolean
            query = "INSERT INTO [dbo].[CompuestoPor] " & _
                                                       "([LoteFinal] " & _
                                                       ",[LotePartida] " & _
                                                       ",[MovimientoID] " & _
                                                       ",[Cantidad] " & _
                                                       ",[FechaModificacion] " & _
                                                       ",[UsuarioModificacion])" & _
                                            "VALUES " & _
                                                        "( (select top 1 loteid from lotes where codigoLote = @codigoDestino ) " & _
                                                        ", (select top 1 loteid from lotes where codigoLote = @codigoOrigen ) " & _
                                                        ", (select max(movimientoid) from movimientos) " & _
                                                        ", @cantidad " & _
                                                        ", CURRENT_TIMESTAMP " & _
                                                        ", 17 )"
            PrepararConsulta(query)
            AñadirParametroConsulta("@codigoDestino", codigoDestino)
            AñadirParametroConsulta("@codigoOrigen", codigoOrigen)
            AñadirParametroConsulta("@cantidad", cantidad)

            Return Consultar(True)



        End Function


    End Class
End Namespace
