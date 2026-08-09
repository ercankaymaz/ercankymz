using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfJsonDataSetMessageContentMask", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "JsonDataSetMessageContentMask")]
[ComVisible(true)]
public class JsonDataSetMessageContentMaskCollection : List<JsonDataSetMessageContentMask>, ICloneable
{
	public JsonDataSetMessageContentMaskCollection()
	{
	}

	public JsonDataSetMessageContentMaskCollection(int capacity)
		: base(capacity)
	{
	}

	public JsonDataSetMessageContentMaskCollection(IEnumerable<JsonDataSetMessageContentMask> collection)
		: base(collection)
	{
	}

	public static implicit operator JsonDataSetMessageContentMaskCollection(JsonDataSetMessageContentMask[] values)
	{
		if (values != null)
		{
			return new JsonDataSetMessageContentMaskCollection(values);
		}
		return new JsonDataSetMessageContentMaskCollection();
	}

	public static explicit operator JsonDataSetMessageContentMask[](JsonDataSetMessageContentMaskCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (JsonDataSetMessageContentMaskCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		JsonDataSetMessageContentMaskCollection jsonDataSetMessageContentMaskCollection = new JsonDataSetMessageContentMaskCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			jsonDataSetMessageContentMaskCollection.Add((JsonDataSetMessageContentMask)Utils.Clone(base[i]));
		}
		return jsonDataSetMessageContentMaskCollection;
	}
}
