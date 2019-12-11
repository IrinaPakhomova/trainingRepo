using System;
using System.Collections.Generic;
using ServiceLib;

namespace FinancialProgram
{
    class VisualisationData
    {
        public void OutputDataToTable(List<OperationEntity> list)
        {
            if (list == null || list.Count == 0)
            {
                Console.WriteLine("Нет данных для отображения");
            }
            else
            { 
                Console.WriteLine(" ".PadRight(35, '-'));
                foreach (OperationEntity item in list)
                {
                    Console.WriteLine($"|  {item.Date}  | {item.Money}  |");
                }
                Console.WriteLine(" ".PadRight(35, '-'));
            }
        }

        /* public static void OutputDataToChart(List<OperationEntity> list)
         {

         }
         public static void OutputDataToDiagram(List<OperationEntity> list)
         {

         }*/
    }
}
