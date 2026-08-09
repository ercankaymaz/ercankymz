using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DeleteEventDetails : HistoryUpdateDetails
{
	private ByteStringCollection m_eventIds;

	[DataMember(Name = "EventIds", IsRequired = false, Order = 1)]
	public ByteStringCollection EventIds
	{
		get
		{
			return m_eventIds;
		}
		set
		{
			m_eventIds = value;
			if (value == null)
			{
				m_eventIds = new ByteStringCollection();
			}
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.DeleteEventDetails;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.DeleteEventDetails_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.DeleteEventDetails_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.DeleteEventDetails_Encoding_DefaultJson;

	public DeleteEventDetails()
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
		m_eventIds = new ByteStringCollection();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteByteStringArray("EventIds", EventIds);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		EventIds = decoder.ReadByteStringArray("EventIds");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is DeleteEventDetails deleteEventDetails))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_eventIds, deleteEventDetails.m_eventIds))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (DeleteEventDetails)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DeleteEventDetails obj = (DeleteEventDetails)base.MemberwiseClone();
		obj.m_eventIds = (ByteStringCollection)Utils.Clone(m_eventIds);
		return obj;
	}
}
