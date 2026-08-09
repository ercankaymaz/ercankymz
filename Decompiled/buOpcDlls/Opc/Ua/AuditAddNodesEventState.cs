using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditAddNodesEventState : AuditNodeManagementEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAHgAAAEF1ZGl0QWRkTm9kZXNFdmVudFR5cGVJbnN0YW5jZQEAKwgBACsIKwgAAP////8OAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQB4DQAuAER4DQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQB5DQAuAER5DQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAeg0ALgBEeg0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAHsNAC4ARHsNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQB8DQAuAER8DQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAfQ0ALgBEfQ0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAfw0ALgBEfw0AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQCADQAuAESADQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQCBDQAuAESBDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAIINAC4ARIINAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAgw0ALgBEgw0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAhA0ALgBEhA0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAhQ0ALgBEhQ0AAAAM/////wEB/////wAAAAAXYIkKAgAAAAAACgAAAE5vZGVzVG9BZGQBACwIAC4ARCwIAAABAHgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	private PropertyState<AddNodesItem[]> m_nodesToAdd;

	public PropertyState<AddNodesItem[]> NodesToAdd
	{
		get
		{
			return m_nodesToAdd;
		}
		set
		{
			if (m_nodesToAdd != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_nodesToAdd = value;
		}
	}

	public AuditAddNodesEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2091u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHgAAAEF1ZGl0QWRkTm9kZXNFdmVudFR5cGVJbnN0YW5jZQEAKwgBACsIKwgAAP////8OAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQB4DQAuAER4DQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQB5DQAuAER5DQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAeg0ALgBEeg0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAHsNAC4ARHsNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQB8DQAuAER8DQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAfQ0ALgBEfQ0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAfw0ALgBEfw0AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQCADQAuAESADQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQCBDQAuAESBDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAIINAC4ARIINAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAgw0ALgBEgw0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAhA0ALgBEhA0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAhQ0ALgBEhQ0AAAAM/////wEB/////wAAAAAXYIkKAgAAAAAACgAAAE5vZGVzVG9BZGQBACwIAC4ARCwIAAABAHgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		if (m_nodesToAdd != null)
		{
			children.Add(m_nodesToAdd);
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
		if (browseName.Name == "NodesToAdd")
		{
			if (createOrReplace && NodesToAdd == null)
			{
				if (replacement == null)
				{
					NodesToAdd = new PropertyState<AddNodesItem[]>(this);
				}
				else
				{
					NodesToAdd = (PropertyState<AddNodesItem[]>)replacement;
				}
			}
			baseInstanceState = NodesToAdd;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
