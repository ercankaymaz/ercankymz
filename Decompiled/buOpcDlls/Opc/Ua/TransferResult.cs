using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class TransferResult : IEncodeable, ICloneable, IJsonEncodeable
{
	private StatusCode m_statusCode;

	private UInt32Collection m_availableSequenceNumbers;

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

	[DataMember(Name = "AvailableSequenceNumbers", IsRequired = false, Order = 2)]
	public UInt32Collection AvailableSequenceNumbers
	{
		get
		{
			return m_availableSequenceNumbers;
		}
		set
		{
			m_availableSequenceNumbers = value;
			if (value == null)
			{
				m_availableSequenceNumbers = new UInt32Collection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.TransferResult;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.TransferResult_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.TransferResult_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.TransferResult_Encoding_DefaultJson;

	public TransferResult()
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
		m_availableSequenceNumbers = new UInt32Collection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteStatusCode("StatusCode", StatusCode);
		encoder.WriteUInt32Array("AvailableSequenceNumbers", AvailableSequenceNumbers);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		StatusCode = decoder.ReadStatusCode("StatusCode");
		AvailableSequenceNumbers = decoder.ReadUInt32Array("AvailableSequenceNumbers");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is TransferResult transferResult))
		{
			return false;
		}
		if (!Utils.IsEqual(m_statusCode, transferResult.m_statusCode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_availableSequenceNumbers, transferResult.m_availableSequenceNumbers))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (TransferResult)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		TransferResult obj = (TransferResult)base.MemberwiseClone();
		obj.m_statusCode = (StatusCode)Utils.Clone(m_statusCode);
		obj.m_availableSequenceNumbers = (UInt32Collection)Utils.Clone(m_availableSequenceNumbers);
		return obj;
	}
}
