using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class EnumValueType : IEncodeable, ICloneable, IJsonEncodeable
{
	private long m_value;

	private LocalizedText m_displayName;

	private LocalizedText m_description;

	[DataMember(Name = "Value", IsRequired = false, Order = 1)]
	public long Value
	{
		get
		{
			return m_value;
		}
		set
		{
			m_value = value;
		}
	}

	[DataMember(Name = "DisplayName", IsRequired = false, Order = 2)]
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

	[DataMember(Name = "Description", IsRequired = false, Order = 3)]
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.EnumValueType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.EnumValueType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.EnumValueType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.EnumValueType_Encoding_DefaultJson;

	public EnumValueType()
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
		m_value = 0L;
		m_displayName = null;
		m_description = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteInt64("Value", Value);
		encoder.WriteLocalizedText("DisplayName", DisplayName);
		encoder.WriteLocalizedText("Description", Description);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Value = decoder.ReadInt64("Value");
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
		if (!(encodeable is EnumValueType enumValueType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_value, enumValueType.m_value))
		{
			return false;
		}
		if (!Utils.IsEqual(m_displayName, enumValueType.m_displayName))
		{
			return false;
		}
		if (!Utils.IsEqual(m_description, enumValueType.m_description))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (EnumValueType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		EnumValueType obj = (EnumValueType)base.MemberwiseClone();
		obj.m_value = (long)Utils.Clone(m_value);
		obj.m_displayName = (LocalizedText)Utils.Clone(m_displayName);
		obj.m_description = (LocalizedText)Utils.Clone(m_description);
		return obj;
	}
}
