using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserDetayService
    {
        IResult Add(UserDetay userDetay);
        IDataResult<List<UserDetay>> GetAll();
        IDataResult<UserDetay> GetById(int id);
        IDataResult<UserDetay> GetByUserId(int userId);
        IResult Update(UserDetay userDetay);
    }
}
