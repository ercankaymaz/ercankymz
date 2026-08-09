using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfNamingRuleType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "NamingRuleType")]
[ComVisible(true)]
public class NamingRuleTypeCollection : List<NamingRuleType>, ICloneable
{
	public NamingRuleTypeCollection()
	{
	}

	public NamingRuleTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public NamingRuleTypeCollection(IEnumerable<NamingRuleType> collection)
		: base(collection)
	{
	}

	public static implicit operator NamingRuleTypeCollection(NamingRuleType[] values)
	{
		if (values != null)
		{
			return new NamingRuleTypeCollection(values);
		}
		return new NamingRuleTypeCollection();
	}

	public static explicit operator NamingRuleType[](NamingRuleTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (NamingRuleTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		NamingRuleTypeCollection namingRuleTypeCollection = new NamingRuleTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			namingRuleTypeCollection.Add((NamingRuleType)Utils.Clone(base[i]));
		}
		return namingRuleTypeCollection;
	}
}
