using Entities.Abstract;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Brans:IEntity
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public bool Durum { get; set; }
        public int KurumTurId { get; set; }
    }
 }
