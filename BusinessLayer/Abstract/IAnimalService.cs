using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAnimalService
    {
        void AnimalAdd(Animal animal);
        void AnimalDelete(Animal animal);
        void AnimalUpdate(Animal animal);
        List<Animal> GetList();
        Animal GetById(int id);

    }
}
