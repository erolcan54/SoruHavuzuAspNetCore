using Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class SoruPuan : IEntity
    {
        public int Id { get; set; }
        public int SoruId { get; set; }
        public int UserId { get; set; }
        public int Puan { get; set; }
        public bool Durum { get; set; }
        public DateTime Tarih{ get; set; }
    }
 }
