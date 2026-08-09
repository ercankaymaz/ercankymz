using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfRedundantServerDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "RedundantServerDataType")]
[ComVisible(true)]
public class RedundantServerDataTypeCollection : List<RedundantServerDataType>, ICloneable
{
	public RedundantServerDataTypeCollection()
	{
	}

	public RedundantServerDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public RedundantServerDataTypeCollection(IEnumerable<RedundantServerDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator RedundantServerDataTypeCollection(RedundantServerDataType[] values)
	{
		if (values != null)
		{
			return new RedundantServerDataTypeCollection(values);
		}
		return new RedundantServerDataTypeCollection();
	}

	public static explicit operator RedundantServerDataType[](RedundantServerDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (RedundantServerDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		RedundantServerDataTypeCollection redundantServerDataTypeCollection = new RedundantServerDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			redundantServerDataTypeCollection.Add((RedundantServerDataType)Utils.Clone(base[i]));
		}
		return redundantServerDataTypeCollection;
	}
}
