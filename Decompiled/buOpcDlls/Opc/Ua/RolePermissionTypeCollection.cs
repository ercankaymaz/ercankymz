using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfRolePermissionType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "RolePermissionType")]
[ComVisible(true)]
public class RolePermissionTypeCollection : List<RolePermissionType>, ICloneable
{
	public RolePermissionTypeCollection()
	{
	}

	public RolePermissionTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public RolePermissionTypeCollection(IEnumerable<RolePermissionType> collection)
		: base(collection)
	{
	}

	public static implicit operator RolePermissionTypeCollection(RolePermissionType[] values)
	{
		if (values != null)
		{
			return new RolePermissionTypeCollection(values);
		}
		return new RolePermissionTypeCollection();
	}

	public static explicit operator RolePermissionType[](RolePermissionTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (RolePermissionTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		RolePermissionTypeCollection rolePermissionTypeCollection = new RolePermissionTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			rolePermissionTypeCollection.Add((RolePermissionType)Utils.Clone(base[i]));
		}
		return rolePermissionTypeCollection;
	}
}
