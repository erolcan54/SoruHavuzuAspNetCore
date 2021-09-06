using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IKurumTipiService
    {
        IResult Add(KurumTipi kurumTipi);
        IDataResult<List<KurumTipi>> GetAll();
        IDataResult<List<KurumTipi>> AktifGetAll();
        IDataResult<List<KurumTipi>> GetByKurumTurIdList(int kurumTurId);
        IDataResult<KurumTipi> GetById(int kurumTipId);
        IResult Delete(KurumTipi kurumTipi);
        IResult Update(KurumTipi kurumTipi);
    }
}
