using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Coin : BaseEntity
    {
        public decimal Amount { get; set; }
        public string Symbol { get; set; }
        public string Status { get; set; }
        public string CoinName { get; set; }

        public Coin()
        {

        }

        /// <summary>
        /// el siguiente codigo verifica que todos los inputs contengan informacion 
        /// </summary>
        /// <param name="infoArray"></param>
        /// 
        public Coin(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 3)
            {
                CoinName = infoArray[0];

                var amount = 0;
                if (Int32.TryParse(infoArray[1], out amount))
                    Amount = amount;
                else
                    throw new Exception("El AMOUNT debe ser un valor numerico");


                Symbol = infoArray[2];
                Status = infoArray[3];


            }
            else
            {
                throw new Exception("Todos los valores son requeridos");
            }

        }
    }
}
