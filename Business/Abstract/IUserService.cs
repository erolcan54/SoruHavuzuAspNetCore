using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetAktifUser();
        IDataResult<List<User>> GetPasifUser();
        IDataResult<User> GetById(int userId);
        IDataResult<List<User>> GetByilIdListUser(int ilId);
        IDataResult<List<User>> GetByilceIdListUser(int ilceId);
        IDataResult<List<User>> GetByOkulIdListUser(int okulId);
        IResult Add(User user);
        IResult Update(User user);
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
    }
}
