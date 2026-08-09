using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class SessionlessInvokeResponseType : IEncodeable, ICloneable, IJsonEncodeable
{
	private StringCollection m_namespaceUris;

	private StringCollection m_serverUris;

	private uint m_serviceId;

	[DataMember(Name = "NamespaceUris", IsRequired = false, Order = 1)]
	public StringCollection NamespaceUris
	{
		get
		{
			return m_namespaceUris;
		}
		set
		{
			m_namespaceUris = value;
			if (value == null)
			{
				m_namespaceUris = new StringCollection();
			}
		}
	}

	[DataMember(Name = "ServerUris", IsRequired = false, Order = 2)]
	public StringCollection ServerUris
	{
		get
		{
			return m_serverUris;
		}
		set
		{
			m_serverUris = value;
			if (value == null)
			{
				m_serverUris = new StringCollection();
			}
		}
	}

	[DataMember(Name = "ServiceId", IsRequired = false, Order = 3)]
	public uint ServiceId
	{
		get
		{
			return m_serviceId;
		}
		set
		{
			m_serviceId = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.SessionlessInvokeResponseType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.SessionlessInvokeResponseType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.SessionlessInvokeResponseType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.SessionlessInvokeResponseType_Encoding_DefaultJson;

	public SessionlessInvokeResponseType()
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
		m_namespaceUris = new StringCollection();
		m_serverUris = new StringCollection();
		m_serviceId = 0u;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteStringArray("NamespaceUris", NamespaceUris);
		encoder.WriteStringArray("ServerUris", ServerUris);
		encoder.WriteUInt32("ServiceId", ServiceId);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		NamespaceUris = decoder.ReadStringArray("NamespaceUris");
		ServerUris = decoder.ReadStringArray("ServerUris");
		ServiceId = decoder.ReadUInt32("ServiceId");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is SessionlessInvokeResponseType sessionlessInvokeResponseType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_namespaceUris, sessionlessInvokeResponseType.m_namespaceUris))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverUris, sessionlessInvokeResponseType.m_serverUris))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serviceId, sessionlessInvokeResponseType.m_serviceId))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (SessionlessInvokeResponseType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SessionlessInvokeResponseType obj = (SessionlessInvokeResponseType)base.MemberwiseClone();
		obj.m_namespaceUris = (StringCollection)Utils.Clone(m_namespaceUris);
		obj.m_serverUris = (StringCollection)Utils.Clone(m_serverUris);
		obj.m_serviceId = (uint)Utils.Clone(m_serviceId);
		return obj;
	}
}
