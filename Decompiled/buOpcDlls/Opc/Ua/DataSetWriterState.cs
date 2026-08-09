using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DataSetWriterState : BaseObjectState
{
	private const string KeyFrameCount_InitializationString = "//////////8VYIkKAgAAAAAADQAAAEtleUZyYW1lQ291bnQBAGZSAC4ARGZSAAAAB/////8BAf////8AAAAA";

	private const string TransportSettings_InitializationString = "//////////8EYIAKAQAAAAAAEQAAAFRyYW5zcG9ydFNldHRpbmdzAQDHOwAvAQDJO8c7AAD/////AAAAAA==";

	private const string MessageSettings_InitializationString = "//////////8EYIAKAQAAAAAADwAAAE1lc3NhZ2VTZXR0aW5ncwEAZ1IALwEAaFJnUgAA/////wAAAAA=";

	private const string Diagnostics_InitializationString = "//////////8EYIAKAQAAAAAACwAAAERpYWdub3N0aWNzAQBeTAAvAQAATl5MAAD/////BwAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAX0wALwA/X0wAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAVG90YWxJbmZvcm1hdGlvbgEAYEwALwEADU1gTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQBhTAAuAERhTAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAGJMAC4ARGJMAAABABJN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAGNMAC4ARGNMAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFRvdGFsRXJyb3IBAGVMAC8BAA1NZUwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAZkwALgBEZkwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQBnTAAuAERnTAAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBoTAAuAERoTAAAAQALTf////8BAf////8AAAAABGGCCgQAAAAAAAUAAABSZXNldAEAakwALwEA6UxqTAAAAQH/////AAAAABVgiQoCAAAAAAAIAAAAU3ViRXJyb3IBAGtMAC8AP2tMAAAAAf////8BAf////8AAAAABGCACgEAAAAAAAgAAABDb3VudGVycwEAbEwALwA6bEwAAP////8HAAAAFWCJCgIAAAAAAAoAAABTdGF0ZUVycm9yAQBtTAAvAQANTW1MAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAG5MAC4ARG5MAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAb0wALgBEb0wAAAYBAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBwTAAuAERwTAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFN0YXRlT3BlcmF0aW9uYWxCeU1ldGhvZAEAckwALwEADU1yTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQBzTAAuAERzTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAHRMAC4ARHRMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAdUwALgBEdUwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlQYXJlbnQBAHdMAC8BAA1Nd0wAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAeEwALgBEeEwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQB5TAAuAER5TAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAHpMAC4ARHpMAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAZAAAAU3RhdGVPcGVyYXRpb25hbEZyb21FcnJvcgEAfEwALwEADU18TAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQB9TAAuAER9TAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAH5MAC4ARH5MAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAf0wALgBEf0wAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdGF0ZVBhdXNlZEJ5UGFyZW50AQCBTAAvAQANTYFMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAIJMAC4ARIJMAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAg0wALgBEg0wAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCETAAuAESETAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFN0YXRlRGlzYWJsZWRCeU1ldGhvZAEAhkwALwEADU2GTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCHTAAuAESHTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAIhMAC4ARIhMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAiUwALgBEiUwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABGYWlsZWREYXRhU2V0TWVzc2FnZXMBAIxMAC8BAA1NjEwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAjUwALgBEjUwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQCOTAAuAESOTAAABgEAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAI9MAC4ARI9MAAAGAAAAAAEAC03/////AQH/////AAAAAARggAoBAAAAAAAKAAAATGl2ZVZhbHVlcwEAi0wALwA6i0wAAP////8AAAAA";

	private const string InitializationString = "//////////8EYIACAQAAAAAAGQAAAERhdGFTZXRXcml0ZXJUeXBlSW5zdGFuY2UBAMI7AQDCO8I7AAD/////CAAAABVgiQoCAAAAAAAPAAAARGF0YVNldFdyaXRlcklkAQBkUgAuAERkUgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAXAAAARGF0YVNldEZpZWxkQ29udGVudE1hc2sBAGVSAC4ARGVSAAABAN88/////wEB/////wAAAAAVYIkKAgAAAAAADQAAAEtleUZyYW1lQ291bnQBAGZSAC4ARGZSAAAAB/////8BAf////8AAAAAF2CJCgIAAAAAABcAAABEYXRhU2V0V3JpdGVyUHJvcGVydGllcwEAVUQALgBEVUQAAAEAxTgBAAAAAQAAAAAAAAABAf////8AAAAABGCACgEAAAAAABEAAABUcmFuc3BvcnRTZXR0aW5ncwEAxzsALwEAyTvHOwAA/////wAAAAAEYIAKAQAAAAAADwAAAE1lc3NhZ2VTZXR0aW5ncwEAZ1IALwEAaFJnUgAA/////wAAAAAEYIAKAQAAAAAABgAAAFN0YXR1cwEAwzsALwEAMznDOwAA/////wEAAAAVYIkKAgAAAAAABQAAAFN0YXRlAQDEOwAvAD/EOwAAAQA3Of////8BAf////8AAAAABGCACgEAAAAAAAsAAABEaWFnbm9zdGljcwEAXkwALwEAAE5eTAAA/////wcAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAF9MAC8AP19MAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAFRvdGFsSW5mb3JtYXRpb24BAGBMAC8BAA1NYEwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAYUwALgBEYUwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQBiTAAuAERiTAAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBjTAAuAERjTAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABUb3RhbEVycm9yAQBlTAAvAQANTWVMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAGZMAC4ARGZMAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAZ0wALgBEZ0wAAAEAEk3/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAaEwALgBEaEwAAAEAC03/////AQH/////AAAAAARhggoEAAAAAAAFAAAAUmVzZXQBAGpMAC8BAOlMakwAAAEB/////wAAAAAVYIkKAgAAAAAACAAAAFN1YkVycm9yAQBrTAAvAD9rTAAAAAH/////AQH/////AAAAAARggAoBAAAAAAAIAAAAQ291bnRlcnMBAGxMAC8AOmxMAAD/////BwAAABVgiQoCAAAAAAAKAAAAU3RhdGVFcnJvcgEAbUwALwEADU1tTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQBuTAAuAERuTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAG9MAC4ARG9MAAAGAQAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAcEwALgBEcEwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlNZXRob2QBAHJMAC8BAA1NckwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAc0wALgBEc0wAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQB0TAAuAER0TAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAHVMAC4ARHVMAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAYAAAAU3RhdGVPcGVyYXRpb25hbEJ5UGFyZW50AQB3TAAvAQANTXdMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAHhMAC4ARHhMAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAeUwALgBEeUwAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQB6TAAuAER6TAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAFN0YXRlT3BlcmF0aW9uYWxGcm9tRXJyb3IBAHxMAC8BAA1NfEwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAfUwALgBEfUwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQB+TAAuAER+TAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAH9MAC4ARH9MAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAATAAAAU3RhdGVQYXVzZWRCeVBhcmVudAEAgUwALwEADU2BTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCCTAAuAESCTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAINMAC4ARINMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAhEwALgBEhEwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABTdGF0ZURpc2FibGVkQnlNZXRob2QBAIZMAC8BAA1NhkwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAh0wALgBEh0wAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQCITAAuAESITAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAIlMAC4ARIlMAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAVAAAARmFpbGVkRGF0YVNldE1lc3NhZ2VzAQCMTAAvAQANTYxMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAI1MAC4ARI1MAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAjkwALgBEjkwAAAYBAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCPTAAuAESPTAAABgAAAAABAAtN/////wEB/////wAAAAAEYIAKAQAAAAAACgAAAExpdmVWYWx1ZXMBAItMAC8AOotMAAD/////AAAAAA==";

	private PropertyState<ushort> m_dataSetWriterId;

	private PropertyState<uint> m_dataSetFieldContentMask;

	private PropertyState<uint> m_keyFrameCount;

	private PropertyState<KeyValuePair[]> m_dataSetWriterProperties;

	private DataSetWriterTransportState m_transportSettings;

	private DataSetWriterMessageState m_messageSettings;

	private PubSubStatusState m_status;

	private PubSubDiagnosticsDataSetWriterState m_diagnostics;

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

	public PropertyState<KeyValuePair[]> DataSetWriterProperties
	{
		get
		{
			return m_dataSetWriterProperties;
		}
		set
		{
			if (m_dataSetWriterProperties != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_dataSetWriterProperties = value;
		}
	}

	public DataSetWriterTransportState TransportSettings
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

	public DataSetWriterMessageState MessageSettings
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

	public PubSubDiagnosticsDataSetWriterState Diagnostics
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

	public DataSetWriterState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(15298u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAGQAAAERhdGFTZXRXcml0ZXJUeXBlSW5zdGFuY2UBAMI7AQDCO8I7AAD/////CAAAABVgiQoCAAAAAAAPAAAARGF0YVNldFdyaXRlcklkAQBkUgAuAERkUgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAXAAAARGF0YVNldEZpZWxkQ29udGVudE1hc2sBAGVSAC4ARGVSAAABAN88/////wEB/////wAAAAAVYIkKAgAAAAAADQAAAEtleUZyYW1lQ291bnQBAGZSAC4ARGZSAAAAB/////8BAf////8AAAAAF2CJCgIAAAAAABcAAABEYXRhU2V0V3JpdGVyUHJvcGVydGllcwEAVUQALgBEVUQAAAEAxTgBAAAAAQAAAAAAAAABAf////8AAAAABGCACgEAAAAAABEAAABUcmFuc3BvcnRTZXR0aW5ncwEAxzsALwEAyTvHOwAA/////wAAAAAEYIAKAQAAAAAADwAAAE1lc3NhZ2VTZXR0aW5ncwEAZ1IALwEAaFJnUgAA/////wAAAAAEYIAKAQAAAAAABgAAAFN0YXR1cwEAwzsALwEAMznDOwAA/////wEAAAAVYIkKAgAAAAAABQAAAFN0YXRlAQDEOwAvAD/EOwAAAQA3Of////8BAf////8AAAAABGCACgEAAAAAAAsAAABEaWFnbm9zdGljcwEAXkwALwEAAE5eTAAA/////wcAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAF9MAC8AP19MAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAFRvdGFsSW5mb3JtYXRpb24BAGBMAC8BAA1NYEwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAYUwALgBEYUwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQBiTAAuAERiTAAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBjTAAuAERjTAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABUb3RhbEVycm9yAQBlTAAvAQANTWVMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAGZMAC4ARGZMAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAZ0wALgBEZ0wAAAEAEk3/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAaEwALgBEaEwAAAEAC03/////AQH/////AAAAAARhggoEAAAAAAAFAAAAUmVzZXQBAGpMAC8BAOlMakwAAAEB/////wAAAAAVYIkKAgAAAAAACAAAAFN1YkVycm9yAQBrTAAvAD9rTAAAAAH/////AQH/////AAAAAARggAoBAAAAAAAIAAAAQ291bnRlcnMBAGxMAC8AOmxMAAD/////BwAAABVgiQoCAAAAAAAKAAAAU3RhdGVFcnJvcgEAbUwALwEADU1tTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQBuTAAuAERuTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAG9MAC4ARG9MAAAGAQAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAcEwALgBEcEwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlNZXRob2QBAHJMAC8BAA1NckwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAc0wALgBEc0wAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQB0TAAuAER0TAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAHVMAC4ARHVMAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAYAAAAU3RhdGVPcGVyYXRpb25hbEJ5UGFyZW50AQB3TAAvAQANTXdMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAHhMAC4ARHhMAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAeUwALgBEeUwAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQB6TAAuAER6TAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAFN0YXRlT3BlcmF0aW9uYWxGcm9tRXJyb3IBAHxMAC8BAA1NfEwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAfUwALgBEfUwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQB+TAAuAER+TAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAH9MAC4ARH9MAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAATAAAAU3RhdGVQYXVzZWRCeVBhcmVudAEAgUwALwEADU2BTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCCTAAuAESCTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAINMAC4ARINMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAhEwALgBEhEwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABTdGF0ZURpc2FibGVkQnlNZXRob2QBAIZMAC8BAA1NhkwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAh0wALgBEh0wAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQCITAAuAESITAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAIlMAC4ARIlMAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAVAAAARmFpbGVkRGF0YVNldE1lc3NhZ2VzAQCMTAAvAQANTYxMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAI1MAC4ARI1MAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAjkwALgBEjkwAAAYBAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCPTAAuAESPTAAABgAAAAABAAtN/////wEB/////wAAAAAEYIAKAQAAAAAACgAAAExpdmVWYWx1ZXMBAItMAC8AOotMAAD/////AAAAAA==");
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
		if (KeyFrameCount != null)
		{
			KeyFrameCount.Initialize(context, "//////////8VYIkKAgAAAAAADQAAAEtleUZyYW1lQ291bnQBAGZSAC4ARGZSAAAAB/////8BAf////8AAAAA");
		}
		if (TransportSettings != null)
		{
			TransportSettings.Initialize(context, "//////////8EYIAKAQAAAAAAEQAAAFRyYW5zcG9ydFNldHRpbmdzAQDHOwAvAQDJO8c7AAD/////AAAAAA==");
		}
		if (MessageSettings != null)
		{
			MessageSettings.Initialize(context, "//////////8EYIAKAQAAAAAADwAAAE1lc3NhZ2VTZXR0aW5ncwEAZ1IALwEAaFJnUgAA/////wAAAAA=");
		}
		if (Diagnostics != null)
		{
			Diagnostics.Initialize(context, "//////////8EYIAKAQAAAAAACwAAAERpYWdub3N0aWNzAQBeTAAvAQAATl5MAAD/////BwAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAX0wALwA/X0wAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAVG90YWxJbmZvcm1hdGlvbgEAYEwALwEADU1gTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQBhTAAuAERhTAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAGJMAC4ARGJMAAABABJN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAGNMAC4ARGNMAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFRvdGFsRXJyb3IBAGVMAC8BAA1NZUwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAZkwALgBEZkwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQBnTAAuAERnTAAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBoTAAuAERoTAAAAQALTf////8BAf////8AAAAABGGCCgQAAAAAAAUAAABSZXNldAEAakwALwEA6UxqTAAAAQH/////AAAAABVgiQoCAAAAAAAIAAAAU3ViRXJyb3IBAGtMAC8AP2tMAAAAAf////8BAf////8AAAAABGCACgEAAAAAAAgAAABDb3VudGVycwEAbEwALwA6bEwAAP////8HAAAAFWCJCgIAAAAAAAoAAABTdGF0ZUVycm9yAQBtTAAvAQANTW1MAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAG5MAC4ARG5MAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAb0wALgBEb0wAAAYBAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBwTAAuAERwTAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFN0YXRlT3BlcmF0aW9uYWxCeU1ldGhvZAEAckwALwEADU1yTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQBzTAAuAERzTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAHRMAC4ARHRMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAdUwALgBEdUwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlQYXJlbnQBAHdMAC8BAA1Nd0wAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAeEwALgBEeEwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQB5TAAuAER5TAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAHpMAC4ARHpMAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAZAAAAU3RhdGVPcGVyYXRpb25hbEZyb21FcnJvcgEAfEwALwEADU18TAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQB9TAAuAER9TAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAH5MAC4ARH5MAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAf0wALgBEf0wAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdGF0ZVBhdXNlZEJ5UGFyZW50AQCBTAAvAQANTYFMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAIJMAC4ARIJMAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAg0wALgBEg0wAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCETAAuAESETAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFN0YXRlRGlzYWJsZWRCeU1ldGhvZAEAhkwALwEADU2GTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCHTAAuAESHTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAIhMAC4ARIhMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAiUwALgBEiUwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABGYWlsZWREYXRhU2V0TWVzc2FnZXMBAIxMAC8BAA1NjEwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAjUwALgBEjUwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQCOTAAuAESOTAAABgEAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAI9MAC4ARI9MAAAGAAAAAAEAC03/////AQH/////AAAAAARggAoBAAAAAAAKAAAATGl2ZVZhbHVlcwEAi0wALwA6i0wAAP////8AAAAA");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_dataSetWriterId != null)
		{
			children.Add(m_dataSetWriterId);
		}
		if (m_dataSetFieldContentMask != null)
		{
			children.Add(m_dataSetFieldContentMask);
		}
		if (m_keyFrameCount != null)
		{
			children.Add(m_keyFrameCount);
		}
		if (m_dataSetWriterProperties != null)
		{
			children.Add(m_dataSetWriterProperties);
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
		case "DataSetWriterProperties":
			if (createOrReplace && DataSetWriterProperties == null)
			{
				if (replacement == null)
				{
					DataSetWriterProperties = new PropertyState<KeyValuePair[]>(this);
				}
				else
				{
					DataSetWriterProperties = (PropertyState<KeyValuePair[]>)replacement;
				}
			}
			baseInstanceState = DataSetWriterProperties;
			break;
		case "TransportSettings":
			if (createOrReplace && TransportSettings == null)
			{
				if (replacement == null)
				{
					TransportSettings = new DataSetWriterTransportState(this);
				}
				else
				{
					TransportSettings = (DataSetWriterTransportState)replacement;
				}
			}
			baseInstanceState = TransportSettings;
			break;
		case "MessageSettings":
			if (createOrReplace && MessageSettings == null)
			{
				if (replacement == null)
				{
					MessageSettings = new DataSetWriterMessageState(this);
				}
				else
				{
					MessageSettings = (DataSetWriterMessageState)replacement;
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
					Diagnostics = new PubSubDiagnosticsDataSetWriterState(this);
				}
				else
				{
					Diagnostics = (PubSubDiagnosticsDataSetWriterState)replacement;
				}
			}
			baseInstanceState = Diagnostics;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
