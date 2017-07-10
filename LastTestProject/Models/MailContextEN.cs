using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;
using System.Text;

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
            try
            {
                modelBuilder.Entity<MailserverEN>().ToTable("MailEN");
                modelBuilder.Entity<MailserverEN>().HasKey(x => x.Id);
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