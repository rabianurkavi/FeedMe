using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Gate
    {
        [Key]
        public int GateId { get; set; }
        public string GateNo { get; set; }
        public string GateCoordinate { get; set; }

        public int NeighborhoodId { get; set; }
        public virtual Neighborhood Neighborhood { get; set; }
    }
}
