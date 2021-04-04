using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{   //İlişkiler tabloları yaptığımız yer ürün ismi kategori id si gibi birden fazla tablonun joini
    public class CarDetailsDto:IDto
    {
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int DailyPrice { get; set; }
    }
}
