using System;
using ProtoBuf;

namespace MasterChief.DotNet.Infrastructure.SerializerSample
{
    [Serializable]
    [ProtoContract]
    public sealed class Person
    {
        /// <summary>
        /// 使用protobuf的时候，默认构造函数必须有，反序列化会报 No parameterless constructor found for x 错误
        /// </summary>
        public Person()
        {
        }
        [ProtoMember(1)]
        public string FirstName { get; set; }
        [ProtoMember(2)]
        public string LastName { get; set; }
        [ProtoMember(3)]
        public int Age { get; set; }
        [ProtoMember(4)]
        public string Remark { get; set; }


        public override string ToString()
        {
            return $"FirstName:{FirstName},LastName:{LastName},Age:{Age},Remark:{Remark}";
        }
    }
}