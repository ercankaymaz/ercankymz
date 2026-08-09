using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfTimeZoneDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "TimeZoneDataType")]
[ComVisible(true)]
public class TimeZoneDataTypeCollection : List<TimeZoneDataType>, ICloneable
{
	public TimeZoneDataTypeCollection()
	{
	}

	public TimeZoneDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public TimeZoneDataTypeCollection(IEnumerable<TimeZoneDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator TimeZoneDataTypeCollection(TimeZoneDataType[] values)
	{
		if (values != null)
		{
			return new TimeZoneDataTypeCollection(values);
		}
		return new TimeZoneDataTypeCollection();
	}

	public static explicit operator TimeZoneDataType[](TimeZoneDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (TimeZoneDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		TimeZoneDataTypeCollection timeZoneDataTypeCollection = new TimeZoneDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			timeZoneDataTypeCollection.Add((TimeZoneDataType)Utils.Clone(base[i]));
		}
		return timeZoneDataTypeCollection;
	}
}
