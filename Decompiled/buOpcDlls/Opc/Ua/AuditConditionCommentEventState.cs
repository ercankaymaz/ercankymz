using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditConditionCommentEventState : AuditConditionEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAJgAAAEF1ZGl0Q29uZGl0aW9uQ29tbWVudEV2ZW50VHlwZUluc3RhbmNlAQANCwEADQsNCwAA/////xEAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAEoQAC4AREoQAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAEsQAC4AREsQAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQBMEAAuAERMEAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEATRAALgBETRAAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAE4QAC4ARE4QAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQBPEAAuAERPEAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQBREAAuAERREAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAFIQAC4ARFIQAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAFMQAC4ARFMQAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAVBAALgBEVBAAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQBVEAAuAERVEAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQBWEAAuAERWEAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQBXEAAuAERXEAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAATWV0aG9kSWQBAFgQAC4ARFgQAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAWRAALgBEWRAAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAQAAAAQ29uZGl0aW9uRXZlbnRJZAEARkMALgBERkMAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAENvbW1lbnQBAEsuAC4AREsuAAAAFf////8BAf////8AAAAA";

	private PropertyState<byte[]> m_conditionEventId;

	private PropertyState<LocalizedText> m_comment;

	public PropertyState<byte[]> ConditionEventId
	{
		get
		{
			return m_conditionEventId;
		}
		set
		{
			if (m_conditionEventId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_conditionEventId = value;
		}
	}

	public PropertyState<LocalizedText> Comment
	{
		get
		{
			return m_comment;
		}
		set
		{
			if (m_comment != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_comment = value;
		}
	}

	public AuditConditionCommentEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2829u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJgAAAEF1ZGl0Q29uZGl0aW9uQ29tbWVudEV2ZW50VHlwZUluc3RhbmNlAQANCwEADQsNCwAA/////xEAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAEoQAC4AREoQAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAEsQAC4AREsQAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQBMEAAuAERMEAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEATRAALgBETRAAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAE4QAC4ARE4QAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQBPEAAuAERPEAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQBREAAuAERREAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAFIQAC4ARFIQAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAFMQAC4ARFMQAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAVBAALgBEVBAAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQBVEAAuAERVEAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQBWEAAuAERWEAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQBXEAAuAERXEAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAATWV0aG9kSWQBAFgQAC4ARFgQAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAWRAALgBEWRAAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAQAAAAQ29uZGl0aW9uRXZlbnRJZAEARkMALgBERkMAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAENvbW1lbnQBAEsuAC4AREsuAAAAFf////8BAf////8AAAAA");
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
		if (m_conditionEventId != null)
		{
			children.Add(m_conditionEventId);
		}
		if (m_comment != null)
		{
			children.Add(m_comment);
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
		string name = browseName.Name;
		if (!(name == "ConditionEventId"))
		{
			if (name == "Comment")
			{
				if (createOrReplace && Comment == null)
				{
					if (replacement == null)
					{
						Comment = new PropertyState<LocalizedText>(this);
					}
					else
					{
						Comment = (PropertyState<LocalizedText>)replacement;
					}
				}
				baseInstanceState = Comment;
			}
		}
		else
		{
			if (createOrReplace && ConditionEventId == null)
			{
				if (replacement == null)
				{
					ConditionEventId = new PropertyState<byte[]>(this);
				}
				else
				{
					ConditionEventId = (PropertyState<byte[]>)replacement;
				}
			}
			baseInstanceState = ConditionEventId;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
