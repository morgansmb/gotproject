﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ThronesTournamentEntities : DbContext
    {
        public ThronesTournamentEntities()
            : base("name=ThronesTournamentEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<Fight> Fights { get; set; }
        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<Territory> Territories { get; set; }
        public virtual DbSet<Territory_Type> TerritoriesTypes { get; set; }
        public virtual DbSet<War> Wars { get; set; }
    }
}
