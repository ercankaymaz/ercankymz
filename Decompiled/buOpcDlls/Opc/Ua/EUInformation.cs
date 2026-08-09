using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class EUInformation : IEncodeable, ICloneable, IJsonEncodeable
{
	private string m_namespaceUri;

	private int m_unitId;

	private LocalizedText m_displayName;

	private LocalizedText m_description;

	[DataMember(Name = "NamespaceUri", IsRequired = false, Order = 1)]
	public string NamespaceUri
	{
		get
		{
			return m_namespaceUri;
		}
		set
		{
			m_namespaceUri = value;
		}
	}

	[DataMember(Name = "UnitId", IsRequired = false, Order = 2)]
	public int UnitId
	{
		get
		{
			return m_unitId;
		}
		set
		{
			m_unitId = value;
		}
	}

	[DataMember(Name = "DisplayName", IsRequired = false, Order = 3)]
	public LocalizedText DisplayName
	{
		get
		{
			return m_displayName;
		}
		set
		{
			m_displayName = value;
		}
	}

	[DataMember(Name = "Description", IsRequired = false, Order = 4)]
	public LocalizedText Description
	{
		get
		{
			return m_description;
		}
		set
		{
			m_description = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.EUInformation;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.EUInformation_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.EUInformation_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.EUInformation_Encoding_DefaultJson;

	public EUInformation()
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
		m_namespaceUri = null;
		m_unitId = 0;
		m_displayName = null;
		m_description = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("NamespaceUri", NamespaceUri);
		encoder.WriteInt32("UnitId", UnitId);
		encoder.WriteLocalizedText("DisplayName", DisplayName);
		encoder.WriteLocalizedText("Description", Description);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		NamespaceUri = decoder.ReadString("NamespaceUri");
		UnitId = decoder.ReadInt32("UnitId");
		DisplayName = decoder.ReadLocalizedText("DisplayName");
		Description = decoder.ReadLocalizedText("Description");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is EUInformation eUInformation))
		{
			return false;
		}
		if (!Utils.IsEqual(m_namespaceUri, eUInformation.m_namespaceUri))
		{
			return false;
		}
		if (!Utils.IsEqual(m_unitId, eUInformation.m_unitId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_displayName, eUInformation.m_displayName))
		{
			return false;
		}
		if (!Utils.IsEqual(m_description, eUInformation.m_description))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (EUInformation)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		EUInformation obj = (EUInformation)base.MemberwiseClone();
		obj.m_namespaceUri = (string)Utils.Clone(m_namespaceUri);
		obj.m_unitId = (int)Utils.Clone(m_unitId);
		obj.m_displayName = (LocalizedText)Utils.Clone(m_displayName);
		obj.m_description = (LocalizedText)Utils.Clone(m_description);
		return obj;
	}

	public EUInformation(string unitName, string namespaceUri)
	{
		Initialize();
		m_displayName = new LocalizedText(unitName);
		m_description = new LocalizedText(unitName);
		m_namespaceUri = namespaceUri;
	}

	public EUInformation(string shortName, string longName, string namespaceUri)
	{
		Initialize();
		m_displayName = new LocalizedText(shortName);
		m_description = new LocalizedText(longName);
		m_namespaceUri = namespaceUri;
	}
}
