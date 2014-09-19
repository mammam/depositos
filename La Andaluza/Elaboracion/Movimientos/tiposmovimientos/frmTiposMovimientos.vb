Imports DataGridViewExtension
Public Class frmTiposMovimientos
   Inherits gridsimpleform
   Implements Queriable

   private dboTiposMovimientos As DBO_TiposMovimientos
       
   Public Sub New(Optional ByVal MaestroID As Integer = 0)
       MyBase.new(new spTiposMovimientos(),MaestroID.ToString)
       InitializeComponent()
       dboTiposMovimientos = new DBO_TiposMovimientos
       MyBase.newRegForm = ctype(New frmEntTiposMovimientos(GridSimpleForm.ACCION_INSERTAR, ctype(sp, spTiposMovimientos)), DetailedSimpleForm)
   End Sub

   Private Sub Insert_Before() Handles MyBase.BeforeInsert
       newRegForm.SetDataBussinesObject(ctype(Me.dboTiposMovimientos, databussines))
   End Sub

   Private Sub modify_Before() Handles MyBase.BeforeModify
       dboTiposMovimientos =ctype(sp, spTiposMovimientos).Select_Record(ctype(dgvGeneral.CurrentRow.Cells("Id").Value, integer))
       If Not dboTiposMovimientos Is Nothing Then
           newRegForm.SetDataBussinesObject(ctype(Me.dboTiposMovimientos,databussines))
       Else
           MyBase.EventHandeld = True
           Messagebox.show("No se pudo recuperar los datos",  "Atenci�n", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
       End If
   End Sub

   Protected Overrides Sub BindDataSource() Implements Queriable.dataGridViewFill
       'dim dt as datatable = DataTableFill(Me.spTiposMovimientos.DataGridViewStoredProcedure)

       If not datasource Is Nothing Then
       GeneralBindingSource.DataSource = datasource
               With dgvGeneral
                   .DataSource = GeneralBindingSource
               .Columns("Id").Visible = False
                   .FormatoColumna("Descripcion", TiposColumna.Izquierda, true)
                   .FormatoColumna("Observaciones", TiposColumna.Izquierda, true)
               End With
       End If

   End Sub

End Class
