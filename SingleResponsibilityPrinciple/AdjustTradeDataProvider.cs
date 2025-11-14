using SingleResponsibilityPrinciple.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    public class AdjustTradeDataProvider : ITradeDataProvider
    {
        // store the ITradeDataProvider instance to use locally
       private readonly ITradeDataProvider localProvider;
        public AdjustTradeDataProvider(ITradeDataProvider localProvider)
        {
            this.localProvider = localProvider;
        }

        public async IAsyncEnumerable<string> GetTradeData()
        {
            //call original provider to get data
            IAsyncEnumerable<string> lines = localProvider.GetTradeData();

            List<string> result = new List<string>();

            // Adjust "GBP to "EUR" in all the txt lines
            await foreach (string line in lines)
            {
                result.Add(line.Replace("GBP", "EUR"));
            }
            foreach (var item in result)
            {
                yield return item;
            }
        }
    }    
}