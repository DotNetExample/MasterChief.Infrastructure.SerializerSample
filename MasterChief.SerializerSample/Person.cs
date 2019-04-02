using System;
using ProtoBuf;

namespace MasterChief.SerializerSample
{
    [Serializable]
    [ProtoContract]
    public sealed class Person
    {
        [ProtoMember(1)] public string FirstName { get; set; }

        [ProtoMember(2)] public string LastName { get; set; }

        [ProtoMember(3)] public int Age { get; set; }

        [ProtoMember(4)] public string Remark { get; set; }


        public override string ToString()
        {
            return $"FirstName:{FirstName},LastName:{LastName},Age:{Age},Remark:{Remark}";
        }
    }
}