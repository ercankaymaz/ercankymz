using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class BuildInfo : IEncodeable, ICloneable, IJsonEncodeable
{
	private string m_productUri;

	private string m_manufacturerName;

	private string m_productName;

	private string m_softwareVersion;

	private string m_buildNumber;

	private DateTime m_buildDate;

	[DataMember(Name = "ProductUri", IsRequired = false, Order = 1)]
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

	[DataMember(Name = "ManufacturerName", IsRequired = false, Order = 2)]
	public string ManufacturerName
	{
		get
		{
			return m_manufacturerName;
		}
		set
		{
			m_manufacturerName = value;
		}
	}

	[DataMember(Name = "ProductName", IsRequired = false, Order = 3)]
	public string ProductName
	{
		get
		{
			return m_productName;
		}
		set
		{
			m_productName = value;
		}
	}

	[DataMember(Name = "SoftwareVersion", IsRequired = false, Order = 4)]
	public string SoftwareVersion
	{
		get
		{
			return m_softwareVersion;
		}
		set
		{
			m_softwareVersion = value;
		}
	}

	[DataMember(Name = "BuildNumber", IsRequired = false, Order = 5)]
	public string BuildNumber
	{
		get
		{
			return m_buildNumber;
		}
		set
		{
			m_buildNumber = value;
		}
	}

	[DataMember(Name = "BuildDate", IsRequired = false, Order = 6)]
	public DateTime BuildDate
	{
		get
		{
			return m_buildDate;
		}
		set
		{
			m_buildDate = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.BuildInfo;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.BuildInfo_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.BuildInfo_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.BuildInfo_Encoding_DefaultJson;

	public BuildInfo()
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
		m_productUri = null;
		m_manufacturerName = null;
		m_productName = null;
		m_softwareVersion = null;
		m_buildNumber = null;
		m_buildDate = DateTime.MinValue;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("ProductUri", ProductUri);
		encoder.WriteString("ManufacturerName", ManufacturerName);
		encoder.WriteString("ProductName", ProductName);
		encoder.WriteString("SoftwareVersion", SoftwareVersion);
		encoder.WriteString("BuildNumber", BuildNumber);
		encoder.WriteDateTime("BuildDate", BuildDate);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ProductUri = decoder.ReadString("ProductUri");
		ManufacturerName = decoder.ReadString("ManufacturerName");
		ProductName = decoder.ReadString("ProductName");
		SoftwareVersion = decoder.ReadString("SoftwareVersion");
		BuildNumber = decoder.ReadString("BuildNumber");
		BuildDate = decoder.ReadDateTime("BuildDate");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is BuildInfo buildInfo))
		{
			return false;
		}
		if (!Utils.IsEqual(m_productUri, buildInfo.m_productUri))
		{
			return false;
		}
		if (!Utils.IsEqual(m_manufacturerName, buildInfo.m_manufacturerName))
		{
			return false;
		}
		if (!Utils.IsEqual(m_productName, buildInfo.m_productName))
		{
			return false;
		}
		if (!Utils.IsEqual(m_softwareVersion, buildInfo.m_softwareVersion))
		{
			return false;
		}
		if (!Utils.IsEqual(m_buildNumber, buildInfo.m_buildNumber))
		{
			return false;
		}
		if (!Utils.IsEqual(m_buildDate, buildInfo.m_buildDate))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (BuildInfo)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BuildInfo obj = (BuildInfo)base.MemberwiseClone();
		obj.m_productUri = (string)Utils.Clone(m_productUri);
		obj.m_manufacturerName = (string)Utils.Clone(m_manufacturerName);
		obj.m_productName = (string)Utils.Clone(m_productName);
		obj.m_softwareVersion = (string)Utils.Clone(m_softwareVersion);
		obj.m_buildNumber = (string)Utils.Clone(m_buildNumber);
		obj.m_buildDate = (DateTime)Utils.Clone(m_buildDate);
		return obj;
	}
}
