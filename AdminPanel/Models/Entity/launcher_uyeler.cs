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
    
    public partial class launcher_uyeler
    {
        public int uye_id { get; set; }
        public string uye_ad { get; set; }
        public string uye_soyad { get; set; }
        public string uye_kadi { get; set; }
        public string uye_parola { get; set; }
        public Nullable<System.DateTime> uye_gtarih { get; set; }
        public string steam_id { get; set; }
        public string discord_id { get; set; }
        public string hile_tespiti { get; set; }
        public string login_durum { get; set; }
    }
}
