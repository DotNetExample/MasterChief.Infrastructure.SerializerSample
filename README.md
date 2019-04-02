# 序列化与序列化简单示例
> 项目说明
>
> 1. 通过实现接口ISerializer可以扩展其他方式序列化与反序列化；
>
> 2. 目前实现基于Newtonsoft.Json和ProtoBuf两种方式；
>
> 3. 项目源码：[MasterChief.DotNet.Infrastructure.Serializer](https://github.com/YanZhiwei/MasterChief/tree/master/MasterChief.DotNet.Infrastructure.Serializer)
>
> 4. Nuget：Install-Package MasterChief.DotNet.Infrastructure.Serialize  
>
>    ​                        Install-Package MasterChief.DotNet.Infrastructure.ProtobufSerializer
>
> 5. 欢迎Star，欢迎PR；
>
>    

#### 如何使用

```C#
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
```