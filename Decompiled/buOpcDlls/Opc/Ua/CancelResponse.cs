using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class CancelResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
	private ResponseHeader m_responseHeader;

	private uint m_cancelCount;

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

	[DataMember(Name = "CancelCount", IsRequired = false, Order = 2)]
	public uint CancelCount
	{
		get
		{
			return m_cancelCount;
		}
		set
		{
			m_cancelCount = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.CancelResponse;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.CancelResponse_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.CancelResponse_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.CancelResponse_Encoding_DefaultJson;

	public CancelResponse()
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
		m_cancelCount = 0u;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("ResponseHeader", ResponseHeader, typeof(ResponseHeader));
		encoder.WriteUInt32("CancelCount", CancelCount);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ResponseHeader = (ResponseHeader)decoder.ReadEncodeable("ResponseHeader", typeof(ResponseHeader));
		CancelCount = decoder.ReadUInt32("CancelCount");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is CancelResponse cancelResponse))
		{
			return false;
		}
		if (!Utils.IsEqual(m_responseHeader, cancelResponse.m_responseHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_cancelCount, cancelResponse.m_cancelCount))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (CancelResponse)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		CancelResponse obj = (CancelResponse)base.MemberwiseClone();
		obj.m_responseHeader = (ResponseHeader)Utils.Clone(m_responseHeader);
		obj.m_cancelCount = (uint)Utils.Clone(m_cancelCount);
		return obj;
	}
}
