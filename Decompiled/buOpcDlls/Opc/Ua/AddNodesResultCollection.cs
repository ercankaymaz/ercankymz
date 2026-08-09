using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfAddNodesResult", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "AddNodesResult")]
[ComVisible(true)]
public class AddNodesResultCollection : List<AddNodesResult>, ICloneable
{
	public AddNodesResultCollection()
	{
	}

	public AddNodesResultCollection(int capacity)
		: base(capacity)
	{
	}

	public AddNodesResultCollection(IEnumerable<AddNodesResult> collection)
		: base(collection)
	{
	}

	public static implicit operator AddNodesResultCollection(AddNodesResult[] values)
	{
		if (values != null)
		{
			return new AddNodesResultCollection(values);
		}
		return new AddNodesResultCollection();
	}

	public static explicit operator AddNodesResult[](AddNodesResultCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (AddNodesResultCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		AddNodesResultCollection addNodesResultCollection = new AddNodesResultCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			addNodesResultCollection.Add((AddNodesResult)Utils.Clone(base[i]));
		}
		return addNodesResultCollection;
	}
}
