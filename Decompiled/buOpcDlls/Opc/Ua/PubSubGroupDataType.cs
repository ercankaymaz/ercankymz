using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class PubSubGroupDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private string m_name;

	private bool m_enabled;

	private MessageSecurityMode m_securityMode;

	private string m_securityGroupId;

	private EndpointDescriptionCollection m_securityKeyServices;

	private uint m_maxNetworkMessageSize;

	private KeyValuePairCollection m_groupProperties;

	[DataMember(Name = "Name", IsRequired = false, Order = 1)]
	public string Name
	{
		get
		{
			return m_name;
		}
		set
		{
			m_name = value;
		}
	}

	[DataMember(Name = "Enabled", IsRequired = false, Order = 2)]
	public bool Enabled
	{
		get
		{
			return m_enabled;
		}
		set
		{
			m_enabled = value;
		}
	}

	[DataMember(Name = "SecurityMode", IsRequired = false, Order = 3)]
	public MessageSecurityMode SecurityMode
	{
		get
		{
			return m_securityMode;
		}
		set
		{
			m_securityMode = value;
		}
	}

	[DataMember(Name = "SecurityGroupId", IsRequired = false, Order = 4)]
	public string SecurityGroupId
	{
		get
		{
			return m_securityGroupId;
		}
		set
		{
			m_securityGroupId = value;
		}
	}

	[DataMember(Name = "SecurityKeyServices", IsRequired = false, Order = 5)]
	public EndpointDescriptionCollection SecurityKeyServices
	{
		get
		{
			return m_securityKeyServices;
		}
		set
		{
			m_securityKeyServices = value;
			if (value == null)
			{
				m_securityKeyServices = new EndpointDescriptionCollection();
			}
		}
	}

	[DataMember(Name = "MaxNetworkMessageSize", IsRequired = false, Order = 6)]
	public uint MaxNetworkMessageSize
	{
		get
		{
			return m_maxNetworkMessageSize;
		}
		set
		{
			m_maxNetworkMessageSize = value;
		}
	}

	[DataMember(Name = "GroupProperties", IsRequired = false, Order = 7)]
	public KeyValuePairCollection GroupProperties
	{
		get
		{
			return m_groupProperties;
		}
		set
		{
			m_groupProperties = value;
			if (value == null)
			{
				m_groupProperties = new KeyValuePairCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.PubSubGroupDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.PubSubGroupDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.PubSubGroupDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.PubSubGroupDataType_Encoding_DefaultJson;

	public PubSubGroupDataType()
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
		m_name = null;
		m_enabled = true;
		m_securityMode = MessageSecurityMode.Invalid;
		m_securityGroupId = null;
		m_securityKeyServices = new EndpointDescriptionCollection();
		m_maxNetworkMessageSize = 0u;
		m_groupProperties = new KeyValuePairCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("Name", Name);
		encoder.WriteBoolean("Enabled", Enabled);
		encoder.WriteEnumerated("SecurityMode", SecurityMode);
		encoder.WriteString("SecurityGroupId", SecurityGroupId);
		encoder.WriteEncodeableArray("SecurityKeyServices", SecurityKeyServices.ToArray(), typeof(EndpointDescription));
		encoder.WriteUInt32("MaxNetworkMessageSize", MaxNetworkMessageSize);
		encoder.WriteEncodeableArray("GroupProperties", GroupProperties.ToArray(), typeof(KeyValuePair));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Name = decoder.ReadString("Name");
		Enabled = decoder.ReadBoolean("Enabled");
		SecurityMode = (MessageSecurityMode)(object)decoder.ReadEnumerated("SecurityMode", typeof(MessageSecurityMode));
		SecurityGroupId = decoder.ReadString("SecurityGroupId");
		SecurityKeyServices = (EndpointDescription[])decoder.ReadEncodeableArray("SecurityKeyServices", typeof(EndpointDescription));
		MaxNetworkMessageSize = decoder.ReadUInt32("MaxNetworkMessageSize");
		GroupProperties = (KeyValuePair[])decoder.ReadEncodeableArray("GroupProperties", typeof(KeyValuePair));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is PubSubGroupDataType pubSubGroupDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_name, pubSubGroupDataType.m_name))
		{
			return false;
		}
		if (!Utils.IsEqual(m_enabled, pubSubGroupDataType.m_enabled))
		{
			return false;
		}
		if (!Utils.IsEqual(m_securityMode, pubSubGroupDataType.m_securityMode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_securityGroupId, pubSubGroupDataType.m_securityGroupId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_securityKeyServices, pubSubGroupDataType.m_securityKeyServices))
		{
			return false;
		}
		if (!Utils.IsEqual(m_maxNetworkMessageSize, pubSubGroupDataType.m_maxNetworkMessageSize))
		{
			return false;
		}
		if (!Utils.IsEqual(m_groupProperties, pubSubGroupDataType.m_groupProperties))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (PubSubGroupDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		PubSubGroupDataType obj = (PubSubGroupDataType)base.MemberwiseClone();
		obj.m_name = (string)Utils.Clone(m_name);
		obj.m_enabled = (bool)Utils.Clone(m_enabled);
		obj.m_securityMode = (MessageSecurityMode)Utils.Clone(m_securityMode);
		obj.m_securityGroupId = (string)Utils.Clone(m_securityGroupId);
		obj.m_securityKeyServices = (EndpointDescriptionCollection)Utils.Clone(m_securityKeyServices);
		obj.m_maxNetworkMessageSize = (uint)Utils.Clone(m_maxNetworkMessageSize);
		obj.m_groupProperties = (KeyValuePairCollection)Utils.Clone(m_groupProperties);
		return obj;
	}
}
