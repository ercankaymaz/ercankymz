using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditConditionAcknowledgeEventState : AuditConditionEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAKgAAAEF1ZGl0Q29uZGl0aW9uQWNrbm93bGVkZ2VFdmVudFR5cGVJbnN0YW5jZQEA8CIBAPAi8CIAAP////8RAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQDxIgAuAETxIgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQDyIgAuAETyIgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEA8yIALgBE8yIAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAPQiAC4ARPQiAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQD1IgAuAET1IgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEA9iIALgBE9iIAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEA+CIALgBE+CIAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQD5IgAuAET5IgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQD6IgAuAET6IgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAPsiAC4ARPsiAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEA/CIALgBE/CIAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEA/SIALgBE/SIAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEA/iIALgBE/iIAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAE1ldGhvZElkAQD/IgAuAET/IgAAABH/////AQH/////AAAAABdgiQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAAAjAC4ARAAjAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAAEAAAAENvbmRpdGlvbkV2ZW50SWQBAEdDAC4AREdDAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABDb21tZW50AQBNLgAuAERNLgAAABX/////AQH/////AAAAAA==";

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

	public AuditConditionAcknowledgeEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(8944u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAKgAAAEF1ZGl0Q29uZGl0aW9uQWNrbm93bGVkZ2VFdmVudFR5cGVJbnN0YW5jZQEA8CIBAPAi8CIAAP////8RAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQDxIgAuAETxIgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQDyIgAuAETyIgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEA8yIALgBE8yIAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAPQiAC4ARPQiAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQD1IgAuAET1IgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEA9iIALgBE9iIAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEA+CIALgBE+CIAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQD5IgAuAET5IgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQD6IgAuAET6IgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAPsiAC4ARPsiAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEA/CIALgBE/CIAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEA/SIALgBE/SIAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEA/iIALgBE/iIAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAE1ldGhvZElkAQD/IgAuAET/IgAAABH/////AQH/////AAAAABdgiQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAAAjAC4ARAAjAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAAEAAAAENvbmRpdGlvbkV2ZW50SWQBAEdDAC4AREdDAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABDb21tZW50AQBNLgAuAERNLgAAABX/////AQH/////AAAAAA==");
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
