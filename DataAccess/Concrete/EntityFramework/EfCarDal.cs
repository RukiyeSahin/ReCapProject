using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Metodların hepsi EfEntityRepositoryBase de var diyor ICarDal var bende ondan inherite edicem diyor
    //ICarDal neden gerekli:ICarDal a özel operasyonlar yazınca implemete etmekte kolaylık sağlar
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {  //
        public List<CarDetailsDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new CarDetailsDto
                             {
                                 CarName = c.Description,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();

            }

        }

        public List<CarDetailsDto> GetColorDetails() //Aslında bu joini color da da yazabiliriz
        {
            using (ReCapContext context = new ReCapContext())
            {
                var donus = from c in context.Cars
                            join b in context.Colors
                            on c.ColorId equals b.ColorId
                            select new CarDetailsDto
                            {
                                ColorName = b.ColorName
                               
                            };
                return donus.ToList();

            }
        }
    }


}
