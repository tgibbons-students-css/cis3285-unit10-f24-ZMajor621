using SingleResponsibilityPrinciple.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    public class URLAsyncProvider : ITradeDataProvider
    {
        // store the ITradeDataProvider instance to use locally
       private readonly ITradeDataProvider localProvider;
        public URLAsyncProvider(ITradeDataProvider localProvider)
        {
            this.localProvider = localProvider;
        }

        //public Task<IEnumerable<string>> GetTradeAsync()
       // {
        //    Task<IEnumerable<string>> task = Task.Run(() => localProvider.GetTradeData());
        //    return task;
        //}

        public async IAsyncEnumerable<string> GetTradeData()
        {
            Task<IAsyncEnumerable<string>> task = Task.Run(() => localProvider.GetTradeData());
            task.Wait();

            IAsyncEnumerable<string> tradeList = task.Result;
            await foreach (var trade in tradeList)
            {
                yield return trade;
            }
        }
    }    
}