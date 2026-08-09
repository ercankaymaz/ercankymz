using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfArgument", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Argument")]
[ComVisible(true)]
public class ArgumentCollection : List<Argument>, ICloneable
{
	public ArgumentCollection()
	{
	}

	public ArgumentCollection(int capacity)
		: base(capacity)
	{
	}

	public ArgumentCollection(IEnumerable<Argument> collection)
		: base(collection)
	{
	}

	public static implicit operator ArgumentCollection(Argument[] values)
	{
		if (values != null)
		{
			return new ArgumentCollection(values);
		}
		return new ArgumentCollection();
	}

	public static explicit operator Argument[](ArgumentCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (ArgumentCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ArgumentCollection argumentCollection = new ArgumentCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			argumentCollection.Add((Argument)Utils.Clone(base[i]));
		}
		return argumentCollection;
	}
}
