using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();//***). haftanın ödevi join işlemlerini yazdırdığımız kısım
            //BrandTest();
            //ColorTest();
            //CarTestResult();
            //UserTest();
            //CustomerTest();
            RentalTest();
        }
        private static void CarTestResult()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();//Bu metodu çalıştırdığımız için bunun içindeki mesajları dataları falan verdi
            if (result.Success==true)
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName);//Bana brandNamelerin hepsini verdi

                }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());//içine ne ile çalışıyorsak onu veririz
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName);
                Console.WriteLine(car.BrandName);
                Console.WriteLine(car.DailyPrice);
            }

            foreach (var car in carManager.GetColorDetails().Data)
            {
                Console.WriteLine(car.ColorName);
            }
            Car car1 = new Car { BrandId = 2, ColorId = 3, DailyPrice = 100, ModelYear = 2018, Description = "LPG" };
            Car car2 = new Car { CarId = 15, BrandId = 2, ColorId = 2, DailyPrice = 100, ModelYear = 2018, Description = "Diesel" };
            Car car3 = new Car { BrandId = 2, ColorId = 2, DailyPrice = 90, ModelYear = 2017, Description = "LPG" };
            Car car4 = new Car { CarId = 22 };

            carManager.Add(car1);
            carManager.Add(car3);
            carManager.Update(car2);
            carManager.Delete(car4);
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarId);
            }

        }
        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand { BrandName = "Volvo" };
            brandManager.Add(brand);
            brandManager.Delete(new Brand { BrandId = 17 });
            Console.WriteLine(brandManager.GetById(2));

            foreach (var brands in brandManager.GetAll().Data)
            {
                Console.WriteLine("Araç Markaları: " + brands.BrandName);
            }


        }
        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color { ColorName = "Gray" };
            colorManager.Add(color);
            colorManager.Delete(new Color { ColorId = 5 });
            Console.WriteLine(colorManager.GetById(4));

            foreach (var colors in colorManager.GetAll().Data)
            {
                Console.WriteLine("Araç Renkleri: " + colors.ColorName);
            }
        }
        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User { FirstName = "Rukiye", LastName = "Şahin", Email = "deneme@deneme.gmail.com", Password = "123456" };
            userManager.Add(user);
            Console.WriteLine(userManager.GetById(1));
            foreach (var users in userManager.GetAll().Data)
            {
                Console.WriteLine("Kullanıcı İsimleri: " + users.FirstName);
            }
        }
        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //UserManager userManager = new UserManager(new EfUserDal());
            //customerManager.Add(new Customer { CompanyName = "Logo", UserId = userManager.GetById(1).Data.UserId })
            Customer customer = new Customer {CompanyName="Samsan Tech" , UserId=1 };
            customerManager.Add(customer);
            Console.WriteLine(customerManager.GetById(1));
            foreach (var customers in customerManager.GetAll().Data)
            {
                Console.WriteLine("Şirket İsimleri: " + customers.CompanyName);
            }
        }
        private static void RentalTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { CarId = carManager.GetById(4).Data.CarId, CustomerId = customerManager.GetById(1).Data.CustomerId, RentDate = new DateTime(2021, 03, 20), ReturnDate = new DateTime(2021, 03, 23) });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
