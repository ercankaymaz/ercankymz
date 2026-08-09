using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DataChangeNotification : NotificationData
{
	private MonitoredItemNotificationCollection m_monitoredItems;

	private DiagnosticInfoCollection m_diagnosticInfos;

	[DataMember(Name = "MonitoredItems", IsRequired = false, Order = 1)]
	public MonitoredItemNotificationCollection MonitoredItems
	{
		get
		{
			return m_monitoredItems;
		}
		set
		{
			m_monitoredItems = value;
			if (value == null)
			{
				m_monitoredItems = new MonitoredItemNotificationCollection();
			}
		}
	}

	[DataMember(Name = "DiagnosticInfos", IsRequired = false, Order = 2)]
	public DiagnosticInfoCollection DiagnosticInfos
	{
		get
		{
			return m_diagnosticInfos;
		}
		set
		{
			m_diagnosticInfos = value;
			if (value == null)
			{
				m_diagnosticInfos = new DiagnosticInfoCollection();
			}
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.DataChangeNotification;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.DataChangeNotification_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.DataChangeNotification_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.DataChangeNotification_Encoding_DefaultJson;

	public DataChangeNotification()
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
		m_monitoredItems = new MonitoredItemNotificationCollection();
		m_diagnosticInfos = new DiagnosticInfoCollection();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeableArray("MonitoredItems", MonitoredItems.ToArray(), typeof(MonitoredItemNotification));
		encoder.WriteDiagnosticInfoArray("DiagnosticInfos", DiagnosticInfos);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		MonitoredItems = (MonitoredItemNotification[])decoder.ReadEncodeableArray("MonitoredItems", typeof(MonitoredItemNotification));
		DiagnosticInfos = decoder.ReadDiagnosticInfoArray("DiagnosticInfos");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is DataChangeNotification dataChangeNotification))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_monitoredItems, dataChangeNotification.m_monitoredItems))
		{
			return false;
		}
		if (!Utils.IsEqual(m_diagnosticInfos, dataChangeNotification.m_diagnosticInfos))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (DataChangeNotification)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DataChangeNotification obj = (DataChangeNotification)base.MemberwiseClone();
		obj.m_monitoredItems = (MonitoredItemNotificationCollection)Utils.Clone(m_monitoredItems);
		obj.m_diagnosticInfos = (DiagnosticInfoCollection)Utils.Clone(m_diagnosticInfos);
		return obj;
	}
}
