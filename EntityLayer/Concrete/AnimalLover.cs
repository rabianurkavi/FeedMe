using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AnimalLover
    {
        [Key]
        public int AnimalLoverId { get; set; }
        [StringLength(50)]
        public string AnimalLoverName { get; set; }
        [StringLength(50)]
        public string AnimalLoverSurName { get; set; }
        [StringLength(150)]
        public string AnimalLoverImage { get; set; }
        [StringLength(50)]
        public string AnimalLoverMail { get; set; }
        [StringLength(20)]
        public string AnimalLoverPassword { get; set; }
        public string AnimalLoverAbout { get; set; }
        public bool AnimalLoverStatus { get; set; }
        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}
