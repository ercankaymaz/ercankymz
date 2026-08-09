using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfWriteValue", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "WriteValue")]
[ComVisible(true)]
public class WriteValueCollection : List<WriteValue>, ICloneable
{
	public WriteValueCollection()
	{
	}

	public WriteValueCollection(int capacity)
		: base(capacity)
	{
	}

	public WriteValueCollection(IEnumerable<WriteValue> collection)
		: base(collection)
	{
	}

	public static implicit operator WriteValueCollection(WriteValue[] values)
	{
		if (values != null)
		{
			return new WriteValueCollection(values);
		}
		return new WriteValueCollection();
	}

	public static explicit operator WriteValue[](WriteValueCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (WriteValueCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		WriteValueCollection writeValueCollection = new WriteValueCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			writeValueCollection.Add((WriteValue)Utils.Clone(base[i]));
		}
		return writeValueCollection;
	}
}
