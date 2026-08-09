using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfBrowsePath", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "BrowsePath")]
[ComVisible(true)]
public class BrowsePathCollection : List<BrowsePath>, ICloneable
{
	public BrowsePathCollection()
	{
	}

	public BrowsePathCollection(int capacity)
		: base(capacity)
	{
	}

	public BrowsePathCollection(IEnumerable<BrowsePath> collection)
		: base(collection)
	{
	}

	public static implicit operator BrowsePathCollection(BrowsePath[] values)
	{
		if (values != null)
		{
			return new BrowsePathCollection(values);
		}
		return new BrowsePathCollection();
	}

	public static explicit operator BrowsePath[](BrowsePathCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (BrowsePathCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BrowsePathCollection browsePathCollection = new BrowsePathCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			browsePathCollection.Add((BrowsePath)Utils.Clone(base[i]));
		}
		return browsePathCollection;
	}
}
