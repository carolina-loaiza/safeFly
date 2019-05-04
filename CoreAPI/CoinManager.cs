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
    public class CoinManager : BaseManager
    {
        private CoinCrudFactory crudCoin;

        public CoinManager()
        {
            crudCoin = new CoinCrudFactory();
        }

        public void Create(Coin coin)
        {
            try
            {
                var c = crudCoin.Retrieve<Coin>(coin);

                if (c != null)
                {
                    //Coin already exist
                    throw new BussinessException(3);
                }
                else
                    crudCoin.Create(coin);    // CREATED COIN
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Coin> RetrieveAll()
        {
            return crudCoin.RetrieveAll<Coin>();
        }

        public Coin RetrieveById(Coin coin)
        {
            Coin c = null;
            try
            {
                c = crudCoin.Retrieve<Coin>(coin);
                if (c == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public void Update(Coin coin)
        {
            crudCoin.Update(coin);
        }

        public void Delete(Coin coin)
        {
            crudCoin.Delete(coin);
        }
    }
}
