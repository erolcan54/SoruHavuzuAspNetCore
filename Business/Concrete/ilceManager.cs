using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ilceManager : IilceService
    {
        private IilceDal _ilceDal;

        public ilceManager(IilceDal ilceDal)
        {
            _ilceDal = ilceDal;
        }

        public IDataResult<List<ilce>> GetAll()
        {
            return new SuccessDataResult<List<ilce>>(_ilceDal.GetAll(),"Tüm ilçeler listelendi.");
        }

        public IDataResult<ilce> GetById(int id)
        {
            return new SuccessDataResult<ilce>(_ilceDal.Get(a=>a.Id==id),"Belirtilen ilçe getirildi.");
        }

        public IDataResult<List<ilce>> GetByListilId(int ilId)
        {
            return new SuccessDataResult<List<ilce>>(_ilceDal.GetAll(a => a.ilId == ilId), "ilId'ye göre ilçeler listelendi.");
        }
    }
}
