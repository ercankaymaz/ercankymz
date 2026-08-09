using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfQueryDataSet", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "QueryDataSet")]
[ComVisible(true)]
public class QueryDataSetCollection : List<QueryDataSet>, ICloneable
{
	public QueryDataSetCollection()
	{
	}

	public QueryDataSetCollection(int capacity)
		: base(capacity)
	{
	}

	public QueryDataSetCollection(IEnumerable<QueryDataSet> collection)
		: base(collection)
	{
	}

	public static implicit operator QueryDataSetCollection(QueryDataSet[] values)
	{
		if (values != null)
		{
			return new QueryDataSetCollection(values);
		}
		return new QueryDataSetCollection();
	}

	public static explicit operator QueryDataSet[](QueryDataSetCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (QueryDataSetCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		QueryDataSetCollection queryDataSetCollection = new QueryDataSetCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			queryDataSetCollection.Add((QueryDataSet)Utils.Clone(base[i]));
		}
		return queryDataSetCollection;
	}
}
