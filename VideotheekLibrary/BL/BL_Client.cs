using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideotheekLibrary.DAL;
using VideotheekLibrary.Entities;

namespace VideotheekLibrary.BL
{
    public static class BL_Client
    {
        public static List<Client> GetAll()
        {
            try
            {
                return DAL_Client.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string GetFullDetails(int clientID)
        {
            try
            {
                return DAL_Client.GetFullDetails(clientID);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static bool Save(Client model)
        {
            try
            {
                if (model.IsNew())
                    Create(model);

                else
                    Update(model);
            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }

        private static void Update(Client model)
        {
            try
            {
                DAL_Client.Update(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void Create(Client model)
        {
            try
            {
                DAL_Client.Create(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Delete(Client model)
        {
            try
            {
                model.DeletedAt = DateTime.Now;
                Save(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
