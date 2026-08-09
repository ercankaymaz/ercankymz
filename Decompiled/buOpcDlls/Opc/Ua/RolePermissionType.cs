using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class RolePermissionType : IEncodeable, ICloneable, IJsonEncodeable
{
	private NodeId m_roleId;

	private uint m_permissions;

	[DataMember(Name = "RoleId", IsRequired = false, Order = 1)]
	public NodeId RoleId
	{
		get
		{
			return m_roleId;
		}
		set
		{
			m_roleId = value;
		}
	}

	[DataMember(Name = "Permissions", IsRequired = false, Order = 2)]
	public uint Permissions
	{
		get
		{
			return m_permissions;
		}
		set
		{
			m_permissions = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.RolePermissionType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.RolePermissionType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.RolePermissionType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.RolePermissionType_Encoding_DefaultJson;

	public RolePermissionType()
	{
		Initialize();
	}

	[OnDeserializing]
	private void Initialize(StreamingContext context)
	{
		Initialize();
	}

	private void Initialize()
	{
		m_roleId = null;
		m_permissions = 0u;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("RoleId", RoleId);
		encoder.WriteUInt32("Permissions", Permissions);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RoleId = decoder.ReadNodeId("RoleId");
		Permissions = decoder.ReadUInt32("Permissions");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is RolePermissionType rolePermissionType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_roleId, rolePermissionType.m_roleId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_permissions, rolePermissionType.m_permissions))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (RolePermissionType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		RolePermissionType obj = (RolePermissionType)base.MemberwiseClone();
		obj.m_roleId = (NodeId)Utils.Clone(m_roleId);
		obj.m_permissions = (uint)Utils.Clone(m_permissions);
		return obj;
	}
}
