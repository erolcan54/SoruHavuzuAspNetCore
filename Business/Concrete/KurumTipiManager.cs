using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class KurumTipiManager : IKurumTipiService
    {
        private IKurumTipiDal _kurumTipiDal;

        public KurumTipiManager(IKurumTipiDal kurumTipiDal)
        {
            _kurumTipiDal = kurumTipiDal;
        }

        public IResult Add(KurumTipi kurumTipi)
        {
            _kurumTipiDal.Add(kurumTipi);
            return new SuccessResult("Kurum Tipi eklendi.");
        }

        public IDataResult<List<KurumTipi>> AktifGetAll()
        {
            return new SuccessDataResult<List<KurumTipi>>(_kurumTipiDal.GetAll(a=>a.Durum==true),"Aktif Kurum Tipleri getirildi.");
        }

        public IResult Delete(KurumTipi kurumTipi)
        {
            kurumTipi.Durum = false;
            _kurumTipiDal.Update(kurumTipi);
            return new SuccessResult("Kurum Tipi bilgileri silindi.");
        }

        public IDataResult<List<KurumTipi>> GetAll()
        {
            return new SuccessDataResult<List<KurumTipi>>(_kurumTipiDal.GetAll(), "Tüm Kurum Tipleri getirildi.");
        }

        public IDataResult<KurumTipi> GetById(int kurumTipId)
        {
            return new SuccessDataResult<KurumTipi>(_kurumTipiDal.Get(a=>a.Id==kurumTipId),"Seçilen Kurum Tipi getirildi.");
        }

        public IDataResult<List<KurumTipi>> GetByKurumTurIdList(int kurumTurId)
        {
            return new SuccessDataResult<List<KurumTipi>>(_kurumTipiDal.GetAll(a=>a.KurumTurId==kurumTurId && a.Durum==true),"Seçilen Kurum Türüne göre Kurum Tipleri listelendi.");
        }

        public IResult Update(KurumTipi kurumTipi)
        {
            _kurumTipiDal.Update(kurumTipi);
            return new SuccessResult("Kurum Tipi bilgileri güncellendi.");
        }
    }
}
