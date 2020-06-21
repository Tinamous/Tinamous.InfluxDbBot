using System;
using System.Collections.Generic;

namespace Tinamous.InfluxDbBot.Domain
{
    public class Bot
    {
        public Guid Id { get; set; }

        public Guid MembershipId { get; set; }

        public Guid OwnerId { get; set; }

        public Guid AccountId { get; set; }

        /// <summary>
        /// If the bot should send all device data. If not, devices should
        /// be spefiedi in FilterByUsers
        /// </summary>
        public bool AllDevices { get; set; } = true;

        /// <summary>
        /// If the bot should send data from only selected devices.
        /// </summary>
        public List<Guid> FilterByUsers { get; set; }


        // if Influx specifics...

        /// <summary>
        /// The url for the influx cloud (or user hosted?)
        /// </summary>
        /// <remarks>
        /// https://eu-central-1-1.aws.cloud2.influxdata.com
        /// </remarks>
        public string Url { get; set; } = "https://eu-central-1-1.aws.cloud2.influxdata.com";

        public string Bucket { get; set; }

        // ??
        public string Org { get; set; }
        

        public AuthenticationOptions Authentication { get; set; }

        public string GetToken()
        {
            if (Authentication == null)
            {
                return null;
            }
            // TODO: Decrypt the auth token
            return "Hello";
        }
    }
}
