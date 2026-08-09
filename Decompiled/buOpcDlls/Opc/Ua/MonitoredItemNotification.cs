using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class MonitoredItemNotification : IEncodeable, ICloneable, IJsonEncodeable
{
	private uint m_clientHandle;

	private DataValue m_value;

	private NotificationMessage m_message;

	private DiagnosticInfo m_diagnosticInfo;

	[DataMember(Name = "ClientHandle", IsRequired = false, Order = 1)]
	public uint ClientHandle
	{
		get
		{
			return m_clientHandle;
		}
		set
		{
			m_clientHandle = value;
		}
	}

	[DataMember(Name = "Value", IsRequired = false, Order = 2)]
	public DataValue Value
	{
		get
		{
			return m_value;
		}
		set
		{
			m_value = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.MonitoredItemNotification;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.MonitoredItemNotification_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.MonitoredItemNotification_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.MonitoredItemNotification_Encoding_DefaultJson;

	public NotificationMessage Message
	{
		get
		{
			return m_message;
		}
		set
		{
			m_message = value;
		}
	}

	public DiagnosticInfo DiagnosticInfo
	{
		get
		{
			return m_diagnosticInfo;
		}
		set
		{
			m_diagnosticInfo = value;
		}
	}

	public MonitoredItemNotification()
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
		m_clientHandle = 0u;
		m_value = new DataValue();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteUInt32("ClientHandle", ClientHandle);
		encoder.WriteDataValue("Value", Value);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ClientHandle = decoder.ReadUInt32("ClientHandle");
		Value = decoder.ReadDataValue("Value");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is MonitoredItemNotification monitoredItemNotification))
		{
			return false;
		}
		if (!Utils.IsEqual(m_clientHandle, monitoredItemNotification.m_clientHandle))
		{
			return false;
		}
		if (!Utils.IsEqual(m_value, monitoredItemNotification.m_value))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (MonitoredItemNotification)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		MonitoredItemNotification obj = (MonitoredItemNotification)base.MemberwiseClone();
		obj.m_clientHandle = (uint)Utils.Clone(m_clientHandle);
		obj.m_value = (DataValue)Utils.Clone(m_value);
		return obj;
	}
}
