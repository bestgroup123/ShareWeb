﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Share.Domain.ResourceCenter.Entity
{
    public class MysqlDb_Resource : DbContext
    {
        static DbContextOptions<MysqlDb_Resource> _defaultOptions = null;
        public static void SetDefaultOptions(DbContextOptions<MysqlDb_Resource> options)
        {
            _defaultOptions = options;
        }
        public MysqlDb_Resource() : base(_defaultOptions)
        {
        }
        public MysqlDb_Resource(DbContextOptions<MysqlDb_Resource> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {     
            modelBuilder.Entity<ResourceRepo>().Property(r => r.Delete).HasConversion(new BoolToZeroOneConverter<Int16>());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ResourceRepo> ResourceRepos { get; set; }

        public DbSet<ResourceCommentRepo> ResourceCommentRepos { get; set; }
        public DbSet<ResourceContentRepo> ResourceContentRepos { get; set; }
    }
}
