using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfFloat", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Float")]
[ComVisible(true)]
public class FloatCollection : List<float>, ICloneable
{
	public FloatCollection()
	{
	}

	public FloatCollection(int capacity)
		: base(capacity)
	{
	}

	public FloatCollection(IEnumerable<float> collection)
		: base(collection)
	{
	}

	public static FloatCollection ToFloatCollection(float[] values)
	{
		if (values != null)
		{
			return new FloatCollection(values);
		}
		return new FloatCollection();
	}

	public static implicit operator FloatCollection(float[] values)
	{
		return ToFloatCollection(values);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return new FloatCollection(this);
	}
}
