using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfAliasNameDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "AliasNameDataType")]
[ComVisible(true)]
public class AliasNameDataTypeCollection : List<AliasNameDataType>, ICloneable
{
	public AliasNameDataTypeCollection()
	{
	}

	public AliasNameDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public AliasNameDataTypeCollection(IEnumerable<AliasNameDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator AliasNameDataTypeCollection(AliasNameDataType[] values)
	{
		if (values != null)
		{
			return new AliasNameDataTypeCollection(values);
		}
		return new AliasNameDataTypeCollection();
	}

	public static explicit operator AliasNameDataType[](AliasNameDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (AliasNameDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		AliasNameDataTypeCollection aliasNameDataTypeCollection = new AliasNameDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			aliasNameDataTypeCollection.Add((AliasNameDataType)Utils.Clone(base[i]));
		}
		return aliasNameDataTypeCollection;
	}
}
