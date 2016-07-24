using System;
using System.Data.Entity;
using CommuneCalculator.DB.Entities;
using CryptSharp;

namespace CommuneCalculator.DB.DbUtils
{
    public class DbInitializer : CreateDatabaseIfNotExists<ComCalcContext>
    {
        protected override void Seed(ComCalcContext context)
        {
            context.Roommates.Add(new Roommate
            {
                MoveInDate = DateTime.Today,
                IsTreasurer = true,
                Login = "admin",
                FirstName = "admin",
                LastName = "admin",
                PasswordHash = Crypter.Blowfish.Crypt("1n1t-R00t!")
            });

            context.SaveChanges();
        }
    }
}