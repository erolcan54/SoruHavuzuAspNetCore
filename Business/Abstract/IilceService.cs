using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IilceService
    {
        IDataResult<List<ilce>> GetAll();
        IDataResult<List<ilce>> GetByListilId(int ilId);
        IDataResult<ilce> GetById(int id);

    }
}
