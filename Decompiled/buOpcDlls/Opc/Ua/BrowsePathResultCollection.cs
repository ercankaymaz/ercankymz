using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfBrowsePathResult", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "BrowsePathResult")]
[ComVisible(true)]
public class BrowsePathResultCollection : List<BrowsePathResult>, ICloneable
{
	public BrowsePathResultCollection()
	{
	}

	public BrowsePathResultCollection(int capacity)
		: base(capacity)
	{
	}

	public BrowsePathResultCollection(IEnumerable<BrowsePathResult> collection)
		: base(collection)
	{
	}

	public static implicit operator BrowsePathResultCollection(BrowsePathResult[] values)
	{
		if (values != null)
		{
			return new BrowsePathResultCollection(values);
		}
		return new BrowsePathResultCollection();
	}

	public static explicit operator BrowsePathResult[](BrowsePathResultCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (BrowsePathResultCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BrowsePathResultCollection browsePathResultCollection = new BrowsePathResultCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			browsePathResultCollection.Add((BrowsePathResult)Utils.Clone(base[i]));
		}
		return browsePathResultCollection;
	}
}
