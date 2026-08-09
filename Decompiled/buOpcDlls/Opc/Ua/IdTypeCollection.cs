using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfIdType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "IdType")]
[ComVisible(true)]
public class IdTypeCollection : List<IdType>, ICloneable
{
	public IdTypeCollection()
	{
	}

	public IdTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public IdTypeCollection(IEnumerable<IdType> collection)
		: base(collection)
	{
	}

	public static implicit operator IdTypeCollection(IdType[] values)
	{
		if (values != null)
		{
			return new IdTypeCollection(values);
		}
		return new IdTypeCollection();
	}

	public static explicit operator IdType[](IdTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (IdTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		IdTypeCollection idTypeCollection = new IdTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			idTypeCollection.Add((IdType)Utils.Clone(base[i]));
		}
		return idTypeCollection;
	}
}
