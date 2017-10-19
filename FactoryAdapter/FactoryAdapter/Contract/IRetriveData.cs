using System;

namespace FactoryAdapter.Contract
{
    internal interface IRetriveData
    {
        String GetAsString(string columnName);

        Int32 GetAsInt(string columnName);

        Double GetAsDouble(string columnName);

        Decimal GetAsDecimal(string columnName);

        DateTime GetAsDate(string columnName);

        Boolean Read();
    }
}
