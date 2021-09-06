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
    public class BransManager : IBransService
    {
        IBransDal _bransDal;

        public BransManager(IBransDal bransDal)
        {
            _bransDal = bransDal;
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IBransService.Get")]
        [ValidationAspect(typeof(BransValidator))]
        public IResult Add(Brans brans)
        {
            _bransDal.Add(brans);
            return new SuccessResult("Branş Eklendi.");
        }

        [CacheAspect]
        public IDataResult<List<Brans>> GetAllAktif()
        {
            return new SuccessDataResult<List<Brans>>(_bransDal.GetAll(a=>a.Durum==true));
        }

        [CacheAspect]
        public IDataResult<List<Brans>> GetAll()
        {
            return new SuccessDataResult<List<Brans>>(_bransDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<Brans> GetById(int bransId)
        {
            return new SuccessDataResult<Brans>(_bransDal.Get(a => a.Id == bransId),"Branş bilgileri getirildi.");
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IBransService.Get")]
        [ValidationAspect(typeof(Brans))]
        public IResult Update(Brans brans)
        {
            _bransDal.Update(brans);
            return new SuccessResult("Branş bilgileri güncellendi.");
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IBransService.Get")]
        public IResult Delete(Brans brans)
        {
            brans.Durum = false;
            _bransDal.Update(brans);
            return new SuccessResult("Branş bilgileri silindi.");
        }

        public IDataResult<List<Brans>> GetByKurumTurIdAll(int kurumTurId)
        {
            return new SuccessDataResult<List<Brans>>(_bransDal.GetAll(a => a.Durum == true && a.KurumTurId == kurumTurId), "Kurum Türüne göre branşlar listelendi.");
        }
    }
}
