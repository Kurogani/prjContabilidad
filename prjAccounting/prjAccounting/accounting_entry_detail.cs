//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace prjAccounting
{
    using System;
    using System.Collections.Generic;
    
    public partial class accounting_entry_detail
    {
        public int id { get; set; }
        public int accounting_entry_id { get; set; }
        public int account_catalog_id { get; set; }
        public int transaction_type { get; set; }
        public decimal amount { get; set; }
    
        public virtual account_catalog account_catalog { get; set; }
        public virtual accounting_entry accounting_entry { get; set; }
    }
}