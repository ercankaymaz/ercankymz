using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfTrustListDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "TrustListDataType")]
[ComVisible(true)]
public class TrustListDataTypeCollection : List<TrustListDataType>, ICloneable
{
	public TrustListDataTypeCollection()
	{
	}

	public TrustListDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public TrustListDataTypeCollection(IEnumerable<TrustListDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator TrustListDataTypeCollection(TrustListDataType[] values)
	{
		if (values != null)
		{
			return new TrustListDataTypeCollection(values);
		}
		return new TrustListDataTypeCollection();
	}

	public static explicit operator TrustListDataType[](TrustListDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (TrustListDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		TrustListDataTypeCollection trustListDataTypeCollection = new TrustListDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			trustListDataTypeCollection.Add((TrustListDataType)Utils.Clone(base[i]));
		}
		return trustListDataTypeCollection;
	}
}
