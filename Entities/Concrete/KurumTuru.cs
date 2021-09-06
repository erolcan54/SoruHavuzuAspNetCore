using Entities.Abstract;

namespace Entities.Concrete
{
    public class KurumTuru : IEntity
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public bool Durum { get; set; }
    }
}
