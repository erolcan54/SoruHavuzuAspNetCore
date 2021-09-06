using Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class SoruMesaj : IEntity
    {
        public int Id { get; set; }
        public int SoruId { get; set; }
        public int UserId { get; set; }
        public bool Durum { get; set; }
        public DateTime Tarih{ get; set; }
        public string Mesaj { get; set; }
        public bool AdminOnay { get; set; }
    }
 }
