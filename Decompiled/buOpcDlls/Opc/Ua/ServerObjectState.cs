using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ServerObjectState : BaseObjectState
{
	private const string UrisVersion_InitializationString = "//////////8VcIkKAgAAAAAACwAAAFVyaXNWZXJzaW9uAQCbOgAuAESbOgAAAQAGUv////8BAQAAAAAAQI9A/////wAAAAA=";

	private const string EstimatedReturnTime_InitializationString = "//////////8VcIkKAgAAAAAAEwAAAEVzdGltYXRlZFJldHVyblRpbWUBAFIyAC4ARFIyAAAADf////8BAQAAAAAAQI9A/////wAAAAA=";

	private const string LocalTime_InitializationString = "//////////8VcIkKAgAAAAAACQAAAExvY2FsVGltZQEAzEQALgBEzEQAAAEA0CL/////AQEAAAAAAECPQP////8AAAAA";

	private const string Namespaces_InitializationString = "//////////8EYIAKAQAAAAAACgAAAE5hbWVzcGFjZXMBAActAC8BAH0tBy0AAP////8AAAAA";

	private const string GetMonitoredItems_InitializationString = "//////////8EYYIKBAAAAAAAEQAAAEdldE1vbml0b3JlZEl0ZW1zAQDhLAAvAQDhLOEsAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA4iwALgBE4iwAAJYBAAAAAQAqAQEdAAAADgAAAFN1YnNjcmlwdGlvbklkAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDjLAAuAETjLAAAlgIAAAABACoBASAAAAANAAAAU2VydmVySGFuZGxlcwAHAQAAAAEAAAAAAAAAAAEAKgEBIAAAAA0AAABDbGllbnRIYW5kbGVzAAcBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private const string ResendData_InitializationString = "//////////8EYYIKBAAAAAAACgAAAFJlc2VuZERhdGEBAEcyAC8BAEcyRzIAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBIMgAuAERIMgAAlgEAAAABACoBAR0AAAAOAAAAU3Vic2NyaXB0aW9uSWQAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	private const string SetSubscriptionDurable_InitializationString = "//////////8EYYIKBAAAAAAAFgAAAFNldFN1YnNjcmlwdGlvbkR1cmFibGUBAMoxAC8BAMoxyjEAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDLMQAuAETLMQAAlgIAAAABACoBAR0AAAAOAAAAU3Vic2NyaXB0aW9uSWQAB/////8AAAAAAAEAKgEBHgAAAA8AAABMaWZldGltZUluSG91cnMAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAMwxAC4ARMwxAACWAQAAAAEAKgEBJQAAABYAAABSZXZpc2VkTGlmZXRpbWVJbkhvdXJzAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	private const string RequestServerStateChange_InitializationString = "//////////8EYYIKBAAAAAAAGAAAAFJlcXVlc3RTZXJ2ZXJTdGF0ZUNoYW5nZQEAUzIALwEAUzJTMgAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAFQyAC4ARFQyAACWBQAAAAEAKgEBFgAAAAUAAABTdGF0ZQEAVAP/////AAAAAAABACoBASIAAAATAAAARXN0aW1hdGVkUmV0dXJuVGltZQAN/////wAAAAAAAQAqAQEiAAAAEwAAAFNlY29uZHNUaWxsU2h1dGRvd24AB/////8AAAAAAAEAKgEBFQAAAAYAAABSZWFzb24AFf////8AAAAAAAEAKgEBFgAAAAcAAABSZXN0YXJ0AAH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	private const string InitializationString = "//////////8EYIACAQAAAAAAEgAAAFNlcnZlclR5cGVJbnN0YW5jZQEA1AcBANQH1AcAAP////8RAAAAF3CJCgIAAAAAAAsAAABTZXJ2ZXJBcnJheQEA1QcALgBE1QcAAAAMAQAAAAEAAAAAAAAAAQEAAAAAAECPQP////8AAAAAF3CJCgIAAAAAAA4AAABOYW1lc3BhY2VBcnJheQEA1gcALgBE1gcAAAAMAQAAAAEAAAAAAAAAAQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAAsAAABVcmlzVmVyc2lvbgEAmzoALgBEmzoAAAEABlL/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAAwAAABTZXJ2ZXJTdGF0dXMBANcHAC8BAFoI1wcAAAEAXgP/////AQEAAAAAAECPQP////8GAAAAFWCJCgIAAAAAAAkAAABTdGFydFRpbWUBAAIMAC8APwIMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAEN1cnJlbnRUaW1lAQADDAAvAD8DDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAUAAABTdGF0ZQEABAwALwA/BAwAAAEAVAP/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAQnVpbGRJbmZvAQAFDAAvAQDrCwUMAAABAFIB/////wEB/////wYAAAAVcIkKAgAAAAAACgAAAFByb2R1Y3RVcmkBAAYMAC8APwYMAAAADP////8BAQAAAAAAQI9A/////wAAAAAVcIkKAgAAAAAAEAAAAE1hbnVmYWN0dXJlck5hbWUBAAcMAC8APwcMAAAADP////8BAQAAAAAAQI9A/////wAAAAAVcIkKAgAAAAAACwAAAFByb2R1Y3ROYW1lAQAIDAAvAD8IDAAAAAz/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAA8AAABTb2Z0d2FyZVZlcnNpb24BAAkMAC8APwkMAAAADP////8BAQAAAAAAQI9A/////wAAAAAVcIkKAgAAAAAACwAAAEJ1aWxkTnVtYmVyAQAKDAAvAD8KDAAAAAz/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAAkAAABCdWlsZERhdGUBAAsMAC8APwsMAAABACYB/////wEBAAAAAABAj0D/////AAAAABVgiQoCAAAAAAATAAAAU2Vjb25kc1RpbGxTaHV0ZG93bgEADAwALwA/DAwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFNodXRkb3duUmVhc29uAQANDAAvAD8NDAAAABX/////AQH/////AAAAABVwiQoCAAAAAAAMAAAAU2VydmljZUxldmVsAQDYBwAuAETYBwAAAAP/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAAgAAABBdWRpdGluZwEAtgoALgBEtgoAAAAB/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAATAAAARXN0aW1hdGVkUmV0dXJuVGltZQEAUjIALgBEUjIAAAAN/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAAJAAAATG9jYWxUaW1lAQDMRAAuAETMRAAAAQDQIv////8BAQAAAAAAQI9A/////wAAAAAEYIAKAQAAAAAAEgAAAFNlcnZlckNhcGFiaWxpdGllcwEA2QcALwEA3QfZBwAA/////wkAAAAXYIkKAgAAAAAAEgAAAFNlcnZlclByb2ZpbGVBcnJheQEADgwALgBEDgwAAAAMAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAANAAAATG9jYWxlSWRBcnJheQEADwwALgBEDwwAAAEAJwEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABYAAABNaW5TdXBwb3J0ZWRTYW1wbGVSYXRlAQAQDAAuAEQQDAAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAABsAAABNYXhCcm93c2VDb250aW51YXRpb25Qb2ludHMBABEMAC4ARBEMAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABoAAABNYXhRdWVyeUNvbnRpbnVhdGlvblBvaW50cwEAEgwALgBEEgwAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAAHAAAAE1heEhpc3RvcnlDb250aW51YXRpb25Qb2ludHMBABMMAC4ARBMMAAAABf////8BAf////8AAAAAF2CJCgIAAAAAABQAAABTb2Z0d2FyZUNlcnRpZmljYXRlcwEAFAwALgBEFAwAAAEAWAEBAAAAAQAAAAAAAAABAf////8AAAAABGCACgEAAAAAAA4AAABNb2RlbGxpbmdSdWxlcwEAFQwALwA9FQwAAP////8AAAAABGCACgEAAAAAABIAAABBZ2dyZWdhdGVGdW5jdGlvbnMBABYMAC8APRYMAAD/////AAAAAARggAoBAAAAAAARAAAAU2VydmVyRGlhZ25vc3RpY3MBANoHAC8BAOQH2gcAAP////8EAAAAFWCJCgIAAAAAABgAAABTZXJ2ZXJEaWFnbm9zdGljc1N1bW1hcnkBABcMAC8BAGYIFwwAAAEAWwP/////AQH/////DAAAABVgiQoCAAAAAAAPAAAAU2VydmVyVmlld0NvdW50AQAYDAAvAD8YDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAATAAAAQ3VycmVudFNlc3Npb25Db3VudAEAGQwALwA/GQwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAEN1bXVsYXRlZFNlc3Npb25Db3VudAEAGgwALwA/GgwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHAAAAFNlY3VyaXR5UmVqZWN0ZWRTZXNzaW9uQ291bnQBABsMAC8APxsMAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABSZWplY3RlZFNlc3Npb25Db3VudAEAHAwALwA/HAwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFNlc3Npb25UaW1lb3V0Q291bnQBAB0MAC8APx0MAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABEAAABTZXNzaW9uQWJvcnRDb3VudAEAHgwALwA/HgwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFwAAAFB1Ymxpc2hpbmdJbnRlcnZhbENvdW50AQAgDAAvAD8gDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAYAAAAQ3VycmVudFN1YnNjcmlwdGlvbkNvdW50AQAhDAAvAD8hDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAaAAAAQ3VtdWxhdGVkU3Vic2NyaXB0aW9uQ291bnQBACIMAC8APyIMAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAB0AAABTZWN1cml0eVJlamVjdGVk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";

	private PropertyState<string[]> m_serverArray;

	private PropertyState<string[]> m_namespaceArray;

	private PropertyState<uint> m_urisVersion;

	private ServerStatusState m_serverStatus;

	private PropertyState<byte> m_serviceLevel;

	private PropertyState<bool> m_auditing;

	private PropertyState<DateTime> m_estimatedReturnTime;

	private PropertyState<TimeZoneDataType> m_localTime;

	private ServerCapabilitiesState m_serverCapabilities;

	private ServerDiagnosticsState m_serverDiagnostics;

	private VendorServerInfoState m_vendorServerInfo;

	private ServerRedundancyState m_serverRedundancy;

	private NamespacesState m_namespaces;

	private GetMonitoredItemsMethodState m_getMonitoredItemsMethod;

	private ResendDataMethodState m_resendDataMethod;

	private SetSubscriptionDurableMethodState m_setSubscriptionDurableMethod;

	private RequestServerStateChangeMethodState m_requestServerStateChangeMethod;

	public PropertyState<string[]> ServerArray
	{
		get
		{
			return m_serverArray;
		}
		set
		{
			if (m_serverArray != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_serverArray = value;
		}
	}

	public PropertyState<string[]> NamespaceArray
	{
		get
		{
			return m_namespaceArray;
		}
		set
		{
			if (m_namespaceArray != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_namespaceArray = value;
		}
	}

	public PropertyState<uint> UrisVersion
	{
		get
		{
			return m_urisVersion;
		}
		set
		{
			if (m_urisVersion != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_urisVersion = value;
		}
	}

	public ServerStatusState ServerStatus
	{
		get
		{
			return m_serverStatus;
		}
		set
		{
			if (m_serverStatus != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_serverStatus = value;
		}
	}

	public PropertyState<byte> ServiceLevel
	{
		get
		{
			return m_serviceLevel;
		}
		set
		{
			if (m_serviceLevel != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_serviceLevel = value;
		}
	}

	public PropertyState<bool> Auditing
	{
		get
		{
			return m_auditing;
		}
		set
		{
			if (m_auditing != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_auditing = value;
		}
	}

	public PropertyState<DateTime> EstimatedReturnTime
	{
		get
		{
			return m_estimatedReturnTime;
		}
		set
		{
			if (m_estimatedReturnTime != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_estimatedReturnTime = value;
		}
	}

	public PropertyState<TimeZoneDataType> LocalTime
	{
		get
		{
			return m_localTime;
		}
		set
		{
			if (m_localTime != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_localTime = value;
		}
	}

	public ServerCapabilitiesState ServerCapabilities
	{
		get
		{
			return m_serverCapabilities;
		}
		set
		{
			if (m_serverCapabilities != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_serverCapabilities = value;
		}
	}

	public ServerDiagnosticsState ServerDiagnostics
	{
		get
		{
			return m_serverDiagnostics;
		}
		set
		{
			if (m_serverDiagnostics != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_serverDiagnostics = value;
		}
	}

	public VendorServerInfoState VendorServerInfo
	{
		get
		{
			return m_vendorServerInfo;
		}
		set
		{
			if (m_vendorServerInfo != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_vendorServerInfo = value;
		}
	}

	public ServerRedundancyState ServerRedundancy
	{
		get
		{
			return m_serverRedundancy;
		}
		set
		{
			if (m_serverRedundancy != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_serverRedundancy = value;
		}
	}

	public NamespacesState Namespaces
	{
		get
		{
			return m_namespaces;
		}
		set
		{
			if (m_namespaces != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_namespaces = value;
		}
	}

	public GetMonitoredItemsMethodState GetMonitoredItems
	{
		get
		{
			return m_getMonitoredItemsMethod;
		}
		set
		{
			if (m_getMonitoredItemsMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_getMonitoredItemsMethod = value;
		}
	}

	public ResendDataMethodState ResendData
	{
		get
		{
			return m_resendDataMethod;
		}
		set
		{
			if (m_resendDataMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_resendDataMethod = value;
		}
	}

	public SetSubscriptionDurableMethodState SetSubscriptionDurable
	{
		get
		{
			return m_setSubscriptionDurableMethod;
		}
		set
		{
			if (m_setSubscriptionDurableMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_setSubscriptionDurableMethod = value;
		}
	}

	public RequestServerStateChangeMethodState RequestServerStateChange
	{
		get
		{
			return m_requestServerStateChangeMethod;
		}
		set
		{
			if (m_requestServerStateChangeMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_requestServerStateChangeMethod = value;
		}
	}

	public ServerObjectState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2004u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAEgAAAFNlcnZlclR5cGVJbnN0YW5jZQEA1AcBANQH1AcAAP////8RAAAAF3CJCgIAAAAAAAsAAABTZXJ2ZXJBcnJheQEA1QcALgBE1QcAAAAMAQAAAAEAAAAAAAAAAQEAAAAAAECPQP////8AAAAAF3CJCgIAAAAAAA4AAABOYW1lc3BhY2VBcnJheQEA1gcALgBE1gcAAAAMAQAAAAEAAAAAAAAAAQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAAsAAABVcmlzVmVyc2lvbgEAmzoALgBEmzoAAAEABlL/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAAwAAABTZXJ2ZXJTdGF0dXMBANcHAC8BAFoI1wcAAAEAXgP/////AQEAAAAAAECPQP////8GAAAAFWCJCgIAAAAAAAkAAABTdGFydFRpbWUBAAIMAC8APwIMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAEN1cnJlbnRUaW1lAQADDAAvAD8DDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAUAAABTdGF0ZQEABAwALwA/BAwAAAEAVAP/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAQnVpbGRJbmZvAQAFDAAvAQDrCwUMAAABAFIB/////wEB/////wYAAAAVcIkKAgAAAAAACgAAAFByb2R1Y3RVcmkBAAYMAC8APwYMAAAADP////8BAQAAAAAAQI9A/////wAAAAAVcIkKAgAAAAAAEAAAAE1hbnVmYWN0dXJlck5hbWUBAAcMAC8APwcMAAAADP////8BAQAAAAAAQI9A/////wAAAAAVcIkKAgAAAAAACwAAAFByb2R1Y3ROYW1lAQAIDAAvAD8IDAAAAAz/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAA8AAABTb2Z0d2FyZVZlcnNpb24BAAkMAC8APwkMAAAADP////8BAQAAAAAAQI9A/////wAAAAAVcIkKAgAAAAAACwAAAEJ1aWxkTnVtYmVyAQAKDAAvAD8KDAAAAAz/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAAkAAABCdWlsZERhdGUBAAsMAC8APwsMAAABACYB/////wEBAAAAAABAj0D/////AAAAABVgiQoCAAAAAAATAAAAU2Vjb25kc1RpbGxTaHV0ZG93bgEADAwALwA/DAwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFNodXRkb3duUmVhc29uAQANDAAvAD8NDAAAABX/////AQH/////AAAAABVwiQoCAAAAAAAMAAAAU2VydmljZUxldmVsAQDYBwAuAETYBwAAAAP/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAAgAAABBdWRpdGluZwEAtgoALgBEtgoAAAAB/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAATAAAARXN0aW1hdGVkUmV0dXJuVGltZQEAUjIALgBEUjIAAAAN/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAAJAAAATG9jYWxUaW1lAQDMRAAuAETMRAAAAQDQIv////8BAQAAAAAAQI9A/////wAAAAAEYIAKAQAAAAAAEgAAAFNlcnZlckNhcGFiaWxpdGllcwEA2QcALwEA3QfZBwAA/////wkAAAAXYIkKAgAAAAAAEgAAAFNlcnZlclByb2ZpbGVBcnJheQEADgwALgBEDgwAAAAMAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAANAAAATG9jYWxlSWRBcnJheQEADwwALgBEDwwAAAEAJwEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABYAAABNaW5TdXBwb3J0ZWRTYW1wbGVSYXRlAQAQDAAuAEQQDAAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAABsAAABNYXhCcm93c2VDb250aW51YXRpb25Qb2ludHMBABEMAC4ARBEMAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABoAAABNYXhRdWVyeUNvbnRpbnVhdGlvblBvaW50cwEAEgwALgBEEgwAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAAHAAAAE1heEhpc3RvcnlDb250aW51YXRpb25Qb2ludHMBABMMAC4ARBMMAAAABf////8BAf////8AAAAAF2CJCgIAAAAAABQAAABTb2Z0d2FyZUNlcnRpZmljYXRlcwEAFAwALgBEFAwAAAEAWAEBAAAAAQAAAAAAAAABAf////8AAAAABGCACgEAAAAAAA4AAABNb2RlbGxpbmdSdWxlcwEAFQwALwA9FQwAAP////8AAAAABGCACgEAAAAAABIAAABBZ2dyZWdhdGVGdW5jdGlvbnMBABYMAC8APRYMAAD/////AAAAAARggAoBAAAAAAARAAAAU2VydmVyRGlhZ25vc3RpY3MBANoHAC8BAOQH2gcAAP////8EAAAAFWCJCgIAAAAAABgAAABTZXJ2ZXJEaWFnbm9zdGljc1N1bW1hcnkBABcMAC8BAGYIFwwAAAEAWwP/////AQH/////DAAAABVgiQoCAAAAAAAPAAAAU2VydmVyVmlld0NvdW50AQAYDAAvAD8YDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAATAAAAQ3VycmVudFNlc3Npb25Db3VudAEAGQwALwA/GQwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAEN1bXVsYXRlZFNlc3Npb25Db3VudAEAGgwALwA/GgwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHAAAAFNlY3VyaXR5UmVqZWN0ZWRTZXNzaW9uQ291bnQBABsMAC8APxsMAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABSZWplY3RlZFNlc3Npb25Db3VudAEAHAwALwA/HAwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFNlc3Npb25UaW1lb3V0Q291bnQBAB0MAC8APx0MAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABEAAABTZXNzaW9uQWJvcnRDb3VudAEAHgwALwA/HgwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFwAAAFB1Ymxpc2hpbmdJbnRlcnZhbENvdW50AQAgDAAvAD8gDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAYAAAAQ3VycmVudFN1YnNjcmlwdGlvbkNvdW50AQAhDAAvAD8hDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAaAAAAQ3VtdWxhdGVkU3Vic2NyaXB0aW9uQ291bnQBACIMAC8APyIMAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAB0AAABTZWN1cml0eVJlamVjdGVk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");
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
		if (UrisVersion != null)
		{
			UrisVersion.Initialize(context, "//////////8VcIkKAgAAAAAACwAAAFVyaXNWZXJzaW9uAQCbOgAuAESbOgAAAQAGUv////8BAQAAAAAAQI9A/////wAAAAA=");
		}
		if (EstimatedReturnTime != null)
		{
			EstimatedReturnTime.Initialize(context, "//////////8VcIkKAgAAAAAAEwAAAEVzdGltYXRlZFJldHVyblRpbWUBAFIyAC4ARFIyAAAADf////8BAQAAAAAAQI9A/////wAAAAA=");
		}
		if (LocalTime != null)
		{
			LocalTime.Initialize(context, "//////////8VcIkKAgAAAAAACQAAAExvY2FsVGltZQEAzEQALgBEzEQAAAEA0CL/////AQEAAAAAAECPQP////8AAAAA");
		}
		if (Namespaces != null)
		{
			Namespaces.Initialize(context, "//////////8EYIAKAQAAAAAACgAAAE5hbWVzcGFjZXMBAActAC8BAH0tBy0AAP////8AAAAA");
		}
		if (GetMonitoredItems != null)
		{
			GetMonitoredItems.Initialize(context, "//////////8EYYIKBAAAAAAAEQAAAEdldE1vbml0b3JlZEl0ZW1zAQDhLAAvAQDhLOEsAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA4iwALgBE4iwAAJYBAAAAAQAqAQEdAAAADgAAAFN1YnNjcmlwdGlvbklkAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDjLAAuAETjLAAAlgIAAAABACoBASAAAAANAAAAU2VydmVySGFuZGxlcwAHAQAAAAEAAAAAAAAAAAEAKgEBIAAAAA0AAABDbGllbnRIYW5kbGVzAAcBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
		}
		if (ResendData != null)
		{
			ResendData.Initialize(context, "//////////8EYYIKBAAAAAAACgAAAFJlc2VuZERhdGEBAEcyAC8BAEcyRzIAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBIMgAuAERIMgAAlgEAAAABACoBAR0AAAAOAAAAU3Vic2NyaXB0aW9uSWQAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
		}
		if (SetSubscriptionDurable != null)
		{
			SetSubscriptionDurable.Initialize(context, "//////////8EYYIKBAAAAAAAFgAAAFNldFN1YnNjcmlwdGlvbkR1cmFibGUBAMoxAC8BAMoxyjEAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDLMQAuAETLMQAAlgIAAAABACoBAR0AAAAOAAAAU3Vic2NyaXB0aW9uSWQAB/////8AAAAAAAEAKgEBHgAAAA8AAABMaWZldGltZUluSG91cnMAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAMwxAC4ARMwxAACWAQAAAAEAKgEBJQAAABYAAABSZXZpc2VkTGlmZXRpbWVJbkhvdXJzAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
		}
		if (RequestServerStateChange != null)
		{
			RequestServerStateChange.Initialize(context, "//////////8EYYIKBAAAAAAAGAAAAFJlcXVlc3RTZXJ2ZXJTdGF0ZUNoYW5nZQEAUzIALwEAUzJTMgAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAFQyAC4ARFQyAACWBQAAAAEAKgEBFgAAAAUAAABTdGF0ZQEAVAP/////AAAAAAABACoBASIAAAATAAAARXN0aW1hdGVkUmV0dXJuVGltZQAN/////wAAAAAAAQAqAQEiAAAAEwAAAFNlY29uZHNUaWxsU2h1dGRvd24AB/////8AAAAAAAEAKgEBFQAAAAYAAABSZWFzb24AFf////8AAAAAAAEAKgEBFgAAAAcAAABSZXN0YXJ0AAH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_serverArray != null)
		{
			children.Add(m_serverArray);
		}
		if (m_namespaceArray != null)
		{
			children.Add(m_namespaceArray);
		}
		if (m_urisVersion != null)
		{
			children.Add(m_urisVersion);
		}
		if (m_serverStatus != null)
		{
			children.Add(m_serverStatus);
		}
		if (m_serviceLevel != null)
		{
			children.Add(m_serviceLevel);
		}
		if (m_auditing != null)
		{
			children.Add(m_auditing);
		}
		if (m_estimatedReturnTime != null)
		{
			children.Add(m_estimatedReturnTime);
		}
		if (m_localTime != null)
		{
			children.Add(m_localTime);
		}
		if (m_serverCapabilities != null)
		{
			children.Add(m_serverCapabilities);
		}
		if (m_serverDiagnostics != null)
		{
			children.Add(m_serverDiagnostics);
		}
		if (m_vendorServerInfo != null)
		{
			children.Add(m_vendorServerInfo);
		}
		if (m_serverRedundancy != null)
		{
			children.Add(m_serverRedundancy);
		}
		if (m_namespaces != null)
		{
			children.Add(m_namespaces);
		}
		if (m_getMonitoredItemsMethod != null)
		{
			children.Add(m_getMonitoredItemsMethod);
		}
		if (m_resendDataMethod != null)
		{
			children.Add(m_resendDataMethod);
		}
		if (m_setSubscriptionDurableMethod != null)
		{
			children.Add(m_setSubscriptionDurableMethod);
		}
		if (m_requestServerStateChangeMethod != null)
		{
			children.Add(m_requestServerStateChangeMethod);
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
		case "ServerArray":
			if (createOrReplace && ServerArray == null)
			{
				if (replacement == null)
				{
					ServerArray = new PropertyState<string[]>(this);
				}
				else
				{
					ServerArray = (PropertyState<string[]>)replacement;
				}
			}
			baseInstanceState = ServerArray;
			break;
		case "NamespaceArray":
			if (createOrReplace && NamespaceArray == null)
			{
				if (replacement == null)
				{
					NamespaceArray = new PropertyState<string[]>(this);
				}
				else
				{
					NamespaceArray = (PropertyState<string[]>)replacement;
				}
			}
			baseInstanceState = NamespaceArray;
			break;
		case "UrisVersion":
			if (createOrReplace && UrisVersion == null)
			{
				if (replacement == null)
				{
					UrisVersion = new PropertyState<uint>(this);
				}
				else
				{
					UrisVersion = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = UrisVersion;
			break;
		case "ServerStatus":
			if (createOrReplace && ServerStatus == null)
			{
				if (replacement == null)
				{
					ServerStatus = new ServerStatusState(this);
				}
				else
				{
					ServerStatus = (ServerStatusState)replacement;
				}
			}
			baseInstanceState = ServerStatus;
			break;
		case "ServiceLevel":
			if (createOrReplace && ServiceLevel == null)
			{
				if (replacement == null)
				{
					ServiceLevel = new PropertyState<byte>(this);
				}
				else
				{
					ServiceLevel = (PropertyState<byte>)replacement;
				}
			}
			baseInstanceState = ServiceLevel;
			break;
		case "Auditing":
			if (createOrReplace && Auditing == null)
			{
				if (replacement == null)
				{
					Auditing = new PropertyState<bool>(this);
				}
				else
				{
					Auditing = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = Auditing;
			break;
		case "EstimatedReturnTime":
			if (createOrReplace && EstimatedReturnTime == null)
			{
				if (replacement == null)
				{
					EstimatedReturnTime = new PropertyState<DateTime>(this);
				}
				else
				{
					EstimatedReturnTime = (PropertyState<DateTime>)replacement;
				}
			}
			baseInstanceState = EstimatedReturnTime;
			break;
		case "LocalTime":
			if (createOrReplace && LocalTime == null)
			{
				if (replacement == null)
				{
					LocalTime = new PropertyState<TimeZoneDataType>(this);
				}
				else
				{
					LocalTime = (PropertyState<TimeZoneDataType>)replacement;
				}
			}
			baseInstanceState = LocalTime;
			break;
		case "ServerCapabilities":
			if (createOrReplace && ServerCapabilities == null)
			{
				if (replacement == null)
				{
					ServerCapabilities = new ServerCapabilitiesState(this);
				}
				else
				{
					ServerCapabilities = (ServerCapabilitiesState)replacement;
				}
			}
			baseInstanceState = ServerCapabilities;
			break;
		case "ServerDiagnostics":
			if (createOrReplace && ServerDiagnostics == null)
			{
				if (replacement == null)
				{
					ServerDiagnostics = new ServerDiagnosticsState(this);
				}
				else
				{
					ServerDiagnostics = (ServerDiagnosticsState)replacement;
				}
			}
			baseInstanceState = ServerDiagnostics;
			break;
		case "VendorServerInfo":
			if (createOrReplace && VendorServerInfo == null)
			{
				if (replacement == null)
				{
					VendorServerInfo = new VendorServerInfoState(this);
				}
				else
				{
					VendorServerInfo = (VendorServerInfoState)replacement;
				}
			}
			baseInstanceState = VendorServerInfo;
			break;
		case "ServerRedundancy":
			if (createOrReplace && ServerRedundancy == null)
			{
				if (replacement == null)
				{
					ServerRedundancy = new ServerRedundancyState(this);
				}
				else
				{
					ServerRedundancy = (ServerRedundancyState)replacement;
				}
			}
			baseInstanceState = ServerRedundancy;
			break;
		case "Namespaces":
			if (createOrReplace && Namespaces == null)
			{
				if (replacement == null)
				{
					Namespaces = new NamespacesState(this);
				}
				else
				{
					Namespaces = (NamespacesState)replacement;
				}
			}
			baseInstanceState = Namespaces;
			break;
		case "GetMonitoredItems":
			if (createOrReplace && GetMonitoredItems == null)
			{
				if (replacement == null)
				{
					GetMonitoredItems = new GetMonitoredItemsMethodState(this);
				}
				else
				{
					GetMonitoredItems = (GetMonitoredItemsMethodState)replacement;
				}
			}
			baseInstanceState = GetMonitoredItems;
			break;
		case "ResendData":
			if (createOrReplace && ResendData == null)
			{
				if (replacement == null)
				{
					ResendData = new ResendDataMethodState(this);
				}
				else
				{
					ResendData = (ResendDataMethodState)replacement;
				}
			}
			baseInstanceState = ResendData;
			break;
		case "SetSubscriptionDurable":
			if (createOrReplace && SetSubscriptionDurable == null)
			{
				if (replacement == null)
				{
					SetSubscriptionDurable = new SetSubscriptionDurableMethodState(this);
				}
				else
				{
					SetSubscriptionDurable = (SetSubscriptionDurableMethodState)replacement;
				}
			}
			baseInstanceState = SetSubscriptionDurable;
			break;
		case "RequestServerStateChange":
			if (createOrReplace && RequestServerStateChange == null)
			{
				if (replacement == null)
				{
					RequestServerStateChange = new RequestServerStateChangeMethodState(this);
				}
				else
				{
					RequestServerStateChange = (RequestServerStateChangeMethodState)replacement;
				}
			}
			baseInstanceState = RequestServerStateChange;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
