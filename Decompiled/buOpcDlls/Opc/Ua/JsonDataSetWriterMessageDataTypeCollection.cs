using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfJsonDataSetWriterMessageDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "JsonDataSetWriterMessageDataType")]
[ComVisible(true)]
public class JsonDataSetWriterMessageDataTypeCollection : List<JsonDataSetWriterMessageDataType>, ICloneable
{
	public JsonDataSetWriterMessageDataTypeCollection()
	{
	}

	public JsonDataSetWriterMessageDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public JsonDataSetWriterMessageDataTypeCollection(IEnumerable<JsonDataSetWriterMessageDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator JsonDataSetWriterMessageDataTypeCollection(JsonDataSetWriterMessageDataType[] values)
	{
		if (values != null)
		{
			return new JsonDataSetWriterMessageDataTypeCollection(values);
		}
		return new JsonDataSetWriterMessageDataTypeCollection();
	}

	public static explicit operator JsonDataSetWriterMessageDataType[](JsonDataSetWriterMessageDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (JsonDataSetWriterMessageDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		JsonDataSetWriterMessageDataTypeCollection jsonDataSetWriterMessageDataTypeCollection = new JsonDataSetWriterMessageDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			jsonDataSetWriterMessageDataTypeCollection.Add((JsonDataSetWriterMessageDataType)Utils.Clone(base[i]));
		}
		return jsonDataSetWriterMessageDataTypeCollection;
	}
}
