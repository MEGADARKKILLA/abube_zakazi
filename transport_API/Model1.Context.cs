﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace transport_API
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ЗаказыEntities : DbContext
    {
        public ЗаказыEntities()
            : base("name=ЗаказыEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Заказ> Заказ { get; set; }
        public virtual DbSet<Категория> Категория { get; set; }
        public virtual DbSet<Клиент> Клиент { get; set; }
        public virtual DbSet<Скидки> Скидки { get; set; }
        public virtual DbSet<Товары> Товары { get; set; }
        public virtual DbSet<Транспорт> Транспорт { get; set; }
    }
}
