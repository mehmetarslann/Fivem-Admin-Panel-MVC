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
    
    public partial class banlisthistory
    {
        public int id { get; set; }
        public string identifier { get; set; }
        public string license { get; set; }
        public string liveid { get; set; }
        public string xblid { get; set; }
        public string discord { get; set; }
        public string playerip { get; set; }
        public string targetplayername { get; set; }
        public string sourceplayername { get; set; }
        public string reason { get; set; }
        public int timeat { get; set; }
        public Nullable<System.DateTime> added { get; set; }
        public int expiration { get; set; }
        public int permanent { get; set; }
    }
}
