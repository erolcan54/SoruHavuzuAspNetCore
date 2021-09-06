using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ilce:IEntity
    {
        public int Id { get; set; }
        public int ilId { get; set; }
        public string Adi { get; set; }

    }
}
