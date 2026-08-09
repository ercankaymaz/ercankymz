using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfInt32", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Int32")]
[ComVisible(true)]
public class Int32Collection : List<int>, ICloneable
{
	public Int32Collection()
	{
	}

	public Int32Collection(int capacity)
		: base(capacity)
	{
	}

	public Int32Collection(IEnumerable<int> collection)
		: base(collection)
	{
	}

	public static Int32Collection ToInt32Collection(int[] values)
	{
		if (values != null)
		{
			return new Int32Collection(values);
		}
		return new Int32Collection();
	}

	public static implicit operator Int32Collection(int[] values)
	{
		return ToInt32Collection(values);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return new Int32Collection(this);
	}
}
