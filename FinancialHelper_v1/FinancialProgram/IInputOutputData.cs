using System;
using System.Collections.Generic;
using ServiceLib;

namespace FinancialProgram
{
    interface IInputOutputData
    {
        void Input(DateTime date, decimal amount, Storage storage);

        List<OperationEntity> GetDataOperations(Storage storage);
    }
}
