using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LastTestProject.Models
{
    public class MailContextEN:DbContext
    {
        public MailContextEN() :
         base("DBConnection")
        { }
        public DbSet<MailserverEN> mailserverEN { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailserverEN>().ToTable("MailEN");
            modelBuilder.Entity<MailserverEN>().HasKey(x => x.Id);
        }
    }
}