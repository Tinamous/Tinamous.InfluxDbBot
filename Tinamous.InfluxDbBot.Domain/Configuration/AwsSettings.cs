using System.Configuration;

namespace Tinamous.InfluxDbBot.Domain.Configuration
{
    public class AwsSettings
    {
        public AwsSettings()
        {

            ProfileName = ConfigurationManager.AppSettings["Aws.ProfileName"];
            Region = ConfigurationManager.AppSettings["Aws.Region"];

            RawMeasurementsStreamName = ConfigurationManager.AppSettings["Aws.Kinesis.RawMeasurements.StreamName"];
            ProcessedMeasurementsStreamName = ConfigurationManager.AppSettings["Aws.Kinesis.ProcessedMeasurements.StreamName"];
            DynamoDbTablePrefix = ConfigurationManager.AppSettings["Aws.DynamoDb.TablePrefix"];
        }

        public string ProfileName { get; set; }

        public string Region { get; set; }

        public string RawMeasurementsStreamName { get; set; }

        public string ProcessedMeasurementsStreamName { get; set; }

        /// <summary>
        /// Table prefix for DynamoDB tables.
        /// </summary>
        public string DynamoDbTablePrefix { get; set; }

        public bool CreateStream { get; set; }

        #region SQS Queues

        #endregion
    }
}