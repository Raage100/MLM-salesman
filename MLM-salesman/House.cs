using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLM_salesman
{
    public class House
    {
        public bool IsSalesman { get; set; }
        public int SalesmanCount { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public House()
        {
            IsSalesman = false;
            SalesmanCount = 0;
            X = 0;
            Y = 0;
        }

        public void ConvertToSalesman()
        {
            IsSalesman = true;
            SalesmanCount++;
        }

        public bool GetIsSalesman()
        {
            return IsSalesman;
        }

        public override string ToString()
        {
            return $"House at ({X}, {Y})";
        }
    }
}
