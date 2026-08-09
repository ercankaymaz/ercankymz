using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfInt16", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Int16")]
[ComVisible(true)]
public class Int16Collection : List<short>, ICloneable
{
	public Int16Collection()
	{
	}

	public Int16Collection(int capacity)
		: base(capacity)
	{
	}

	public Int16Collection(IEnumerable<short> collection)
		: base(collection)
	{
	}

	public static Int16Collection ToInt16Collection(short[] values)
	{
		if (values != null)
		{
			return new Int16Collection(values);
		}
		return new Int16Collection();
	}

	public static implicit operator Int16Collection(short[] values)
	{
		return ToInt16Collection(values);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return new Int16Collection(this);
	}
}
