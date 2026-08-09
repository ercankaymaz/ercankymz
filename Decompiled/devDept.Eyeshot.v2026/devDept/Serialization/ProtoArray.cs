using ProtoBuf;

namespace devDept.Serialization;

[ProtoContract]
public class ProtoArray<T>
{
	[ProtoMember(1, IsPacked = true)]
	public int[] Dimensions;

	[ProtoMember(2)]
	public T[] Data;
}
