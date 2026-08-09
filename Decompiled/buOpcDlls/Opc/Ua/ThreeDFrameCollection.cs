using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfThreeDFrame", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ThreeDFrame")]
[ComVisible(true)]
public class ThreeDFrameCollection : List<ThreeDFrame>, ICloneable
{
	public ThreeDFrameCollection()
	{
	}

	public ThreeDFrameCollection(int capacity)
		: base(capacity)
	{
	}

	public ThreeDFrameCollection(IEnumerable<ThreeDFrame> collection)
		: base(collection)
	{
	}

	public static implicit operator ThreeDFrameCollection(ThreeDFrame[] values)
	{
		if (values != null)
		{
			return new ThreeDFrameCollection(values);
		}
		return new ThreeDFrameCollection();
	}

	public static explicit operator ThreeDFrame[](ThreeDFrameCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (ThreeDFrameCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ThreeDFrameCollection threeDFrameCollection = new ThreeDFrameCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			threeDFrameCollection.Add((ThreeDFrame)Utils.Clone(base[i]));
		}
		return threeDFrameCollection;
	}
}
