using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfBrowseResult", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "BrowseResult")]
[ComVisible(true)]
public class BrowseResultCollection : List<BrowseResult>, ICloneable
{
	public BrowseResultCollection()
	{
	}

	public BrowseResultCollection(int capacity)
		: base(capacity)
	{
	}

	public BrowseResultCollection(IEnumerable<BrowseResult> collection)
		: base(collection)
	{
	}

	public static implicit operator BrowseResultCollection(BrowseResult[] values)
	{
		if (values != null)
		{
			return new BrowseResultCollection(values);
		}
		return new BrowseResultCollection();
	}

	public static explicit operator BrowseResult[](BrowseResultCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (BrowseResultCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BrowseResultCollection browseResultCollection = new BrowseResultCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			browseResultCollection.Add((BrowseResult)Utils.Clone(base[i]));
		}
		return browseResultCollection;
	}
}
