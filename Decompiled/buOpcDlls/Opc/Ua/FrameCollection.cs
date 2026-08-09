using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfFrame", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Frame")]
[ComVisible(true)]
public class FrameCollection : List<Frame>, ICloneable
{
	public FrameCollection()
	{
	}

	public FrameCollection(int capacity)
		: base(capacity)
	{
	}

	public FrameCollection(IEnumerable<Frame> collection)
		: base(collection)
	{
	}

	public static implicit operator FrameCollection(Frame[] values)
	{
		if (values != null)
		{
			return new FrameCollection(values);
		}
		return new FrameCollection();
	}

	public static explicit operator Frame[](FrameCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (FrameCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		FrameCollection frameCollection = new FrameCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			frameCollection.Add((Frame)Utils.Clone(base[i]));
		}
		return frameCollection;
	}
}
