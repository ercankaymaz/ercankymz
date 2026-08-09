using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ServerDiagnosticsState : BaseObjectState
{
	private const string SamplingIntervalDiagnosticsArray_InitializationString = "//////////8XYIkKAgAAAAAAIAAAAFNhbXBsaW5nSW50ZXJ2YWxEaWFnbm9zdGljc0FycmF5AQDmBwAvAQB0COYHAAABAFgDAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	private const string InitializationString = "//////////8EYIACAQAAAAAAHQAAAFNlcnZlckRpYWdub3N0aWNzVHlwZUluc3RhbmNlAQDkBwEA5AfkBwAA/////wUAAAAVYIkKAgAAAAAAGAAAAFNlcnZlckRpYWdub3N0aWNzU3VtbWFyeQEA5QcALwEAZgjlBwAAAQBbA/////8BAf////8MAAAAFWCJCgIAAAAAAA8AAABTZXJ2ZXJWaWV3Q291bnQBACwMAC8APywMAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABMAAABDdXJyZW50U2Vzc2lvbkNvdW50AQAtDAAvAD8tDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAVAAAAQ3VtdWxhdGVkU2Vzc2lvbkNvdW50AQAuDAAvAD8uDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAcAAAAU2VjdXJpdHlSZWplY3RlZFNlc3Npb25Db3VudAEALwwALwA/LwwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFAAAAFJlamVjdGVkU2Vzc2lvbkNvdW50AQAwDAAvAD8wDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAATAAAAU2Vzc2lvblRpbWVvdXRDb3VudAEAMQwALwA/MQwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAFNlc3Npb25BYm9ydENvdW50AQAyDAAvAD8yDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAXAAAAUHVibGlzaGluZ0ludGVydmFsQ291bnQBADQMAC8APzQMAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABgAAABDdXJyZW50U3Vic2NyaXB0aW9uQ291bnQBADUMAC8APzUMAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABoAAABDdW11bGF0ZWRTdWJzY3JpcHRpb25Db3VudAEANgwALwA/NgwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHQAAAFNlY3VyaXR5UmVqZWN0ZWRSZXF1ZXN0c0NvdW50AQA3DAAvAD83DAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAVAAAAUmVqZWN0ZWRSZXF1ZXN0c0NvdW50AQA4DAAvAD84DAAAAAf/////AQH/////AAAAABdgiQoCAAAAAAAgAAAAU2FtcGxpbmdJbnRlcnZhbERpYWdub3N0aWNzQXJyYXkBAOYHAC8BAHQI5gcAAAEAWAMBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABwAAABTdWJzY3JpcHRpb25EaWFnbm9zdGljc0FycmF5AQDnBwAvAQB7COcHAAABAGoDAQAAAAEAAAAAAAAAAQH/////AAAAAARggAoBAAAAAAAaAAAAU2Vzc2lvbnNEaWFnbm9zdGljc1N1bW1hcnkBALgKAC8BAOoHuAoAAP////8CAAAAF2CJCgIAAAAAABcAAABTZXNzaW9uRGlhZ25vc3RpY3NBcnJheQEAOQwALwEAlAg5DAAAAQBhAwEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAHwAAAFNlc3Npb25TZWN1cml0eURpYWdub3N0aWNzQXJyYXkBADoMAC8BAMMIOgwAAAEAZAMBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAsAAABFbmFibGVkRmxhZwEA6QcALgBE6QcAAAAB/////wMD/////wAAAAA=";

	private ServerDiagnosticsSummaryState m_serverDiagnosticsSummary;

	private SamplingIntervalDiagnosticsArrayState m_samplingIntervalDiagnosticsArray;

	private SubscriptionDiagnosticsArrayState m_subscriptionDiagnosticsArray;

	private SessionsDiagnosticsSummaryState m_sessionsDiagnosticsSummary;

	private PropertyState<bool> m_enabledFlag;

	public ServerDiagnosticsSummaryState ServerDiagnosticsSummary
	{
		get
		{
			return m_serverDiagnosticsSummary;
		}
		set
		{
			if (m_serverDiagnosticsSummary != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_serverDiagnosticsSummary = value;
		}
	}

	public SamplingIntervalDiagnosticsArrayState SamplingIntervalDiagnosticsArray
	{
		get
		{
			return m_samplingIntervalDiagnosticsArray;
		}
		set
		{
			if (m_samplingIntervalDiagnosticsArray != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_samplingIntervalDiagnosticsArray = value;
		}
	}

	public SubscriptionDiagnosticsArrayState SubscriptionDiagnosticsArray
	{
		get
		{
			return m_subscriptionDiagnosticsArray;
		}
		set
		{
			if (m_subscriptionDiagnosticsArray != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_subscriptionDiagnosticsArray = value;
		}
	}

	public SessionsDiagnosticsSummaryState SessionsDiagnosticsSummary
	{
		get
		{
			return m_sessionsDiagnosticsSummary;
		}
		set
		{
			if (m_sessionsDiagnosticsSummary != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_sessionsDiagnosticsSummary = value;
		}
	}

	public PropertyState<bool> EnabledFlag
	{
		get
		{
			return m_enabledFlag;
		}
		set
		{
			if (m_enabledFlag != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_enabledFlag = value;
		}
	}

	public ServerDiagnosticsState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2020u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHQAAAFNlcnZlckRpYWdub3N0aWNzVHlwZUluc3RhbmNlAQDkBwEA5AfkBwAA/////wUAAAAVYIkKAgAAAAAAGAAAAFNlcnZlckRpYWdub3N0aWNzU3VtbWFyeQEA5QcALwEAZgjlBwAAAQBbA/////8BAf////8MAAAAFWCJCgIAAAAAAA8AAABTZXJ2ZXJWaWV3Q291bnQBACwMAC8APywMAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABMAAABDdXJyZW50U2Vzc2lvbkNvdW50AQAtDAAvAD8tDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAVAAAAQ3VtdWxhdGVkU2Vzc2lvbkNvdW50AQAuDAAvAD8uDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAcAAAAU2VjdXJpdHlSZWplY3RlZFNlc3Npb25Db3VudAEALwwALwA/LwwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFAAAAFJlamVjdGVkU2Vzc2lvbkNvdW50AQAwDAAvAD8wDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAATAAAAU2Vzc2lvblRpbWVvdXRDb3VudAEAMQwALwA/MQwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAFNlc3Npb25BYm9ydENvdW50AQAyDAAvAD8yDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAXAAAAUHVibGlzaGluZ0ludGVydmFsQ291bnQBADQMAC8APzQMAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABgAAABDdXJyZW50U3Vic2NyaXB0aW9uQ291bnQBADUMAC8APzUMAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABoAAABDdW11bGF0ZWRTdWJzY3JpcHRpb25Db3VudAEANgwALwA/NgwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHQAAAFNlY3VyaXR5UmVqZWN0ZWRSZXF1ZXN0c0NvdW50AQA3DAAvAD83DAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAVAAAAUmVqZWN0ZWRSZXF1ZXN0c0NvdW50AQA4DAAvAD84DAAAAAf/////AQH/////AAAAABdgiQoCAAAAAAAgAAAAU2FtcGxpbmdJbnRlcnZhbERpYWdub3N0aWNzQXJyYXkBAOYHAC8BAHQI5gcAAAEAWAMBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABwAAABTdWJzY3JpcHRpb25EaWFnbm9zdGljc0FycmF5AQDnBwAvAQB7COcHAAABAGoDAQAAAAEAAAAAAAAAAQH/////AAAAAARggAoBAAAAAAAaAAAAU2Vzc2lvbnNEaWFnbm9zdGljc1N1bW1hcnkBALgKAC8BAOoHuAoAAP////8CAAAAF2CJCgIAAAAAABcAAABTZXNzaW9uRGlhZ25vc3RpY3NBcnJheQEAOQwALwEAlAg5DAAAAQBhAwEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAHwAAAFNlc3Npb25TZWN1cml0eURpYWdub3N0aWNzQXJyYXkBADoMAC8BAMMIOgwAAAEAZAMBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAsAAABFbmFibGVkRmxhZwEA6QcALgBE6QcAAAAB/////wMD/////wAAAAA=");
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
		if (SamplingIntervalDiagnosticsArray != null)
		{
			SamplingIntervalDiagnosticsArray.Initialize(context, "//////////8XYIkKAgAAAAAAIAAAAFNhbXBsaW5nSW50ZXJ2YWxEaWFnbm9zdGljc0FycmF5AQDmBwAvAQB0COYHAAABAFgDAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_serverDiagnosticsSummary != null)
		{
			children.Add(m_serverDiagnosticsSummary);
		}
		if (m_samplingIntervalDiagnosticsArray != null)
		{
			children.Add(m_samplingIntervalDiagnosticsArray);
		}
		if (m_subscriptionDiagnosticsArray != null)
		{
			children.Add(m_subscriptionDiagnosticsArray);
		}
		if (m_sessionsDiagnosticsSummary != null)
		{
			children.Add(m_sessionsDiagnosticsSummary);
		}
		if (m_enabledFlag != null)
		{
			children.Add(m_enabledFlag);
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
		case "ServerDiagnosticsSummary":
			if (createOrReplace && ServerDiagnosticsSummary == null)
			{
				if (replacement == null)
				{
					ServerDiagnosticsSummary = new ServerDiagnosticsSummaryState(this);
				}
				else
				{
					ServerDiagnosticsSummary = (ServerDiagnosticsSummaryState)replacement;
				}
			}
			baseInstanceState = ServerDiagnosticsSummary;
			break;
		case "SamplingIntervalDiagnosticsArray":
			if (createOrReplace && SamplingIntervalDiagnosticsArray == null)
			{
				if (replacement == null)
				{
					SamplingIntervalDiagnosticsArray = new SamplingIntervalDiagnosticsArrayState(this);
				}
				else
				{
					SamplingIntervalDiagnosticsArray = (SamplingIntervalDiagnosticsArrayState)replacement;
				}
			}
			baseInstanceState = SamplingIntervalDiagnosticsArray;
			break;
		case "SubscriptionDiagnosticsArray":
			if (createOrReplace && SubscriptionDiagnosticsArray == null)
			{
				if (replacement == null)
				{
					SubscriptionDiagnosticsArray = new SubscriptionDiagnosticsArrayState(this);
				}
				else
				{
					SubscriptionDiagnosticsArray = (SubscriptionDiagnosticsArrayState)replacement;
				}
			}
			baseInstanceState = SubscriptionDiagnosticsArray;
			break;
		case "SessionsDiagnosticsSummary":
			if (createOrReplace && SessionsDiagnosticsSummary == null)
			{
				if (replacement == null)
				{
					SessionsDiagnosticsSummary = new SessionsDiagnosticsSummaryState(this);
				}
				else
				{
					SessionsDiagnosticsSummary = (SessionsDiagnosticsSummaryState)replacement;
				}
			}
			baseInstanceState = SessionsDiagnosticsSummary;
			break;
		case "EnabledFlag":
			if (createOrReplace && EnabledFlag == null)
			{
				if (replacement == null)
				{
					EnabledFlag = new PropertyState<bool>(this);
				}
				else
				{
					EnabledFlag = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = EnabledFlag;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
