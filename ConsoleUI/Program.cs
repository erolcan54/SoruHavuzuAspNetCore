using Business.CCS;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //UserManager userManager = new UserManager(new EfUserDal());
            //foreach (var item in userManager.GetAll().Data)
            //{
            //    Console.WriteLine(item.Ad);
            //}

            ilManager ilManager = new ilManager(new EfilDal());
            foreach (var item in ilManager.GetAll().Data)
            {
                Console.WriteLine(item.Adi);
            }
            Console.WriteLine("-------------------------------------------------");
            ilceManager ilceManager = new ilceManager(new EfilceDal());
            foreach (var item in ilceManager.GetByListilId(54).Data)
            {
                Console.WriteLine(item.Adi);
            }
        }
    }
}
