using Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class Soru : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SoruKoku { get; set; }
        public bool Durum { get; set; }
        public byte[] Resim { get; set; }
        public int Hit { get; set; }
        public int GosterimId { get; set; }
        public int SoruTurId { get; set; }
        public DateTime Tarih { get; set; }
        public int BransId { get; set; }
    }
}
