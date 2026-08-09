using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ApplicationDescription : IEncodeable, ICloneable, IJsonEncodeable
{
	private string m_applicationUri;

	private string m_productUri;

	private LocalizedText m_applicationName;

	private ApplicationType m_applicationType;

	private string m_gatewayServerUri;

	private string m_discoveryProfileUri;

	private StringCollection m_discoveryUrls;

	[DataMember(Name = "ApplicationUri", IsRequired = false, Order = 1)]
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

	[DataMember(Name = "ProductUri", IsRequired = false, Order = 2)]
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

	[DataMember(Name = "ApplicationName", IsRequired = false, Order = 3)]
	public LocalizedText ApplicationName
	{
		get
		{
			return m_applicationName;
		}
		set
		{
			m_applicationName = value;
		}
	}

	[DataMember(Name = "ApplicationType", IsRequired = false, Order = 4)]
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

	[DataMember(Name = "GatewayServerUri", IsRequired = false, Order = 5)]
	public string GatewayServerUri
	{
		get
		{
			return m_gatewayServerUri;
		}
		set
		{
			m_gatewayServerUri = value;
		}
	}

	[DataMember(Name = "DiscoveryProfileUri", IsRequired = false, Order = 6)]
	public string DiscoveryProfileUri
	{
		get
		{
			return m_discoveryProfileUri;
		}
		set
		{
			m_discoveryProfileUri = value;
		}
	}

	[DataMember(Name = "DiscoveryUrls", IsRequired = false, Order = 7)]
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.ApplicationDescription;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ApplicationDescription_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ApplicationDescription_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ApplicationDescription_Encoding_DefaultJson;

	public ApplicationDescription()
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
		m_applicationUri = null;
		m_productUri = null;
		m_applicationName = null;
		m_applicationType = ApplicationType.Server;
		m_gatewayServerUri = null;
		m_discoveryProfileUri = null;
		m_discoveryUrls = new StringCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("ApplicationUri", ApplicationUri);
		encoder.WriteString("ProductUri", ProductUri);
		encoder.WriteLocalizedText("ApplicationName", ApplicationName);
		encoder.WriteEnumerated("ApplicationType", ApplicationType);
		encoder.WriteString("GatewayServerUri", GatewayServerUri);
		encoder.WriteString("DiscoveryProfileUri", DiscoveryProfileUri);
		encoder.WriteStringArray("DiscoveryUrls", DiscoveryUrls);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ApplicationUri = decoder.ReadString("ApplicationUri");
		ProductUri = decoder.ReadString("ProductUri");
		ApplicationName = decoder.ReadLocalizedText("ApplicationName");
		ApplicationType = (ApplicationType)(object)decoder.ReadEnumerated("ApplicationType", typeof(ApplicationType));
		GatewayServerUri = decoder.ReadString("GatewayServerUri");
		DiscoveryProfileUri = decoder.ReadString("DiscoveryProfileUri");
		DiscoveryUrls = decoder.ReadStringArray("DiscoveryUrls");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ApplicationDescription applicationDescription))
		{
			return false;
		}
		if (!Utils.IsEqual(m_applicationUri, applicationDescription.m_applicationUri))
		{
			return false;
		}
		if (!Utils.IsEqual(m_productUri, applicationDescription.m_productUri))
		{
			return false;
		}
		if (!Utils.IsEqual(m_applicationName, applicationDescription.m_applicationName))
		{
			return false;
		}
		if (!Utils.IsEqual(m_applicationType, applicationDescription.m_applicationType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_gatewayServerUri, applicationDescription.m_gatewayServerUri))
		{
			return false;
		}
		if (!Utils.IsEqual(m_discoveryProfileUri, applicationDescription.m_discoveryProfileUri))
		{
			return false;
		}
		if (!Utils.IsEqual(m_discoveryUrls, applicationDescription.m_discoveryUrls))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ApplicationDescription)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ApplicationDescription obj = (ApplicationDescription)base.MemberwiseClone();
		obj.m_applicationUri = (string)Utils.Clone(m_applicationUri);
		obj.m_productUri = (string)Utils.Clone(m_productUri);
		obj.m_applicationName = (LocalizedText)Utils.Clone(m_applicationName);
		obj.m_applicationType = (ApplicationType)Utils.Clone(m_applicationType);
		obj.m_gatewayServerUri = (string)Utils.Clone(m_gatewayServerUri);
		obj.m_discoveryProfileUri = (string)Utils.Clone(m_discoveryProfileUri);
		obj.m_discoveryUrls = (StringCollection)Utils.Clone(m_discoveryUrls);
		return obj;
	}
}
