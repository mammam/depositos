﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GuiMovimientoPieCuba
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GuiMovimientoPieCuba))
        Me.cboTipoLote = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnProductoDestinoIncorrecto = New System.Windows.Forms.Button()
        Me.btncantidadDestinoIncorrecta = New System.Windows.Forms.Button()
        Me.lDescripcionDestino = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lDescripcionOrigen = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.dgvDeposito = New System.Windows.Forms.DataGridView()
        Me.dgvLote = New System.Windows.Forms.DataGridView()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvDeposito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLote, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboTipoLote
        '
        Me.cboTipoLote.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTipoLote.FormattingEnabled = True
        Me.cboTipoLote.Location = New System.Drawing.Point(693, 513)
        Me.cboTipoLote.Name = "cboTipoLote"
        Me.cboTipoLote.Size = New System.Drawing.Size(568, 21)
        Me.cboTipoLote.TabIndex = 9
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnProductoDestinoIncorrecto)
        Me.GroupBox2.Controls.Add(Me.btncantidadDestinoIncorrecta)
        Me.GroupBox2.Controls.Add(Me.lDescripcionDestino)
        Me.GroupBox2.Location = New System.Drawing.Point(693, 325)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(571, 165)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalles"
        '
        'btnProductoDestinoIncorrecto
        '
        Me.btnProductoDestinoIncorrecto.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnProductoDestinoIncorrecto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProductoDestinoIncorrecto.Image = CType(resources.GetObject("btnProductoDestinoIncorrecto.Image"), System.Drawing.Image)
        Me.btnProductoDestinoIncorrecto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProductoDestinoIncorrecto.Location = New System.Drawing.Point(3, 91)
        Me.btnProductoDestinoIncorrecto.Name = "btnProductoDestinoIncorrecto"
        Me.btnProductoDestinoIncorrecto.Size = New System.Drawing.Size(565, 37)
        Me.btnProductoDestinoIncorrecto.TabIndex = 4
        Me.btnProductoDestinoIncorrecto.Text = "Producto incorrecto"
        Me.btnProductoDestinoIncorrecto.UseVisualStyleBackColor = True
        '
        'btncantidadDestinoIncorrecta
        '
        Me.btncantidadDestinoIncorrecta.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btncantidadDestinoIncorrecta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncantidadDestinoIncorrecta.Image = CType(resources.GetObject("btncantidadDestinoIncorrecta.Image"), System.Drawing.Image)
        Me.btncantidadDestinoIncorrecta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncantidadDestinoIncorrecta.Location = New System.Drawing.Point(3, 128)
        Me.btncantidadDestinoIncorrecta.Name = "btncantidadDestinoIncorrecta"
        Me.btncantidadDestinoIncorrecta.Size = New System.Drawing.Size(565, 34)
        Me.btncantidadDestinoIncorrecta.TabIndex = 3
        Me.btncantidadDestinoIncorrecta.Text = "Cantidad incorrecta"
        Me.btncantidadDestinoIncorrecta.UseVisualStyleBackColor = True
        '
        'lDescripcionDestino
        '
        Me.lDescripcionDestino.Dock = System.Windows.Forms.DockStyle.Top
        Me.lDescripcionDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lDescripcionDestino.Location = New System.Drawing.Point(3, 16)
        Me.lDescripcionDestino.Name = "lDescripcionDestino"
        Me.lDescripcionDestino.Size = New System.Drawing.Size(565, 72)
        Me.lDescripcionDestino.TabIndex = 1
        Me.lDescripcionDestino.Text = "-"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lDescripcionOrigen)
        Me.GroupBox1.Location = New System.Drawing.Point(109, 325)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(578, 165)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalles"
        '
        'lDescripcionOrigen
        '
        Me.lDescripcionOrigen.Dock = System.Windows.Forms.DockStyle.Top
        Me.lDescripcionOrigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lDescripcionOrigen.Location = New System.Drawing.Point(3, 16)
        Me.lDescripcionOrigen.Name = "lDescripcionOrigen"
        Me.lDescripcionOrigen.Size = New System.Drawing.Size(572, 72)
        Me.lDescripcionOrigen.TabIndex = 0
        Me.lDescripcionOrigen.Text = "-"
        '
        'btnGuardar
        '
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Image = Global.La_Andaluza_MovimientosDepositos.My.Resources.Resources.glyphicons_198_ok
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.Location = New System.Drawing.Point(1017, 645)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(244, 69)
        Me.btnGuardar.TabIndex = 16
        Me.btnGuardar.Text = "Continuar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'txtCantidad
        '
        Me.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte), True)
        Me.txtCantidad.Location = New System.Drawing.Point(696, 645)
        Me.txtCantidad.Multiline = True
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(210, 69)
        Me.txtCantidad.TabIndex = 12
        Me.txtCantidad.Text = "30000000"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgvDeposito
        '
        Me.dgvDeposito.AllowUserToAddRows = False
        Me.dgvDeposito.AllowUserToDeleteRows = False
        Me.dgvDeposito.AllowUserToResizeRows = False
        Me.dgvDeposito.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvDeposito.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvDeposito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDeposito.Location = New System.Drawing.Point(693, 68)
        Me.dgvDeposito.Name = "dgvDeposito"
        Me.dgvDeposito.ReadOnly = True
        Me.dgvDeposito.RowHeadersVisible = False
        Me.dgvDeposito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDeposito.Size = New System.Drawing.Size(571, 239)
        Me.dgvDeposito.TabIndex = 15
        '
        'dgvLote
        '
        Me.dgvLote.AllowUserToAddRows = False
        Me.dgvLote.AllowUserToDeleteRows = False
        Me.dgvLote.AllowUserToResizeRows = False
        Me.dgvLote.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvLote.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvLote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLote.Location = New System.Drawing.Point(109, 68)
        Me.dgvLote.Name = "dgvLote"
        Me.dgvLote.ReadOnly = True
        Me.dgvLote.RowHeadersVisible = False
        Me.dgvLote.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLote.Size = New System.Drawing.Size(578, 239)
        Me.dgvLote.TabIndex = 11
        '
        'GuiMovimientoPieCuba
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1373, 788)
        Me.Controls.Add(Me.cboTipoLote)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.dgvDeposito)
        Me.Controls.Add(Me.dgvLote)
        Me.Name = "GuiMovimientoPieCuba"
        Me.Text = "GuiMovimientoPieCuba"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvDeposito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLote, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents cboTipoLote As System.Windows.Forms.ComboBox
    Public WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents btnProductoDestinoIncorrecto As System.Windows.Forms.Button
    Public WithEvents btncantidadDestinoIncorrecta As System.Windows.Forms.Button
    Friend WithEvents lDescripcionDestino As System.Windows.Forms.Label
    Public WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lDescripcionOrigen As System.Windows.Forms.Label
    Public WithEvents btnGuardar As System.Windows.Forms.Button
    Public WithEvents txtCantidad As System.Windows.Forms.TextBox
    Public WithEvents dgvDeposito As System.Windows.Forms.DataGridView
    Public WithEvents dgvLote As System.Windows.Forms.DataGridView
End Class
