using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{CarId =1,BrandId=1,ColorId=1,ModelYear=2012,DailyPrice=225,Description="Sedan"},
                new Car{CarId =2,BrandId=1,ColorId=2,ModelYear=2016,DailyPrice=260,Description="Hatchback"},
                new Car{CarId =3,BrandId=2,ColorId=3,ModelYear=2018,DailyPrice=280,Description="Coupe"},
                new Car{CarId =4,BrandId=2,ColorId=1,ModelYear=2013,DailyPrice=250,Description="Station Wagon"},
                new Car{CarId =5,BrandId=3,ColorId=2,ModelYear=2020,DailyPrice=320,Description="SUV"}
            };
            
        }
        public void Add(Car car)
        {
           _cars.Add(car);//parametre olarak bana arayüzden businessdan gönderilen ürünü listeye ekledim
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete = _cars.SingleOrDefault(c=>c.CarId==car.CarId);//SingleOrDefault bir değer arar bir değer verer id yapılarda kullanılır
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList();
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailsDto> GetColorDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {   //gönderdiğim araba idsine sahip olan listedeki ürünü bul
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.CarId = car.CarId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        
    }
}
