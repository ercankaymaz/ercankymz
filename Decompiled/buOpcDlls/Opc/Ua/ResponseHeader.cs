using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ResponseHeader : IEncodeable, ICloneable, IJsonEncodeable
{
	private DateTime m_timestamp;

	private uint m_requestHandle;

	private StatusCode m_serviceResult;

	private DiagnosticInfo m_serviceDiagnostics;

	private StringCollection m_stringTable;

	private ExtensionObject m_additionalHeader;

	[DataMember(Name = "Timestamp", IsRequired = false, Order = 1)]
	public DateTime Timestamp
	{
		get
		{
			return m_timestamp;
		}
		set
		{
			m_timestamp = value;
		}
	}

	[DataMember(Name = "RequestHandle", IsRequired = false, Order = 2)]
	public uint RequestHandle
	{
		get
		{
			return m_requestHandle;
		}
		set
		{
			m_requestHandle = value;
		}
	}

	[DataMember(Name = "ServiceResult", IsRequired = false, Order = 3)]
	public StatusCode ServiceResult
	{
		get
		{
			return m_serviceResult;
		}
		set
		{
			m_serviceResult = value;
		}
	}

	[DataMember(Name = "ServiceDiagnostics", IsRequired = false, Order = 4)]
	public DiagnosticInfo ServiceDiagnostics
	{
		get
		{
			return m_serviceDiagnostics;
		}
		set
		{
			m_serviceDiagnostics = value;
		}
	}

	[DataMember(Name = "StringTable", IsRequired = false, Order = 5)]
	public StringCollection StringTable
	{
		get
		{
			return m_stringTable;
		}
		set
		{
			m_stringTable = value;
			if (value == null)
			{
				m_stringTable = new StringCollection();
			}
		}
	}

	[DataMember(Name = "AdditionalHeader", IsRequired = false, Order = 6)]
	public ExtensionObject AdditionalHeader
	{
		get
		{
			return m_additionalHeader;
		}
		set
		{
			m_additionalHeader = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ResponseHeader;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ResponseHeader_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ResponseHeader_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ResponseHeader_Encoding_DefaultJson;

	public ResponseHeader()
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
		m_timestamp = DateTime.MinValue;
		m_requestHandle = 0u;
		m_serviceResult = 0u;
		m_serviceDiagnostics = null;
		m_stringTable = new StringCollection();
		m_additionalHeader = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteDateTime("Timestamp", Timestamp);
		encoder.WriteUInt32("RequestHandle", RequestHandle);
		encoder.WriteStatusCode("ServiceResult", ServiceResult);
		encoder.WriteDiagnosticInfo("ServiceDiagnostics", ServiceDiagnostics);
		encoder.WriteStringArray("StringTable", StringTable);
		encoder.WriteExtensionObject("AdditionalHeader", AdditionalHeader);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Timestamp = decoder.ReadDateTime("Timestamp");
		RequestHandle = decoder.ReadUInt32("RequestHandle");
		ServiceResult = decoder.ReadStatusCode("ServiceResult");
		ServiceDiagnostics = decoder.ReadDiagnosticInfo("ServiceDiagnostics");
		StringTable = decoder.ReadStringArray("StringTable");
		AdditionalHeader = decoder.ReadExtensionObject("AdditionalHeader");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ResponseHeader responseHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_timestamp, responseHeader.m_timestamp))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHandle, responseHeader.m_requestHandle))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serviceResult, responseHeader.m_serviceResult))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serviceDiagnostics, responseHeader.m_serviceDiagnostics))
		{
			return false;
		}
		if (!Utils.IsEqual(m_stringTable, responseHeader.m_stringTable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_additionalHeader, responseHeader.m_additionalHeader))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ResponseHeader)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ResponseHeader obj = (ResponseHeader)base.MemberwiseClone();
		obj.m_timestamp = (DateTime)Utils.Clone(m_timestamp);
		obj.m_requestHandle = (uint)Utils.Clone(m_requestHandle);
		obj.m_serviceResult = (StatusCode)Utils.Clone(m_serviceResult);
		obj.m_serviceDiagnostics = (DiagnosticInfo)Utils.Clone(m_serviceDiagnostics);
		obj.m_stringTable = (StringCollection)Utils.Clone(m_stringTable);
		obj.m_additionalHeader = (ExtensionObject)Utils.Clone(m_additionalHeader);
		return obj;
	}
}
