using System;
using System.Collections.Generic;

namespace FactoryAdapter.Contract
{
    internal interface IMappingContract
    {
        T MapObject<T>(IRetriveData dataTypes) where T : class, new();

        List<T> MapList<T>(IRetriveData dataTypes) where T : class, new();
    }
}
