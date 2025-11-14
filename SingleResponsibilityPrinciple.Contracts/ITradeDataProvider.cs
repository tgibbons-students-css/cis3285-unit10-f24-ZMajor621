using System.Collections.Generic;

namespace SingleResponsibilityPrinciple.Contracts
{
    public interface ITradeDataProvider
    {
        IAsyncEnumerable<string> GetTradeData();
    }
}