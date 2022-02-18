using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthService
    {
        bool AdminLogin(AdminForLoginDto adminForLoginDto);
        Admin AdminExists(string mail);
        void AdminRegister(string adminUserName, string adminMail, string password);
        AnimalLover AnimalLoverLogin(string animalLoverMail, string animalLoverPassword);
        void AnimalLoverRegister(string animalLoverName, string animalLoverSurName, string animaLoverAbout, string animalLoverMail, string animalLoverPassword, bool animalLoverStatus);
    }
}
