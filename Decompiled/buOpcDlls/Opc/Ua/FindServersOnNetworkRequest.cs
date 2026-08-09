using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class FindServersOnNetworkRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private uint m_startingRecordId;

	private uint m_maxRecordsToReturn;

	private StringCollection m_serverCapabilityFilter;

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

	[DataMember(Name = "StartingRecordId", IsRequired = false, Order = 2)]
	public uint StartingRecordId
	{
		get
		{
			return m_startingRecordId;
		}
		set
		{
			m_startingRecordId = value;
		}
	}

	[DataMember(Name = "MaxRecordsToReturn", IsRequired = false, Order = 3)]
	public uint MaxRecordsToReturn
	{
		get
		{
			return m_maxRecordsToReturn;
		}
		set
		{
			m_maxRecordsToReturn = value;
		}
	}

	[DataMember(Name = "ServerCapabilityFilter", IsRequired = false, Order = 4)]
	public StringCollection ServerCapabilityFilter
	{
		get
		{
			return m_serverCapabilityFilter;
		}
		set
		{
			m_serverCapabilityFilter = value;
			if (value == null)
			{
				m_serverCapabilityFilter = new StringCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.FindServersOnNetworkRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.FindServersOnNetworkRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.FindServersOnNetworkRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.FindServersOnNetworkRequest_Encoding_DefaultJson;

	public FindServersOnNetworkRequest()
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
		m_startingRecordId = 0u;
		m_maxRecordsToReturn = 0u;
		m_serverCapabilityFilter = new StringCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteUInt32("StartingRecordId", StartingRecordId);
		encoder.WriteUInt32("MaxRecordsToReturn", MaxRecordsToReturn);
		encoder.WriteStringArray("ServerCapabilityFilter", ServerCapabilityFilter);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		StartingRecordId = decoder.ReadUInt32("StartingRecordId");
		MaxRecordsToReturn = decoder.ReadUInt32("MaxRecordsToReturn");
		ServerCapabilityFilter = decoder.ReadStringArray("ServerCapabilityFilter");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is FindServersOnNetworkRequest findServersOnNetworkRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, findServersOnNetworkRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_startingRecordId, findServersOnNetworkRequest.m_startingRecordId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_maxRecordsToReturn, findServersOnNetworkRequest.m_maxRecordsToReturn))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverCapabilityFilter, findServersOnNetworkRequest.m_serverCapabilityFilter))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (FindServersOnNetworkRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		FindServersOnNetworkRequest obj = (FindServersOnNetworkRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_startingRecordId = (uint)Utils.Clone(m_startingRecordId);
		obj.m_maxRecordsToReturn = (uint)Utils.Clone(m_maxRecordsToReturn);
		obj.m_serverCapabilityFilter = (StringCollection)Utils.Clone(m_serverCapabilityFilter);
		return obj;
	}
}
