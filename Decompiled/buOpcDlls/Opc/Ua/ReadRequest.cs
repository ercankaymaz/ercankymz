using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ReadRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private double m_maxAge;

	private TimestampsToReturn m_timestampsToReturn;

	private ReadValueIdCollection m_nodesToRead;

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

	[DataMember(Name = "MaxAge", IsRequired = false, Order = 2)]
	public double MaxAge
	{
		get
		{
			return m_maxAge;
		}
		set
		{
			m_maxAge = value;
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

	[DataMember(Name = "NodesToRead", IsRequired = false, Order = 4)]
	public ReadValueIdCollection NodesToRead
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
				m_nodesToRead = new ReadValueIdCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ReadRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ReadRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ReadRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ReadRequest_Encoding_DefaultJson;

	public ReadRequest()
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
		m_maxAge = 0.0;
		m_timestampsToReturn = TimestampsToReturn.Source;
		m_nodesToRead = new ReadValueIdCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteDouble("MaxAge", MaxAge);
		encoder.WriteEnumerated("TimestampsToReturn", TimestampsToReturn);
		encoder.WriteEncodeableArray("NodesToRead", NodesToRead.ToArray(), typeof(ReadValueId));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		MaxAge = decoder.ReadDouble("MaxAge");
		TimestampsToReturn = (TimestampsToReturn)(object)decoder.ReadEnumerated("TimestampsToReturn", typeof(TimestampsToReturn));
		NodesToRead = (ReadValueId[])decoder.ReadEncodeableArray("NodesToRead", typeof(ReadValueId));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ReadRequest readRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, readRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_maxAge, readRequest.m_maxAge))
		{
			return false;
		}
		if (!Utils.IsEqual(m_timestampsToReturn, readRequest.m_timestampsToReturn))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nodesToRead, readRequest.m_nodesToRead))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ReadRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ReadRequest obj = (ReadRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_maxAge = (double)Utils.Clone(m_maxAge);
		obj.m_timestampsToReturn = (TimestampsToReturn)Utils.Clone(m_timestampsToReturn);
		obj.m_nodesToRead = (ReadValueIdCollection)Utils.Clone(m_nodesToRead);
		return obj;
	}
}
