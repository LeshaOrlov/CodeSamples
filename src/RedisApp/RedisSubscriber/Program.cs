using StackExchange.Redis;

class Program
{
    //option connect
    static ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(
        new ConfigurationOptions
        {
            EndPoints = { "localhost:6379" }
        });

    static async Task Main(string[] args)
    {
        var sub = redis.GetSubscriber();

        //first subscribe, until we publish
        //subscribe to a test message
        sub.Subscribe("test", (channel, message) =>
        {
            Console.WriteLine("Got notification: " + (string)message);
        });

        //pattern match with a message
        sub.Subscribe(new RedisChannel("a*c", RedisChannel.PatternMode.Pattern), (channel, message) =>
        {
            Console.WriteLine($"Got pattern a*c notification: {message}");
        });

        //Never a pattern match with a message
        sub.Subscribe(new RedisChannel("*123", RedisChannel.PatternMode.Literal), (channel, message) =>
        {
            Console.WriteLine($"Got Literal pattern *123 notification: {message}");
        });

        //Auto pattern match with a message
        sub.Subscribe(new RedisChannel("zyx*", RedisChannel.PatternMode.Auto), (channel, message) =>
        {
            Console.WriteLine($"Got Literal pattern zyx* notification: {message}");
        });

        //no message being published to it so it will not receive any previous messages
        sub.Subscribe("test", (channel, message) =>
        {
            Console.WriteLine($"I am a late subscriber Got notification: {message}");
        });

        //sub.Unsubscribe("a*c");

        Console.ReadKey();


    }
}







