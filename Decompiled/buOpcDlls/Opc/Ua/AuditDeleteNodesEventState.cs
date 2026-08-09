using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditDeleteNodesEventState : AuditNodeManagementEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIQAAAEF1ZGl0RGVsZXRlTm9kZXNFdmVudFR5cGVJbnN0YW5jZQEALQgBAC0ILQgAAP////8OAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQCGDQAuAESGDQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCHDQAuAESHDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAiA0ALgBEiA0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAIkNAC4ARIkNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCKDQAuAESKDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAiw0ALgBEiw0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAjQ0ALgBEjQ0AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQCODQAuAESODQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQCPDQAuAESPDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAJANAC4ARJANAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAkQ0ALgBEkQ0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAkg0ALgBEkg0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAkw0ALgBEkw0AAAAM/////wEB/////wAAAAAXYIkKAgAAAAAADQAAAE5vZGVzVG9EZWxldGUBAC4IAC4ARC4IAAABAH4BAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	private PropertyState<DeleteNodesItem[]> m_nodesToDelete;

	public PropertyState<DeleteNodesItem[]> NodesToDelete
	{
		get
		{
			return m_nodesToDelete;
		}
		set
		{
			if (m_nodesToDelete != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_nodesToDelete = value;
		}
	}

	public AuditDeleteNodesEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2093u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIQAAAEF1ZGl0RGVsZXRlTm9kZXNFdmVudFR5cGVJbnN0YW5jZQEALQgBAC0ILQgAAP////8OAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQCGDQAuAESGDQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCHDQAuAESHDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAiA0ALgBEiA0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAIkNAC4ARIkNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCKDQAuAESKDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAiw0ALgBEiw0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAjQ0ALgBEjQ0AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQCODQAuAESODQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQCPDQAuAESPDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAJANAC4ARJANAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAkQ0ALgBEkQ0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAkg0ALgBEkg0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAkw0ALgBEkw0AAAAM/////wEB/////wAAAAAXYIkKAgAAAAAADQAAAE5vZGVzVG9EZWxldGUBAC4IAC4ARC4IAAABAH4BAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		if (m_nodesToDelete != null)
		{
			children.Add(m_nodesToDelete);
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
		if (browseName.Name == "NodesToDelete")
		{
			if (createOrReplace && NodesToDelete == null)
			{
				if (replacement == null)
				{
					NodesToDelete = new PropertyState<DeleteNodesItem[]>(this);
				}
				else
				{
					NodesToDelete = (PropertyState<DeleteNodesItem[]>)replacement;
				}
			}
			baseInstanceState = NodesToDelete;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
