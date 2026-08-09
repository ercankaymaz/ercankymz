using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfDouble", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Double")]
[ComVisible(true)]
public class DoubleCollection : List<double>, ICloneable
{
	public DoubleCollection()
	{
	}

	public DoubleCollection(int capacity)
		: base(capacity)
	{
	}

	public DoubleCollection(IEnumerable<double> collection)
		: base(collection)
	{
	}

	public static DoubleCollection ToDoubleCollection(double[] values)
	{
		if (values != null)
		{
			return new DoubleCollection(values);
		}
		return new DoubleCollection();
	}

	public static implicit operator DoubleCollection(double[] values)
	{
		return ToDoubleCollection(values);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return new DoubleCollection(this);
	}
}
