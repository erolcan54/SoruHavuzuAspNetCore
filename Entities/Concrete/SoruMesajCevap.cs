using Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class SoruMesajCevap : IEntity
    {
        public int Id { get; set; }
        public int SoruMesajId { get; set; }
        public int UserId { get; set; }
        public DateTime Durum{ get; set; }
        public string Cevap { get; set; }
        public bool AdminOnay { get; set; }
    }
 }
