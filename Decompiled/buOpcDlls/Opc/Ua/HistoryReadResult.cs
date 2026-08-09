using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class HistoryReadResult : IEncodeable, ICloneable, IJsonEncodeable
{
	private StatusCode m_statusCode;

	private byte[] m_continuationPoint;

	private ExtensionObject m_historyData;

	[DataMember(Name = "StatusCode", IsRequired = false, Order = 1)]
	public StatusCode StatusCode
	{
		get
		{
			return m_statusCode;
		}
		set
		{
			m_statusCode = value;
		}
	}

	[DataMember(Name = "ContinuationPoint", IsRequired = false, Order = 2)]
	public byte[] ContinuationPoint
	{
		get
		{
			return m_continuationPoint;
		}
		set
		{
			m_continuationPoint = value;
		}
	}

	[DataMember(Name = "HistoryData", IsRequired = false, Order = 3)]
	public ExtensionObject HistoryData
	{
		get
		{
			return m_historyData;
		}
		set
		{
			m_historyData = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.HistoryReadResult;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.HistoryReadResult_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.HistoryReadResult_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.HistoryReadResult_Encoding_DefaultJson;

	public HistoryReadResult()
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
		m_statusCode = 0u;
		m_continuationPoint = null;
		m_historyData = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteStatusCode("StatusCode", StatusCode);
		encoder.WriteByteString("ContinuationPoint", ContinuationPoint);
		encoder.WriteExtensionObject("HistoryData", HistoryData);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		StatusCode = decoder.ReadStatusCode("StatusCode");
		ContinuationPoint = decoder.ReadByteString("ContinuationPoint");
		HistoryData = decoder.ReadExtensionObject("HistoryData");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is HistoryReadResult historyReadResult))
		{
			return false;
		}
		if (!Utils.IsEqual(m_statusCode, historyReadResult.m_statusCode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_continuationPoint, historyReadResult.m_continuationPoint))
		{
			return false;
		}
		if (!Utils.IsEqual(m_historyData, historyReadResult.m_historyData))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (HistoryReadResult)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		HistoryReadResult obj = (HistoryReadResult)base.MemberwiseClone();
		obj.m_statusCode = (StatusCode)Utils.Clone(m_statusCode);
		obj.m_continuationPoint = (byte[])Utils.Clone(m_continuationPoint);
		obj.m_historyData = (ExtensionObject)Utils.Clone(m_historyData);
		return obj;
	}
}
