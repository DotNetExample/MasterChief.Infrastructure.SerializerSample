using System;
using System.Collections.Generic;
using System.Globalization;
using MasterChief.DotNet.Infrastructure.ProtobufSerializer;
using MasterChief.DotNet.Infrastructure.Serializer;

namespace MasterChief.SerializerSample
{
    internal class Program
    {
        private static void Main()
        {
            SampleSerializer(new JsonSerializer());
            Console.WriteLine(Environment.NewLine);
            SampleSerializer(new ProtocolBufferSerializer());
            Console.ReadLine();
        }

        private static void SampleSerializer(ISerializer serializer)
        {
            #region 单个对象序列化与反序列化

            var person = new Person();
            person.Age = 10;
            person.FirstName = "yan";
            person.LastName = "zhiwei";
            person.Remark = "ISerializer Sample";
            var jsonText = serializer.Serialize(person);
            Console.WriteLine($"{serializer.GetType().Name}-Serialize" + jsonText);


            var getPerson = serializer.Deserialize<Person>(jsonText);
            Console.WriteLine($"{serializer.GetType().Name}-Deserialize" + getPerson);

            #endregion

            #region 集合序列化与反序列化

            var persons = new List<Person>();
            for (var i = 0; i < 10; i++)
                persons.Add(new Person
                {
                    FirstName = "Yan",
                    Age = 20 + i,
                    LastName = "Zhiwei",
                    Remark = DateTime.Now.ToString(CultureInfo.InvariantCulture)
                });
            jsonText = serializer.Serialize(persons);
            Console.WriteLine($"{serializer.GetType().Name}-Serialize" + jsonText);

            var getPersons = serializer.Deserialize<List<Person>>(jsonText);
            foreach (var item in getPersons)
                Console.WriteLine($"{serializer.GetType().Name}-Deserialize" + item);

            #endregion
        }
    }
}