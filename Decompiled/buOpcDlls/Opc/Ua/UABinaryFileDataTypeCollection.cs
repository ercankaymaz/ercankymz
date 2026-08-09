using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfUABinaryFileDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "UABinaryFileDataType")]
[ComVisible(true)]
public class UABinaryFileDataTypeCollection : List<UABinaryFileDataType>, ICloneable
{
	public UABinaryFileDataTypeCollection()
	{
	}

	public UABinaryFileDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public UABinaryFileDataTypeCollection(IEnumerable<UABinaryFileDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator UABinaryFileDataTypeCollection(UABinaryFileDataType[] values)
	{
		if (values != null)
		{
			return new UABinaryFileDataTypeCollection(values);
		}
		return new UABinaryFileDataTypeCollection();
	}

	public static explicit operator UABinaryFileDataType[](UABinaryFileDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (UABinaryFileDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		UABinaryFileDataTypeCollection uABinaryFileDataTypeCollection = new UABinaryFileDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			uABinaryFileDataTypeCollection.Add((UABinaryFileDataType)Utils.Clone(base[i]));
		}
		return uABinaryFileDataTypeCollection;
	}
}
