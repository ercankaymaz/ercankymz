using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfByteString", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ByteString")]
[ComVisible(true)]
public class ByteStringCollection : List<byte[]>, ICloneable
{
	public ByteStringCollection()
	{
	}

	public ByteStringCollection(int capacity)
		: base(capacity)
	{
	}

	public ByteStringCollection(IEnumerable<byte[]> collection)
		: base(collection)
	{
	}

	public static ByteStringCollection ToByteStringCollection(byte[][] values)
	{
		if (values != null)
		{
			return new ByteStringCollection(values);
		}
		return new ByteStringCollection();
	}

	public static implicit operator ByteStringCollection(byte[][] values)
	{
		return ToByteStringCollection(values);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ByteStringCollection byteStringCollection = new ByteStringCollection(base.Count);
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			byte[] current = enumerator.Current;
			byteStringCollection.Add((byte[])Utils.Clone(current));
		}
		return byteStringCollection;
	}
}
