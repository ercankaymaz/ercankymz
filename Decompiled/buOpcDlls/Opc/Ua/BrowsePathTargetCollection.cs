using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfBrowsePathTarget", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "BrowsePathTarget")]
[ComVisible(true)]
public class BrowsePathTargetCollection : List<BrowsePathTarget>, ICloneable
{
	public BrowsePathTargetCollection()
	{
	}

	public BrowsePathTargetCollection(int capacity)
		: base(capacity)
	{
	}

	public BrowsePathTargetCollection(IEnumerable<BrowsePathTarget> collection)
		: base(collection)
	{
	}

	public static implicit operator BrowsePathTargetCollection(BrowsePathTarget[] values)
	{
		if (values != null)
		{
			return new BrowsePathTargetCollection(values);
		}
		return new BrowsePathTargetCollection();
	}

	public static explicit operator BrowsePathTarget[](BrowsePathTargetCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (BrowsePathTargetCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BrowsePathTargetCollection browsePathTargetCollection = new BrowsePathTargetCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			browsePathTargetCollection.Add((BrowsePathTarget)Utils.Clone(base[i]));
		}
		return browsePathTargetCollection;
	}
}
