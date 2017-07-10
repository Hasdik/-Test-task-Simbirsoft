using System.Data.Entity;

namespace LastTestProject.Models
{
    public class MailContext:DbContext
    {
        public MailContext() :
         base("DBConnection")
        { }
        public DbSet<Mailserver> mailservers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mailserver>().ToTable("Mail");
            modelBuilder.Entity<Mailserver>().HasKey(x => x.Id);
        }

    }

}
