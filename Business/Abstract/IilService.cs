using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IilService
    {
        IDataResult<List<il>> GetAll();
        IDataResult<il> GetById(int id);
    }
}
