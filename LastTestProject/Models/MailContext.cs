using System;
using System.Data.Entity;
using System.IO;
using System.Text;

namespace LastTestProject.Models
{
    public class MailContext:DbContext
    {
        public MailContext() :
         base("name=MyDatabaseEntities")
        { }
        public virtual DbSet<Mailserver> mailservers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            try
            {
                modelBuilder.Entity<Mailserver>().ToTable("Mail");
                modelBuilder.Entity<Mailserver>().HasKey(x => x.Id);
            }
            catch(Exception ex)
            {
                using (FileStream fstream = new FileStream(@"C:\Logerror.txt", FileMode.OpenOrCreate))
                {
                    byte[] input = Encoding.Default.GetBytes(ex.Message);
                    fstream.Write(input, 0, input.Length);
                    fstream.Flush();
                    fstream.Close();
                }
            }
        }

    }

}
