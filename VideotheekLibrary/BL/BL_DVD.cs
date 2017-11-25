using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideotheekLibrary.DAL;
using VideotheekLibrary.Entities;

namespace VideotheekLibrary.BL
{
    public static class BL_DVD
    {
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


    }
}
