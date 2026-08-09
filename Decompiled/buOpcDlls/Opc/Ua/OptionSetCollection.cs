using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfOptionSet", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "OptionSet")]
[ComVisible(true)]
public class OptionSetCollection : List<OptionSet>, ICloneable
{
	public OptionSetCollection()
	{
	}

	public OptionSetCollection(int capacity)
		: base(capacity)
	{
	}

	public OptionSetCollection(IEnumerable<OptionSet> collection)
		: base(collection)
	{
	}

	public static implicit operator OptionSetCollection(OptionSet[] values)
	{
		if (values != null)
		{
			return new OptionSetCollection(values);
		}
		return new OptionSetCollection();
	}

	public static explicit operator OptionSet[](OptionSetCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (OptionSetCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		OptionSetCollection optionSetCollection = new OptionSetCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			optionSetCollection.Add((OptionSet)Utils.Clone(base[i]));
		}
		return optionSetCollection;
	}
}
