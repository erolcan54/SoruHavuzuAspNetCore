using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public byte[] SifreHash { get; set; }
        public byte[] SifreSalt { get; set; }
        public bool Durum { get; set; }
        public DateTime Tarih { get; set; }
    }
}
