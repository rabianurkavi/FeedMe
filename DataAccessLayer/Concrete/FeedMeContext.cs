using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class FeedMeContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalLover> AnimalLovers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Gate> Gates { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<Heading> Headings { get; set; }
    }
}
