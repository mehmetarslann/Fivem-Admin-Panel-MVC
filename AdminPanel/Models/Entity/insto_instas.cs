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
    
    public partial class insto_instas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public insto_instas()
        {
            this.insto_likes = new HashSet<insto_likes>();
        }
    
        public int id { get; set; }
        public int authorId { get; set; }
        public string realUser { get; set; }
        public string message { get; set; }
        public string image { get; set; }
        public string filters { get; set; }
        public System.DateTime time { get; set; }
        public int likes { get; set; }
    
        public virtual insto_accounts insto_accounts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<insto_likes> insto_likes { get; set; }
    }
}
