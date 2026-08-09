using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class FindServersOnNetworkResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
	private ResponseHeader m_responseHeader;

	private DateTime m_lastCounterResetTime;

	private ServerOnNetworkCollection m_servers;

	[DataMember(Name = "ResponseHeader", IsRequired = false, Order = 1)]
	public ResponseHeader ResponseHeader
	{
		get
		{
			return m_responseHeader;
		}
		set
		{
			m_responseHeader = value;
			if (value == null)
			{
				m_responseHeader = new ResponseHeader();
			}
		}
	}

	[DataMember(Name = "LastCounterResetTime", IsRequired = false, Order = 2)]
	public DateTime LastCounterResetTime
	{
		get
		{
			return m_lastCounterResetTime;
		}
		set
		{
			m_lastCounterResetTime = value;
		}
	}

	[DataMember(Name = "Servers", IsRequired = false, Order = 3)]
	public ServerOnNetworkCollection Servers
	{
		get
		{
			return m_servers;
		}
		set
		{
			m_servers = value;
			if (value == null)
			{
				m_servers = new ServerOnNetworkCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.FindServersOnNetworkResponse;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.FindServersOnNetworkResponse_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.FindServersOnNetworkResponse_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.FindServersOnNetworkResponse_Encoding_DefaultJson;

	public FindServersOnNetworkResponse()
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
		m_responseHeader = new ResponseHeader();
		m_lastCounterResetTime = DateTime.MinValue;
		m_servers = new ServerOnNetworkCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("ResponseHeader", ResponseHeader, typeof(ResponseHeader));
		encoder.WriteDateTime("LastCounterResetTime", LastCounterResetTime);
		encoder.WriteEncodeableArray("Servers", Servers.ToArray(), typeof(ServerOnNetwork));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ResponseHeader = (ResponseHeader)decoder.ReadEncodeable("ResponseHeader", typeof(ResponseHeader));
		LastCounterResetTime = decoder.ReadDateTime("LastCounterResetTime");
		Servers = (ServerOnNetwork[])decoder.ReadEncodeableArray("Servers", typeof(ServerOnNetwork));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is FindServersOnNetworkResponse findServersOnNetworkResponse))
		{
			return false;
		}
		if (!Utils.IsEqual(m_responseHeader, findServersOnNetworkResponse.m_responseHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_lastCounterResetTime, findServersOnNetworkResponse.m_lastCounterResetTime))
		{
			return false;
		}
		if (!Utils.IsEqual(m_servers, findServersOnNetworkResponse.m_servers))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (FindServersOnNetworkResponse)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		FindServersOnNetworkResponse obj = (FindServersOnNetworkResponse)base.MemberwiseClone();
		obj.m_responseHeader = (ResponseHeader)Utils.Clone(m_responseHeader);
		obj.m_lastCounterResetTime = (DateTime)Utils.Clone(m_lastCounterResetTime);
		obj.m_servers = (ServerOnNetworkCollection)Utils.Clone(m_servers);
		return obj;
	}
}
