using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface INeighborhoodService
    {
        void NeighborhoodAdd(Neighborhood neighborhood);
        void NeighborhoodDelete(Neighborhood neighborhood);
        void NeighborhoodUpdate(Neighborhood neighborhood);
        List<Neighborhood> GetList();
        Neighborhood GetById(int id);
    }
}
