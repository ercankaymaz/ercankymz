using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfInterfaceAdminStatus", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "InterfaceAdminStatus")]
[ComVisible(true)]
public class InterfaceAdminStatusCollection : List<InterfaceAdminStatus>, ICloneable
{
	public InterfaceAdminStatusCollection()
	{
	}

	public InterfaceAdminStatusCollection(int capacity)
		: base(capacity)
	{
	}

	public InterfaceAdminStatusCollection(IEnumerable<InterfaceAdminStatus> collection)
		: base(collection)
	{
	}

	public static implicit operator InterfaceAdminStatusCollection(InterfaceAdminStatus[] values)
	{
		if (values != null)
		{
			return new InterfaceAdminStatusCollection(values);
		}
		return new InterfaceAdminStatusCollection();
	}

	public static explicit operator InterfaceAdminStatus[](InterfaceAdminStatusCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (InterfaceAdminStatusCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		InterfaceAdminStatusCollection interfaceAdminStatusCollection = new InterfaceAdminStatusCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			interfaceAdminStatusCollection.Add((InterfaceAdminStatus)Utils.Clone(base[i]));
		}
		return interfaceAdminStatusCollection;
	}
}
