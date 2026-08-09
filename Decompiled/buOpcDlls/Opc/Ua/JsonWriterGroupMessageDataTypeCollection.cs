using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfJsonWriterGroupMessageDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "JsonWriterGroupMessageDataType")]
[ComVisible(true)]
public class JsonWriterGroupMessageDataTypeCollection : List<JsonWriterGroupMessageDataType>, ICloneable
{
	public JsonWriterGroupMessageDataTypeCollection()
	{
	}

	public JsonWriterGroupMessageDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public JsonWriterGroupMessageDataTypeCollection(IEnumerable<JsonWriterGroupMessageDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator JsonWriterGroupMessageDataTypeCollection(JsonWriterGroupMessageDataType[] values)
	{
		if (values != null)
		{
			return new JsonWriterGroupMessageDataTypeCollection(values);
		}
		return new JsonWriterGroupMessageDataTypeCollection();
	}

	public static explicit operator JsonWriterGroupMessageDataType[](JsonWriterGroupMessageDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (JsonWriterGroupMessageDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		JsonWriterGroupMessageDataTypeCollection jsonWriterGroupMessageDataTypeCollection = new JsonWriterGroupMessageDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			jsonWriterGroupMessageDataTypeCollection.Add((JsonWriterGroupMessageDataType)Utils.Clone(base[i]));
		}
		return jsonWriterGroupMessageDataTypeCollection;
	}
}
