using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfUadpDataSetMessageContentMask", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "UadpDataSetMessageContentMask")]
[ComVisible(true)]
public class UadpDataSetMessageContentMaskCollection : List<UadpDataSetMessageContentMask>, ICloneable
{
	public UadpDataSetMessageContentMaskCollection()
	{
	}

	public UadpDataSetMessageContentMaskCollection(int capacity)
		: base(capacity)
	{
	}

	public UadpDataSetMessageContentMaskCollection(IEnumerable<UadpDataSetMessageContentMask> collection)
		: base(collection)
	{
	}

	public static implicit operator UadpDataSetMessageContentMaskCollection(UadpDataSetMessageContentMask[] values)
	{
		if (values != null)
		{
			return new UadpDataSetMessageContentMaskCollection(values);
		}
		return new UadpDataSetMessageContentMaskCollection();
	}

	public static explicit operator UadpDataSetMessageContentMask[](UadpDataSetMessageContentMaskCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (UadpDataSetMessageContentMaskCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		UadpDataSetMessageContentMaskCollection uadpDataSetMessageContentMaskCollection = new UadpDataSetMessageContentMaskCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			uadpDataSetMessageContentMaskCollection.Add((UadpDataSetMessageContentMask)Utils.Clone(base[i]));
		}
		return uadpDataSetMessageContentMaskCollection;
	}
}
