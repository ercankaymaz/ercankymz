using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ServiceCounterDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private uint m_totalCount;

	private uint m_errorCount;

	[DataMember(Name = "TotalCount", IsRequired = false, Order = 1)]
	public uint TotalCount
	{
		get
		{
			return m_totalCount;
		}
		set
		{
			m_totalCount = value;
		}
	}

	[DataMember(Name = "ErrorCount", IsRequired = false, Order = 2)]
	public uint ErrorCount
	{
		get
		{
			return m_errorCount;
		}
		set
		{
			m_errorCount = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ServiceCounterDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ServiceCounterDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ServiceCounterDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ServiceCounterDataType_Encoding_DefaultJson;

	public ServiceCounterDataType()
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
		m_totalCount = 0u;
		m_errorCount = 0u;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteUInt32("TotalCount", TotalCount);
		encoder.WriteUInt32("ErrorCount", ErrorCount);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		TotalCount = decoder.ReadUInt32("TotalCount");
		ErrorCount = decoder.ReadUInt32("ErrorCount");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ServiceCounterDataType serviceCounterDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_totalCount, serviceCounterDataType.m_totalCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_errorCount, serviceCounterDataType.m_errorCount))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ServiceCounterDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ServiceCounterDataType obj = (ServiceCounterDataType)base.MemberwiseClone();
		obj.m_totalCount = (uint)Utils.Clone(m_totalCount);
		obj.m_errorCount = (uint)Utils.Clone(m_errorCount);
		return obj;
	}
}
