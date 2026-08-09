using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditConditionConfirmEventState : AuditConditionEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAJgAAAEF1ZGl0Q29uZGl0aW9uQ29uZmlybUV2ZW50VHlwZUluc3RhbmNlAQABIwEAASMBIwAA/////xEAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAAIjAC4ARAIjAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAAMjAC4ARAMjAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQAEIwAuAEQEIwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEABSMALgBEBSMAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAAYjAC4ARAYjAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQAHIwAuAEQHIwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQAJIwAuAEQJIwAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAAojAC4ARAojAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAAsjAC4ARAsjAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEADCMALgBEDCMAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQANIwAuAEQNIwAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQAOIwAuAEQOIwAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQAPIwAuAEQPIwAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAATWV0aG9kSWQBABAjAC4ARBAjAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAESMALgBEESMAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAQAAAAQ29uZGl0aW9uRXZlbnRJZAEASEMALgBESEMAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAENvbW1lbnQBAE4uAC4ARE4uAAAAFf////8BAf////8AAAAA";

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

	public AuditConditionConfirmEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(8961u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJgAAAEF1ZGl0Q29uZGl0aW9uQ29uZmlybUV2ZW50VHlwZUluc3RhbmNlAQABIwEAASMBIwAA/////xEAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAAIjAC4ARAIjAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAAMjAC4ARAMjAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQAEIwAuAEQEIwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEABSMALgBEBSMAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAAYjAC4ARAYjAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQAHIwAuAEQHIwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQAJIwAuAEQJIwAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAAojAC4ARAojAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAAsjAC4ARAsjAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEADCMALgBEDCMAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQANIwAuAEQNIwAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQAOIwAuAEQOIwAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQAPIwAuAEQPIwAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAATWV0aG9kSWQBABAjAC4ARBAjAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAESMALgBEESMAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAQAAAAQ29uZGl0aW9uRXZlbnRJZAEASEMALgBESEMAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAENvbW1lbnQBAE4uAC4ARE4uAAAAFf////8BAf////8AAAAA");
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
