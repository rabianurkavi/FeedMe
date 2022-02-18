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
    public class AnimalManager : IAnimalService
    {
        IAnimalDal _animalDal;
        public AnimalManager(IAnimalDal animalDal)
        {
            _animalDal = animalDal;
        }
        public void AnimalAdd(Animal animal)
        {
            _animalDal.Insert(animal);
        }

        public void AnimalDelete(Animal animal)
        {
            _animalDal.Delete(animal);
        }

        public void AnimalUpdate(Animal animal)
        {
            _animalDal.Update(animal);
        }

        public Animal GetById(int id)
        {
            return _animalDal.Get(x => x.AnimalId == id);
        }

        public List<Animal> GetList()
        {
            return _animalDal.List();
        }
    }
}
