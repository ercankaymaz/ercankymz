using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class TimeZoneDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private short m_offset;

	private bool m_daylightSavingInOffset;

	[DataMember(Name = "Offset", IsRequired = false, Order = 1)]
	public short Offset
	{
		get
		{
			return m_offset;
		}
		set
		{
			m_offset = value;
		}
	}

	[DataMember(Name = "DaylightSavingInOffset", IsRequired = false, Order = 2)]
	public bool DaylightSavingInOffset
	{
		get
		{
			return m_daylightSavingInOffset;
		}
		set
		{
			m_daylightSavingInOffset = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.TimeZoneDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.TimeZoneDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.TimeZoneDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.TimeZoneDataType_Encoding_DefaultJson;

	public TimeZoneDataType()
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
		m_offset = 0;
		m_daylightSavingInOffset = true;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteInt16("Offset", Offset);
		encoder.WriteBoolean("DaylightSavingInOffset", DaylightSavingInOffset);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Offset = decoder.ReadInt16("Offset");
		DaylightSavingInOffset = decoder.ReadBoolean("DaylightSavingInOffset");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is TimeZoneDataType timeZoneDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_offset, timeZoneDataType.m_offset))
		{
			return false;
		}
		if (!Utils.IsEqual(m_daylightSavingInOffset, timeZoneDataType.m_daylightSavingInOffset))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (TimeZoneDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		TimeZoneDataType obj = (TimeZoneDataType)base.MemberwiseClone();
		obj.m_offset = (short)Utils.Clone(m_offset);
		obj.m_daylightSavingInOffset = (bool)Utils.Clone(m_daylightSavingInOffset);
		return obj;
	}
}
