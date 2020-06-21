using System;
using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Core;
using Tinamous.InfluxDbBot.Domain;

namespace Tinamous.InfluxDbBot.InfluxDbClient
{
    public class Client : IInfluxDbClient
    {
        private InfluxDBClient _client;

        private void Connect(Bot bot)
        {
            if (bot.Authentication == null)
            {
                return;
            }

            // You can generate a Token from the "Tokens Tab" in the UI
            string token = bot.GetToken(); //  "token";
            string bucket = bot.Bucket; // "bucketID";
            string org = bot.Org; //  "f937c3f9111c90c4";

            _client = InfluxDBClientFactory.Create(bot.Url, token.ToCharArray());
        }

        public void WriteData(Bot bot, Mem mem)
        {
            mem = new Mem { Host = "host1", UsedPercent = 23.43234543, Time = DateTime.UtcNow };

            using (var writeApi = _client.GetWriteApi())
            {
                writeApi.WriteMeasurement(bot.Bucket, bot.Org, WritePrecision.Ms, mem);
            }
        }
    }

    // TODO: Make a specific class for the data.
    [Measurement("mem")]
    public class Mem
    {
        [Column("host", IsTag = true)] 
        public string Host { get; set; }

        [Column("used_percent")] 
        public double? UsedPercent { get; set; }

        [Column(IsTimestamp = true)] 
        public DateTime Time { get; set; }
    }
}
