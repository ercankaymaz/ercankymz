using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditConditionRespondEventState : AuditConditionEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAJgAAAEF1ZGl0Q29uZGl0aW9uUmVzcG9uZEV2ZW50VHlwZUluc3RhbmNlAQDfIgEA3yLfIgAA/////xAAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAOAiAC4AROAiAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAOEiAC4AROEiAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQDiIgAuAETiIgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEA4yIALgBE4yIAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAOQiAC4AROQiAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQDlIgAuAETlIgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQDnIgAuAETnIgAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAOgiAC4AROgiAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAOkiAC4AROkiAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEA6iIALgBE6iIAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQDrIgAuAETrIgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQDsIgAuAETsIgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQDtIgAuAETtIgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAATWV0aG9kSWQBAO4iAC4ARO4iAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA7yIALgBE7yIAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAQAAAAU2VsZWN0ZWRSZXNwb25zZQEATC4ALgBETC4AAAAH/////wEB/////wAAAAA=";

	private PropertyState<uint> m_selectedResponse;

	public PropertyState<uint> SelectedResponse
	{
		get
		{
			return m_selectedResponse;
		}
		set
		{
			if (m_selectedResponse != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_selectedResponse = value;
		}
	}

	public AuditConditionRespondEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(8927u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJgAAAEF1ZGl0Q29uZGl0aW9uUmVzcG9uZEV2ZW50VHlwZUluc3RhbmNlAQDfIgEA3yLfIgAA/////xAAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAOAiAC4AROAiAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAOEiAC4AROEiAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQDiIgAuAETiIgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEA4yIALgBE4yIAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAOQiAC4AROQiAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQDlIgAuAETlIgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQDnIgAuAETnIgAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAOgiAC4AROgiAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAOkiAC4AROkiAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEA6iIALgBE6iIAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQDrIgAuAETrIgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQDsIgAuAETsIgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQDtIgAuAETtIgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAATWV0aG9kSWQBAO4iAC4ARO4iAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA7yIALgBE7yIAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAQAAAAU2VsZWN0ZWRSZXNwb25zZQEATC4ALgBETC4AAAAH/////wEB/////wAAAAA=");
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
		if (m_selectedResponse != null)
		{
			children.Add(m_selectedResponse);
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
		if (browseName.Name == "SelectedResponse")
		{
			if (createOrReplace && SelectedResponse == null)
			{
				if (replacement == null)
				{
					SelectedResponse = new PropertyState<uint>(this);
				}
				else
				{
					SelectedResponse = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = SelectedResponse;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
