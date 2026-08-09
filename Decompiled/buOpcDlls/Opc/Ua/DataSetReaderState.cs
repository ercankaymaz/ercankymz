using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DataSetReaderState : BaseObjectState
{
	private const string SecurityMode_InitializationString = "//////////8VYIkKAgAAAAAADAAAAFNlY3VyaXR5TW9kZQEAPD4ALgBEPD4AAAEALgH/////AQH/////AAAAAA==";

	private const string SecurityGroupId_InitializationString = "//////////8VYIkKAgAAAAAADwAAAFNlY3VyaXR5R3JvdXBJZAEAPT4ALgBEPT4AAAAM/////wEB/////wAAAAA=";

	private const string SecurityKeyServices_InitializationString = "//////////8XYIkKAgAAAAAAEwAAAFNlY3VyaXR5S2V5U2VydmljZXMBAD4+AC4ARD4+AAABADgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	private const string TransportSettings_InitializationString = "//////////8EYIAKAQAAAAAAEQAAAFRyYW5zcG9ydFNldHRpbmdzAQDPOwAvAQDXO887AAD/////AAAAAA==";

	private const string MessageSettings_InitializationString = "//////////8EYIAKAQAAAAAADwAAAE1lc3NhZ2VTZXR0aW5ncwEAb1IALwEAcFJvUgAA/////wAAAAA=";

	private const string Diagnostics_InitializationString = "//////////8EYIAKAQAAAAAACwAAAERpYWdub3N0aWNzAQCZTAAvAQA7TplMAAD/////BwAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAmkwALwA/mkwAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAVG90YWxJbmZvcm1hdGlvbgEAm0wALwEADU2bTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCcTAAuAEScTAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAJ1MAC4ARJ1MAAABABJN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAJ5MAC4ARJ5MAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFRvdGFsRXJyb3IBAKBMAC8BAA1NoEwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAoUwALgBEoUwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQCiTAAuAESiTAAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCjTAAuAESjTAAAAQALTf////8BAf////8AAAAABGGCCgQAAAAAAAUAAABSZXNldAEApUwALwEA6UylTAAAAQH/////AAAAABVgiQoCAAAAAAAIAAAAU3ViRXJyb3IBAKZMAC8AP6ZMAAAAAf////8BAf////8AAAAABGCACgEAAAAAAAgAAABDb3VudGVycwEAp0wALwA6p0wAAP////8HAAAAFWCJCgIAAAAAAAoAAABTdGF0ZUVycm9yAQCoTAAvAQANTahMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAKlMAC4ARKlMAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAqkwALgBEqkwAAAYBAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCrTAAuAESrTAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFN0YXRlT3BlcmF0aW9uYWxCeU1ldGhvZAEArUwALwEADU2tTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCuTAAuAESuTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAK9MAC4ARK9MAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAsEwALgBEsEwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlQYXJlbnQBALJMAC8BAA1NskwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAs0wALgBEs0wAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQC0TAAuAES0TAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBALVMAC4ARLVMAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAZAAAAU3RhdGVPcGVyYXRpb25hbEZyb21FcnJvcgEAt0wALwEADU23TAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQC4TAAuAES4TAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BALlMAC4ARLlMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAukwALgBEukwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdGF0ZVBhdXNlZEJ5UGFyZW50AQC8TAAvAQANTbxMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAL1MAC4ARL1MAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAvkwALgBEvkwAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQC/TAAuAES/TAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFN0YXRlRGlzYWJsZWRCeU1ldGhvZAEAwUwALwEADU3BTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQDCTAAuAETCTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAMNMAC4ARMNMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAxEwALgBExEwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABGYWlsZWREYXRhU2V0TWVzc2FnZXMBAMdMAC8BAA1Nx0wAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAyEwALgBEyEwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQDJTAAuAETJTAAABgEAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAMpMAC4ARMpMAAAGAAAAAAEAC03/////AQH/////AAAAAARggAoBAAAAAAAKAAAATGl2ZVZhbHVlcwEAxkwALwA6xkwAAP////8AAAAA";

	private const string CreateTargetVariables_InitializationString = "//////////8EYYIKBAAAAAAAFQAAAENyZWF0ZVRhcmdldFZhcmlhYmxlcwEA6kMALwEA6kPqQwAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOtDAC4AROtDAACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASkAAAAUAAAAVGFyZ2V0VmFyaWFibGVzVG9BZGQBAJg5AQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAOxDAC4AROxDAACWAQAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private const string CreateDataSetMirror_InitializationString = "//////////8EYYIKBAAAAAAAEwAAAENyZWF0ZURhdGFTZXRNaXJyb3IBAO1DAC8BAO1D7UMAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDuQwAuAETuQwAAlgIAAAABACoBAR0AAAAOAAAAUGFyZW50Tm9kZU5hbWUADP////8AAAAAAAEAKgEBIgAAAA8AAABSb2xlUGVybWlzc2lvbnMAYAEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDvQwAuAETvQwAAlgEAAAABACoBARsAAAAMAAAAUGFyZW50Tm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	private const string InitializationString = "//////////8EYIACAQAAAAAAGQAAAERhdGFTZXRSZWFkZXJUeXBlSW5zdGFuY2UBAMo7AQDKO8o7AAD/////EwAAABVgiQoCAAAAAAALAAAAUHVibGlzaGVySWQBAGlSAC4ARGlSAAAAGP////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABXcml0ZXJHcm91cElkAQBqUgAuAERqUgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAARGF0YVNldFdyaXRlcklkAQBrUgAuAERrUgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAARGF0YVNldE1ldGFEYXRhAQBsUgAuAERsUgAAAQC7OP////8BAf////8AAAAAFWCJCgIAAAAAABcAAABEYXRhU2V0RmllbGRDb250ZW50TWFzawEAbVIALgBEbVIAAAEA3zz/////AQH/////AAAAABVgiQoCAAAAAAAVAAAATWVzc2FnZVJlY2VpdmVUaW1lb3V0AQBuUgAuAERuUgAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABLZXlGcmFtZUNvdW50AQCbRAAuAESbRAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAPAAAASGVhZGVyTGF5b3V0VXJpAQCcRAAuAEScRAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAU2VjdXJpdHlNb2RlAQA8PgAuAEQ8PgAAAQAuAf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABTZWN1cml0eUdyb3VwSWQBAD0+AC4ARD0+AAAADP////8BAf////8AAAAAF2CJCgIAAAAAABMAAABTZWN1cml0eUtleVNlcnZpY2VzAQA+PgAuAEQ+PgAAAQA4AQEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAFwAAAERhdGFTZXRSZWFkZXJQcm9wZXJ0aWVzAQBWRAAuAERWRAAAAQDFOAEAAAABAAAAAAAAAAEB/////wAAAAAEYIAKAQAAAAAAEQAAAFRyYW5zcG9ydFNldHRpbmdzAQDPOwAvAQDXO887AAD/////AAAAAARggAoBAAAAAAAPAAAATWVzc2FnZVNldHRpbmdzAQBvUgAvAQBwUm9SAAD/////AAAAAARggAoBAAAAAAAGAAAAU3RhdHVzAQDLOwAvAQAzOcs7AAD/////AQAAABVgiQoCAAAAAAAFAAAAU3RhdGUBAMw7AC8AP8w7AAABADc5/////wEB/////wAAAAAEYIAKAQAAAAAACwAAAERpYWdub3N0aWNzAQCZTAAvAQA7TplMAAD/////BwAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAmkwALwA/mkwAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAVG90YWxJbmZvcm1hdGlvbgEAm0wALwEADU2bTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCcTAAuAEScTAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAJ1MAC4ARJ1MAAABABJN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAJ5MAC4ARJ5MAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFRvdGFsRXJyb3IBAKBMAC8BAA1NoEwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAoUwALgBEoUwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQCiTAAuAESiTAAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCjTAAuAESjTAAAAQALTf////8BAf////8AAAAABGGCCgQAAAAAAAUAAABSZXNldAEApUwALwEA6UylTAAAAQH/////AAAAABVgiQoCAAAAAAAIAAAAU3ViRXJyb3IBAKZMAC8AP6ZMAAAAAf////8BAf////8AAAAABGCACgEAAAAAAAgAAABDb3VudGVycwEAp0wALwA6p0wAAP////8HAAAAFWCJCgIAAAAAAAoAAABTdGF0ZUVycm9yAQCoTAAvAQANTahMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAKlMAC4ARKlMAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAqkwALgBEqkwAAAYBAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCrTAAuAESrTAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFN0YXRlT3BlcmF0aW9uYWxCeU1ldGhvZAEArUwALwEADU2tTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCuTAAuAESuTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAK9MAC4ARK9MAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAsEwALgBEsEwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlQYXJlbnQBALJMAC8BAA1NskwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAs0wALgBEs0wAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQC0TAAuAES0TAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBALVMAC4ARLVMAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAZAAAAU3RhdGVPcGVyYXRpb25hbEZyb21FcnJvcgEAt0wALwEADU23TAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQC4TAAuAES4TAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BALlMAC4ARLlMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAukwALgBEukwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdGF0ZVBhdXNlZEJ5UGFyZW50AQC8TAAvAQANTbxMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAL1MAC4ARL1MAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAvkwALgBEvkwAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQC/TAAuAES/TAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFN0YXRlRGlzYWJsZWRCeU1ldGhvZAEAwUwALwEADU3BTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQDCTAAuAETCTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAMNMAC4ARMNMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAxEwALgBExEwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABGYWlsZWREYXRhU2V0TWVzc2FnZXMBAMdMAC8BAA1Nx0wAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAyEwALgBEyEwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQDJTAAuAETJTAAABgEAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAMpMAC4ARMpMAAAGAAAAAAEAC03/////AQH/////AAAAAARggAoBAAAAAAAKAAAATGl2ZVZhbHVlcwEAxkwALwA6xkwAAP////8AAAAABGCACgEAAAAAABEAAABTdWJzY3JpYmVkRGF0YVNldAEA1DsALwEABDvUOwAA/////wAAAAAEYYIKBAAAAAAAFQAAAENyZWF0ZVRhcmdldFZhcmlhYmxlcwEA6kMALwEA6kPqQwAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOtDAC4AROtDAACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASkAAAAUAAAAVGFyZ2V0VmFyaWFibGVzVG9BZGQBAJg5AQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAOxDAC4AROxDAACWAQAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAEwAAAENyZWF0ZURhdGFTZXRNaXJyb3IBAO1DAC8BAO1D7UMAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDuQwAuAETuQwAAlgIAAAABACoBAR0AAAAOAAAAUGFyZW50Tm9kZU5hbWUADP////8AAAAAAAEAKgEBIgAAAA8AAABSb2xlUGVybWlzc2lvbnMAYAEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDvQwAuAETvQwAAlgEAAAABACoBARsAAAAMAAAAUGFyZW50Tm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	private PropertyState m_publisherId;

	private PropertyState<ushort> m_writerGroupId;

	private PropertyState<ushort> m_dataSetWriterId;

	private PropertyState<DataSetMetaDataType> m_dataSetMetaData;

	private PropertyState<uint> m_dataSetFieldContentMask;

	private PropertyState<double> m_messageReceiveTimeout;

	private PropertyState<uint> m_keyFrameCount;

	private PropertyState<string> m_headerLayoutUri;

	private PropertyState<MessageSecurityMode> m_securityMode;

	private PropertyState<string> m_securityGroupId;

	private PropertyState<EndpointDescription[]> m_securityKeyServices;

	private PropertyState<KeyValuePair[]> m_dataSetReaderProperties;

	private DataSetReaderTransportState m_transportSettings;

	private DataSetReaderMessageState m_messageSettings;

	private PubSubStatusState m_status;

	private PubSubDiagnosticsDataSetReaderState m_diagnostics;

	private SubscribedDataSetState m_subscribedDataSet;

	private DataSetReaderTypeCreateTargetVariablesMethodState m_createTargetVariablesMethod;

	private DataSetReaderTypeCreateDataSetMirrorMethodState m_createDataSetMirrorMethod;

	public PropertyState PublisherId
	{
		get
		{
			return m_publisherId;
		}
		set
		{
			if (m_publisherId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_publisherId = value;
		}
	}

	public PropertyState<ushort> WriterGroupId
	{
		get
		{
			return m_writerGroupId;
		}
		set
		{
			if (m_writerGroupId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_writerGroupId = value;
		}
	}

	public PropertyState<ushort> DataSetWriterId
	{
		get
		{
			return m_dataSetWriterId;
		}
		set
		{
			if (m_dataSetWriterId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_dataSetWriterId = value;
		}
	}

	public PropertyState<DataSetMetaDataType> DataSetMetaData
	{
		get
		{
			return m_dataSetMetaData;
		}
		set
		{
			if (m_dataSetMetaData != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_dataSetMetaData = value;
		}
	}

	public PropertyState<uint> DataSetFieldContentMask
	{
		get
		{
			return m_dataSetFieldContentMask;
		}
		set
		{
			if (m_dataSetFieldContentMask != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_dataSetFieldContentMask = value;
		}
	}

	public PropertyState<double> MessageReceiveTimeout
	{
		get
		{
			return m_messageReceiveTimeout;
		}
		set
		{
			if (m_messageReceiveTimeout != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_messageReceiveTimeout = value;
		}
	}

	public PropertyState<uint> KeyFrameCount
	{
		get
		{
			return m_keyFrameCount;
		}
		set
		{
			if (m_keyFrameCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_keyFrameCount = value;
		}
	}

	public PropertyState<string> HeaderLayoutUri
	{
		get
		{
			return m_headerLayoutUri;
		}
		set
		{
			if (m_headerLayoutUri != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_headerLayoutUri = value;
		}
	}

	public PropertyState<MessageSecurityMode> SecurityMode
	{
		get
		{
			return m_securityMode;
		}
		set
		{
			if (m_securityMode != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_securityMode = value;
		}
	}

	public PropertyState<string> SecurityGroupId
	{
		get
		{
			return m_securityGroupId;
		}
		set
		{
			if (m_securityGroupId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_securityGroupId = value;
		}
	}

	public PropertyState<EndpointDescription[]> SecurityKeyServices
	{
		get
		{
			return m_securityKeyServices;
		}
		set
		{
			if (m_securityKeyServices != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_securityKeyServices = value;
		}
	}

	public PropertyState<KeyValuePair[]> DataSetReaderProperties
	{
		get
		{
			return m_dataSetReaderProperties;
		}
		set
		{
			if (m_dataSetReaderProperties != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_dataSetReaderProperties = value;
		}
	}

	public DataSetReaderTransportState TransportSettings
	{
		get
		{
			return m_transportSettings;
		}
		set
		{
			if (m_transportSettings != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_transportSettings = value;
		}
	}

	public DataSetReaderMessageState MessageSettings
	{
		get
		{
			return m_messageSettings;
		}
		set
		{
			if (m_messageSettings != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_messageSettings = value;
		}
	}

	public PubSubStatusState Status
	{
		get
		{
			return m_status;
		}
		set
		{
			if (m_status != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_status = value;
		}
	}

	public PubSubDiagnosticsDataSetReaderState Diagnostics
	{
		get
		{
			return m_diagnostics;
		}
		set
		{
			if (m_diagnostics != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_diagnostics = value;
		}
	}

	public SubscribedDataSetState SubscribedDataSet
	{
		get
		{
			return m_subscribedDataSet;
		}
		set
		{
			if (m_subscribedDataSet != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_subscribedDataSet = value;
		}
	}

	public DataSetReaderTypeCreateTargetVariablesMethodState CreateTargetVariables
	{
		get
		{
			return m_createTargetVariablesMethod;
		}
		set
		{
			if (m_createTargetVariablesMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_createTargetVariablesMethod = value;
		}
	}

	public DataSetReaderTypeCreateDataSetMirrorMethodState CreateDataSetMirror
	{
		get
		{
			return m_createDataSetMirrorMethod;
		}
		set
		{
			if (m_createDataSetMirrorMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_createDataSetMirrorMethod = value;
		}
	}

	public DataSetReaderState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(15306u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAGQAAAERhdGFTZXRSZWFkZXJUeXBlSW5zdGFuY2UBAMo7AQDKO8o7AAD/////EwAAABVgiQoCAAAAAAALAAAAUHVibGlzaGVySWQBAGlSAC4ARGlSAAAAGP////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABXcml0ZXJHcm91cElkAQBqUgAuAERqUgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAARGF0YVNldFdyaXRlcklkAQBrUgAuAERrUgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAARGF0YVNldE1ldGFEYXRhAQBsUgAuAERsUgAAAQC7OP////8BAf////8AAAAAFWCJCgIAAAAAABcAAABEYXRhU2V0RmllbGRDb250ZW50TWFzawEAbVIALgBEbVIAAAEA3zz/////AQH/////AAAAABVgiQoCAAAAAAAVAAAATWVzc2FnZVJlY2VpdmVUaW1lb3V0AQBuUgAuAERuUgAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABLZXlGcmFtZUNvdW50AQCbRAAuAESbRAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAPAAAASGVhZGVyTGF5b3V0VXJpAQCcRAAuAEScRAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAU2VjdXJpdHlNb2RlAQA8PgAuAEQ8PgAAAQAuAf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABTZWN1cml0eUdyb3VwSWQBAD0+AC4ARD0+AAAADP////8BAf////8AAAAAF2CJCgIAAAAAABMAAABTZWN1cml0eUtleVNlcnZpY2VzAQA+PgAuAEQ+PgAAAQA4AQEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAFwAAAERhdGFTZXRSZWFkZXJQcm9wZXJ0aWVzAQBWRAAuAERWRAAAAQDFOAEAAAABAAAAAAAAAAEB/////wAAAAAEYIAKAQAAAAAAEQAAAFRyYW5zcG9ydFNldHRpbmdzAQDPOwAvAQDXO887AAD/////AAAAAARggAoBAAAAAAAPAAAATWVzc2FnZVNldHRpbmdzAQBvUgAvAQBwUm9SAAD/////AAAAAARggAoBAAAAAAAGAAAAU3RhdHVzAQDLOwAvAQAzOcs7AAD/////AQAAABVgiQoCAAAAAAAFAAAAU3RhdGUBAMw7AC8AP8w7AAABADc5/////wEB/////wAAAAAEYIAKAQAAAAAACwAAAERpYWdub3N0aWNzAQCZTAAvAQA7TplMAAD/////BwAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAmkwALwA/mkwAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAVG90YWxJbmZvcm1hdGlvbgEAm0wALwEADU2bTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCcTAAuAEScTAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAJ1MAC4ARJ1MAAABABJN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAJ5MAC4ARJ5MAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFRvdGFsRXJyb3IBAKBMAC8BAA1NoEwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAoUwALgBEoUwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQCiTAAuAESiTAAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCjTAAuAESjTAAAAQALTf////8BAf////8AAAAABGGCCgQAAAAAAAUAAABSZXNldAEApUwALwEA6UylTAAAAQH/////AAAAABVgiQoCAAAAAAAIAAAAU3ViRXJyb3IBAKZMAC8AP6ZMAAAAAf////8BAf////8AAAAABGCACgEAAAAAAAgAAABDb3VudGVycwEAp0wALwA6p0wAAP////8HAAAAFWCJCgIAAAAAAAoAAABTdGF0ZUVycm9yAQCoTAAvAQANTahMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAKlMAC4ARKlMAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAqkwALgBEqkwAAAYBAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCrTAAuAESrTAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFN0YXRlT3BlcmF0aW9uYWxCeU1ldGhvZAEArUwALwEADU2tTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCuTAAuAESuTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAK9MAC4ARK9MAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAsEwALgBEsEwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlQYXJlbnQBALJMAC8BAA1NskwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAs0wALgBEs0wAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQC0TAAuAES0TAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBALVMAC4ARLVMAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAZAAAAU3RhdGVPcGVyYXRpb25hbEZyb21FcnJvcgEAt0wALwEADU23TAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQC4TAAuAES4TAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BALlMAC4ARLlMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAukwALgBEukwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdGF0ZVBhdXNlZEJ5UGFyZW50AQC8TAAvAQANTbxMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAL1MAC4ARL1MAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAvkwALgBEvkwAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQC/TAAuAES/TAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFN0YXRlRGlzYWJsZWRCeU1ldGhvZAEAwUwALwEADU3BTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQDCTAAuAETCTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAMNMAC4ARMNMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAxEwALgBExEwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABGYWlsZWREYXRhU2V0TWVzc2FnZXMBAMdMAC8BAA1Nx0wAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAyEwALgBEyEwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQDJTAAuAETJTAAABgEAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAMpMAC4ARMpMAAAGAAAAAAEAC03/////AQH/////AAAAAARggAoBAAAAAAAKAAAATGl2ZVZhbHVlcwEAxkwALwA6xkwAAP////8AAAAABGCACgEAAAAAABEAAABTdWJzY3JpYmVkRGF0YVNldAEA1DsALwEABDvUOwAA/////wAAAAAEYYIKBAAAAAAAFQAAAENyZWF0ZVRhcmdldFZhcmlhYmxlcwEA6kMALwEA6kPqQwAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOtDAC4AROtDAACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASkAAAAUAAAAVGFyZ2V0VmFyaWFibGVzVG9BZGQBAJg5AQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAOxDAC4AROxDAACWAQAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAEwAAAENyZWF0ZURhdGFTZXRNaXJyb3IBAO1DAC8BAO1D7UMAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDuQwAuAETuQwAAlgIAAAABACoBAR0AAAAOAAAAUGFyZW50Tm9kZU5hbWUADP////8AAAAAAAEAKgEBIgAAAA8AAABSb2xlUGVybWlzc2lvbnMAYAEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDvQwAuAETvQwAAlgEAAAABACoBARsAAAAMAAAAUGFyZW50Tm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
		InitializeOptionalChildren(context);
	}

	protected override void Initialize(ISystemContext context, NodeState source)
	{
		InitializeOptionalChildren(context);
		base.Initialize(context, source);
	}

	protected override void InitializeOptionalChildren(ISystemContext context)
	{
		base.InitializeOptionalChildren(context);
		if (SecurityMode != null)
		{
			SecurityMode.Initialize(context, "//////////8VYIkKAgAAAAAADAAAAFNlY3VyaXR5TW9kZQEAPD4ALgBEPD4AAAEALgH/////AQH/////AAAAAA==");
		}
		if (SecurityGroupId != null)
		{
			SecurityGroupId.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAFNlY3VyaXR5R3JvdXBJZAEAPT4ALgBEPT4AAAAM/////wEB/////wAAAAA=");
		}
		if (SecurityKeyServices != null)
		{
			SecurityKeyServices.Initialize(context, "//////////8XYIkKAgAAAAAAEwAAAFNlY3VyaXR5S2V5U2VydmljZXMBAD4+AC4ARD4+AAABADgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
		}
		if (TransportSettings != null)
		{
			TransportSettings.Initialize(context, "//////////8EYIAKAQAAAAAAEQAAAFRyYW5zcG9ydFNldHRpbmdzAQDPOwAvAQDXO887AAD/////AAAAAA==");
		}
		if (MessageSettings != null)
		{
			MessageSettings.Initialize(context, "//////////8EYIAKAQAAAAAADwAAAE1lc3NhZ2VTZXR0aW5ncwEAb1IALwEAcFJvUgAA/////wAAAAA=");
		}
		if (Diagnostics != null)
		{
			Diagnostics.Initialize(context, "//////////8EYIAKAQAAAAAACwAAAERpYWdub3N0aWNzAQCZTAAvAQA7TplMAAD/////BwAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAmkwALwA/mkwAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAVG90YWxJbmZvcm1hdGlvbgEAm0wALwEADU2bTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCcTAAuAEScTAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAJ1MAC4ARJ1MAAABABJN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAJ5MAC4ARJ5MAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFRvdGFsRXJyb3IBAKBMAC8BAA1NoEwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAoUwALgBEoUwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQCiTAAuAESiTAAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCjTAAuAESjTAAAAQALTf////8BAf////8AAAAABGGCCgQAAAAAAAUAAABSZXNldAEApUwALwEA6UylTAAAAQH/////AAAAABVgiQoCAAAAAAAIAAAAU3ViRXJyb3IBAKZMAC8AP6ZMAAAAAf////8BAf////8AAAAABGCACgEAAAAAAAgAAABDb3VudGVycwEAp0wALwA6p0wAAP////8HAAAAFWCJCgIAAAAAAAoAAABTdGF0ZUVycm9yAQCoTAAvAQANTahMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAKlMAC4ARKlMAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAqkwALgBEqkwAAAYBAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCrTAAuAESrTAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFN0YXRlT3BlcmF0aW9uYWxCeU1ldGhvZAEArUwALwEADU2tTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCuTAAuAESuTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAK9MAC4ARK9MAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAsEwALgBEsEwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlQYXJlbnQBALJMAC8BAA1NskwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAs0wALgBEs0wAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQC0TAAuAES0TAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBALVMAC4ARLVMAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAZAAAAU3RhdGVPcGVyYXRpb25hbEZyb21FcnJvcgEAt0wALwEADU23TAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQC4TAAuAES4TAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BALlMAC4ARLlMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAukwALgBEukwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdGF0ZVBhdXNlZEJ5UGFyZW50AQC8TAAvAQANTbxMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAL1MAC4ARL1MAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAvkwALgBEvkwAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQC/TAAuAES/TAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFN0YXRlRGlzYWJsZWRCeU1ldGhvZAEAwUwALwEADU3BTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQDCTAAuAETCTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAMNMAC4ARMNMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAxEwALgBExEwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABGYWlsZWREYXRhU2V0TWVzc2FnZXMBAMdMAC8BAA1Nx0wAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAyEwALgBEyEwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQDJTAAuAETJTAAABgEAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAMpMAC4ARMpMAAAGAAAAAAEAC03/////AQH/////AAAAAARggAoBAAAAAAAKAAAATGl2ZVZhbHVlcwEAxkwALwA6xkwAAP////8AAAAA");
		}
		if (CreateTargetVariables != null)
		{
			CreateTargetVariables.Initialize(context, "//////////8EYYIKBAAAAAAAFQAAAENyZWF0ZVRhcmdldFZhcmlhYmxlcwEA6kMALwEA6kPqQwAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOtDAC4AROtDAACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASkAAAAUAAAAVGFyZ2V0VmFyaWFibGVzVG9BZGQBAJg5AQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAOxDAC4AROxDAACWAQAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
		}
		if (CreateDataSetMirror != null)
		{
			CreateDataSetMirror.Initialize(context, "//////////8EYYIKBAAAAAAAEwAAAENyZWF0ZURhdGFTZXRNaXJyb3IBAO1DAC8BAO1D7UMAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDuQwAuAETuQwAAlgIAAAABACoBAR0AAAAOAAAAUGFyZW50Tm9kZU5hbWUADP////8AAAAAAAEAKgEBIgAAAA8AAABSb2xlUGVybWlzc2lvbnMAYAEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDvQwAuAETvQwAAlgEAAAABACoBARsAAAAMAAAAUGFyZW50Tm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_publisherId != null)
		{
			children.Add(m_publisherId);
		}
		if (m_writerGroupId != null)
		{
			children.Add(m_writerGroupId);
		}
		if (m_dataSetWriterId != null)
		{
			children.Add(m_dataSetWriterId);
		}
		if (m_dataSetMetaData != null)
		{
			children.Add(m_dataSetMetaData);
		}
		if (m_dataSetFieldContentMask != null)
		{
			children.Add(m_dataSetFieldContentMask);
		}
		if (m_messageReceiveTimeout != null)
		{
			children.Add(m_messageReceiveTimeout);
		}
		if (m_keyFrameCount != null)
		{
			children.Add(m_keyFrameCount);
		}
		if (m_headerLayoutUri != null)
		{
			children.Add(m_headerLayoutUri);
		}
		if (m_securityMode != null)
		{
			children.Add(m_securityMode);
		}
		if (m_securityGroupId != null)
		{
			children.Add(m_securityGroupId);
		}
		if (m_securityKeyServices != null)
		{
			children.Add(m_securityKeyServices);
		}
		if (m_dataSetReaderProperties != null)
		{
			children.Add(m_dataSetReaderProperties);
		}
		if (m_transportSettings != null)
		{
			children.Add(m_transportSettings);
		}
		if (m_messageSettings != null)
		{
			children.Add(m_messageSettings);
		}
		if (m_status != null)
		{
			children.Add(m_status);
		}
		if (m_diagnostics != null)
		{
			children.Add(m_diagnostics);
		}
		if (m_subscribedDataSet != null)
		{
			children.Add(m_subscribedDataSet);
		}
		if (m_createTargetVariablesMethod != null)
		{
			children.Add(m_createTargetVariablesMethod);
		}
		if (m_createDataSetMirrorMethod != null)
		{
			children.Add(m_createDataSetMirrorMethod);
		}
		base.GetChildren(context, children);
	}

	protected override BaseInstanceState FindChild(ISystemContext context, QualifiedName browseName, bool createOrReplace, BaseInstanceState replacement)
	{
		if (QualifiedName.IsNull(browseName))
		{
			return null;
		}
		BaseInstanceState baseInstanceState = null;
		switch (browseName.Name)
		{
		case "PublisherId":
			if (createOrReplace && PublisherId == null)
			{
				if (replacement == null)
				{
					PublisherId = new PropertyState(this);
				}
				else
				{
					PublisherId = (PropertyState)replacement;
				}
			}
			baseInstanceState = PublisherId;
			break;
		case "WriterGroupId":
			if (createOrReplace && WriterGroupId == null)
			{
				if (replacement == null)
				{
					WriterGroupId = new PropertyState<ushort>(this);
				}
				else
				{
					WriterGroupId = (PropertyState<ushort>)replacement;
				}
			}
			baseInstanceState = WriterGroupId;
			break;
		case "DataSetWriterId":
			if (createOrReplace && DataSetWriterId == null)
			{
				if (replacement == null)
				{
					DataSetWriterId = new PropertyState<ushort>(this);
				}
				else
				{
					DataSetWriterId = (PropertyState<ushort>)replacement;
				}
			}
			baseInstanceState = DataSetWriterId;
			break;
		case "DataSetMetaData":
			if (createOrReplace && DataSetMetaData == null)
			{
				if (replacement == null)
				{
					DataSetMetaData = new PropertyState<DataSetMetaDataType>(this);
				}
				else
				{
					DataSetMetaData = (PropertyState<DataSetMetaDataType>)replacement;
				}
			}
			baseInstanceState = DataSetMetaData;
			break;
		case "DataSetFieldContentMask":
			if (createOrReplace && DataSetFieldContentMask == null)
			{
				if (replacement == null)
				{
					DataSetFieldContentMask = new PropertyState<uint>(this);
				}
				else
				{
					DataSetFieldContentMask = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = DataSetFieldContentMask;
			break;
		case "MessageReceiveTimeout":
			if (createOrReplace && MessageReceiveTimeout == null)
			{
				if (replacement == null)
				{
					MessageReceiveTimeout = new PropertyState<double>(this);
				}
				else
				{
					MessageReceiveTimeout = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = MessageReceiveTimeout;
			break;
		case "KeyFrameCount":
			if (createOrReplace && KeyFrameCount == null)
			{
				if (replacement == null)
				{
					KeyFrameCount = new PropertyState<uint>(this);
				}
				else
				{
					KeyFrameCount = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = KeyFrameCount;
			break;
		case "HeaderLayoutUri":
			if (createOrReplace && HeaderLayoutUri == null)
			{
				if (replacement == null)
				{
					HeaderLayoutUri = new PropertyState<string>(this);
				}
				else
				{
					HeaderLayoutUri = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = HeaderLayoutUri;
			break;
		case "SecurityMode":
			if (createOrReplace && SecurityMode == null)
			{
				if (replacement == null)
				{
					SecurityMode = new PropertyState<MessageSecurityMode>(this);
				}
				else
				{
					SecurityMode = (PropertyState<MessageSecurityMode>)replacement;
				}
			}
			baseInstanceState = SecurityMode;
			break;
		case "SecurityGroupId":
			if (createOrReplace && SecurityGroupId == null)
			{
				if (replacement == null)
				{
					SecurityGroupId = new PropertyState<string>(this);
				}
				else
				{
					SecurityGroupId = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = SecurityGroupId;
			break;
		case "SecurityKeyServices":
			if (createOrReplace && SecurityKeyServices == null)
			{
				if (replacement == null)
				{
					SecurityKeyServices = new PropertyState<EndpointDescription[]>(this);
				}
				else
				{
					SecurityKeyServices = (PropertyState<EndpointDescription[]>)replacement;
				}
			}
			baseInstanceState = SecurityKeyServices;
			break;
		case "DataSetReaderProperties":
			if (createOrReplace && DataSetReaderProperties == null)
			{
				if (replacement == null)
				{
					DataSetReaderProperties = new PropertyState<KeyValuePair[]>(this);
				}
				else
				{
					DataSetReaderProperties = (PropertyState<KeyValuePair[]>)replacement;
				}
			}
			baseInstanceState = DataSetReaderProperties;
			break;
		case "TransportSettings":
			if (createOrReplace && TransportSettings == null)
			{
				if (replacement == null)
				{
					TransportSettings = new DataSetReaderTransportState(this);
				}
				else
				{
					TransportSettings = (DataSetReaderTransportState)replacement;
				}
			}
			baseInstanceState = TransportSettings;
			break;
		case "MessageSettings":
			if (createOrReplace && MessageSettings == null)
			{
				if (replacement == null)
				{
					MessageSettings = new DataSetReaderMessageState(this);
				}
				else
				{
					MessageSettings = (DataSetReaderMessageState)replacement;
				}
			}
			baseInstanceState = MessageSettings;
			break;
		case "Status":
			if (createOrReplace && Status == null)
			{
				if (replacement == null)
				{
					Status = new PubSubStatusState(this);
				}
				else
				{
					Status = (PubSubStatusState)replacement;
				}
			}
			baseInstanceState = Status;
			break;
		case "Diagnostics":
			if (createOrReplace && Diagnostics == null)
			{
				if (replacement == null)
				{
					Diagnostics = new PubSubDiagnosticsDataSetReaderState(this);
				}
				else
				{
					Diagnostics = (PubSubDiagnosticsDataSetReaderState)replacement;
				}
			}
			baseInstanceState = Diagnostics;
			break;
		case "SubscribedDataSet":
			if (createOrReplace && SubscribedDataSet == null)
			{
				if (replacement == null)
				{
					SubscribedDataSet = new SubscribedDataSetState(this);
				}
				else
				{
					SubscribedDataSet = (SubscribedDataSetState)replacement;
				}
			}
			baseInstanceState = SubscribedDataSet;
			break;
		case "CreateTargetVariables":
			if (createOrReplace && CreateTargetVariables == null)
			{
				if (replacement == null)
				{
					CreateTargetVariables = new DataSetReaderTypeCreateTargetVariablesMethodState(this);
				}
				else
				{
					CreateTargetVariables = (DataSetReaderTypeCreateTargetVariablesMethodState)replacement;
				}
			}
			baseInstanceState = CreateTargetVariables;
			break;
		case "CreateDataSetMirror":
			if (createOrReplace && CreateDataSetMirror == null)
			{
				if (replacement == null)
				{
					CreateDataSetMirror = new DataSetReaderTypeCreateDataSetMirrorMethodState(this);
				}
				else
				{
					CreateDataSetMirror = (DataSetReaderTypeCreateDataSetMirrorMethodState)replacement;
				}
			}
			baseInstanceState = CreateDataSetMirror;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
