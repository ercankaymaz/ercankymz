using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfString", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "String")]
[ComVisible(true)]
public class StringCollection : List<string>, ICloneable
{
	public StringCollection()
	{
	}

	public StringCollection(int capacity)
		: base(capacity)
	{
	}

	public StringCollection(IEnumerable<string> collection)
		: base(collection)
	{
	}

	public static StringCollection ToStringCollection(string[] values)
	{
		if (values != null)
		{
			return new StringCollection(values);
		}
		return new StringCollection();
	}

	public static implicit operator StringCollection(string[] values)
	{
		return ToStringCollection(values);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return new StringCollection(this);
	}
}
