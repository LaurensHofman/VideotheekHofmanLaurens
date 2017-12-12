using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideotheekLibrary.Data;
using VideotheekLibrary.Entities;

namespace VideotheekLibrary.DAL
{
    public static class DAL_Client
    {
        public static List<Client> GetAll()
        {
            var ctx = AppDbContext.Instance();

            return ctx.Clients
                .Where(c => c.DeletedAt == null)
                .OrderBy(c => c.Surname)
                .ThenBy(c => c.FirstName)
                .ThenBy(c => c.BirthDate)
                .ToList();
        }

        public static string GetFullDetails(int clientID)
        {
            var ctx = AppDbContext.Instance();

            var det = ctx.Clients.SingleOrDefault(c => c.ID == clientID);
            return det.FullDetails;

        }

        public static void Create(Client model)
        {
            var ctx = AppDbContext.Instance();

            ctx.Clients.Add(model);
            ctx.SaveChanges();
        }

        public static void Update(Client model)
        {
            var ctx = AppDbContext.Instance();

            ctx.Entry(model).State = EntityState.Modified;
            ctx.SaveChanges();
        }



    }
}
