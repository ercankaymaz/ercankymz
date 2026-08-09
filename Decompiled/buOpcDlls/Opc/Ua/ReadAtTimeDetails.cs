using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ReadAtTimeDetails : HistoryReadDetails
{
	private DateTimeCollection m_reqTimes;

	private bool m_useSimpleBounds;

	[DataMember(Name = "ReqTimes", IsRequired = false, Order = 1)]
	public DateTimeCollection ReqTimes
	{
		get
		{
			return m_reqTimes;
		}
		set
		{
			m_reqTimes = value;
			if (value == null)
			{
				m_reqTimes = new DateTimeCollection();
			}
		}
	}

	[DataMember(Name = "UseSimpleBounds", IsRequired = false, Order = 2)]
	public bool UseSimpleBounds
	{
		get
		{
			return m_useSimpleBounds;
		}
		set
		{
			m_useSimpleBounds = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.ReadAtTimeDetails;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.ReadAtTimeDetails_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.ReadAtTimeDetails_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.ReadAtTimeDetails_Encoding_DefaultJson;

	public ReadAtTimeDetails()
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
		m_reqTimes = new DateTimeCollection();
		m_useSimpleBounds = true;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteDateTimeArray("ReqTimes", ReqTimes);
		encoder.WriteBoolean("UseSimpleBounds", UseSimpleBounds);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ReqTimes = decoder.ReadDateTimeArray("ReqTimes");
		UseSimpleBounds = decoder.ReadBoolean("UseSimpleBounds");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ReadAtTimeDetails readAtTimeDetails))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_reqTimes, readAtTimeDetails.m_reqTimes))
		{
			return false;
		}
		if (!Utils.IsEqual(m_useSimpleBounds, readAtTimeDetails.m_useSimpleBounds))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (ReadAtTimeDetails)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ReadAtTimeDetails obj = (ReadAtTimeDetails)base.MemberwiseClone();
		obj.m_reqTimes = (DateTimeCollection)Utils.Clone(m_reqTimes);
		obj.m_useSimpleBounds = (bool)Utils.Clone(m_useSimpleBounds);
		return obj;
	}
}
