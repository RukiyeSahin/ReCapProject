using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
        //İş sınıflarını yazarız
    {   //Bağımlılıkları azaltmak için yaparız bu işlemi
        ICarDal _carDal;
    

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        //Bu şeyleri resultlı yapmamızın sebebi bize mesaj ve işlem sonucu versin istiyoruz o yüzden başarılı olanlar için successli başarısız olanlar iin errorlu classlar yazdık onların içinde mesaj kısmında işlem ne yaptıysa vermek istediğimiz mesajı verdik bu sayede 3 değer döndürebildik
        public IResult Add(Car car)
        {   //Eğer öyleyse ekle kodları buraya yazılır
            if (car.Description.Length < 2 && car.DailyPrice<=0)
            {
                return new ErrorResult(Messages.CarNameInvalited);
            }
            _carDal.Add(car);
            //Bunu yazmammızın nedeni IResult döndürüyor ve onun 2 metodu var
            ///return new Result(true,"Ürün eklendi");//Consructora 2 parametre yolluyoruz//Result bir IResult implementasyonu(Bunu alttaki yapıya çevirdik)
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour ==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MainteanceTime);
            }
            //iş kodları yazılır iş kodlarından geçince veri erişimi çağırmalıyım işlem başarılıysa işlemi yap
            return  new SuccessDataResult<List<Car>>( _carDal.GetAll(),Messages.Listed);
            
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c => c.BrandId == id));//SuccessDataResult içinde çalıştığım tipi belirledim onun içine parantez kısında constructorına bu değeri gönderdim
        }


        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return  new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<List<CarDetailsDto>> GetColorDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetColorDetails());//ICarDal daki GetColorDetails() bana ver dedik
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }
    }
}
