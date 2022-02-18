using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NeighborhoodManager : INeighborhoodService
    {
        INeighborhoodDal _neighborhoodDal;
        public NeighborhoodManager(INeighborhoodDal neighborhoodDal)
        {
            _neighborhoodDal = neighborhoodDal;
        }
        public Neighborhood GetById(int id)
        {
            return _neighborhoodDal.Get(x => x.NeighborhoodId == id);
        }

        public List<Neighborhood> GetList()
        {
            return _neighborhoodDal.List();
        }

        public void NeighborhoodAdd(Neighborhood neighborhood)
        {
            _neighborhoodDal.Insert(neighborhood);
        }

        public void NeighborhoodDelete(Neighborhood neighborhood)
        {
            _neighborhoodDal.Delete(neighborhood);
        }

        public void NeighborhoodUpdate(Neighborhood neighborhood)
        {
            _neighborhoodDal.Update(neighborhood);
        }
    }
}
