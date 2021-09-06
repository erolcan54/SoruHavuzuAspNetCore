using Entities.Abstract;

namespace Entities.Concrete
{
    public class Secenek : IEntity
    {
        public int Id { get; set; }
        public int SoruId { get; set; }
        public string SecenekAdi { get; set; }
        public string SecenekKoku { get; set; }
        public bool DogrySecenekMi { get; set; }
    }
}
