using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ReadRawModifiedDetails : HistoryReadDetails
{
	private bool m_isReadModified;

	private DateTime m_startTime;

	private DateTime m_endTime;

	private uint m_numValuesPerNode;

	private bool m_returnBounds;

	[DataMember(Name = "IsReadModified", IsRequired = false, Order = 1)]
	public bool IsReadModified
	{
		get
		{
			return m_isReadModified;
		}
		set
		{
			m_isReadModified = value;
		}
	}

	[DataMember(Name = "StartTime", IsRequired = false, Order = 2)]
	public DateTime StartTime
	{
		get
		{
			return m_startTime;
		}
		set
		{
			m_startTime = value;
		}
	}

	[DataMember(Name = "EndTime", IsRequired = false, Order = 3)]
	public DateTime EndTime
	{
		get
		{
			return m_endTime;
		}
		set
		{
			m_endTime = value;
		}
	}

	[DataMember(Name = "NumValuesPerNode", IsRequired = false, Order = 4)]
	public uint NumValuesPerNode
	{
		get
		{
			return m_numValuesPerNode;
		}
		set
		{
			m_numValuesPerNode = value;
		}
	}

	[DataMember(Name = "ReturnBounds", IsRequired = false, Order = 5)]
	public bool ReturnBounds
	{
		get
		{
			return m_returnBounds;
		}
		set
		{
			m_returnBounds = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.ReadRawModifiedDetails;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.ReadRawModifiedDetails_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.ReadRawModifiedDetails_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.ReadRawModifiedDetails_Encoding_DefaultJson;

	public ReadRawModifiedDetails()
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
		m_isReadModified = true;
		m_startTime = DateTime.MinValue;
		m_endTime = DateTime.MinValue;
		m_numValuesPerNode = 0u;
		m_returnBounds = true;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteBoolean("IsReadModified", IsReadModified);
		encoder.WriteDateTime("StartTime", StartTime);
		encoder.WriteDateTime("EndTime", EndTime);
		encoder.WriteUInt32("NumValuesPerNode", NumValuesPerNode);
		encoder.WriteBoolean("ReturnBounds", ReturnBounds);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		IsReadModified = decoder.ReadBoolean("IsReadModified");
		StartTime = decoder.ReadDateTime("StartTime");
		EndTime = decoder.ReadDateTime("EndTime");
		NumValuesPerNode = decoder.ReadUInt32("NumValuesPerNode");
		ReturnBounds = decoder.ReadBoolean("ReturnBounds");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ReadRawModifiedDetails readRawModifiedDetails))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_isReadModified, readRawModifiedDetails.m_isReadModified))
		{
			return false;
		}
		if (!Utils.IsEqual(m_startTime, readRawModifiedDetails.m_startTime))
		{
			return false;
		}
		if (!Utils.IsEqual(m_endTime, readRawModifiedDetails.m_endTime))
		{
			return false;
		}
		if (!Utils.IsEqual(m_numValuesPerNode, readRawModifiedDetails.m_numValuesPerNode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_returnBounds, readRawModifiedDetails.m_returnBounds))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (ReadRawModifiedDetails)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ReadRawModifiedDetails obj = (ReadRawModifiedDetails)base.MemberwiseClone();
		obj.m_isReadModified = (bool)Utils.Clone(m_isReadModified);
		obj.m_startTime = (DateTime)Utils.Clone(m_startTime);
		obj.m_endTime = (DateTime)Utils.Clone(m_endTime);
		obj.m_numValuesPerNode = (uint)Utils.Clone(m_numValuesPerNode);
		obj.m_returnBounds = (bool)Utils.Clone(m_returnBounds);
		return obj;
	}
}
