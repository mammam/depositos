﻿Namespace Movimientos
    Public Class GuiSalida
        Private salida As Movimientos.Salida
        Public Event CantidadIncorrecta(lote As Integer, e As EventArgs)
        Public Event ProductoIncorrecto(lote As Integer, e As EventArgs)

        Public Sub New(ByVal salida As Movimientos.Salida)
            InitializeComponent()
            Me.salida = salida
            Dim pop As New DgvFilterPopup.DgvFilterManager(Me.dgvOrigen)
            Dim filter As New DecimalWatcher(Me.txtCantidad, 0)

            If salida.proceso = 6 Then
                Me.cboRecipiente.Visible = True
                lRecipiente.Visible = True
            End If
        End Sub

        Public WriteOnly Property OrigenDatasource As DataTable
            Set(value As DataTable)
                Me.dgvOrigen.DataSource = value
                If Not value Is Nothing Then
                    Me.dgvOrigen.Columns("TipoProductoID").Visible = False
                    Me.dgvOrigen.Columns("TipoLoteID").Visible = False
                    Me.dgvOrigen.Columns("depositoID").Visible = False
                    Me.dgvOrigen.Columns("Capacidad").Visible = False
                    Me.dgvOrigen.Columns("Listado").Visible = False
                    Me.dgvOrigen.Columns("LoteID").Visible = False
                End If
            End Set
        End Property
        Public WriteOnly Property DestinoDatasource As DataTable
            Set(value As DataTable)
                Me.dgvOrigen.DataSource = value
                If Not value Is Nothing Then
                    Me.dgvOrigen.Columns("TipoProductoID").Visible = False
                    Me.dgvOrigen.Columns("TipoLoteID").Visible = False
                    Me.dgvOrigen.Columns("depositoID").Visible = False
                    Me.dgvOrigen.Columns("Capacidad").Visible = False
                    Me.dgvOrigen.Columns("Listado").Visible = False
                    Me.dgvOrigen.Columns("LoteID").Visible = False
                End If
            End Set
        End Property


        Public WriteOnly Property RecipientesDatasource As DataTable
            Set(value As DataTable)
                Me.cboRecipiente.mam_DataSource(value, False, False)
            End Set
        End Property

        Public WriteOnly Property TransicubasDatasource As DataTable
            Set(value As DataTable)
                Me.cboTransicuba.mam_DataSource(value, False, False)
            End Set
        End Property

        Public ReadOnly Property valores As Movimientos.Salida
            Get


                salida.lotePartida.producto = Convert.ToInt32(dgvOrigen.CurrentRow.Cells("TipoProductoID").Value)
                salida.loteFinal.producto = Convert.ToInt32(dgvOrigen.CurrentRow.Cells("TipoProductoID").Value)
                salida.lotePartida.deposito = Convert.ToInt32(dgvOrigen.CurrentRow.Cells("depositoID").Value)
                salida.lotePartida.codigo_lote = Convert.ToString(dgvOrigen.CurrentRow.Cells("CodigoLote").Value)
                salida.lotePartida.id = Convert.ToInt32(dgvOrigen.CurrentRow.Cells("LoteID").Value)
                salida.lotePartida.tipo = Convert.ToInt32(dgvOrigen.CurrentRow.Cells("TipoLoteID").Value)
                If cboRecipiente.Visible Then
                    salida.recipiente = Convert.ToInt32(cboRecipiente.SelectedValue)

                    If cboTransicuba.Visible Then salida.transicuba = Convert.ToInt32(cboTransicuba.SelectedValue)
                End If

                salida.sumarAdestino = chbSuma.Checked

                salida.cantidad = Convert.ToDouble(txtCantidad.Text)
                salida.fecha = dtpFecha.Value.Date
                salida.muestra = Me.chbMuestra.Checked

                Return salida
            End Get
        End Property

        Private Sub actualiza_descripcion(sender As Object, e As EventArgs)
            If dgvOrigen.CurrentRow Is Nothing Then
                Return
            End If

            If Convert.IsDBNull(dgvOrigen.CurrentRow.Cells("CodigoLote").Value) Then
                Me.btncantidadOrigenIncorrecta.Visible = False
                Me.btnProductoOrigenncorrecto.Visible = False
            Else
                Me.btncantidadOrigenIncorrecta.Visible = True
                Me.btnProductoOrigenncorrecto.Visible = True
            End If
        End Sub

        Private Sub GuiMovimientoCompra_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            AddHandler dgvOrigen.SelectionChanged, AddressOf actualiza_descripcion
            AddHandler txtCantidad.TextChanged, AddressOf actualiza_descripcion
        End Sub


        Private Sub btnProductoDestinoIncorrecto_Click(sender As Object, e As EventArgs) Handles btnProductoOrigenncorrecto.Click
            RaiseEvent ProductoIncorrecto(Convert.ToInt32(dgvOrigen.CurrentRow.Cells("loteid").Value), Nothing)
        End Sub

        Private Sub btncantidadDestinoIncorrecta_Click(sender As Object, e As EventArgs) Handles btncantidadOrigenIncorrecta.Click
            RaiseEvent CantidadIncorrecta(Convert.ToInt32(dgvOrigen.CurrentRow.Cells("loteid").Value), Nothing)
        End Sub

        Private Sub btnTodo_Click(sender As Object, e As EventArgs) Handles btnTodo.Click
            txtCantidad.Text = Convert.ToString(dgvOrigen.CurrentRow.Cells("CantidadRestante").Value)
        End Sub

        Private Sub cboRecipiente_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboRecipiente.SelectedValueChanged
            'If CType(cboRecipiente.SelectedValue, DataRowView).Row.Item(0) Is Nothing Then
            '    cboTransicuba.SelectedValue = False
            '    Return
            'End If

            Try
                If Convert.ToInt32(cboRecipiente.SelectedValue) = 1 Then
                    Me.cboTransicuba.Visible = True
                    lTransicuba.Visible = True
                Else
                    Me.cboTransicuba.Visible = False
                    lTransicuba.Visible = False
                End If
            Catch ex As Exception

            End Try
        End Sub
    End Class
End Namespace