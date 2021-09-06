using Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class Havuz : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string HavuzAdi { get; set; }
        public bool Durum { get; set; }
        public DateTime Tarih { get; set; }
    }
}
