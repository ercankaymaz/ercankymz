using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class SubscribedDataSetMirrorDataType : SubscribedDataSetDataType
{
	private string m_parentNodeName;

	private RolePermissionTypeCollection m_rolePermissions;

	[DataMember(Name = "ParentNodeName", IsRequired = false, Order = 1)]
	public string ParentNodeName
	{
		get
		{
			return m_parentNodeName;
		}
		set
		{
			m_parentNodeName = value;
		}
	}

	[DataMember(Name = "RolePermissions", IsRequired = false, Order = 2)]
	public RolePermissionTypeCollection RolePermissions
	{
		get
		{
			return m_rolePermissions;
		}
		set
		{
			m_rolePermissions = value;
			if (value == null)
			{
				m_rolePermissions = new RolePermissionTypeCollection();
			}
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.SubscribedDataSetMirrorDataType;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.SubscribedDataSetMirrorDataType_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.SubscribedDataSetMirrorDataType_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.SubscribedDataSetMirrorDataType_Encoding_DefaultJson;

	public SubscribedDataSetMirrorDataType()
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
		m_parentNodeName = null;
		m_rolePermissions = new RolePermissionTypeCollection();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("ParentNodeName", ParentNodeName);
		encoder.WriteEncodeableArray("RolePermissions", RolePermissions.ToArray(), typeof(RolePermissionType));
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ParentNodeName = decoder.ReadString("ParentNodeName");
		RolePermissions = (RolePermissionType[])decoder.ReadEncodeableArray("RolePermissions", typeof(RolePermissionType));
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is SubscribedDataSetMirrorDataType subscribedDataSetMirrorDataType))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_parentNodeName, subscribedDataSetMirrorDataType.m_parentNodeName))
		{
			return false;
		}
		if (!Utils.IsEqual(m_rolePermissions, subscribedDataSetMirrorDataType.m_rolePermissions))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (SubscribedDataSetMirrorDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SubscribedDataSetMirrorDataType obj = (SubscribedDataSetMirrorDataType)base.MemberwiseClone();
		obj.m_parentNodeName = (string)Utils.Clone(m_parentNodeName);
		obj.m_rolePermissions = (RolePermissionTypeCollection)Utils.Clone(m_rolePermissions);
		return obj;
	}
}
