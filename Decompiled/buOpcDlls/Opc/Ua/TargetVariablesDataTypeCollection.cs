using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfTargetVariablesDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "TargetVariablesDataType")]
[ComVisible(true)]
public class TargetVariablesDataTypeCollection : List<TargetVariablesDataType>, ICloneable
{
	public TargetVariablesDataTypeCollection()
	{
	}

	public TargetVariablesDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public TargetVariablesDataTypeCollection(IEnumerable<TargetVariablesDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator TargetVariablesDataTypeCollection(TargetVariablesDataType[] values)
	{
		if (values != null)
		{
			return new TargetVariablesDataTypeCollection(values);
		}
		return new TargetVariablesDataTypeCollection();
	}

	public static explicit operator TargetVariablesDataType[](TargetVariablesDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (TargetVariablesDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		TargetVariablesDataTypeCollection targetVariablesDataTypeCollection = new TargetVariablesDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			targetVariablesDataTypeCollection.Add((TargetVariablesDataType)Utils.Clone(base[i]));
		}
		return targetVariablesDataTypeCollection;
	}
}
