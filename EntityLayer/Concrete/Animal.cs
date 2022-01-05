using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }
        [StringLength(50)]
        public string AnimalName { get; set; }
        public string AnimalDescription { get; set; }
        public ICollection<Heading> Headings { get; set; }


    }
}
