using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfDateTime", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DateTime")]
[ComVisible(true)]
public class DateTimeCollection : List<DateTime>, ICloneable
{
	public DateTimeCollection()
	{
	}

	public DateTimeCollection(int capacity)
		: base(capacity)
	{
	}

	public DateTimeCollection(IEnumerable<DateTime> collection)
		: base(collection)
	{
	}

	public static DateTimeCollection ToDateTimeCollection(DateTime[] values)
	{
		if (values != null)
		{
			return new DateTimeCollection(values);
		}
		return new DateTimeCollection();
	}

	public static implicit operator DateTimeCollection(DateTime[] values)
	{
		return ToDateTimeCollection(values);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return new DateTimeCollection(this);
	}
}
