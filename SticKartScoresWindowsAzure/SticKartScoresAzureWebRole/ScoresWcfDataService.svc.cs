﻿using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;

namespace SticKartScoresAzureWebRole
{
    public class ScoresWcfDataService : DataService<SticKartScores_0Entities>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("HighScores", EntitySetRights.All);
            config.UseVerboseErrors = false;
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
            
            // config.SetEntitySetAccessRule("MyEntityset", EntitySetRights.AllRead);
            // config.SetServiceOperationAccessRule("MyServiceOperation", ServiceOperationRights.All);
        }
    }
}
