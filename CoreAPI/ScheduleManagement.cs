using DataAccess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class ScheduleManagement
    {

        private ScheduleCrudFactory crudfactory;

        public ScheduleManagement()
        {
            crudfactory = new ScheduleCrudFactory();
        }

        public void Create(Schedule a)
        {
            try
            {
                var tmpSchedule = crudfactory.Retrieve<Schedule>(a);
                if (tmpSchedule != null)
                {
                    throw new BussinessException(3);
                }
                crudfactory.Create(a);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        public List<Schedule> RetrieveAll()
        {
            return crudfactory.RetrieveAll<Schedule>();
        }

        public Schedule RetrieveById(Schedule a)
        {
            Schedule tmpSchedule = null;
            try
            {
                tmpSchedule = crudfactory.Retrieve<Schedule>(a);
                if (tmpSchedule == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return tmpSchedule;
        }

        public void Update(Schedule a)
        {
            crudfactory.Update(a);
        }

        public void Delete(Schedule a)
        {
            crudfactory.Delete(a);
        }

        public void Activar()
        {
        }

    }
}
