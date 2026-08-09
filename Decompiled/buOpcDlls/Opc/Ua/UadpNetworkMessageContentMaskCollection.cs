using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfUadpNetworkMessageContentMask", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "UadpNetworkMessageContentMask")]
[ComVisible(true)]
public class UadpNetworkMessageContentMaskCollection : List<UadpNetworkMessageContentMask>, ICloneable
{
	public UadpNetworkMessageContentMaskCollection()
	{
	}

	public UadpNetworkMessageContentMaskCollection(int capacity)
		: base(capacity)
	{
	}

	public UadpNetworkMessageContentMaskCollection(IEnumerable<UadpNetworkMessageContentMask> collection)
		: base(collection)
	{
	}

	public static implicit operator UadpNetworkMessageContentMaskCollection(UadpNetworkMessageContentMask[] values)
	{
		if (values != null)
		{
			return new UadpNetworkMessageContentMaskCollection(values);
		}
		return new UadpNetworkMessageContentMaskCollection();
	}

	public static explicit operator UadpNetworkMessageContentMask[](UadpNetworkMessageContentMaskCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (UadpNetworkMessageContentMaskCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		UadpNetworkMessageContentMaskCollection uadpNetworkMessageContentMaskCollection = new UadpNetworkMessageContentMaskCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			uadpNetworkMessageContentMaskCollection.Add((UadpNetworkMessageContentMask)Utils.Clone(base[i]));
		}
		return uadpNetworkMessageContentMaskCollection;
	}
}
