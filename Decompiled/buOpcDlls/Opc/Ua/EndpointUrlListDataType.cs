using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class EndpointUrlListDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private StringCollection m_endpointUrlList;

	[DataMember(Name = "EndpointUrlList", IsRequired = false, Order = 1)]
	public StringCollection EndpointUrlList
	{
		get
		{
			return m_endpointUrlList;
		}
		set
		{
			m_endpointUrlList = value;
			if (value == null)
			{
				m_endpointUrlList = new StringCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.EndpointUrlListDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.EndpointUrlListDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.EndpointUrlListDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.EndpointUrlListDataType_Encoding_DefaultJson;

	public EndpointUrlListDataType()
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
		m_endpointUrlList = new StringCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteStringArray("EndpointUrlList", EndpointUrlList);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		EndpointUrlList = decoder.ReadStringArray("EndpointUrlList");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is EndpointUrlListDataType endpointUrlListDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_endpointUrlList, endpointUrlListDataType.m_endpointUrlList))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (EndpointUrlListDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		EndpointUrlListDataType obj = (EndpointUrlListDataType)base.MemberwiseClone();
		obj.m_endpointUrlList = (StringCollection)Utils.Clone(m_endpointUrlList);
		return obj;
	}
}
