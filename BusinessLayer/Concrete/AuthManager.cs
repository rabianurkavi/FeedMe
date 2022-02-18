using BusinessLayer.Abstract;
using BusinessLayer.Security;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthManager : IAuthService
    {
        IAdminService _adminService;
        IAnimalLoverService _animalLoverService;
        public AuthManager(IAdminService adminService, IAnimalLoverService animalLoverService)
        {
            _adminService = adminService;
            _animalLoverService = animalLoverService;
        }
        public Admin AdminExists(string mail)
        {
            throw new NotImplementedException();
        }

        public bool AdminLogin(AdminForLoginDto adminForLoginDto)
        {
            using (var crypto = new System.Security.Cryptography.HMACSHA512())
            {
                var mailHash = crypto.ComputeHash(Encoding.UTF8.GetBytes(adminForLoginDto.AdminMail));
                var admin = _adminService.GetList();
                foreach (var item in admin)
                {
                    if (HashingHelper.VerifyPasswordHash(adminForLoginDto.AdminMail, adminForLoginDto.AdminPassword, item.AdminMail,
                        item.PasswordHash, item.PasswordSalt))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void AdminRegister(string adminUserName, string adminMail, string password)
        {
            byte[] mailHash, passwordHash, passworSalt;
            HashingHelper.CreatePasswordHash(adminMail, password, out mailHash, out passwordHash, out passworSalt);
            var admin = new Admin
            {
                PasswordHash = passwordHash,
                PasswordSalt = passworSalt,
                AdminMail = mailHash,
                AdminRole = "A",
                AdminUserName = adminUserName,


            };
            _adminService.AdminAdd(admin);
        }

        public AnimalLover AnimalLoverLogin(string animalLoverMail, string animalLoverPassword)
        {
            FeedMeContext feedMeContext = new FeedMeContext();
            return feedMeContext.AnimalLovers.FirstOrDefault(x => x.AnimalLoverMail == animalLoverMail && x.AnimalLoverPassword == animalLoverPassword);
        }

        public void AnimalLoverRegister(string animalLoverName, string animalLoverSurName, string animaLoverAbout, string animalLoverMail, string animalLoverPassword, bool animalLoverStatus)
        {
            var animalLover = new AnimalLover
            {
                AnimalLoverName = animalLoverName,
                AnimalLoverSurName = animalLoverSurName,
                AnimalLoverAbout = animaLoverAbout,
                AnimalLoverMail = animalLoverMail,
                AnimalLoverPassword = animalLoverPassword,
                AnimalLoverStatus = animalLoverStatus
            };
            _animalLoverService.AnimalLoverAdd(animalLover);
        }
    }
}
