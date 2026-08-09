using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfDataTypeSchemaHeader", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataTypeSchemaHeader")]
[ComVisible(true)]
public class DataTypeSchemaHeaderCollection : List<DataTypeSchemaHeader>, ICloneable
{
	public DataTypeSchemaHeaderCollection()
	{
	}

	public DataTypeSchemaHeaderCollection(int capacity)
		: base(capacity)
	{
	}

	public DataTypeSchemaHeaderCollection(IEnumerable<DataTypeSchemaHeader> collection)
		: base(collection)
	{
	}

	public static implicit operator DataTypeSchemaHeaderCollection(DataTypeSchemaHeader[] values)
	{
		if (values != null)
		{
			return new DataTypeSchemaHeaderCollection(values);
		}
		return new DataTypeSchemaHeaderCollection();
	}

	public static explicit operator DataTypeSchemaHeader[](DataTypeSchemaHeaderCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (DataTypeSchemaHeaderCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DataTypeSchemaHeaderCollection dataTypeSchemaHeaderCollection = new DataTypeSchemaHeaderCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			dataTypeSchemaHeaderCollection.Add((DataTypeSchemaHeader)Utils.Clone(base[i]));
		}
		return dataTypeSchemaHeaderCollection;
	}
}
