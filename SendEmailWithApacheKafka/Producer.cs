using Confluent.Kafka;
using Newtonsoft.Json;
using SendEmailWithApacheKafka.Dto;

namespace SendEmailWithApacheKafka;

public class Producer
{
    static async Task Main(string[] args)
    {
       await EmailProducerAsync();
    }
    public static async Task EmailProducerAsync()
    {

        var config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092"
        };
        using var producer = new ProducerBuilder<Null,string>(config).Build();
        try
        {
            while (true)
            {
                Console.Write("To:");
                var to = Console.ReadLine();
                Console.Write("\nSubject:");
                var subject = Console.ReadLine();
                var email = new Email
                {
                    To=to,
                    Subject = subject
                };
                var emailMessage = JsonConvert.SerializeObject(email);
                var result = await producer.ProduceAsync("testTopic",new Message<Null, string>{Value = emailMessage});
                Console.WriteLine($"Sent:{result.Value} Topic: {result.TopicPartitionOffset} \n");
            }
        }
        catch (ProduceException<Null,string> e)
        {
            Console.WriteLine(e.Error.Reason);
        }
    }
}
