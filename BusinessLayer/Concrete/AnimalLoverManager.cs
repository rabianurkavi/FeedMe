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
    public class AnimalLoverManager : IAnimalLoverService
    {
        IAnimalLoverDal _animalLoverDal;
        public AnimalLoverManager(IAnimalLoverDal animalLoverDal)
        {
            _animalLoverDal = animalLoverDal;
        }
        public void AnimalLoverAdd(AnimalLover animalLover)
        {
            _animalLoverDal.Insert(animalLover);
        }

        public void AnimalLoverDelete(AnimalLover animalLover)
        {
            _animalLoverDal.Delete(animalLover);
        }

        public void AnimalLoverUpdate(AnimalLover animalLover)
        {
            _animalLoverDal.Update(animalLover);
        }

        public AnimalLover GetById(int id)
        {
            return _animalLoverDal.Get(x => x.AnimalLoverId == id);
        }

        public List<AnimalLover> GetList()
        {
            return _animalLoverDal.List();
        }
    }
}
