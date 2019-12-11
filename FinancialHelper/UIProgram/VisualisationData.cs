using System;
using System.Collections.Generic;
using ServiceLib;

namespace UIProgram
{
    class VisualisationData
    {
        public static void OutputDataToTable(List<OperationEntity> list)
        {
            if (list != null && list.Count>0)
            {
                Console.WriteLine(" ".PadRight(35,'-'));
                foreach (OperationEntity item in list)
                {
                    Console.WriteLine($"|  {item.Date}  | {item.Money}  |");
                }
                Console.WriteLine(" ".PadRight(35, '-'));
            }
            if (list.Count == 0)
            {
                Console.WriteLine("Нет данных для отображения");
            }
        }

        public static void OutputDataToChart(List<OperationEntity> list)
        {
            
        }
        public static void OutputDataToDiagram(List<OperationEntity> list)
        {

        }
    }
}
