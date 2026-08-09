using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class SessionlessInvokeRequestType : IEncodeable, ICloneable, IJsonEncodeable
{
	private uint m_urisVersion;

	private StringCollection m_namespaceUris;

	private StringCollection m_serverUris;

	private StringCollection m_localeIds;

	private uint m_serviceId;

	[DataMember(Name = "UrisVersion", IsRequired = false, Order = 1)]
	public uint UrisVersion
	{
		get
		{
			return m_urisVersion;
		}
		set
		{
			m_urisVersion = value;
		}
	}

	[DataMember(Name = "NamespaceUris", IsRequired = false, Order = 2)]
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

	[DataMember(Name = "ServerUris", IsRequired = false, Order = 3)]
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

	[DataMember(Name = "LocaleIds", IsRequired = false, Order = 4)]
	public StringCollection LocaleIds
	{
		get
		{
			return m_localeIds;
		}
		set
		{
			m_localeIds = value;
			if (value == null)
			{
				m_localeIds = new StringCollection();
			}
		}
	}

	[DataMember(Name = "ServiceId", IsRequired = false, Order = 5)]
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.SessionlessInvokeRequestType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.SessionlessInvokeRequestType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.SessionlessInvokeRequestType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.SessionlessInvokeRequestType_Encoding_DefaultJson;

	public SessionlessInvokeRequestType()
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
		m_urisVersion = 0u;
		m_namespaceUris = new StringCollection();
		m_serverUris = new StringCollection();
		m_localeIds = new StringCollection();
		m_serviceId = 0u;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteUInt32("UrisVersion", UrisVersion);
		encoder.WriteStringArray("NamespaceUris", NamespaceUris);
		encoder.WriteStringArray("ServerUris", ServerUris);
		encoder.WriteStringArray("LocaleIds", LocaleIds);
		encoder.WriteUInt32("ServiceId", ServiceId);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		UrisVersion = decoder.ReadUInt32("UrisVersion");
		NamespaceUris = decoder.ReadStringArray("NamespaceUris");
		ServerUris = decoder.ReadStringArray("ServerUris");
		LocaleIds = decoder.ReadStringArray("LocaleIds");
		ServiceId = decoder.ReadUInt32("ServiceId");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is SessionlessInvokeRequestType sessionlessInvokeRequestType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_urisVersion, sessionlessInvokeRequestType.m_urisVersion))
		{
			return false;
		}
		if (!Utils.IsEqual(m_namespaceUris, sessionlessInvokeRequestType.m_namespaceUris))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverUris, sessionlessInvokeRequestType.m_serverUris))
		{
			return false;
		}
		if (!Utils.IsEqual(m_localeIds, sessionlessInvokeRequestType.m_localeIds))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serviceId, sessionlessInvokeRequestType.m_serviceId))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (SessionlessInvokeRequestType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SessionlessInvokeRequestType obj = (SessionlessInvokeRequestType)base.MemberwiseClone();
		obj.m_urisVersion = (uint)Utils.Clone(m_urisVersion);
		obj.m_namespaceUris = (StringCollection)Utils.Clone(m_namespaceUris);
		obj.m_serverUris = (StringCollection)Utils.Clone(m_serverUris);
		obj.m_localeIds = (StringCollection)Utils.Clone(m_localeIds);
		obj.m_serviceId = (uint)Utils.Clone(m_serviceId);
		return obj;
	}
}
