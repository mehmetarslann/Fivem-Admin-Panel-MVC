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
    
    public partial class twitter_likes
    {
        public int id { get; set; }
        public Nullable<int> authorId { get; set; }
        public Nullable<int> tweetId { get; set; }
    
        public virtual twitter_accounts twitter_accounts { get; set; }
        public virtual twitter_tweets twitter_tweets { get; set; }
    }
}
