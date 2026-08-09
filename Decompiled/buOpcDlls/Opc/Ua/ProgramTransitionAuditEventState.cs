using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ProgramTransitionAuditEventState : AuditUpdateStateEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAJwAAAFByb2dyYW1UcmFuc2l0aW9uQXVkaXRFdmVudFR5cGVJbnN0YW5jZQEA3g4BAN4O3g4AAP////8SAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQDfDgAuAETfDgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQDgDgAuAETgDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEA4Q4ALgBE4Q4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAOIOAC4AROIOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQDjDgAuAETjDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEA5A4ALgBE5A4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEA5g4ALgBE5g4AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQDnDgAuAETnDgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQDoDgAuAEToDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAOkOAC4AROkOAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEA6g4ALgBE6g4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEA6w4ALgBE6w4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEA7A4ALgBE7A4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAE1ldGhvZElkAQDtDgAuAETtDgAAABH/////AQH/////AAAAABdgiQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAO4OAC4ARO4OAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACgAAAE9sZFN0YXRlSWQBAO8OAC4ARO8OAAAAGP////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABOZXdTdGF0ZUlkAQDwDgAuAETwDgAAABj/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAVHJhbnNpdGlvbgEA8Q4ALwEAzwrxDgAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQBAPIOAC4ARPIOAAAAEf////8BAf////8AAAAA";

	private FiniteTransitionVariableState m_transition;

	public FiniteTransitionVariableState Transition
	{
		get
		{
			return m_transition;
		}
		set
		{
			if (m_transition != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_transition = value;
		}
	}

	public ProgramTransitionAuditEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(3806u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJwAAAFByb2dyYW1UcmFuc2l0aW9uQXVkaXRFdmVudFR5cGVJbnN0YW5jZQEA3g4BAN4O3g4AAP////8SAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQDfDgAuAETfDgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQDgDgAuAETgDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEA4Q4ALgBE4Q4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAOIOAC4AROIOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQDjDgAuAETjDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEA5A4ALgBE5A4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEA5g4ALgBE5g4AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQDnDgAuAETnDgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQDoDgAuAEToDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAOkOAC4AROkOAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEA6g4ALgBE6g4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEA6w4ALgBE6w4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEA7A4ALgBE7A4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAE1ldGhvZElkAQDtDgAuAETtDgAAABH/////AQH/////AAAAABdgiQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAO4OAC4ARO4OAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACgAAAE9sZFN0YXRlSWQBAO8OAC4ARO8OAAAAGP////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABOZXdTdGF0ZUlkAQDwDgAuAETwDgAAABj/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAVHJhbnNpdGlvbgEA8Q4ALwEAzwrxDgAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQBAPIOAC4ARPIOAAAAEf////8BAf////8AAAAA");
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
		if (m_transition != null)
		{
			children.Add(m_transition);
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
		if (browseName.Name == "Transition")
		{
			if (createOrReplace && Transition == null)
			{
				if (replacement == null)
				{
					Transition = new FiniteTransitionVariableState(this);
				}
				else
				{
					Transition = (FiniteTransitionVariableState)replacement;
				}
			}
			baseInstanceState = Transition;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
