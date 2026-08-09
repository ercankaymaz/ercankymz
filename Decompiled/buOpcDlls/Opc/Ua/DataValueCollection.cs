using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfDataValue", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataValue")]
[ComVisible(true)]
public class DataValueCollection : List<DataValue>, ICloneable
{
	public DataValueCollection()
	{
	}

	public DataValueCollection(IEnumerable<DataValue> collection)
		: base(collection)
	{
	}

	public DataValueCollection(int capacity)
		: base(capacity)
	{
	}

	public static DataValueCollection ToDataValueCollection(DataValue[] values)
	{
		if (values != null)
		{
			return new DataValueCollection(values);
		}
		return new DataValueCollection();
	}

	public static implicit operator DataValueCollection(DataValue[] values)
	{
		return ToDataValueCollection(values);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DataValueCollection dataValueCollection = new DataValueCollection(base.Count);
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			DataValue current = enumerator.Current;
			dataValueCollection.Add((DataValue)Utils.Clone(current));
		}
		return dataValueCollection;
	}
}
