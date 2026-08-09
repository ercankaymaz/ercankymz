using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfQueryDataDescription", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "QueryDataDescription")]
[ComVisible(true)]
public class QueryDataDescriptionCollection : List<QueryDataDescription>, ICloneable
{
	public QueryDataDescriptionCollection()
	{
	}

	public QueryDataDescriptionCollection(int capacity)
		: base(capacity)
	{
	}

	public QueryDataDescriptionCollection(IEnumerable<QueryDataDescription> collection)
		: base(collection)
	{
	}

	public static implicit operator QueryDataDescriptionCollection(QueryDataDescription[] values)
	{
		if (values != null)
		{
			return new QueryDataDescriptionCollection(values);
		}
		return new QueryDataDescriptionCollection();
	}

	public static explicit operator QueryDataDescription[](QueryDataDescriptionCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (QueryDataDescriptionCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		QueryDataDescriptionCollection queryDataDescriptionCollection = new QueryDataDescriptionCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			queryDataDescriptionCollection.Add((QueryDataDescription)Utils.Clone(base[i]));
		}
		return queryDataDescriptionCollection;
	}
}
