using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfGuid", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Guid")]
[ComVisible(true)]
public class UuidCollection : List<Uuid>, ICloneable
{
	public UuidCollection()
	{
	}

	public UuidCollection(IEnumerable<Uuid> collection)
		: base(collection)
	{
	}

	public UuidCollection(int capacity)
		: base(capacity)
	{
	}

	public static UuidCollection ToUuidCollection(Uuid[] values)
	{
		if (values != null)
		{
			return new UuidCollection(values);
		}
		return new UuidCollection();
	}

	public static implicit operator UuidCollection(Uuid[] values)
	{
		return ToUuidCollection(values);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return new UuidCollection(this);
	}
}
