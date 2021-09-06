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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult("Kullanıcı bilgileri eklendi.");
        }

        [SecuredOperation("admin")]
        public IDataResult<List<User>> GetAktifUser()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(a=>a.Durum==true), "Aktif kullanıcılar listelendi.");
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), "Tüm kullanıcılar listelendi.");
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(a => a.Id == userId), "Kullanıcı bilgileri alındı.");
        }

        public IDataResult<List<User>> GetByilceIdListUser(int ilceId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetByilIdListUser(int ilId)
        {
            throw new NotImplementedException();
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(a => a.Email == email);
        }

        public IDataResult<List<User>> GetByOkulIdListUser(int okulId)
        {
            throw new NotImplementedException();
        }


        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        [SecuredOperation("admin")]
        public IDataResult<List<User>> GetPasifUser()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(a => a.Durum == false), "Pasif kullanıcılar listelendi.");
        }

        [SecuredOperation("admin,user")]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult("Kullanıcı bilgileri güncellendi.");
        }
    }
}
