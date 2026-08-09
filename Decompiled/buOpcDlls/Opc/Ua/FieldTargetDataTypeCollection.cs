using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfFieldTargetDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "FieldTargetDataType")]
[ComVisible(true)]
public class FieldTargetDataTypeCollection : List<FieldTargetDataType>, ICloneable
{
	public FieldTargetDataTypeCollection()
	{
	}

	public FieldTargetDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public FieldTargetDataTypeCollection(IEnumerable<FieldTargetDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator FieldTargetDataTypeCollection(FieldTargetDataType[] values)
	{
		if (values != null)
		{
			return new FieldTargetDataTypeCollection(values);
		}
		return new FieldTargetDataTypeCollection();
	}

	public static explicit operator FieldTargetDataType[](FieldTargetDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (FieldTargetDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		FieldTargetDataTypeCollection fieldTargetDataTypeCollection = new FieldTargetDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			fieldTargetDataTypeCollection.Add((FieldTargetDataType)Utils.Clone(base[i]));
		}
		return fieldTargetDataTypeCollection;
	}
}
