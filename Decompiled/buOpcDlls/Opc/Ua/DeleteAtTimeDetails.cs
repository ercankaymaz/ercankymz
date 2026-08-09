using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DeleteAtTimeDetails : HistoryUpdateDetails
{
	private DateTimeCollection m_reqTimes;

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

	public override ExpandedNodeId TypeId => DataTypeIds.DeleteAtTimeDetails;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.DeleteAtTimeDetails_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.DeleteAtTimeDetails_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.DeleteAtTimeDetails_Encoding_DefaultJson;

	public DeleteAtTimeDetails()
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
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteDateTimeArray("ReqTimes", ReqTimes);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ReqTimes = decoder.ReadDateTimeArray("ReqTimes");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is DeleteAtTimeDetails deleteAtTimeDetails))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_reqTimes, deleteAtTimeDetails.m_reqTimes))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (DeleteAtTimeDetails)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DeleteAtTimeDetails obj = (DeleteAtTimeDetails)base.MemberwiseClone();
		obj.m_reqTimes = (DateTimeCollection)Utils.Clone(m_reqTimes);
		return obj;
	}
}
