using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class StatusChangeNotification : NotificationData
{
	private StatusCode m_status;

	private DiagnosticInfo m_diagnosticInfo;

	[DataMember(Name = "Status", IsRequired = false, Order = 1)]
	public StatusCode Status
	{
		get
		{
			return m_status;
		}
		set
		{
			m_status = value;
		}
	}

	[DataMember(Name = "DiagnosticInfo", IsRequired = false, Order = 2)]
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

	public override ExpandedNodeId TypeId => DataTypeIds.StatusChangeNotification;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.StatusChangeNotification_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.StatusChangeNotification_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.StatusChangeNotification_Encoding_DefaultJson;

	public StatusChangeNotification()
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
		m_status = 0u;
		m_diagnosticInfo = null;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteStatusCode("Status", Status);
		encoder.WriteDiagnosticInfo("DiagnosticInfo", DiagnosticInfo);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Status = decoder.ReadStatusCode("Status");
		DiagnosticInfo = decoder.ReadDiagnosticInfo("DiagnosticInfo");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is StatusChangeNotification statusChangeNotification))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_status, statusChangeNotification.m_status))
		{
			return false;
		}
		if (!Utils.IsEqual(m_diagnosticInfo, statusChangeNotification.m_diagnosticInfo))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (StatusChangeNotification)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		StatusChangeNotification obj = (StatusChangeNotification)base.MemberwiseClone();
		obj.m_status = (StatusCode)Utils.Clone(m_status);
		obj.m_diagnosticInfo = (DiagnosticInfo)Utils.Clone(m_diagnosticInfo);
		return obj;
	}
}
