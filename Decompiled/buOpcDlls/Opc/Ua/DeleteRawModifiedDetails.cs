using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DeleteRawModifiedDetails : HistoryUpdateDetails
{
	private bool m_isDeleteModified;

	private DateTime m_startTime;

	private DateTime m_endTime;

	[DataMember(Name = "IsDeleteModified", IsRequired = false, Order = 1)]
	public bool IsDeleteModified
	{
		get
		{
			return m_isDeleteModified;
		}
		set
		{
			m_isDeleteModified = value;
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

	public override ExpandedNodeId TypeId => DataTypeIds.DeleteRawModifiedDetails;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.DeleteRawModifiedDetails_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.DeleteRawModifiedDetails_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.DeleteRawModifiedDetails_Encoding_DefaultJson;

	public DeleteRawModifiedDetails()
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
		m_isDeleteModified = true;
		m_startTime = DateTime.MinValue;
		m_endTime = DateTime.MinValue;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteBoolean("IsDeleteModified", IsDeleteModified);
		encoder.WriteDateTime("StartTime", StartTime);
		encoder.WriteDateTime("EndTime", EndTime);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		IsDeleteModified = decoder.ReadBoolean("IsDeleteModified");
		StartTime = decoder.ReadDateTime("StartTime");
		EndTime = decoder.ReadDateTime("EndTime");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is DeleteRawModifiedDetails deleteRawModifiedDetails))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_isDeleteModified, deleteRawModifiedDetails.m_isDeleteModified))
		{
			return false;
		}
		if (!Utils.IsEqual(m_startTime, deleteRawModifiedDetails.m_startTime))
		{
			return false;
		}
		if (!Utils.IsEqual(m_endTime, deleteRawModifiedDetails.m_endTime))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (DeleteRawModifiedDetails)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DeleteRawModifiedDetails obj = (DeleteRawModifiedDetails)base.MemberwiseClone();
		obj.m_isDeleteModified = (bool)Utils.Clone(m_isDeleteModified);
		obj.m_startTime = (DateTime)Utils.Clone(m_startTime);
		obj.m_endTime = (DateTime)Utils.Clone(m_endTime);
		return obj;
	}
}
