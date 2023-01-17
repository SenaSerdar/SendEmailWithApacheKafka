using Confluent.Kafka;

namespace SendEmailWithApacheKafka;

public class Consumer
{
    static void Main(string[] args)
    {
        EmailConsumer();
    }
    public static void EmailConsumer()
    {

        var config = new ConsumerConfig
        {
            GroupId = "emailTestGroup",
            BootstrapServers = "localhost:9092",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
        using var consumer = new ConsumerBuilder<Ignore,string>(config).Build();
        consumer.Subscribe("testTopic");
        try
        {
            while (true)
            {
                var result = consumer.Consume();
                Console.WriteLine($"Consumed Message:{result.Message.Value} Topic: {result.TopicPartitionOffset}");
            }
        }
        catch (ConsumeException e)
        {
            Console.WriteLine(e.Error.Reason);
        }
    }
}
