﻿using StackExchange.Redis;

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
        //var sub = redis.GetSubscriber();

        //first subscribe, until we publish
        //subscribe to a test message
        //sub.Subscribe("test", (channel, message) =>
        //{
        //    Console.WriteLine("Got notification: " + (string)message);
        //});

        //create a publisher
        var pub = redis.GetSubscriber();

        //pubish to test channel a message
        var count = pub.Publish("test", "Hello there I am a test message");
        Console.WriteLine($"Number of listeners for test {count}");


        //pattern match with a message
        //sub.Subscribe(new RedisChannel("a*c", RedisChannel.PatternMode.Pattern), (channel, message) =>
        //{
        //    Console.WriteLine($"Got pattern a*c notification: {message}");
        //});


        count = pub.Publish("a*c", "Hello there I am a a*c message");
        Console.WriteLine($"Number of listeners for a*c {count}");

        pub.Publish("abc", "Hello there I am a abc message");
        pub.Publish("a1234567890c", "Hello there I am a a1234567890c message");
        pub.Publish("ab", "Hello I am a lost message"); //this mesage is never printed


        //Never a pattern match with a message
        //sub.Subscribe(new RedisChannel("*123", RedisChannel.PatternMode.Literal), (channel, message) =>
        //{
        //    Console.WriteLine($"Got Literal pattern *123 notification: {message}");
        //});


        pub.Publish("*123", "Hello there I am a *123 message");
        pub.Publish("a123", "Hello there I am a a123 message"); //message is never received due to literal pattern


        //Auto pattern match with a message
        //sub.Subscribe(new RedisChannel("zyx*", RedisChannel.PatternMode.Auto), (channel, message) =>
        //{
        //    Console.WriteLine($"Got Literal pattern zyx* notification: {message}");
        //});


        pub.Publish("zyxabc", "Hello there I am a zyxabc message");
        pub.Publish("zyx1234", "Hello there I am a zyxabc message");

        //no message being published to it so it will not receive any previous messages
        //sub.Subscribe("test", (channel, message) =>
        //{
        //    Console.WriteLine($"I am a late subscriber Got notification: {message}");
        //});


        //sub.Unsubscribe("a*c");
        //count = pub.Publish("abc", "Hello there I am a abc message"); //no one listening anymore
        Console.WriteLine($"Number of listeners for a*c {count}");

        Console.ReadKey();


    }
}







