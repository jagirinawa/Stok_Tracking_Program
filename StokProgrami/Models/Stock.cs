//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StokProgrami.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stock
    {
        public long id { get; set; }
        public long stock_amount { get; set; }
        public long id_product { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
