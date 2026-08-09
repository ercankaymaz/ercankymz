using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfIdentityMappingRuleType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "IdentityMappingRuleType")]
[ComVisible(true)]
public class IdentityMappingRuleTypeCollection : List<IdentityMappingRuleType>, ICloneable
{
	public IdentityMappingRuleTypeCollection()
	{
	}

	public IdentityMappingRuleTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public IdentityMappingRuleTypeCollection(IEnumerable<IdentityMappingRuleType> collection)
		: base(collection)
	{
	}

	public static implicit operator IdentityMappingRuleTypeCollection(IdentityMappingRuleType[] values)
	{
		if (values != null)
		{
			return new IdentityMappingRuleTypeCollection(values);
		}
		return new IdentityMappingRuleTypeCollection();
	}

	public static explicit operator IdentityMappingRuleType[](IdentityMappingRuleTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (IdentityMappingRuleTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		IdentityMappingRuleTypeCollection identityMappingRuleTypeCollection = new IdentityMappingRuleTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			identityMappingRuleTypeCollection.Add((IdentityMappingRuleType)Utils.Clone(base[i]));
		}
		return identityMappingRuleTypeCollection;
	}
}
