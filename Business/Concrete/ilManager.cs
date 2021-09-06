using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ilManager:IilService
    {
        private IilDal _ilDal;

        public ilManager(IilDal ilDal)
        {
            _ilDal = ilDal;
        }

        [CacheAspect]
        public IDataResult<List<il>> GetAll()
        {
            return new SuccessDataResult<List<il>>(_ilDal.GetAll(), "Tüm iller listelendi.");
        }
        [CacheAspect]
        public IDataResult<il> GetById(int id)
        {
            return new SuccessDataResult<il>(_ilDal.Get(a=>a.Id==id),"Seçili il getirildi.");
        }
    }
}
