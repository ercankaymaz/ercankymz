using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditProgramTransitionEventState : AuditUpdateStateEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAJwAAAEF1ZGl0UHJvZ3JhbVRyYW5zaXRpb25FdmVudFR5cGVJbnN0YW5jZQEAUC4BAFAuUC4AAP////8SAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQBRLgAuAERRLgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQBSLgAuAERSLgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAUy4ALgBEUy4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAFQuAC4ARFQuAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQBVLgAuAERVLgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAVi4ALgBEVi4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAWC4ALgBEWC4AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQBZLgAuAERZLgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQBaLgAuAERaLgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAFsuAC4ARFsuAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAXC4ALgBEXC4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAXS4ALgBEXS4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAXi4ALgBEXi4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAE1ldGhvZElkAQBfLgAuAERfLgAAABH/////AQH/////AAAAABdgiQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAGAuAC4ARGAuAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACgAAAE9sZFN0YXRlSWQBAGEuAC4ARGEuAAAAGP////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABOZXdTdGF0ZUlkAQBiLgAuAERiLgAAABj/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAVHJhbnNpdGlvbk51bWJlcgEAYy4ALgBEYy4AAAAH/////wEB/////wAAAAA=";

	private PropertyState<uint> m_transitionNumber;

	public PropertyState<uint> TransitionNumber
	{
		get
		{
			return m_transitionNumber;
		}
		set
		{
			if (m_transitionNumber != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_transitionNumber = value;
		}
	}

	public AuditProgramTransitionEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(11856u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJwAAAEF1ZGl0UHJvZ3JhbVRyYW5zaXRpb25FdmVudFR5cGVJbnN0YW5jZQEAUC4BAFAuUC4AAP////8SAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQBRLgAuAERRLgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQBSLgAuAERSLgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAUy4ALgBEUy4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAFQuAC4ARFQuAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQBVLgAuAERVLgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAVi4ALgBEVi4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAWC4ALgBEWC4AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQBZLgAuAERZLgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQBaLgAuAERaLgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAFsuAC4ARFsuAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAXC4ALgBEXC4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAXS4ALgBEXS4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAXi4ALgBEXi4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAE1ldGhvZElkAQBfLgAuAERfLgAAABH/////AQH/////AAAAABdgiQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAGAuAC4ARGAuAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACgAAAE9sZFN0YXRlSWQBAGEuAC4ARGEuAAAAGP////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABOZXdTdGF0ZUlkAQBiLgAuAERiLgAAABj/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAVHJhbnNpdGlvbk51bWJlcgEAYy4ALgBEYy4AAAAH/////wEB/////wAAAAA=");
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
		if (m_transitionNumber != null)
		{
			children.Add(m_transitionNumber);
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
		if (browseName.Name == "TransitionNumber")
		{
			if (createOrReplace && TransitionNumber == null)
			{
				if (replacement == null)
				{
					TransitionNumber = new PropertyState<uint>(this);
				}
				else
				{
					TransitionNumber = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = TransitionNumber;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
