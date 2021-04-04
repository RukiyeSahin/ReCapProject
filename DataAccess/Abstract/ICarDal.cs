using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{   //sadece kendilerine özgü metodları yazdık
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailsDto> GetCarDetails();//sadece bu kısıma özgü bir join yazdık klasörlememizin sebebi bu 
        List<CarDetailsDto> GetColorDetails();
    }
}
