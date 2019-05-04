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
    public class SeatManagement
    {
        private SeatCrudFactory crudfactory;

        public SeatManagement()
        {
            crudfactory = new SeatCrudFactory();
        }

        public void Create(Seat a)
        {
            try
            {
                var seat = crudfactory.Retrieve<Seat>(a);
                if (seat != null)
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
        public List<Seat> RetrieveAll()
        {
            return crudfactory.RetrieveAll<Seat>();
        }

        public Seat RetrieveById(Seat a)
        {
            Seat tmpSeat = null;
            try
            {
                tmpSeat = crudfactory.Retrieve<Seat>(a);
                if (tmpSeat == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return tmpSeat;
        }

        public void Update(Seat a)
        {
            crudfactory.Update(a);
        }

        public void Delete(Seat a)
        {
            crudfactory.Delete(a);
        }
    }
}
