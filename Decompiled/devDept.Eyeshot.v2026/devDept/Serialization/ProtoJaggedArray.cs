using ProtoBuf;

namespace devDept.Serialization;

[ProtoContract]
public class ProtoJaggedArray<T>
{
	[ProtoMember(1)]
	public T[] Array;

	public ProtoJaggedArray()
	{
	}

	public ProtoJaggedArray(T[] array)
	{
		Array = array;
	}
}
