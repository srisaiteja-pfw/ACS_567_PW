using HW.Data;
using HW.Models;
using System;

public class Seed
{
    /// <summary>
    /// 
    ///  Seed method in C# is typically used as a method to populate data when the database is first created. 
	///  Method is called in the context of a database migration or setup process.
    /// </summary>
    private readonly DataContext dataContext;
    public Seed(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }
    public void SeedDataContext()
    {
        if (!dataContext.Fintech.Any())
        {
            //Account data
            List<Fintech> bill = new()
            {
                new Fintech {Id = 9, Firstname = "Likhita", Lastname = "B", Address = "Seattle", Email = "likithab@gmail.com",Contact ="2602154789", Age = 25, SSN="0145786545",Balance=30.0},
                new Fintech {Id = 9, Firstname = "Anuradha", Lastname = "K", Address = "New York", Email = "anuk@gmail.com",Contact ="7845124245", Age = 23, SSN="4587891254",Balance=30.0}
            };
            dataContext.Fintech.AddRange(bill);
            dataContext.SaveChanges();
        }
    }

}
