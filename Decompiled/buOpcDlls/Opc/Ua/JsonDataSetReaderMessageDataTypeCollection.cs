using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfJsonDataSetReaderMessageDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "JsonDataSetReaderMessageDataType")]
[ComVisible(true)]
public class JsonDataSetReaderMessageDataTypeCollection : List<JsonDataSetReaderMessageDataType>, ICloneable
{
	public JsonDataSetReaderMessageDataTypeCollection()
	{
	}

	public JsonDataSetReaderMessageDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public JsonDataSetReaderMessageDataTypeCollection(IEnumerable<JsonDataSetReaderMessageDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator JsonDataSetReaderMessageDataTypeCollection(JsonDataSetReaderMessageDataType[] values)
	{
		if (values != null)
		{
			return new JsonDataSetReaderMessageDataTypeCollection(values);
		}
		return new JsonDataSetReaderMessageDataTypeCollection();
	}

	public static explicit operator JsonDataSetReaderMessageDataType[](JsonDataSetReaderMessageDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (JsonDataSetReaderMessageDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		JsonDataSetReaderMessageDataTypeCollection jsonDataSetReaderMessageDataTypeCollection = new JsonDataSetReaderMessageDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			jsonDataSetReaderMessageDataTypeCollection.Add((JsonDataSetReaderMessageDataType)Utils.Clone(base[i]));
		}
		return jsonDataSetReaderMessageDataTypeCollection;
	}
}
