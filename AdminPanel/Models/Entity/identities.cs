//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminPanel.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class identities
    {
        public int id { get; set; }
        public string identifier { get; set; }
        public string owner { get; set; }
        public string position { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string dob { get; set; }
        public Nullable<int> is_male { get; set; }
        public string roles { get; set; }
    }
}
