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
    
    public partial class properties
    {
        public int id { get; set; }
        public string name { get; set; }
        public string label { get; set; }
        public string entering { get; set; }
        public string exit { get; set; }
        public string inside { get; set; }
        public string outside { get; set; }
        public string ipls { get; set; }
        public string gateway { get; set; }
        public Nullable<int> is_single { get; set; }
        public Nullable<int> is_room { get; set; }
        public Nullable<int> is_gateway { get; set; }
        public string room_menu { get; set; }
        public int price { get; set; }
        public Nullable<int> owned { get; set; }
        public int free { get; set; }
    }
}
