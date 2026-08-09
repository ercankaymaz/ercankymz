using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfJsonNetworkMessageContentMask", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "JsonNetworkMessageContentMask")]
[ComVisible(true)]
public class JsonNetworkMessageContentMaskCollection : List<JsonNetworkMessageContentMask>, ICloneable
{
	public JsonNetworkMessageContentMaskCollection()
	{
	}

	public JsonNetworkMessageContentMaskCollection(int capacity)
		: base(capacity)
	{
	}

	public JsonNetworkMessageContentMaskCollection(IEnumerable<JsonNetworkMessageContentMask> collection)
		: base(collection)
	{
	}

	public static implicit operator JsonNetworkMessageContentMaskCollection(JsonNetworkMessageContentMask[] values)
	{
		if (values != null)
		{
			return new JsonNetworkMessageContentMaskCollection(values);
		}
		return new JsonNetworkMessageContentMaskCollection();
	}

	public static explicit operator JsonNetworkMessageContentMask[](JsonNetworkMessageContentMaskCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (JsonNetworkMessageContentMaskCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		JsonNetworkMessageContentMaskCollection jsonNetworkMessageContentMaskCollection = new JsonNetworkMessageContentMaskCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			jsonNetworkMessageContentMaskCollection.Add((JsonNetworkMessageContentMask)Utils.Clone(base[i]));
		}
		return jsonNetworkMessageContentMaskCollection;
	}
}
