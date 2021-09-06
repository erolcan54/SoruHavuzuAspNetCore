using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserDetayManager : IUserDetayService
    {
        private IUserDetayDal _userDetayDal;

        public UserDetayManager(IUserDetayDal userDetayDal)
        {
            _userDetayDal = userDetayDal;
        }

        [SecuredOperation("user")]
        [ValidationAspect(typeof(UserDetayValidator))]
        public IResult Add(UserDetay userDetay)
        {
            _userDetayDal.Add(userDetay);
            return new SuccessResult("Bilgiler Eklendi.");
        }

        [SecuredOperation("admin")]
        public IDataResult<List<UserDetay>> GetAll()
        {
            return new SuccessDataResult<List<UserDetay>>(_userDetayDal.GetAll(), "Tüm kullanıcıların detay bilgileri getirildi.");
        }

        public IDataResult<UserDetay> GetById(int id)
        {
            return new SuccessDataResult<UserDetay>(_userDetayDal.Get(a=>a.Id==id),"Seçilen detay bilgileri getirildi.");
        }

        public IDataResult<UserDetay> GetByUserId(int userId)
        {
            return new SuccessDataResult<UserDetay>(_userDetayDal.Get(a => a.UserId == userId), "Seçilen kullanıcının detay bilgileri getirildi.");
        }

        [ValidationAspect(typeof(UserDetayValidator))]
        public IResult Update(UserDetay userDetay)
        {
            _userDetayDal.Update(userDetay);
            return new SuccessResult("Bilgiler Güncellendi.");
        }
    }
}
