using Entities.Abstract;

namespace Entities.Concrete
{
    public class SoruGosterim : IEntity
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public bool Durum { get; set; }
    }
 }
