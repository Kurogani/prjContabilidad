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
    
    public partial class account_catalog
    {
        public account_catalog()
        {
            this.accounting_entry_detail = new HashSet<accounting_entry_detail>();
        }
    
        public int id { get; set; }
        public int account_type_id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public bool transactional { get; set; }
        public byte level { get; set; }
        public Nullable<int> major { get; set; }
        public decimal balance { get; set; }
        public bool state { get; set; }
    
        public virtual ICollection<accounting_entry_detail> accounting_entry_detail { get; set; }
        public virtual account_type account_type { get; set; }
    }
}
