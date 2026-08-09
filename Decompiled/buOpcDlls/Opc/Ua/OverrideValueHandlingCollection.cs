using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfOverrideValueHandling", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "OverrideValueHandling")]
[ComVisible(true)]
public class OverrideValueHandlingCollection : List<OverrideValueHandling>, ICloneable
{
	public OverrideValueHandlingCollection()
	{
	}

	public OverrideValueHandlingCollection(int capacity)
		: base(capacity)
	{
	}

	public OverrideValueHandlingCollection(IEnumerable<OverrideValueHandling> collection)
		: base(collection)
	{
	}

	public static implicit operator OverrideValueHandlingCollection(OverrideValueHandling[] values)
	{
		if (values != null)
		{
			return new OverrideValueHandlingCollection(values);
		}
		return new OverrideValueHandlingCollection();
	}

	public static explicit operator OverrideValueHandling[](OverrideValueHandlingCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (OverrideValueHandlingCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		OverrideValueHandlingCollection overrideValueHandlingCollection = new OverrideValueHandlingCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			overrideValueHandlingCollection.Add((OverrideValueHandling)Utils.Clone(base[i]));
		}
		return overrideValueHandlingCollection;
	}
}
