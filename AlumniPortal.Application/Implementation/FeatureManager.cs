using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniPortal.Application.Implementation
{
    public class FeatureManager : IFeatureManager
    {
        public IAsyncEnumerable<string> GetFeatureNamesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsEnabledAsync(string feature)
        {
            return Task.FromResult(true);
        }

        public Task<bool> IsEnabledAsync<TContext>(string feature, TContext context)
        {
            return Task<bool>.FromResult(true);
        }
    }
}
