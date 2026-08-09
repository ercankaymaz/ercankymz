using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfBrowseDescription", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "BrowseDescription")]
[ComVisible(true)]
public class BrowseDescriptionCollection : List<BrowseDescription>, ICloneable
{
	public BrowseDescriptionCollection()
	{
	}

	public BrowseDescriptionCollection(int capacity)
		: base(capacity)
	{
	}

	public BrowseDescriptionCollection(IEnumerable<BrowseDescription> collection)
		: base(collection)
	{
	}

	public static implicit operator BrowseDescriptionCollection(BrowseDescription[] values)
	{
		if (values != null)
		{
			return new BrowseDescriptionCollection(values);
		}
		return new BrowseDescriptionCollection();
	}

	public static explicit operator BrowseDescription[](BrowseDescriptionCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (BrowseDescriptionCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BrowseDescriptionCollection browseDescriptionCollection = new BrowseDescriptionCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			browseDescriptionCollection.Add((BrowseDescription)Utils.Clone(base[i]));
		}
		return browseDescriptionCollection;
	}
}
