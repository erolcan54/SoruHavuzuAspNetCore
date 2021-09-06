using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBransService
    {
        IDataResult<List<Brans>> GetAllAktif();
        IDataResult<List<Brans>> GetAll();
        IDataResult<Brans> GetById(int bransId);
        IResult Add(Brans brans);
        IResult Update(Brans brans);
        IResult Delete(Brans brans);
        IDataResult<List<Brans>> GetByKurumTurIdAll(int kurumTurId);
    }
}
