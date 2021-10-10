using MS.MediCenter.Core.Common;
using System;

namespace MS.MediCenter.Core.DrugStore
{
    public class Product : AuditableBaseEntity
    {
        public DateTime? FechaVencimiento;

        //public DateTime? FechaVencimiento
        //{
        //    get => _fechaVencimiento; 
        //    set
        //    {
        //        if(_fechaVencimiento.Value >= DateTime.Now.AddDays(-120))
        //        {
        //            throw new Exception(string.Empty);
        //        }
        //        else
        //        {
        //            _fechaVencimiento = value;
        //        }
        //    }
        //}
    }
}
