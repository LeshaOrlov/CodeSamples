using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace KafkaProducerHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, collection) =>
            {
                collection.AddHostedService<KafkaProducerHostedService>();
            });
    }

    public class KafkaProducerHostedService : IHostedService
    {
        private readonly ILogger _logger;
        private IProducer<Null, string> _producer;
        public KafkaProducerHostedService(ILogger<KafkaProducerHostedService> logger)
        {
            _logger = logger;
            var config = new ProducerConfig()
            {
                BootstrapServers = "localhost:9092"
            };
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            //using (var adminClient = new AdminClientBuilder(new AdminClientConfig { BootstrapServers = "localhost:9092" }).Build())
            //{
            //    try
            //    {
            //        await adminClient.CreateTopicsAsync(new TopicSpecification[] {
            //        new TopicSpecification { Name = "demo", ReplicationFactor = 1, NumPartitions = 1 } });
            //    }
            //    catch (CreateTopicsException e)
            //    {
            //        Console.WriteLine($"An error occured creating topic {e.Results[0].Topic}: {e.Results[0].Error.Reason}");
            //    }
            //}


            for (int i = 0; i < 100; i++)
            {
                var message = $"Hello World {i}";
                _logger.LogInformation(message);

                await _producer.ProduceAsync(topic: "demo1", new Message<Null, string>()
                {
                    Value = message
                }, cancellationToken);
            }

            _producer.Flush(TimeSpan.FromSeconds(10));
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _producer?.Dispose();
            return Task.CompletedTask;
        }
    }
}
