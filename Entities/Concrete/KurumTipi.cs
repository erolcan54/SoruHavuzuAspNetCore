using Entities.Abstract;

namespace Entities.Concrete
{
    public class KurumTipi : IEntity
    {
        public int Id { get; set; }
        public int KurumTurId { get; set; }
        public string Adi { get; set; }
        public bool Durum { get; set; }
    }
}
