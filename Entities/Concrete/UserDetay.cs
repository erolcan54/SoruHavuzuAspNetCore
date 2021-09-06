using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class UserDetay:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ilId { get; set; }
        public int ilceId { get; set; }
        public int BransId { get; set; }
        public int KurumTurId { get; set; }
        public int KurumTipId { get; set; }
        public string OkulAdi { get; set; }
    }
}
