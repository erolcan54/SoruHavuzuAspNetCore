using Entities.Abstract;

namespace Entities.Concrete
{
    public class Sinif : IEntity
    {
        public int Id { get; set; }
        public string SinifAdi { get; set; }
        public int KurumTurId { get; set; }
    }
}
