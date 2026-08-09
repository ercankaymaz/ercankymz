using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfByte", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Byte")]
[ComVisible(true)]
public class ByteCollection : List<byte>, ICloneable
{
	public ByteCollection()
	{
	}

	public ByteCollection(int capacity)
		: base(capacity)
	{
	}

	public ByteCollection(IEnumerable<byte> collection)
		: base(collection)
	{
	}

	public static ByteCollection ToByteCollection(byte[] values)
	{
		if (values != null)
		{
			return new ByteCollection(values);
		}
		return new ByteCollection();
	}

	public static implicit operator ByteCollection(byte[] values)
	{
		return ToByteCollection(values);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return new ByteCollection(this);
	}
}
