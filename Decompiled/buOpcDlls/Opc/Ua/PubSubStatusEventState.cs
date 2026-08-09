using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class PubSubStatusEventState : SystemEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAHQAAAFB1YlN1YlN0YXR1c0V2ZW50VHlwZUluc3RhbmNlAQCvPAEArzyvPAAA/////wsAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBALA8AC4ARLA8AAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBALE8AC4ARLE8AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCyPAAuAESyPAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAszwALgBEszwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBALQ8AC4ARLQ8AAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQC1PAAuAES1PAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQC3PAAuAES3PAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBALg8AC4ARLg8AAAABf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDb25uZWN0aW9uSWQBALk8AC4ARLk8AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABHcm91cElkAQC6PAAuAES6PAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAFAAAAU3RhdGUBALs8AC4ARLs8AAABADc5/////wEB/////wAAAAA=";

	private PropertyState<NodeId> m_connectionId;

	private PropertyState<NodeId> m_groupId;

	private PropertyState<PubSubState> m_state;

	public PropertyState<NodeId> ConnectionId
	{
		get
		{
			return m_connectionId;
		}
		set
		{
			if (m_connectionId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_connectionId = value;
		}
	}

	public PropertyState<NodeId> GroupId
	{
		get
		{
			return m_groupId;
		}
		set
		{
			if (m_groupId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_groupId = value;
		}
	}

	public PropertyState<PubSubState> State
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

	public PubSubStatusEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(15535u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHQAAAFB1YlN1YlN0YXR1c0V2ZW50VHlwZUluc3RhbmNlAQCvPAEArzyvPAAA/////wsAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBALA8AC4ARLA8AAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBALE8AC4ARLE8AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCyPAAuAESyPAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAszwALgBEszwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBALQ8AC4ARLQ8AAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQC1PAAuAES1PAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQC3PAAuAES3PAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBALg8AC4ARLg8AAAABf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDb25uZWN0aW9uSWQBALk8AC4ARLk8AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABHcm91cElkAQC6PAAuAES6PAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAFAAAAU3RhdGUBALs8AC4ARLs8AAABADc5/////wEB/////wAAAAA=");
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
		if (m_connectionId != null)
		{
			children.Add(m_connectionId);
		}
		if (m_groupId != null)
		{
			children.Add(m_groupId);
		}
		if (m_state != null)
		{
			children.Add(m_state);
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
		case "ConnectionId":
			if (createOrReplace && ConnectionId == null)
			{
				if (replacement == null)
				{
					ConnectionId = new PropertyState<NodeId>(this);
				}
				else
				{
					ConnectionId = (PropertyState<NodeId>)replacement;
				}
			}
			baseInstanceState = ConnectionId;
			break;
		case "GroupId":
			if (createOrReplace && GroupId == null)
			{
				if (replacement == null)
				{
					GroupId = new PropertyState<NodeId>(this);
				}
				else
				{
					GroupId = (PropertyState<NodeId>)replacement;
				}
			}
			baseInstanceState = GroupId;
			break;
		case "State":
			if (createOrReplace && State == null)
			{
				if (replacement == null)
				{
					State = new PropertyState<PubSubState>(this);
				}
				else
				{
					State = (PropertyState<PubSubState>)replacement;
				}
			}
			baseInstanceState = State;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
