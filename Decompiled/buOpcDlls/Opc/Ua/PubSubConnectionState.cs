using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class PubSubConnectionState : BaseObjectState
{
	private const string TransportSettings_InitializationString = "//////////8EYIAKAQAAAAAAEQAAAFRyYW5zcG9ydFNldHRpbmdzAQAzQwAvAQA5RTNDAAD/////AAAAAA==";

	private const string Diagnostics_InitializationString = "//////////8EYIAKAQAAAAAACwAAAERpYWdub3N0aWNzAQApSwAvAQBKTSlLAAD/////BwAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAKksALwA/KksAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAVG90YWxJbmZvcm1hdGlvbgEAK0sALwEADU0rSwAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQAsSwAuAEQsSwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAC1LAC4ARC1LAAABABJN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAC5LAC4ARC5LAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFRvdGFsRXJyb3IBADBLAC8BAA1NMEsAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAMUsALgBEMUsAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQAySwAuAEQySwAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQAzSwAuAEQzSwAAAQALTf////8BAf////8AAAAABGGCCgQAAAAAAAUAAABSZXNldAEANUsALwEA6Uw1SwAAAQH/////AAAAABVgiQoCAAAAAAAIAAAAU3ViRXJyb3IBADZLAC8APzZLAAAAAf////8BAf////8AAAAABGCACgEAAAAAAAgAAABDb3VudGVycwEAN0sALwA6N0sAAP////8GAAAAFWCJCgIAAAAAAAoAAABTdGF0ZUVycm9yAQA4SwAvAQANTThLAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBADlLAC4ARDlLAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAOksALgBEOksAAAYBAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQA7SwAuAEQ7SwAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFN0YXRlT3BlcmF0aW9uYWxCeU1ldGhvZAEAPUsALwEADU09SwAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQA+SwAuAEQ+SwAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAD9LAC4ARD9LAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAQEsALgBEQEsAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlQYXJlbnQBAEJLAC8BAA1NQksAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAQ0sALgBEQ0sAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQBESwAuAERESwAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAEVLAC4AREVLAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAZAAAAU3RhdGVPcGVyYXRpb25hbEZyb21FcnJvcgEAR0sALwEADU1HSwAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQBISwAuAERISwAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAElLAC4ARElLAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEASksALgBESksAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdGF0ZVBhdXNlZEJ5UGFyZW50AQBMSwAvAQANTUxLAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAE1LAC4ARE1LAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEATksALgBETksAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBPSwAuAERPSwAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFN0YXRlRGlzYWJsZWRCeU1ldGhvZAEAUUsALwEADU1RSwAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQBSSwAuAERSSwAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAFNLAC4ARFNLAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAVEsALgBEVEsAAAYAAAAAAQALTf////8BAf////8AAAAABGCACgEAAAAAAAoAAABMaXZlVmFsdWVzAQBWSwAvADpWSwAA/////wEAAAAVYIkKAgAAAAAADwAAAFJlc29sdmVkQWRkcmVzcwEAV0sALwA/V0sAAAAM/////wEB/////wEAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAFhLAC4ARFhLAAAGAAAAAAEAC03/////AQH/////AAAAAA==";

	private const string AddWriterGroup_InitializationString = "//////////8EYYIKBAAAAAAADgAAAEFkZFdyaXRlckdyb3VwAQATRAAvAQATRBNEAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAFEQALgBEFEQAAJYBAAAAAQAqAQEeAAAADQAAAENvbmZpZ3VyYXRpb24BAHg8/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAMEQALgBEMEQAAJYBAAAAAQAqAQEWAAAABwAAAEdyb3VwSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	private const string AddReaderGroup_InitializationString = "//////////8EYYIKBAAAAAAADgAAAEFkZFJlYWRlckdyb3VwAQA5RAAvAQA5RDlEAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAY0QALgBEY0QAAJYBAAAAAQAqAQEeAAAADQAAAENvbmZpZ3VyYXRpb24BAKA8/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAZEQALgBEZEQAAJYBAAAAAQAqAQEWAAAABwAAAEdyb3VwSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	private const string RemoveGroup_InitializationString = "//////////8EYYIKBAAAAAAACwAAAFJlbW92ZUdyb3VwAQCRNwAvAQCRN5E3AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAkjcALgBEkjcAAJYBAAAAAQAqAQEWAAAABwAAAEdyb3VwSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	private const string InitializationString = "//////////8EYIACAQAAAAAAHAAAAFB1YlN1YkNvbm5lY3Rpb25UeXBlSW5zdGFuY2UBAIE3AQCBN4E3AAD/////CgAAABVgiQoCAAAAAAALAAAAUHVibGlzaGVySWQBAAM5AC4ARAM5AAAAGP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABUcmFuc3BvcnRQcm9maWxlVXJpAQCaQwAvAQC1P5pDAAAADP////8BAf////8BAAAAF2CJCgIAAAAAAAoAAABTZWxlY3Rpb25zAQAuRQAuAEQuRQAAABgBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABQAAABDb25uZWN0aW9uUHJvcGVydGllcwEATUQALgBETUQAAAEAxTgBAAAAAQAAAAAAAAABAf////8AAAAABGCACgEAAAAAAAcAAABBZGRyZXNzAQCNNwAvAQCZUo03AAD/////AQAAABVgiQoCAAAAAAAQAAAATmV0d29ya0ludGVyZmFjZQEAMkMALwEAtT8yQwAAAAz/////AQH/////AQAAABdgiQoCAAAAAAAKAAAAU2VsZWN0aW9ucwEAqEQALgBEqEQAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAAARggAoBAAAAAAARAAAAVHJhbnNwb3J0U2V0dGluZ3MBADNDAC8BADlFM0MAAP////8AAAAABGCACgEAAAAAAAYAAABTdGF0dXMBAAg5AC8BADM5CDkAAP////8BAAAAFWCJCgIAAAAAAAUAAABTdGF0ZQEACTkALwA/CTkAAAEANzn/////AQH/////AAAAAARggAoBAAAAAAALAAAARGlhZ25vc3RpY3MBAClLAC8BAEpNKUsAAP////8HAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQAqSwAvAD8qSwAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABUb3RhbEluZm9ybWF0aW9uAQArSwAvAQANTStLAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBACxLAC4ARCxLAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEALUsALgBELUsAAAEAEk3/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEALksALgBELksAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAVG90YWxFcnJvcgEAMEsALwEADU0wSwAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQAxSwAuAEQxSwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BADJLAC4ARDJLAAABABJN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBADNLAC4ARDNLAAABAAtN/////wEB/////wAAAAAEYYIKBAAAAAAABQAAAFJlc2V0AQA1SwAvAQDpTDVLAAABAf////8AAAAAFWCJCgIAAAAAAAgAAABTdWJFcnJvcgEANksALwA/NksAAAAB/////wEB/////wAAAAAEYIAKAQAAAAAACAAAAENvdW50ZXJzAQA3SwAvADo3SwAA/////wYAAAAVYIkKAgAAAAAACgAAAFN0YXRlRXJyb3IBADhLAC8BAA1NOEsAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAOUsALgBEOUsAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQA6SwAuAEQ6SwAABgEAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBADtLAC4ARDtLAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAYAAAAU3RhdGVPcGVyYXRpb25hbEJ5TWV0aG9kAQA9SwAvAQANTT1LAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAD5LAC4ARD5LAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAP0sALgBEP0sAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBASwAuAERASwAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFN0YXRlT3BlcmF0aW9uYWxCeVBhcmVudAEAQksALwEADU1CSwAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQBDSwAuAERDSwAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAERLAC4ARERLAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEARUsALgBERUsAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABkAAABTdGF0ZU9wZXJhdGlvbmFsRnJvbUVycm9yAQBHSwAvAQANTUdLAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAEhLAC4AREhLAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEASUsALgBESUsAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBKSwAuAERKSwAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFN0YXRlUGF1c2VkQnlQYXJlbnQBAExLAC8BAA1NTEsAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEATUsALgBETUsAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQBOSwAuAEROSwAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAE9LAC4ARE9LAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAVAAAAU3RhdGVEaXNhYmxlZEJ5TWV0aG9kAQBRSwAvAQANTVFLAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAFJLAC4ARFJLAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAU0sALgBEU0sAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBUSwAuAERUSwAABgAAAAABAAtN/////wEB/////wAAAAAEYIAKAQAAAAAACgAAAExpdmVWYWx1ZXMBAFZLAC8AOlZLAAD/////AQAAABVgiQoCAAAAAAAPAAAAUmVzb2x2ZWRBZGRyZXNzAQBXSwAvAD9XSwAAAAz/////AQH/////AQAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAWEsALgBEWEsAAAYAAAAAAQALTf////8BAf////8AAAAABGGCCgQAAAAAAA4AAABBZGRXcml0ZXJHcm91cAEAE0QALwEAE0QTRAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBABREAC4ARBREAACWAQAAAAEAKgEBHgAAAA0AAABDb25maWd1cmF0aW9uAQB4PP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBADBEAC4ARDBEAACWAQAAAAEAKgEBFgAAAAcAAABHcm91cElkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAOAAAAQWRkUmVhZGVyR3JvdXABADlEAC8BADlEOUQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBjRAAuAERjRAAAlgEAAAABACoBAR4AAAANAAAAQ29uZmlndXJhdGlvbgEAoDz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQBkRAAuAERkRAAAlgEAAAABACoBARYAAAAHAAAAR3JvdXBJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACwAAAFJlbW92ZUdyb3VwAQCRNwAvAQCRN5E3AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAkjcALgBEkjcAAJYBAAAAAQAqAQEWAAAABwAAAEdyb3VwSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	private PropertyState m_publisherId;

	private SelectionListState<string> m_transportProfileUri;

	private PropertyState<KeyValuePair[]> m_connectionProperties;

	private NetworkAddressState m_address;

	private ConnectionTransportState m_transportSettings;

	private PubSubStatusState m_status;

	private PubSubDiagnosticsConnectionState m_diagnostics;

	private PubSubConnectionTypeAddWriterGroupMethodState m_addWriterGroupMethod;

	private PubSubConnectionAddReaderGroupGroupMethodState m_addReaderGroupMethod;

	private PubSubConnectionTypeRemoveGroupMethodState m_removeGroupMethod;

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

	public SelectionListState<string> TransportProfileUri
	{
		get
		{
			return m_transportProfileUri;
		}
		set
		{
			if (m_transportProfileUri != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_transportProfileUri = value;
		}
	}

	public PropertyState<KeyValuePair[]> ConnectionProperties
	{
		get
		{
			return m_connectionProperties;
		}
		set
		{
			if (m_connectionProperties != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_connectionProperties = value;
		}
	}

	public NetworkAddressState Address
	{
		get
		{
			return m_address;
		}
		set
		{
			if (m_address != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_address = value;
		}
	}

	public ConnectionTransportState TransportSettings
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

	public PubSubDiagnosticsConnectionState Diagnostics
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

	public PubSubConnectionTypeAddWriterGroupMethodState AddWriterGroup
	{
		get
		{
			return m_addWriterGroupMethod;
		}
		set
		{
			if (m_addWriterGroupMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_addWriterGroupMethod = value;
		}
	}

	public PubSubConnectionAddReaderGroupGroupMethodState AddReaderGroup
	{
		get
		{
			return m_addReaderGroupMethod;
		}
		set
		{
			if (m_addReaderGroupMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_addReaderGroupMethod = value;
		}
	}

	public PubSubConnectionTypeRemoveGroupMethodState RemoveGroup
	{
		get
		{
			return m_removeGroupMethod;
		}
		set
		{
			if (m_removeGroupMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_removeGroupMethod = value;
		}
	}

	public PubSubConnectionState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(14209u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHAAAAFB1YlN1YkNvbm5lY3Rpb25UeXBlSW5zdGFuY2UBAIE3AQCBN4E3AAD/////CgAAABVgiQoCAAAAAAALAAAAUHVibGlzaGVySWQBAAM5AC4ARAM5AAAAGP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABUcmFuc3BvcnRQcm9maWxlVXJpAQCaQwAvAQC1P5pDAAAADP////8BAf////8BAAAAF2CJCgIAAAAAAAoAAABTZWxlY3Rpb25zAQAuRQAuAEQuRQAAABgBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABQAAABDb25uZWN0aW9uUHJvcGVydGllcwEATUQALgBETUQAAAEAxTgBAAAAAQAAAAAAAAABAf////8AAAAABGCACgEAAAAAAAcAAABBZGRyZXNzAQCNNwAvAQCZUo03AAD/////AQAAABVgiQoCAAAAAAAQAAAATmV0d29ya0ludGVyZmFjZQEAMkMALwEAtT8yQwAAAAz/////AQH/////AQAAABdgiQoCAAAAAAAKAAAAU2VsZWN0aW9ucwEAqEQALgBEqEQAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAAARggAoBAAAAAAARAAAAVHJhbnNwb3J0U2V0dGluZ3MBADNDAC8BADlFM0MAAP////8AAAAABGCACgEAAAAAAAYAAABTdGF0dXMBAAg5AC8BADM5CDkAAP////8BAAAAFWCJCgIAAAAAAAUAAABTdGF0ZQEACTkALwA/CTkAAAEANzn/////AQH/////AAAAAARggAoBAAAAAAALAAAARGlhZ25vc3RpY3MBAClLAC8BAEpNKUsAAP////8HAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQAqSwAvAD8qSwAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABUb3RhbEluZm9ybWF0aW9uAQArSwAvAQANTStLAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBACxLAC4ARCxLAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEALUsALgBELUsAAAEAEk3/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEALksALgBELksAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAVG90YWxFcnJvcgEAMEsALwEADU0wSwAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQAxSwAuAEQxSwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BADJLAC4ARDJLAAABABJN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBADNLAC4ARDNLAAABAAtN/////wEB/////wAAAAAEYYIKBAAAAAAABQAAAFJlc2V0AQA1SwAvAQDpTDVLAAABAf////8AAAAAFWCJCgIAAAAAAAgAAABTdWJFcnJvcgEANksALwA/NksAAAAB/////wEB/////wAAAAAEYIAKAQAAAAAACAAAAENvdW50ZXJzAQA3SwAvADo3SwAA/////wYAAAAVYIkKAgAAAAAACgAAAFN0YXRlRXJyb3IBADhLAC8BAA1NOEsAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAOUsALgBEOUsAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQA6SwAuAEQ6SwAABgEAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBADtLAC4ARDtLAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAYAAAAU3RhdGVPcGVyYXRpb25hbEJ5TWV0aG9kAQA9SwAvAQANTT1LAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAD5LAC4ARD5LAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAP0sALgBEP0sAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBASwAuAERASwAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFN0YXRlT3BlcmF0aW9uYWxCeVBhcmVudAEAQksALwEADU1CSwAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQBDSwAuAERDSwAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAERLAC4ARERLAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEARUsALgBERUsAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABkAAABTdGF0ZU9wZXJhdGlvbmFsRnJvbUVycm9yAQBHSwAvAQANTUdLAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAEhLAC4AREhLAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEASUsALgBESUsAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBKSwAuAERKSwAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFN0YXRlUGF1c2VkQnlQYXJlbnQBAExLAC8BAA1NTEsAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEATUsALgBETUsAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQBOSwAuAEROSwAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAE9LAC4ARE9LAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAVAAAAU3RhdGVEaXNhYmxlZEJ5TWV0aG9kAQBRSwAvAQANTVFLAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAFJLAC4ARFJLAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAU0sALgBEU0sAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBUSwAuAERUSwAABgAAAAABAAtN/////wEB/////wAAAAAEYIAKAQAAAAAACgAAAExpdmVWYWx1ZXMBAFZLAC8AOlZLAAD/////AQAAABVgiQoCAAAAAAAPAAAAUmVzb2x2ZWRBZGRyZXNzAQBXSwAvAD9XSwAAAAz/////AQH/////AQAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAWEsALgBEWEsAAAYAAAAAAQALTf////8BAf////8AAAAABGGCCgQAAAAAAA4AAABBZGRXcml0ZXJHcm91cAEAE0QALwEAE0QTRAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBABREAC4ARBREAACWAQAAAAEAKgEBHgAAAA0AAABDb25maWd1cmF0aW9uAQB4PP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBADBEAC4ARDBEAACWAQAAAAEAKgEBFgAAAAcAAABHcm91cElkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAOAAAAQWRkUmVhZGVyR3JvdXABADlEAC8BADlEOUQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBjRAAuAERjRAAAlgEAAAABACoBAR4AAAANAAAAQ29uZmlndXJhdGlvbgEAoDz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQBkRAAuAERkRAAAlgEAAAABACoBARYAAAAHAAAAR3JvdXBJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACwAAAFJlbW92ZUdyb3VwAQCRNwAvAQCRN5E3AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAkjcALgBEkjcAAJYBAAAAAQAqAQEWAAAABwAAAEdyb3VwSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		if (TransportSettings != null)
		{
			TransportSettings.Initialize(context, "//////////8EYIAKAQAAAAAAEQAAAFRyYW5zcG9ydFNldHRpbmdzAQAzQwAvAQA5RTNDAAD/////AAAAAA==");
		}
		if (Diagnostics != null)
		{
			Diagnostics.Initialize(context, "//////////8EYIAKAQAAAAAACwAAAERpYWdub3N0aWNzAQApSwAvAQBKTSlLAAD/////BwAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAKksALwA/KksAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAVG90YWxJbmZvcm1hdGlvbgEAK0sALwEADU0rSwAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQAsSwAuAEQsSwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAC1LAC4ARC1LAAABABJN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAC5LAC4ARC5LAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFRvdGFsRXJyb3IBADBLAC8BAA1NMEsAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAMUsALgBEMUsAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQAySwAuAEQySwAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQAzSwAuAEQzSwAAAQALTf////8BAf////8AAAAABGGCCgQAAAAAAAUAAABSZXNldAEANUsALwEA6Uw1SwAAAQH/////AAAAABVgiQoCAAAAAAAIAAAAU3ViRXJyb3IBADZLAC8APzZLAAAAAf////8BAf////8AAAAABGCACgEAAAAAAAgAAABDb3VudGVycwEAN0sALwA6N0sAAP////8GAAAAFWCJCgIAAAAAAAoAAABTdGF0ZUVycm9yAQA4SwAvAQANTThLAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBADlLAC4ARDlLAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAOksALgBEOksAAAYBAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQA7SwAuAEQ7SwAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFN0YXRlT3BlcmF0aW9uYWxCeU1ldGhvZAEAPUsALwEADU09SwAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQA+SwAuAEQ+SwAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAD9LAC4ARD9LAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAQEsALgBEQEsAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlQYXJlbnQBAEJLAC8BAA1NQksAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAQ0sALgBEQ0sAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQBESwAuAERESwAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAEVLAC4AREVLAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAZAAAAU3RhdGVPcGVyYXRpb25hbEZyb21FcnJvcgEAR0sALwEADU1HSwAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQBISwAuAERISwAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAElLAC4ARElLAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEASksALgBESksAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdGF0ZVBhdXNlZEJ5UGFyZW50AQBMSwAvAQANTUxLAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAE1LAC4ARE1LAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEATksALgBETksAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBPSwAuAERPSwAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFN0YXRlRGlzYWJsZWRCeU1ldGhvZAEAUUsALwEADU1RSwAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQBSSwAuAERSSwAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAFNLAC4ARFNLAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAVEsALgBEVEsAAAYAAAAAAQALTf////8BAf////8AAAAABGCACgEAAAAAAAoAAABMaXZlVmFsdWVzAQBWSwAvADpWSwAA/////wEAAAAVYIkKAgAAAAAADwAAAFJlc29sdmVkQWRkcmVzcwEAV0sALwA/V0sAAAAM/////wEB/////wEAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAFhLAC4ARFhLAAAGAAAAAAEAC03/////AQH/////AAAAAA==");
		}
		if (AddWriterGroup != null)
		{
			AddWriterGroup.Initialize(context, "//////////8EYYIKBAAAAAAADgAAAEFkZFdyaXRlckdyb3VwAQATRAAvAQATRBNEAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAFEQALgBEFEQAAJYBAAAAAQAqAQEeAAAADQAAAENvbmZpZ3VyYXRpb24BAHg8/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAMEQALgBEMEQAAJYBAAAAAQAqAQEWAAAABwAAAEdyb3VwSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
		}
		if (AddReaderGroup != null)
		{
			AddReaderGroup.Initialize(context, "//////////8EYYIKBAAAAAAADgAAAEFkZFJlYWRlckdyb3VwAQA5RAAvAQA5RDlEAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAY0QALgBEY0QAAJYBAAAAAQAqAQEeAAAADQAAAENvbmZpZ3VyYXRpb24BAKA8/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAZEQALgBEZEQAAJYBAAAAAQAqAQEWAAAABwAAAEdyb3VwSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
		}
		if (RemoveGroup != null)
		{
			RemoveGroup.Initialize(context, "//////////8EYYIKBAAAAAAACwAAAFJlbW92ZUdyb3VwAQCRNwAvAQCRN5E3AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAkjcALgBEkjcAAJYBAAAAAQAqAQEWAAAABwAAAEdyb3VwSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_publisherId != null)
		{
			children.Add(m_publisherId);
		}
		if (m_transportProfileUri != null)
		{
			children.Add(m_transportProfileUri);
		}
		if (m_connectionProperties != null)
		{
			children.Add(m_connectionProperties);
		}
		if (m_address != null)
		{
			children.Add(m_address);
		}
		if (m_transportSettings != null)
		{
			children.Add(m_transportSettings);
		}
		if (m_status != null)
		{
			children.Add(m_status);
		}
		if (m_diagnostics != null)
		{
			children.Add(m_diagnostics);
		}
		if (m_addWriterGroupMethod != null)
		{
			children.Add(m_addWriterGroupMethod);
		}
		if (m_addReaderGroupMethod != null)
		{
			children.Add(m_addReaderGroupMethod);
		}
		if (m_removeGroupMethod != null)
		{
			children.Add(m_removeGroupMethod);
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
		case "TransportProfileUri":
			if (createOrReplace && TransportProfileUri == null)
			{
				if (replacement == null)
				{
					TransportProfileUri = new SelectionListState<string>(this);
				}
				else
				{
					TransportProfileUri = (SelectionListState<string>)replacement;
				}
			}
			baseInstanceState = TransportProfileUri;
			break;
		case "ConnectionProperties":
			if (createOrReplace && ConnectionProperties == null)
			{
				if (replacement == null)
				{
					ConnectionProperties = new PropertyState<KeyValuePair[]>(this);
				}
				else
				{
					ConnectionProperties = (PropertyState<KeyValuePair[]>)replacement;
				}
			}
			baseInstanceState = ConnectionProperties;
			break;
		case "Address":
			if (createOrReplace && Address == null)
			{
				if (replacement == null)
				{
					Address = new NetworkAddressState(this);
				}
				else
				{
					Address = (NetworkAddressState)replacement;
				}
			}
			baseInstanceState = Address;
			break;
		case "TransportSettings":
			if (createOrReplace && TransportSettings == null)
			{
				if (replacement == null)
				{
					TransportSettings = new ConnectionTransportState(this);
				}
				else
				{
					TransportSettings = (ConnectionTransportState)replacement;
				}
			}
			baseInstanceState = TransportSettings;
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
					Diagnostics = new PubSubDiagnosticsConnectionState(this);
				}
				else
				{
					Diagnostics = (PubSubDiagnosticsConnectionState)replacement;
				}
			}
			baseInstanceState = Diagnostics;
			break;
		case "AddWriterGroup":
			if (createOrReplace && AddWriterGroup == null)
			{
				if (replacement == null)
				{
					AddWriterGroup = new PubSubConnectionTypeAddWriterGroupMethodState(this);
				}
				else
				{
					AddWriterGroup = (PubSubConnectionTypeAddWriterGroupMethodState)replacement;
				}
			}
			baseInstanceState = AddWriterGroup;
			break;
		case "AddReaderGroup":
			if (createOrReplace && AddReaderGroup == null)
			{
				if (replacement == null)
				{
					AddReaderGroup = new PubSubConnectionAddReaderGroupGroupMethodState(this);
				}
				else
				{
					AddReaderGroup = (PubSubConnectionAddReaderGroupGroupMethodState)replacement;
				}
			}
			baseInstanceState = AddReaderGroup;
			break;
		case "RemoveGroup":
			if (createOrReplace && RemoveGroup == null)
			{
				if (replacement == null)
				{
					RemoveGroup = new PubSubConnectionTypeRemoveGroupMethodState(this);
				}
				else
				{
					RemoveGroup = (PubSubConnectionTypeRemoveGroupMethodState)replacement;
				}
			}
			baseInstanceState = RemoveGroup;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
