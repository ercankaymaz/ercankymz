using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfFieldMetaData", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "FieldMetaData")]
[ComVisible(true)]
public class FieldMetaDataCollection : List<FieldMetaData>, ICloneable
{
	public FieldMetaDataCollection()
	{
	}

	public FieldMetaDataCollection(int capacity)
		: base(capacity)
	{
	}

	public FieldMetaDataCollection(IEnumerable<FieldMetaData> collection)
		: base(collection)
	{
	}

	public static implicit operator FieldMetaDataCollection(FieldMetaData[] values)
	{
		if (values != null)
		{
			return new FieldMetaDataCollection(values);
		}
		return new FieldMetaDataCollection();
	}

	public static explicit operator FieldMetaData[](FieldMetaDataCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (FieldMetaDataCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		FieldMetaDataCollection fieldMetaDataCollection = new FieldMetaDataCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			fieldMetaDataCollection.Add((FieldMetaData)Utils.Clone(base[i]));
		}
		return fieldMetaDataCollection;
	}
}
