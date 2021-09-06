using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IKurumTuruService
    {
        IDataResult<List<KurumTuru>> GetAll();
        IDataResult<List<KurumTuru>> GetAllAktif();
        IDataResult<KurumTuru> GetById(int kurumTurId);
        IResult Add(KurumTuru kurumTuru);
        IResult Update(KurumTuru kurumTuru);
        IResult Delete(KurumTuru kurumTuru);

    }
}
