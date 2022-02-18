using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAnimalLoverService
    {
        void AnimalLoverAdd(AnimalLover animalLover);
        void AnimalLoverDelete(AnimalLover animalLover);
        void AnimalLoverUpdate(AnimalLover animalLover);
        List<AnimalLover> GetList();
        AnimalLover GetById(int id);
    }
}
