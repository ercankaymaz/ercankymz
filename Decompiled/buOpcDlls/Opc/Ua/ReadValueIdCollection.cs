using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfReadValueId", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ReadValueId")]
[ComVisible(true)]
public class ReadValueIdCollection : List<ReadValueId>, ICloneable
{
	public ReadValueIdCollection()
	{
	}

	public ReadValueIdCollection(int capacity)
		: base(capacity)
	{
	}

	public ReadValueIdCollection(IEnumerable<ReadValueId> collection)
		: base(collection)
	{
	}

	public static implicit operator ReadValueIdCollection(ReadValueId[] values)
	{
		if (values != null)
		{
			return new ReadValueIdCollection(values);
		}
		return new ReadValueIdCollection();
	}

	public static explicit operator ReadValueId[](ReadValueIdCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (ReadValueIdCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ReadValueIdCollection readValueIdCollection = new ReadValueIdCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			readValueIdCollection.Add((ReadValueId)Utils.Clone(base[i]));
		}
		return readValueIdCollection;
	}
}
