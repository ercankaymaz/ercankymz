using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfReferenceDescription", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ReferenceDescription")]
[ComVisible(true)]
public class ReferenceDescriptionCollection : List<ReferenceDescription>, ICloneable
{
	public ReferenceDescriptionCollection()
	{
	}

	public ReferenceDescriptionCollection(int capacity)
		: base(capacity)
	{
	}

	public ReferenceDescriptionCollection(IEnumerable<ReferenceDescription> collection)
		: base(collection)
	{
	}

	public static implicit operator ReferenceDescriptionCollection(ReferenceDescription[] values)
	{
		if (values != null)
		{
			return new ReferenceDescriptionCollection(values);
		}
		return new ReferenceDescriptionCollection();
	}

	public static explicit operator ReferenceDescription[](ReferenceDescriptionCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (ReferenceDescriptionCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ReferenceDescriptionCollection referenceDescriptionCollection = new ReferenceDescriptionCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			referenceDescriptionCollection.Add((ReferenceDescription)Utils.Clone(base[i]));
		}
		return referenceDescriptionCollection;
	}
}
