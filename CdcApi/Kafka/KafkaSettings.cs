using System;

namespace Settings
{
    public static class KafkaSettings
    {
        public static string BootstrapServers = "kafka:9092";

        public static class Topics
        {
            public static string ContractsTopicName = "mssql.dbo.Contracts";
        }
        
        public static class Groups
        {
            public static string GroupId = "api";
        }
    }

}

