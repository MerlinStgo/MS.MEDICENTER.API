using MS.MediCenter.Core.Common;
using System;

namespace MS.MediCenter.Core.DrugStore
{
    public class Product : AuditableBaseEntity
    {
        public string Nombre { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal Stock { get; set; }
        public int Categotria { get; set; }
        public int Proveedor { get; set; }
        public int Presentacion { get; set; }
    }
}
