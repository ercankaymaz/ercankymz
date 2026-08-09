using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditHistoryDeleteEventState : AuditHistoryUpdateEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIwAAAEF1ZGl0SGlzdG9yeURlbGV0ZUV2ZW50VHlwZUluc3RhbmNlAQDECwEAxAvECwAA/////w8AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAPgNAC4ARPgNAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAPkNAC4ARPkNAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQD6DQAuAET6DQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEA+w0ALgBE+w0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAPwNAC4ARPwNAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQD9DQAuAET9DQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQD/DQAuAET/DQAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAAAOAC4ARAAOAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAAEOAC4ARAEOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAAg4ALgBEAg4AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQADDgAuAEQDDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQAEDgAuAEQEDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQAFDgAuAEQFDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAATAAAAUGFyYW1ldGVyRGF0YVR5cGVJZAEABg4ALgBEBg4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFVwZGF0ZWROb2RlAQDTCwAuAETTCwAAABH/////AQH/////AAAAAA==";

	private PropertyState<NodeId> m_updatedNode;

	public PropertyState<NodeId> UpdatedNode
	{
		get
		{
			return m_updatedNode;
		}
		set
		{
			if (m_updatedNode != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_updatedNode = value;
		}
	}

	public AuditHistoryDeleteEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(3012u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIwAAAEF1ZGl0SGlzdG9yeURlbGV0ZUV2ZW50VHlwZUluc3RhbmNlAQDECwEAxAvECwAA/////w8AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAPgNAC4ARPgNAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAPkNAC4ARPkNAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQD6DQAuAET6DQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEA+w0ALgBE+w0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAPwNAC4ARPwNAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQD9DQAuAET9DQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQD/DQAuAET/DQAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAAAOAC4ARAAOAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAAEOAC4ARAEOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAAg4ALgBEAg4AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQADDgAuAEQDDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQAEDgAuAEQEDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQAFDgAuAEQFDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAATAAAAUGFyYW1ldGVyRGF0YVR5cGVJZAEABg4ALgBEBg4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFVwZGF0ZWROb2RlAQDTCwAuAETTCwAAABH/////AQH/////AAAAAA==");
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
		if (m_updatedNode != null)
		{
			children.Add(m_updatedNode);
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
		if (browseName.Name == "UpdatedNode")
		{
			if (createOrReplace && UpdatedNode == null)
			{
				if (replacement == null)
				{
					UpdatedNode = new PropertyState<NodeId>(this);
				}
				else
				{
					UpdatedNode = (PropertyState<NodeId>)replacement;
				}
			}
			baseInstanceState = UpdatedNode;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
