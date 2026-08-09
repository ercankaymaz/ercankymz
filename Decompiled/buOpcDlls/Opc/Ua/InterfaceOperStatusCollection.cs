using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfInterfaceOperStatus", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "InterfaceOperStatus")]
[ComVisible(true)]
public class InterfaceOperStatusCollection : List<InterfaceOperStatus>, ICloneable
{
	public InterfaceOperStatusCollection()
	{
	}

	public InterfaceOperStatusCollection(int capacity)
		: base(capacity)
	{
	}

	public InterfaceOperStatusCollection(IEnumerable<InterfaceOperStatus> collection)
		: base(collection)
	{
	}

	public static implicit operator InterfaceOperStatusCollection(InterfaceOperStatus[] values)
	{
		if (values != null)
		{
			return new InterfaceOperStatusCollection(values);
		}
		return new InterfaceOperStatusCollection();
	}

	public static explicit operator InterfaceOperStatus[](InterfaceOperStatusCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (InterfaceOperStatusCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		InterfaceOperStatusCollection interfaceOperStatusCollection = new InterfaceOperStatusCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			interfaceOperStatusCollection.Add((InterfaceOperStatus)Utils.Clone(base[i]));
		}
		return interfaceOperStatusCollection;
	}
}
