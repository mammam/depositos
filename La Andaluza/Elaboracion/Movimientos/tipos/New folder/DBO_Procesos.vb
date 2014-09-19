Public Class DBO_Procesos
Inherits BasesParaCompatibilidad.DataBussines

   Private m_Id As BasesParaCompatibilidad.DataBussinesParameter
   Private m_Descripcion As BasesParaCompatibilidad.DataBussinesParameter
   Private m_TipoProductoParaLote As BasesParaCompatibilidad.DataBussinesParameter
   Private m_TipoLoteID As BasesParaCompatibilidad.DataBussinesParameter
   Private m_ConMuestra As BasesParaCompatibilidad.DataBussinesParameter
   Private m_TipoMovimientoID As BasesParaCompatibilidad.DataBussinesParameter

   Public Sub New()
       MyBase.New()
       m_Id = New BasesParaCompatibilidad.DataBussinesParameter("@ProcesoID","ProcesoID")
       m_Descripcion= New BasesParaCompatibilidad.DataBussinesParameter("@Descripcion","Descripcion")
       m_TipoProductoParaLote= New BasesParaCompatibilidad.DataBussinesParameter("@TipoProductoParaLote","TipoProductoParaLote")
       m_TipoLoteID= New BasesParaCompatibilidad.DataBussinesParameter("@TipoLoteID","TipoLoteID")
       m_ConMuestra= New BasesParaCompatibilidad.DataBussinesParameter("@ConMuestra","ConMuestra")
       m_TipoMovimientoID= New BasesParaCompatibilidad.DataBussinesParameter("@TipoMovimientoID","TipoMovimientoID")
       MyBase.primaryKey = m_Id
       aņadirParametros()
   End Sub

   Public Property ID() As Integer
       Get
           if m_id.value is convert.dbnull then
             Return 0
           End if
           Return ctype(m_id.value,integer)
       End Get
       Set(ByVal value As Integer)
           Me.primaryKey.value = value
           m_id.value = value
       End Set
   End Property

   Public Property Descripcion() As String
       Get
           if m_Descripcion.value is convert.dbnull then
             Return string.empty
           End if
           Return ctype(m_Descripcion.value,string)
       End Get
       Set(ByVal value As String)
           m_Descripcion.value = value
       End Set
   End Property

   Public Property TipoProductoParaLote() As String
       Get
           if m_TipoProductoParaLote.value is convert.dbnull then
             Return string.empty
           End if
           Return ctype(m_TipoProductoParaLote.value,string)
       End Get
       Set(ByVal value As String)
           m_TipoProductoParaLote.value = value
       End Set
   End Property

   Public Property TipoLoteID() As Integer
       Get
           if m_TipoLoteID.value is convert.dbnull then
             Return 0
           End if
           Return ctype(m_TipoLoteID.value,integer)
       End Get
       Set(ByVal value As Integer)
           m_TipoLoteID.value = value
       End Set
   End Property

   Public Property ConMuestra() As Boolean
       Get
           if m_ConMuestra.value is convert.dbnull then
             Return false
           End if
           Return ctype(m_ConMuestra.value,boolean)
       End Get
       Set(ByVal value As Boolean)
           m_ConMuestra.value = value
       End Set
   End Property

   Public Property TipoMovimientoID() As Integer
       Get
           if m_TipoMovimientoID.value is convert.dbnull then
             Return 0
           End if
           Return ctype(m_TipoMovimientoID.value,integer)
       End Get
       Set(ByVal value As Integer)
           m_TipoMovimientoID.value = value
       End Set
   End Property

   Private Sub aņadirParametros()
       MyBase.atributos.Add(m_Id, m_Id.sqlName)
       MyBase.atributos.Add(m_Descripcion, m_Descripcion.sqlName)
       MyBase.atributos.Add(m_TipoProductoParaLote, m_TipoProductoParaLote.sqlName)
       MyBase.atributos.Add(m_TipoLoteID, m_TipoLoteID.sqlName)
       MyBase.atributos.Add(m_ConMuestra, m_ConMuestra.sqlName)
       MyBase.atributos.Add(m_TipoMovimientoID, m_TipoMovimientoID.sqlName)
   End Sub
End Class
