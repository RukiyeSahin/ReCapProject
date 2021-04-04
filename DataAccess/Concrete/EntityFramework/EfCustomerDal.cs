using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapContext>, ICustomerDal
    {
    }
    //{

    //    //public List<CustomerDetailsDto> GetCustomerDetails()
    //    //{
    //    //    using (ReCapContext context = new ReCapContext())
    //    //    {
    //    //        var result = from c in context.Customers
    //    //                     join u in context.Users
    //    //                     on c.UserId equals u.UserId
    //    //                     select new CustomerDetailsDto
    //    //                     {
    //    //                         UserFirstName =u.FirstName,
    //    //                         UserLastName = u.LastName,
    //    //                         CompanyName = c.CompanyName
    //    //                     };
    //    //        return result.ToList();

    //    //    }
    //    //}
}

