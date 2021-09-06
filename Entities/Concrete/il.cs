using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class il:IEntity
    {
        public int Id { get; set; }
        public string Adi { get; set; }
    }
}
