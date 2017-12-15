using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideotheekLibrary.DAL;
using VideotheekLibrary.Entities;

namespace VideotheekLibrary.BL
{
    /// <summary>
    /// Business Logic for actions concerning DVDs.
    /// </summary>
    public static class BL_DVD
    {
        /// <summary>
        /// Calls the action to get a list of all the DVDs from the database.
        /// </summary>
        /// <returns></returns>
        public static List<DVD> GetAll()
        {
            try
            {
                return DAL_DVD.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Determines whether a new DVD has to be created or that an existing DVD has to be updated
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Save(DVD model)
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

        /// <summary>
        /// Calls the action to update an existing DVD.
        /// </summary>
        /// <param name="model"></param>
        private static void Update(DVD model)
        {
            try
            {
                DAL_DVD.Update(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Calls the action to create a new DVD.
        /// </summary>
        /// <param name="model"></param>
        private static void Create(DVD model)
        {
            try
            {
                DAL_DVD.Create(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Calls the action to Delete an existing DVD.
        /// </summary>
        /// <param name="model"></param>
        public static void Delete(DVD model)
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

        /// <summary>
        /// Calls the action to get a filtered list of DVDs.
        /// </summary>
        /// <param name="search"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static List<DVD> Filter(string search, string filter)
        {
            try
            {
                return DAL_DVD.Filter(search, filter);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
