using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class HistoryReadRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private ExtensionObject m_historyReadDetails;

	private TimestampsToReturn m_timestampsToReturn;

	private bool m_releaseContinuationPoints;

	private HistoryReadValueIdCollection m_nodesToRead;

	[DataMember(Name = "RequestHeader", IsRequired = false, Order = 1)]
	public RequestHeader RequestHeader
	{
		get
		{
			return m_requestHeader;
		}
		set
		{
			m_requestHeader = value;
			if (value == null)
			{
				m_requestHeader = new RequestHeader();
			}
		}
	}

	[DataMember(Name = "HistoryReadDetails", IsRequired = false, Order = 2)]
	public ExtensionObject HistoryReadDetails
	{
		get
		{
			return m_historyReadDetails;
		}
		set
		{
			m_historyReadDetails = value;
		}
	}

	[DataMember(Name = "TimestampsToReturn", IsRequired = false, Order = 3)]
	public TimestampsToReturn TimestampsToReturn
	{
		get
		{
			return m_timestampsToReturn;
		}
		set
		{
			m_timestampsToReturn = value;
		}
	}

	[DataMember(Name = "ReleaseContinuationPoints", IsRequired = false, Order = 4)]
	public bool ReleaseContinuationPoints
	{
		get
		{
			return m_releaseContinuationPoints;
		}
		set
		{
			m_releaseContinuationPoints = value;
		}
	}

	[DataMember(Name = "NodesToRead", IsRequired = false, Order = 5)]
	public HistoryReadValueIdCollection NodesToRead
	{
		get
		{
			return m_nodesToRead;
		}
		set
		{
			m_nodesToRead = value;
			if (value == null)
			{
				m_nodesToRead = new HistoryReadValueIdCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.HistoryReadRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.HistoryReadRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.HistoryReadRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.HistoryReadRequest_Encoding_DefaultJson;

	public HistoryReadRequest()
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
		m_requestHeader = new RequestHeader();
		m_historyReadDetails = null;
		m_timestampsToReturn = TimestampsToReturn.Source;
		m_releaseContinuationPoints = true;
		m_nodesToRead = new HistoryReadValueIdCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteExtensionObject("HistoryReadDetails", HistoryReadDetails);
		encoder.WriteEnumerated("TimestampsToReturn", TimestampsToReturn);
		encoder.WriteBoolean("ReleaseContinuationPoints", ReleaseContinuationPoints);
		encoder.WriteEncodeableArray("NodesToRead", NodesToRead.ToArray(), typeof(HistoryReadValueId));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		HistoryReadDetails = decoder.ReadExtensionObject("HistoryReadDetails");
		TimestampsToReturn = (TimestampsToReturn)(object)decoder.ReadEnumerated("TimestampsToReturn", typeof(TimestampsToReturn));
		ReleaseContinuationPoints = decoder.ReadBoolean("ReleaseContinuationPoints");
		NodesToRead = (HistoryReadValueId[])decoder.ReadEncodeableArray("NodesToRead", typeof(HistoryReadValueId));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is HistoryReadRequest historyReadRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, historyReadRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_historyReadDetails, historyReadRequest.m_historyReadDetails))
		{
			return false;
		}
		if (!Utils.IsEqual(m_timestampsToReturn, historyReadRequest.m_timestampsToReturn))
		{
			return false;
		}
		if (!Utils.IsEqual(m_releaseContinuationPoints, historyReadRequest.m_releaseContinuationPoints))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nodesToRead, historyReadRequest.m_nodesToRead))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (HistoryReadRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		HistoryReadRequest obj = (HistoryReadRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_historyReadDetails = (ExtensionObject)Utils.Clone(m_historyReadDetails);
		obj.m_timestampsToReturn = (TimestampsToReturn)Utils.Clone(m_timestampsToReturn);
		obj.m_releaseContinuationPoints = (bool)Utils.Clone(m_releaseContinuationPoints);
		obj.m_nodesToRead = (HistoryReadValueIdCollection)Utils.Clone(m_nodesToRead);
		return obj;
	}
}
