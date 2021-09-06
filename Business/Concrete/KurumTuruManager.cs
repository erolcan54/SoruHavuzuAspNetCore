using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class KurumTuruManager : IKurumTuruService
    {
        IKurumTuruDal _kurumTuruDal;

        public KurumTuruManager(IKurumTuruDal kurumTuruDal)
        {
            _kurumTuruDal = kurumTuruDal;
        }

        //[SecuredOperation("admin")]
        [CacheRemoveAspect("IKurumTuruService.Get")]
        [ValidationAspect(typeof(KurumTuruValidator))]
        public IResult Add(KurumTuru kurumTuru)
        {
            kurumTuru.Durum = true;
            _kurumTuruDal.Add(kurumTuru);
            return new SuccessResult("Kurum Türü eklendi.");
        }

        public IResult Delete(KurumTuru kurumTuru)
        {
            kurumTuru.Durum = false;
            _kurumTuruDal.Update(kurumTuru);
            return new SuccessResult("Kurum Türü güncellendi.");
        }

        //[SecuredOperation("admin")]
        public IDataResult<List<KurumTuru>> GetAll()
        {
            return new SuccessDataResult<List<KurumTuru>>(_kurumTuruDal.GetAll(),"Tüm Kurum Türleri listelendi.");
        }

        [CacheAspect]
        public IDataResult<List<KurumTuru>> GetAllAktif()
        {
            return new SuccessDataResult<List<KurumTuru>>(_kurumTuruDal.GetAll(a=>a.Durum==true), "Aktif Kurum Türleri listelendi.");
        }

        [CacheAspect]
        public IDataResult<KurumTuru> GetById(int kurumTurId)
        {
            return new SuccessDataResult<KurumTuru>(_kurumTuruDal.Get(a=>a.Id==kurumTurId), "Kurum Türü getirildi.");
        }

        //[SecuredOperation("admin")]
        [CacheRemoveAspect("IKurumTuruService.Get")]
        [ValidationAspect(typeof(KurumTuruValidator))]
        public IResult Update(KurumTuru kurumTuru)
        {
            _kurumTuruDal.Update(kurumTuru);
            return new SuccessResult("Kurum Türü güncellendi.");
        }
    }
}
