using System;
using System.Collections.Generic;

namespace Game.Analytics
{
    public class AnalyticsService
    {
        private readonly IEnumerable<IAnalyticsContextProvider> _contextProviders;

        public AnalyticsService(IEnumerable<IAnalyticsContextProvider> contextProviders)
        {
            _contextProviders = contextProviders;
        }
        
        private AnalyticsContext _analyticsContext;
        
        public AnalyticsContext GetAnalyticsContext()
        {
            _analyticsContext ??= new AnalyticsContext();
            foreach (var contextProvider in _contextProviders) 
                contextProvider.UpdateAnalyticsContext(_analyticsContext);

            return _analyticsContext;
        }
    }
}