using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua.Gds;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/GDS/Types.xsd")]
[ComVisible(true)]
public class ApplicationRecordDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private NodeId m_applicationId;

	private string m_applicationUri;

	private ApplicationType m_applicationType;

	private LocalizedTextCollection m_applicationNames;

	private string m_productUri;

	private StringCollection m_discoveryUrls;

	private StringCollection m_serverCapabilities;

	[DataMember(Name = "ApplicationId", IsRequired = false, Order = 1)]
	public NodeId ApplicationId
	{
		get
		{
			return m_applicationId;
		}
		set
		{
			m_applicationId = value;
		}
	}

	[DataMember(Name = "ApplicationUri", IsRequired = false, Order = 2)]
	public string ApplicationUri
	{
		get
		{
			return m_applicationUri;
		}
		set
		{
			m_applicationUri = value;
		}
	}

	[DataMember(Name = "ApplicationType", IsRequired = false, Order = 3)]
	public ApplicationType ApplicationType
	{
		get
		{
			return m_applicationType;
		}
		set
		{
			m_applicationType = value;
		}
	}

	[DataMember(Name = "ApplicationNames", IsRequired = false, Order = 4)]
	public LocalizedTextCollection ApplicationNames
	{
		get
		{
			return m_applicationNames;
		}
		set
		{
			m_applicationNames = value;
			if (value == null)
			{
				m_applicationNames = new LocalizedTextCollection();
			}
		}
	}

	[DataMember(Name = "ProductUri", IsRequired = false, Order = 5)]
	public string ProductUri
	{
		get
		{
			return m_productUri;
		}
		set
		{
			m_productUri = value;
		}
	}

	[DataMember(Name = "DiscoveryUrls", IsRequired = false, Order = 6)]
	public StringCollection DiscoveryUrls
	{
		get
		{
			return m_discoveryUrls;
		}
		set
		{
			m_discoveryUrls = value;
			if (value == null)
			{
				m_discoveryUrls = new StringCollection();
			}
		}
	}

	[DataMember(Name = "ServerCapabilities", IsRequired = false, Order = 7)]
	public StringCollection ServerCapabilities
	{
		get
		{
			return m_serverCapabilities;
		}
		set
		{
			m_serverCapabilities = value;
			if (value == null)
			{
				m_serverCapabilities = new StringCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ApplicationRecordDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ApplicationRecordDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ApplicationRecordDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ApplicationRecordDataType_Encoding_DefaultJson;

	public ApplicationRecordDataType()
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
		m_applicationId = null;
		m_applicationUri = null;
		m_applicationType = ApplicationType.Server;
		m_applicationNames = new LocalizedTextCollection();
		m_productUri = null;
		m_discoveryUrls = new StringCollection();
		m_serverCapabilities = new StringCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/GDS/Types.xsd");
		encoder.WriteNodeId("ApplicationId", ApplicationId);
		encoder.WriteString("ApplicationUri", ApplicationUri);
		encoder.WriteEnumerated("ApplicationType", ApplicationType);
		encoder.WriteLocalizedTextArray("ApplicationNames", ApplicationNames);
		encoder.WriteString("ProductUri", ProductUri);
		encoder.WriteStringArray("DiscoveryUrls", DiscoveryUrls);
		encoder.WriteStringArray("ServerCapabilities", ServerCapabilities);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/GDS/Types.xsd");
		ApplicationId = decoder.ReadNodeId("ApplicationId");
		ApplicationUri = decoder.ReadString("ApplicationUri");
		ApplicationType = (ApplicationType)(object)decoder.ReadEnumerated("ApplicationType", typeof(ApplicationType));
		ApplicationNames = decoder.ReadLocalizedTextArray("ApplicationNames");
		ProductUri = decoder.ReadString("ProductUri");
		DiscoveryUrls = decoder.ReadStringArray("DiscoveryUrls");
		ServerCapabilities = decoder.ReadStringArray("ServerCapabilities");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ApplicationRecordDataType applicationRecordDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_applicationId, applicationRecordDataType.m_applicationId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_applicationUri, applicationRecordDataType.m_applicationUri))
		{
			return false;
		}
		if (!Utils.IsEqual(m_applicationType, applicationRecordDataType.m_applicationType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_applicationNames, applicationRecordDataType.m_applicationNames))
		{
			return false;
		}
		if (!Utils.IsEqual(m_productUri, applicationRecordDataType.m_productUri))
		{
			return false;
		}
		if (!Utils.IsEqual(m_discoveryUrls, applicationRecordDataType.m_discoveryUrls))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverCapabilities, applicationRecordDataType.m_serverCapabilities))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ApplicationRecordDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ApplicationRecordDataType obj = (ApplicationRecordDataType)base.MemberwiseClone();
		obj.m_applicationId = (NodeId)Utils.Clone(m_applicationId);
		obj.m_applicationUri = (string)Utils.Clone(m_applicationUri);
		obj.m_applicationType = (ApplicationType)Utils.Clone(m_applicationType);
		obj.m_applicationNames = (LocalizedTextCollection)Utils.Clone(m_applicationNames);
		obj.m_productUri = (string)Utils.Clone(m_productUri);
		obj.m_discoveryUrls = (StringCollection)Utils.Clone(m_discoveryUrls);
		obj.m_serverCapabilities = (StringCollection)Utils.Clone(m_serverCapabilities);
		return obj;
	}
}
