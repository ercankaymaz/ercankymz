using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfStatusCode", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "StatusCode")]
[ComVisible(true)]
public class StatusCodeCollection : List<StatusCode>, ICloneable
{
	public StatusCodeCollection()
	{
	}

	public StatusCodeCollection(IEnumerable<StatusCode> collection)
		: base(collection)
	{
	}

	public StatusCodeCollection(int capacity)
		: base(capacity)
	{
	}

	public static StatusCodeCollection ToStatusCodeCollection(StatusCode[] values)
	{
		if (values != null)
		{
			return new StatusCodeCollection(values);
		}
		return new StatusCodeCollection();
	}

	public static implicit operator StatusCodeCollection(StatusCode[] values)
	{
		return ToStatusCodeCollection(values);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return new StatusCodeCollection(this);
	}
}
