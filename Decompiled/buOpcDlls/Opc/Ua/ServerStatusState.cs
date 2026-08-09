using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ServerStatusState : BaseDataVariableState<ServerStatusDataType>
{
	private const string InitializationString = "//////////8VYIkCAgAAAAAAGAAAAFNlcnZlclN0YXR1c1R5cGVJbnN0YW5jZQEAWggBAFoIWggAAAEAXgP/////AQH/////BgAAABVgiQoCAAAAAAAJAAAAU3RhcnRUaW1lAQBbCAAvAD9bCAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABDdXJyZW50VGltZQEAXAgALwA/XAgAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAFAAAAU3RhdGUBAF0IAC8AP10IAAABAFQD/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEJ1aWxkSW5mbwEAXggALwEA6wteCAAAAQBSAf////8BAf////8GAAAAFXCJCgIAAAAAAAoAAABQcm9kdWN0VXJpAQByDgAvAD9yDgAAAAz/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAABAAAABNYW51ZmFjdHVyZXJOYW1lAQBzDgAvAD9zDgAAAAz/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAAsAAABQcm9kdWN0TmFtZQEAdA4ALwA/dA4AAAAM/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAAPAAAAU29mdHdhcmVWZXJzaW9uAQB1DgAvAD91DgAAAAz/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAAsAAABCdWlsZE51bWJlcgEAdg4ALwA/dg4AAAAM/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAAJAAAAQnVpbGREYXRlAQB3DgAvAD93DgAAAQAmAf////8BAQAAAAAAQI9A/////wAAAAAVYIkKAgAAAAAAEwAAAFNlY29uZHNUaWxsU2h1dGRvd24BAMAKAC8AP8AKAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABTaHV0ZG93blJlYXNvbgEAwQoALwA/wQoAAAAV/////wEB/////wAAAAA=";

	private BaseDataVariableState<DateTime> m_startTime;

	private BaseDataVariableState<DateTime> m_currentTime;

	private BaseDataVariableState<ServerState> m_state;

	private BuildInfoVariableState m_buildInfo;

	private BaseDataVariableState<uint> m_secondsTillShutdown;

	private BaseDataVariableState<LocalizedText> m_shutdownReason;

	public BaseDataVariableState<DateTime> StartTime
	{
		get
		{
			return m_startTime;
		}
		set
		{
			if (m_startTime != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_startTime = value;
		}
	}

	public BaseDataVariableState<DateTime> CurrentTime
	{
		get
		{
			return m_currentTime;
		}
		set
		{
			if (m_currentTime != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_currentTime = value;
		}
	}

	public BaseDataVariableState<ServerState> State
	{
		get
		{
			return m_state;
		}
		set
		{
			if (m_state != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_state = value;
		}
	}

	public BuildInfoVariableState BuildInfo
	{
		get
		{
			return m_buildInfo;
		}
		set
		{
			if (m_buildInfo != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_buildInfo = value;
		}
	}

	public BaseDataVariableState<uint> SecondsTillShutdown
	{
		get
		{
			return m_secondsTillShutdown;
		}
		set
		{
			if (m_secondsTillShutdown != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_secondsTillShutdown = value;
		}
	}

	public BaseDataVariableState<LocalizedText> ShutdownReason
	{
		get
		{
			return m_shutdownReason;
		}
		set
		{
			if (m_shutdownReason != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_shutdownReason = value;
		}
	}

	public ServerStatusState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2138u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(862u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAGAAAAFNlcnZlclN0YXR1c1R5cGVJbnN0YW5jZQEAWggBAFoIWggAAAEAXgP/////AQH/////BgAAABVgiQoCAAAAAAAJAAAAU3RhcnRUaW1lAQBbCAAvAD9bCAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABDdXJyZW50VGltZQEAXAgALwA/XAgAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAFAAAAU3RhdGUBAF0IAC8AP10IAAABAFQD/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEJ1aWxkSW5mbwEAXggALwEA6wteCAAAAQBSAf////8BAf////8GAAAAFXCJCgIAAAAAAAoAAABQcm9kdWN0VXJpAQByDgAvAD9yDgAAAAz/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAABAAAABNYW51ZmFjdHVyZXJOYW1lAQBzDgAvAD9zDgAAAAz/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAAsAAABQcm9kdWN0TmFtZQEAdA4ALwA/dA4AAAAM/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAAPAAAAU29mdHdhcmVWZXJzaW9uAQB1DgAvAD91DgAAAAz/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAAsAAABCdWlsZE51bWJlcgEAdg4ALwA/dg4AAAAM/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAAJAAAAQnVpbGREYXRlAQB3DgAvAD93DgAAAQAmAf////8BAQAAAAAAQI9A/////wAAAAAVYIkKAgAAAAAAEwAAAFNlY29uZHNUaWxsU2h1dGRvd24BAMAKAC8AP8AKAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABTaHV0ZG93blJlYXNvbgEAwQoALwA/wQoAAAAV/////wEB/////wAAAAA=");
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
		if (m_startTime != null)
		{
			children.Add(m_startTime);
		}
		if (m_currentTime != null)
		{
			children.Add(m_currentTime);
		}
		if (m_state != null)
		{
			children.Add(m_state);
		}
		if (m_buildInfo != null)
		{
			children.Add(m_buildInfo);
		}
		if (m_secondsTillShutdown != null)
		{
			children.Add(m_secondsTillShutdown);
		}
		if (m_shutdownReason != null)
		{
			children.Add(m_shutdownReason);
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
		case "StartTime":
			if (createOrReplace && StartTime == null)
			{
				if (replacement == null)
				{
					StartTime = new BaseDataVariableState<DateTime>(this);
				}
				else
				{
					StartTime = (BaseDataVariableState<DateTime>)replacement;
				}
			}
			baseInstanceState = StartTime;
			break;
		case "CurrentTime":
			if (createOrReplace && CurrentTime == null)
			{
				if (replacement == null)
				{
					CurrentTime = new BaseDataVariableState<DateTime>(this);
				}
				else
				{
					CurrentTime = (BaseDataVariableState<DateTime>)replacement;
				}
			}
			baseInstanceState = CurrentTime;
			break;
		case "State":
			if (createOrReplace && State == null)
			{
				if (replacement == null)
				{
					State = new BaseDataVariableState<ServerState>(this);
				}
				else
				{
					State = (BaseDataVariableState<ServerState>)replacement;
				}
			}
			baseInstanceState = State;
			break;
		case "BuildInfo":
			if (createOrReplace && BuildInfo == null)
			{
				if (replacement == null)
				{
					BuildInfo = new BuildInfoVariableState(this);
				}
				else
				{
					BuildInfo = (BuildInfoVariableState)replacement;
				}
			}
			baseInstanceState = BuildInfo;
			break;
		case "SecondsTillShutdown":
			if (createOrReplace && SecondsTillShutdown == null)
			{
				if (replacement == null)
				{
					SecondsTillShutdown = new BaseDataVariableState<uint>(this);
				}
				else
				{
					SecondsTillShutdown = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = SecondsTillShutdown;
			break;
		case "ShutdownReason":
			if (createOrReplace && ShutdownReason == null)
			{
				if (replacement == null)
				{
					ShutdownReason = new BaseDataVariableState<LocalizedText>(this);
				}
				else
				{
					ShutdownReason = (BaseDataVariableState<LocalizedText>)replacement;
				}
			}
			baseInstanceState = ShutdownReason;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
