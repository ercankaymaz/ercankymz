using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class TransitionEventState : BaseEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAGwAAAFRyYW5zaXRpb25FdmVudFR5cGVJbnN0YW5jZQEABwkBAAcJBwkAAP////8LAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQCZDgAuAESZDgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCaDgAuAESaDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAmw4ALgBEmw4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAJwOAC4ARJwOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCdDgAuAESdDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAng4ALgBEng4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAoA4ALgBEoA4AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQChDgAuAEShDgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAVHJhbnNpdGlvbgEA1goALwEAygrWCgAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQBAKoOAC4ARKoOAAAAGP////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABGcm9tU3RhdGUBANcKAC8BAMMK1woAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQCiDgAuAESiDgAAABj/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAVG9TdGF0ZQEA2AoALwEAwwrYCgAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQBAKYOAC4ARKYOAAAAGP////8BAf////8AAAAA";

	private TransitionVariableState m_transition;

	private StateVariableState m_fromState;

	private StateVariableState m_toState;

	public TransitionVariableState Transition
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

	public StateVariableState FromState
	{
		get
		{
			return m_fromState;
		}
		set
		{
			if (m_fromState != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_fromState = value;
		}
	}

	public StateVariableState ToState
	{
		get
		{
			return m_toState;
		}
		set
		{
			if (m_toState != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_toState = value;
		}
	}

	public TransitionEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2311u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAGwAAAFRyYW5zaXRpb25FdmVudFR5cGVJbnN0YW5jZQEABwkBAAcJBwkAAP////8LAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQCZDgAuAESZDgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCaDgAuAESaDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAmw4ALgBEmw4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAJwOAC4ARJwOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCdDgAuAESdDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAng4ALgBEng4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAoA4ALgBEoA4AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQChDgAuAEShDgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAVHJhbnNpdGlvbgEA1goALwEAygrWCgAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQBAKoOAC4ARKoOAAAAGP////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABGcm9tU3RhdGUBANcKAC8BAMMK1woAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQCiDgAuAESiDgAAABj/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAVG9TdGF0ZQEA2AoALwEAwwrYCgAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQBAKYOAC4ARKYOAAAAGP////8BAf////8AAAAA");
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
		if (m_fromState != null)
		{
			children.Add(m_fromState);
		}
		if (m_toState != null)
		{
			children.Add(m_toState);
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
		case "Transition":
			if (createOrReplace && Transition == null)
			{
				if (replacement == null)
				{
					Transition = new TransitionVariableState(this);
				}
				else
				{
					Transition = (TransitionVariableState)replacement;
				}
			}
			baseInstanceState = Transition;
			break;
		case "FromState":
			if (createOrReplace && FromState == null)
			{
				if (replacement == null)
				{
					FromState = new StateVariableState(this);
				}
				else
				{
					FromState = (StateVariableState)replacement;
				}
			}
			baseInstanceState = FromState;
			break;
		case "ToState":
			if (createOrReplace && ToState == null)
			{
				if (replacement == null)
				{
					ToState = new StateVariableState(this);
				}
				else
				{
					ToState = (StateVariableState)replacement;
				}
			}
			baseInstanceState = ToState;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
