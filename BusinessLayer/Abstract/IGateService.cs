using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGateService
    {
        void GateAdd(Gate gate);
        void GateDelete(Gate gate);
        void GateUpdate(Gate gate);
        List<Gate> GetList();
        Gate GetById(int id);
    }
}
