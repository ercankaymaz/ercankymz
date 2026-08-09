using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfKeyValuePair", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "KeyValuePair")]
[ComVisible(true)]
public class KeyValuePairCollection : List<KeyValuePair>, ICloneable
{
	public KeyValuePairCollection()
	{
	}

	public KeyValuePairCollection(int capacity)
		: base(capacity)
	{
	}

	public KeyValuePairCollection(IEnumerable<KeyValuePair> collection)
		: base(collection)
	{
	}

	public static implicit operator KeyValuePairCollection(KeyValuePair[] values)
	{
		if (values != null)
		{
			return new KeyValuePairCollection(values);
		}
		return new KeyValuePairCollection();
	}

	public static explicit operator KeyValuePair[](KeyValuePairCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (KeyValuePairCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		KeyValuePairCollection keyValuePairCollection = new KeyValuePairCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			keyValuePairCollection.Add((KeyValuePair)Utils.Clone(base[i]));
		}
		return keyValuePairCollection;
	}
}
