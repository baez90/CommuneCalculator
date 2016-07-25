using System;
using System.Data.Entity;
using CommuneCalculator.DB.Entities;

namespace CommuneCalculator.DB.DbUtils
{
    public class DbInitializer : CreateDatabaseIfNotExists<ComCalcContext>
    {
        protected override void Seed(ComCalcContext context)
        {
            context.Roommates.Add(new Roommate
            {
                MoveInDate = DateTime.Today,
                FirstName = "admin",
                LastName = "admin"
            });

            context.SaveChanges();
        }
    }
}