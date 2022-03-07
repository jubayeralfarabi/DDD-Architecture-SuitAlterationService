// <copyright file="BusOptions.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Bus
{
    public class BusOptions
    {
        public string ConnectionString { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string QueueName { get; set; }

        public int PrefetchCount { get; set; }

        public int RetryCount { get; set; }

        public int RetryInterval { get; set; }
    }
}
