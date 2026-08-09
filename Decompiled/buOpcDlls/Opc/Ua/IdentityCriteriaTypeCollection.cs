using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfIdentityCriteriaType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "IdentityCriteriaType")]
[ComVisible(true)]
public class IdentityCriteriaTypeCollection : List<IdentityCriteriaType>, ICloneable
{
	public IdentityCriteriaTypeCollection()
	{
	}

	public IdentityCriteriaTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public IdentityCriteriaTypeCollection(IEnumerable<IdentityCriteriaType> collection)
		: base(collection)
	{
	}

	public static implicit operator IdentityCriteriaTypeCollection(IdentityCriteriaType[] values)
	{
		if (values != null)
		{
			return new IdentityCriteriaTypeCollection(values);
		}
		return new IdentityCriteriaTypeCollection();
	}

	public static explicit operator IdentityCriteriaType[](IdentityCriteriaTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (IdentityCriteriaTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		IdentityCriteriaTypeCollection identityCriteriaTypeCollection = new IdentityCriteriaTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			identityCriteriaTypeCollection.Add((IdentityCriteriaType)Utils.Clone(base[i]));
		}
		return identityCriteriaTypeCollection;
	}
}
