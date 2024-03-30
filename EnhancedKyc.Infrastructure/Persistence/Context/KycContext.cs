using EnhancedKycVerification.Application.Common.Interface;
using EnhancedKycVerification.Application.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnhancedKyc.Infrastructure.Persistence.Context
{
    public class KycContext: DbContext, IKycContext
    {


        public KycContext(DbContextOptions<KycContext> options)
           : base(options)
        {

        }

        protected KycContext()
        {

        }

        public DbSet<tblRequestandResponseLogs> tblRequestAndResponse { get; set; }




        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<tblRequestandResponseLogs>(entity =>
        //    {

        //        entity.ToTable("tblRequestAndResponse");

        //        entity.HasKey(e => e.Id);
        //        entity.Property(e => e.RequestType).IsRequired(true).IsUnicode(false).HasMaxLength(100);
        //        entity.Property(e => e.RequestPayload).IsRequired(true).IsUnicode(true).HasMaxLength(5000);
        //        entity.Property(e => e.Response).IsRequired(false).IsUnicode(true).HasMaxLength(int.MaxValue);
        //        entity.Property(e => e.RequestTimestamp).IsRequired(true).HasColumnType("datetime");
        //        entity.Property(e => e.ResponseTimestamp).IsRequired(true).HasColumnType("datetime");
        //        entity.Property(e => e.RequestUrl).IsRequired(true).IsUnicode(true).HasMaxLength(int.MaxValue);
               

        //    });
        //}

    }
}
