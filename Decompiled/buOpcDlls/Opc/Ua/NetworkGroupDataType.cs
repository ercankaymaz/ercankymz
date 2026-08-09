using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class NetworkGroupDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private string m_serverUri;

	private EndpointUrlListDataTypeCollection m_networkPaths;

	[DataMember(Name = "ServerUri", IsRequired = false, Order = 1)]
	public string ServerUri
	{
		get
		{
			return m_serverUri;
		}
		set
		{
			m_serverUri = value;
		}
	}

	[DataMember(Name = "NetworkPaths", IsRequired = false, Order = 2)]
	public EndpointUrlListDataTypeCollection NetworkPaths
	{
		get
		{
			return m_networkPaths;
		}
		set
		{
			m_networkPaths = value;
			if (value == null)
			{
				m_networkPaths = new EndpointUrlListDataTypeCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.NetworkGroupDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.NetworkGroupDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.NetworkGroupDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.NetworkGroupDataType_Encoding_DefaultJson;

	public NetworkGroupDataType()
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
		m_serverUri = null;
		m_networkPaths = new EndpointUrlListDataTypeCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("ServerUri", ServerUri);
		encoder.WriteEncodeableArray("NetworkPaths", NetworkPaths.ToArray(), typeof(EndpointUrlListDataType));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ServerUri = decoder.ReadString("ServerUri");
		NetworkPaths = (EndpointUrlListDataType[])decoder.ReadEncodeableArray("NetworkPaths", typeof(EndpointUrlListDataType));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is NetworkGroupDataType networkGroupDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverUri, networkGroupDataType.m_serverUri))
		{
			return false;
		}
		if (!Utils.IsEqual(m_networkPaths, networkGroupDataType.m_networkPaths))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (NetworkGroupDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		NetworkGroupDataType obj = (NetworkGroupDataType)base.MemberwiseClone();
		obj.m_serverUri = (string)Utils.Clone(m_serverUri);
		obj.m_networkPaths = (EndpointUrlListDataTypeCollection)Utils.Clone(m_networkPaths);
		return obj;
	}
}
