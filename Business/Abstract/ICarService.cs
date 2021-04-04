using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {   // List<Car> yerine IDataResult yazarız void olanlar IResult değer döndürenler IDataResult
        //IDataRsult sadece önceden döndürdüğünü(Data) değil bununla birlikte işlem sonucunu  ve mesajı döndürür o yüzden IDataResult yaptık
        IDataResult<List<Car>> GetAll(); 
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailsDto>> GetCarDetails();
        IDataResult<List<CarDetailsDto>> GetColorDetails();//Ben joinli kısmı listelemek istiyorum dedim
        IDataResult<Car> GetById(int carId);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
    }


}

