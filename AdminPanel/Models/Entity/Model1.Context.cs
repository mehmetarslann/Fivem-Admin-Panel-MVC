﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class sunucu1sEntities : DbContext
    {
        public sunucu1sEntities()
            : base("name=sunucu1sEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<accounts> accounts { get; set; }
        public virtual DbSet<addon_account> addon_account { get; set; }
        public virtual DbSet<addon_account_data> addon_account_data { get; set; }
        public virtual DbSet<addon_inventory> addon_inventory { get; set; }
        public virtual DbSet<addon_inventory_items> addon_inventory_items { get; set; }
        public virtual DbSet<aircraft_categories> aircraft_categories { get; set; }
        public virtual DbSet<aircraftdealer_aircrafts> aircraftdealer_aircrafts { get; set; }
        public virtual DbSet<aircrafts> aircrafts { get; set; }
        public virtual DbSet<amekanikkasa> amekanikkasa { get; set; }
        public virtual DbSet<banlist> banlist { get; set; }
        public virtual DbSet<banlisthistory> banlisthistory { get; set; }
        public virtual DbSet<billing> billing { get; set; }
        public virtual DbSet<black_muhshipments> black_muhshipments { get; set; }
        public virtual DbSet<black_shipments> black_shipments { get; set; }
        public virtual DbSet<blackmarket> blackmarket { get; set; }
        public virtual DbSet<bmekanikkasa> bmekanikkasa { get; set; }
        public virtual DbSet<boat_categories> boat_categories { get; set; }
        public virtual DbSet<boatdealer_boats> boatdealer_boats { get; set; }
        public virtual DbSet<boats> boats { get; set; }
        public virtual DbSet<car_parking> car_parking { get; set; }
        public virtual DbSet<cardealer_vehicles> cardealer_vehicles { get; set; }
        public virtual DbSet<cete1kasa> cete1kasa { get; set; }
        public virtual DbSet<cete2kasa> cete2kasa { get; set; }
        public virtual DbSet<cete3kasa> cete3kasa { get; set; }
        public virtual DbSet<cete4kasa> cete4kasa { get; set; }
        public virtual DbSet<cete5kasa> cete5kasa { get; set; }
        public virtual DbSet<cete6kasa> cete6kasa { get; set; }
        public virtual DbSet<characters> characters { get; set; }
        public virtual DbSet<cmekanikkasa> cmekanikkasa { get; set; }
        public virtual DbSet<combat> combat { get; set; }
        public virtual DbSet<datastore> datastore { get; set; }
        public virtual DbSet<datastore_data> datastore_data { get; set; }
        public virtual DbSet<datastores> datastores { get; set; }
        public virtual DbSet<disc_ammo> disc_ammo { get; set; }
        public virtual DbSet<disc_inventory> disc_inventory { get; set; }
        public virtual DbSet<disc_inventory_itemdata> disc_inventory_itemdata { get; set; }
        public virtual DbSet<disc_property> disc_property { get; set; }
        public virtual DbSet<disc_property_garage_vehicles> disc_property_garage_vehicles { get; set; }
        public virtual DbSet<disc_property_inventory> disc_property_inventory { get; set; }
        public virtual DbSet<disc_property_owners> disc_property_owners { get; set; }
        public virtual DbSet<dmekanikkasa> dmekanikkasa { get; set; }
        public virtual DbSet<dpkeybinds> dpkeybinds { get; set; }
        public virtual DbSet<elkoyma> elkoyma { get; set; }
        public virtual DbSet<esrar> esrar { get; set; }
        public virtual DbSet<faturalog> faturalog { get; set; }
        public virtual DbSet<fine_types> fine_types { get; set; }
        public virtual DbSet<glovebox_inventory> glovebox_inventory { get; set; }
        public virtual DbSet<hardlog> hardlog { get; set; }
        public virtual DbSet<hastane> hastane { get; set; }
        public virtual DbSet<identities> identities { get; set; }
        public virtual DbSet<illegalsatis> illegalsatis { get; set; }
        public virtual DbSet<insto_accounts> insto_accounts { get; set; }
        public virtual DbSet<insto_instas> insto_instas { get; set; }
        public virtual DbSet<insto_likes> insto_likes { get; set; }
        public virtual DbSet<inventories> inventories { get; set; }
        public virtual DbSet<items> items { get; set; }
        public virtual DbSet<job_grades> job_grades { get; set; }
        public virtual DbSet<jobs> jobs { get; set; }
        public virtual DbSet<kaiser_ciuchy> kaiser_ciuchy { get; set; }
        public virtual DbSet<kokain> kokain { get; set; }
        public virtual DbSet<launcher_ayarlar> launcher_ayarlar { get; set; }
        public virtual DbSet<launcher_duyurular> launcher_duyurular { get; set; }
        public virtual DbSet<launcher_renk> launcher_renk { get; set; }
        public virtual DbSet<launcher_uyeler> launcher_uyeler { get; set; }
        public virtual DbSet<licenses> licenses { get; set; }
        public virtual DbSet<lsrp_motels> lsrp_motels { get; set; }
        public virtual DbSet<mdt_reports> mdt_reports { get; set; }
        public virtual DbSet<mdt_warrants> mdt_warrants { get; set; }
        public virtual DbSet<migrations> migrations { get; set; }
        public virtual DbSet<outfits> outfits { get; set; }
        public virtual DbSet<owned_aircrafts> owned_aircrafts { get; set; }
        public virtual DbSet<owned_boats> owned_boats { get; set; }
        public virtual DbSet<owned_properties> owned_properties { get; set; }
        public virtual DbSet<owned_vehicles> owned_vehicles { get; set; }
        public virtual DbSet<owned_vehicles_headlights> owned_vehicles_headlights { get; set; }
        public virtual DbSet<phone_app_chat> phone_app_chat { get; set; }
        public virtual DbSet<phone_calls> phone_calls { get; set; }
        public virtual DbSet<phone_ch_reddit> phone_ch_reddit { get; set; }
        public virtual DbSet<phone_messages> phone_messages { get; set; }
        public virtual DbSet<phone_reddit> phone_reddit { get; set; }
        public virtual DbSet<phone_shops> phone_shops { get; set; }
        public virtual DbSet<phone_users_contacts> phone_users_contacts { get; set; }
        public virtual DbSet<players> players { get; set; }
        public virtual DbSet<poliskasa> poliskasa { get; set; }
        public virtual DbSet<properties> properties { get; set; }
        public virtual DbSet<rented_vehicles> rented_vehicles { get; set; }
        public virtual DbSet<society_moneywash> society_moneywash { get; set; }
        public virtual DbSet<transfer> transfer { get; set; }
        public virtual DbSet<truck_inventory> truck_inventory { get; set; }
        public virtual DbSet<trunk_inventory> trunk_inventory { get; set; }
        public virtual DbSet<twitter_accounts> twitter_accounts { get; set; }
        public virtual DbSet<twitter_likes> twitter_likes { get; set; }
        public virtual DbSet<twitter_tweets> twitter_tweets { get; set; }
        public virtual DbSet<user_accounts> user_accounts { get; set; }
        public virtual DbSet<user_convictions> user_convictions { get; set; }
        public virtual DbSet<user_inventory> user_inventory { get; set; }
        public virtual DbSet<user_licenses> user_licenses { get; set; }
        public virtual DbSet<user_mdt> user_mdt { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<vehicle_categories> vehicle_categories { get; set; }
        public virtual DbSet<vehicle_sold> vehicle_sold { get; set; }
        public virtual DbSet<vehicles> vehicles { get; set; }
        public virtual DbSet<vehicles_display> vehicles_display { get; set; }
        public virtual DbSet<whitelist> whitelist { get; set; }
        public virtual DbSet<yellow_tweets> yellow_tweets { get; set; }
    }
}
