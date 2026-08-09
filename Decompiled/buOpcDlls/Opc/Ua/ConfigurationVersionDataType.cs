using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ConfigurationVersionDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private uint m_majorVersion;

	private uint m_minorVersion;

	[DataMember(Name = "MajorVersion", IsRequired = false, Order = 1)]
	public uint MajorVersion
	{
		get
		{
			return m_majorVersion;
		}
		set
		{
			m_majorVersion = value;
		}
	}

	[DataMember(Name = "MinorVersion", IsRequired = false, Order = 2)]
	public uint MinorVersion
	{
		get
		{
			return m_minorVersion;
		}
		set
		{
			m_minorVersion = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ConfigurationVersionDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ConfigurationVersionDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ConfigurationVersionDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ConfigurationVersionDataType_Encoding_DefaultJson;

	public ConfigurationVersionDataType()
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
		m_majorVersion = 0u;
		m_minorVersion = 0u;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteUInt32("MajorVersion", MajorVersion);
		encoder.WriteUInt32("MinorVersion", MinorVersion);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		MajorVersion = decoder.ReadUInt32("MajorVersion");
		MinorVersion = decoder.ReadUInt32("MinorVersion");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ConfigurationVersionDataType configurationVersionDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_majorVersion, configurationVersionDataType.m_majorVersion))
		{
			return false;
		}
		if (!Utils.IsEqual(m_minorVersion, configurationVersionDataType.m_minorVersion))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ConfigurationVersionDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ConfigurationVersionDataType obj = (ConfigurationVersionDataType)base.MemberwiseClone();
		obj.m_majorVersion = (uint)Utils.Clone(m_majorVersion);
		obj.m_minorVersion = (uint)Utils.Clone(m_minorVersion);
		return obj;
	}
}
