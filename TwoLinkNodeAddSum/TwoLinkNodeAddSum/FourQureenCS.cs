using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoLinkNodeAddSum
{
    public  class FourQureenCS
    {
        public  void FourQureen()
        {
            int iQueryCount = 4;
            List<string> fourQureenList = new List<string>();
            string[] TempArray = new string[4];
             int[,] Data=new int[4,4];
            for (int i = 0; i < iQueryCount; i++)
            { 
            
            }
        }

        public  void GetData(int[,]  Data, int[,] TempArray, int StartIndex,int iQureenyIndex,int iQureenCount)
        {
            for (int iRow = 0; iRow < iQureenCount; iRow++)
            {
                for (int jColumn = 0; jColumn < iQureenCount; jColumn++)
                {
                    Data[iRow, jColumn] = 1;
                    GetData(Data, TempArray, StartIndex, iQureenyIndex, iQureenCount);
                }
            }
        }

        public void GetDataRun(int[,] Data, int iRowStart, int jColumnaStart, int iQureenCount)
        {
            for (int iRow = iRowStart; iRow < iQureenCount; iRow++)
            {
                if (iRow == iRowStart) continue;
                Data[iRow, jColumnaStart] = 0;
            }
            for (int jColumn = jColumnaStart; jColumn < iQureenCount; jColumn++)
            {
                if (jColumn == iRowStart) continue;
                Data[iRowStart, jColumn] = 0;
            }
            for (int jColumn = jColumnaStart; jColumn < iQureenCount; jColumn++)
            {

            }
    }
}
