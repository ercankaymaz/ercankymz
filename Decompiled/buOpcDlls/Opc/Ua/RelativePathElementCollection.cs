using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfRelativePathElement", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "RelativePathElement")]
[ComVisible(true)]
public class RelativePathElementCollection : List<RelativePathElement>, ICloneable
{
	public RelativePathElementCollection()
	{
	}

	public RelativePathElementCollection(int capacity)
		: base(capacity)
	{
	}

	public RelativePathElementCollection(IEnumerable<RelativePathElement> collection)
		: base(collection)
	{
	}

	public static implicit operator RelativePathElementCollection(RelativePathElement[] values)
	{
		if (values != null)
		{
			return new RelativePathElementCollection(values);
		}
		return new RelativePathElementCollection();
	}

	public static explicit operator RelativePathElement[](RelativePathElementCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (RelativePathElementCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		RelativePathElementCollection relativePathElementCollection = new RelativePathElementCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			relativePathElementCollection.Add((RelativePathElement)Utils.Clone(base[i]));
		}
		return relativePathElementCollection;
	}
}
