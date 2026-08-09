using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ServerDiagnosticsSummaryState : BaseDataVariableState<ServerDiagnosticsSummaryDataType>
{
	private const string InitializationString = "//////////8VYIkCAgAAAAAAJAAAAFNlcnZlckRpYWdub3N0aWNzU3VtbWFyeVR5cGVJbnN0YW5jZQEAZggBAGYIZggAAAEAWwP/////AQH/////DAAAABVgiQoCAAAAAAAPAAAAU2VydmVyVmlld0NvdW50AQBnCAAvAD9nCAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAATAAAAQ3VycmVudFNlc3Npb25Db3VudAEAaAgALwA/aAgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAEN1bXVsYXRlZFNlc3Npb25Db3VudAEAaQgALwA/aQgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHAAAAFNlY3VyaXR5UmVqZWN0ZWRTZXNzaW9uQ291bnQBAGoIAC8AP2oIAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABSZWplY3RlZFNlc3Npb25Db3VudAEAawgALwA/awgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFNlc3Npb25UaW1lb3V0Q291bnQBAGwIAC8AP2wIAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABEAAABTZXNzaW9uQWJvcnRDb3VudAEAbQgALwA/bQgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFwAAAFB1Ymxpc2hpbmdJbnRlcnZhbENvdW50AQBvCAAvAD9vCAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAYAAAAQ3VycmVudFN1YnNjcmlwdGlvbkNvdW50AQBwCAAvAD9wCAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAaAAAAQ3VtdWxhdGVkU3Vic2NyaXB0aW9uQ291bnQBAHEIAC8AP3EIAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAB0AAABTZWN1cml0eVJlamVjdGVkUmVxdWVzdHNDb3VudAEAcggALwA/cggAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFJlamVjdGVkUmVxdWVzdHNDb3VudAEAcwgALwA/cwgAAAAH/////wEB/////wAAAAA=";

	private BaseDataVariableState<uint> m_serverViewCount;

	private BaseDataVariableState<uint> m_currentSessionCount;

	private BaseDataVariableState<uint> m_cumulatedSessionCount;

	private BaseDataVariableState<uint> m_securityRejectedSessionCount;

	private BaseDataVariableState<uint> m_rejectedSessionCount;

	private BaseDataVariableState<uint> m_sessionTimeoutCount;

	private BaseDataVariableState<uint> m_sessionAbortCount;

	private BaseDataVariableState<uint> m_publishingIntervalCount;

	private BaseDataVariableState<uint> m_currentSubscriptionCount;

	private BaseDataVariableState<uint> m_cumulatedSubscriptionCount;

	private BaseDataVariableState<uint> m_securityRejectedRequestsCount;

	private BaseDataVariableState<uint> m_rejectedRequestsCount;

	public BaseDataVariableState<uint> ServerViewCount
	{
		get
		{
			return m_serverViewCount;
		}
		set
		{
			if (m_serverViewCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_serverViewCount = value;
		}
	}

	public BaseDataVariableState<uint> CurrentSessionCount
	{
		get
		{
			return m_currentSessionCount;
		}
		set
		{
			if (m_currentSessionCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_currentSessionCount = value;
		}
	}

	public BaseDataVariableState<uint> CumulatedSessionCount
	{
		get
		{
			return m_cumulatedSessionCount;
		}
		set
		{
			if (m_cumulatedSessionCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_cumulatedSessionCount = value;
		}
	}

	public BaseDataVariableState<uint> SecurityRejectedSessionCount
	{
		get
		{
			return m_securityRejectedSessionCount;
		}
		set
		{
			if (m_securityRejectedSessionCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_securityRejectedSessionCount = value;
		}
	}

	public BaseDataVariableState<uint> RejectedSessionCount
	{
		get
		{
			return m_rejectedSessionCount;
		}
		set
		{
			if (m_rejectedSessionCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_rejectedSessionCount = value;
		}
	}

	public BaseDataVariableState<uint> SessionTimeoutCount
	{
		get
		{
			return m_sessionTimeoutCount;
		}
		set
		{
			if (m_sessionTimeoutCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_sessionTimeoutCount = value;
		}
	}

	public BaseDataVariableState<uint> SessionAbortCount
	{
		get
		{
			return m_sessionAbortCount;
		}
		set
		{
			if (m_sessionAbortCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_sessionAbortCount = value;
		}
	}

	public BaseDataVariableState<uint> PublishingIntervalCount
	{
		get
		{
			return m_publishingIntervalCount;
		}
		set
		{
			if (m_publishingIntervalCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_publishingIntervalCount = value;
		}
	}

	public BaseDataVariableState<uint> CurrentSubscriptionCount
	{
		get
		{
			return m_currentSubscriptionCount;
		}
		set
		{
			if (m_currentSubscriptionCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_currentSubscriptionCount = value;
		}
	}

	public BaseDataVariableState<uint> CumulatedSubscriptionCount
	{
		get
		{
			return m_cumulatedSubscriptionCount;
		}
		set
		{
			if (m_cumulatedSubscriptionCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_cumulatedSubscriptionCount = value;
		}
	}

	public BaseDataVariableState<uint> SecurityRejectedRequestsCount
	{
		get
		{
			return m_securityRejectedRequestsCount;
		}
		set
		{
			if (m_securityRejectedRequestsCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_securityRejectedRequestsCount = value;
		}
	}

	public BaseDataVariableState<uint> RejectedRequestsCount
	{
		get
		{
			return m_rejectedRequestsCount;
		}
		set
		{
			if (m_rejectedRequestsCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_rejectedRequestsCount = value;
		}
	}

	public ServerDiagnosticsSummaryState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2150u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(859u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAJAAAAFNlcnZlckRpYWdub3N0aWNzU3VtbWFyeVR5cGVJbnN0YW5jZQEAZggBAGYIZggAAAEAWwP/////AQH/////DAAAABVgiQoCAAAAAAAPAAAAU2VydmVyVmlld0NvdW50AQBnCAAvAD9nCAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAATAAAAQ3VycmVudFNlc3Npb25Db3VudAEAaAgALwA/aAgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAEN1bXVsYXRlZFNlc3Npb25Db3VudAEAaQgALwA/aQgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHAAAAFNlY3VyaXR5UmVqZWN0ZWRTZXNzaW9uQ291bnQBAGoIAC8AP2oIAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABSZWplY3RlZFNlc3Npb25Db3VudAEAawgALwA/awgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFNlc3Npb25UaW1lb3V0Q291bnQBAGwIAC8AP2wIAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABEAAABTZXNzaW9uQWJvcnRDb3VudAEAbQgALwA/bQgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFwAAAFB1Ymxpc2hpbmdJbnRlcnZhbENvdW50AQBvCAAvAD9vCAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAYAAAAQ3VycmVudFN1YnNjcmlwdGlvbkNvdW50AQBwCAAvAD9wCAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAaAAAAQ3VtdWxhdGVkU3Vic2NyaXB0aW9uQ291bnQBAHEIAC8AP3EIAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAB0AAABTZWN1cml0eVJlamVjdGVkUmVxdWVzdHNDb3VudAEAcggALwA/cggAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFJlamVjdGVkUmVxdWVzdHNDb3VudAEAcwgALwA/cwgAAAAH/////wEB/////wAAAAA=");
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
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_serverViewCount != null)
		{
			children.Add(m_serverViewCount);
		}
		if (m_currentSessionCount != null)
		{
			children.Add(m_currentSessionCount);
		}
		if (m_cumulatedSessionCount != null)
		{
			children.Add(m_cumulatedSessionCount);
		}
		if (m_securityRejectedSessionCount != null)
		{
			children.Add(m_securityRejectedSessionCount);
		}
		if (m_rejectedSessionCount != null)
		{
			children.Add(m_rejectedSessionCount);
		}
		if (m_sessionTimeoutCount != null)
		{
			children.Add(m_sessionTimeoutCount);
		}
		if (m_sessionAbortCount != null)
		{
			children.Add(m_sessionAbortCount);
		}
		if (m_publishingIntervalCount != null)
		{
			children.Add(m_publishingIntervalCount);
		}
		if (m_currentSubscriptionCount != null)
		{
			children.Add(m_currentSubscriptionCount);
		}
		if (m_cumulatedSubscriptionCount != null)
		{
			children.Add(m_cumulatedSubscriptionCount);
		}
		if (m_securityRejectedRequestsCount != null)
		{
			children.Add(m_securityRejectedRequestsCount);
		}
		if (m_rejectedRequestsCount != null)
		{
			children.Add(m_rejectedRequestsCount);
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
		case "ServerViewCount":
			if (createOrReplace && ServerViewCount == null)
			{
				if (replacement == null)
				{
					ServerViewCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					ServerViewCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = ServerViewCount;
			break;
		case "CurrentSessionCount":
			if (createOrReplace && CurrentSessionCount == null)
			{
				if (replacement == null)
				{
					CurrentSessionCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					CurrentSessionCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = CurrentSessionCount;
			break;
		case "CumulatedSessionCount":
			if (createOrReplace && CumulatedSessionCount == null)
			{
				if (replacement == null)
				{
					CumulatedSessionCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					CumulatedSessionCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = CumulatedSessionCount;
			break;
		case "SecurityRejectedSessionCount":
			if (createOrReplace && SecurityRejectedSessionCount == null)
			{
				if (replacement == null)
				{
					SecurityRejectedSessionCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					SecurityRejectedSessionCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = SecurityRejectedSessionCount;
			break;
		case "RejectedSessionCount":
			if (createOrReplace && RejectedSessionCount == null)
			{
				if (replacement == null)
				{
					RejectedSessionCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					RejectedSessionCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = RejectedSessionCount;
			break;
		case "SessionTimeoutCount":
			if (createOrReplace && SessionTimeoutCount == null)
			{
				if (replacement == null)
				{
					SessionTimeoutCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					SessionTimeoutCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = SessionTimeoutCount;
			break;
		case "SessionAbortCount":
			if (createOrReplace && SessionAbortCount == null)
			{
				if (replacement == null)
				{
					SessionAbortCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					SessionAbortCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = SessionAbortCount;
			break;
		case "PublishingIntervalCount":
			if (createOrReplace && PublishingIntervalCount == null)
			{
				if (replacement == null)
				{
					PublishingIntervalCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					PublishingIntervalCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = PublishingIntervalCount;
			break;
		case "CurrentSubscriptionCount":
			if (createOrReplace && CurrentSubscriptionCount == null)
			{
				if (replacement == null)
				{
					CurrentSubscriptionCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					CurrentSubscriptionCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = CurrentSubscriptionCount;
			break;
		case "CumulatedSubscriptionCount":
			if (createOrReplace && CumulatedSubscriptionCount == null)
			{
				if (replacement == null)
				{
					CumulatedSubscriptionCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					CumulatedSubscriptionCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = CumulatedSubscriptionCount;
			break;
		case "SecurityRejectedRequestsCount":
			if (createOrReplace && SecurityRejectedRequestsCount == null)
			{
				if (replacement == null)
				{
					SecurityRejectedRequestsCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					SecurityRejectedRequestsCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = SecurityRejectedRequestsCount;
			break;
		case "RejectedRequestsCount":
			if (createOrReplace && RejectedRequestsCount == null)
			{
				if (replacement == null)
				{
					RejectedRequestsCount = new BaseDataVariableState<uint>(this);
				}
				else
				{
					RejectedRequestsCount = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = RejectedRequestsCount;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
