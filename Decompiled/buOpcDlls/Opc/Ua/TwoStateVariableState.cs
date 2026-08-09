using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class TwoStateVariableState : StateVariableState
{
	private const string TransitionTime_InitializationString = "//////////8VYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQAoIwAuAEQoIwAAAQAmAf////8BAf////8AAAAA";

	private const string EffectiveTransitionTime_InitializationString = "//////////8VYIkKAgAAAAAAFwAAAEVmZmVjdGl2ZVRyYW5zaXRpb25UaW1lAQApIwAuAEQpIwAAAQAmAf////8BAf////8AAAAA";

	private const string TrueState_InitializationString = "//////////8VYIkKAgAAAAAACQAAAFRydWVTdGF0ZQEAZisALgBEZisAAAAV/////wEB/////wAAAAA=";

	private const string FalseState_InitializationString = "//////////8VYIkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAGcrAC4ARGcrAAAAFf////8BAf////8AAAAA";

	private const string InitializationString = "//////////8VYIkCAgAAAAAAHAAAAFR3b1N0YXRlVmFyaWFibGVUeXBlSW5zdGFuY2UBACMjAQAjIyMjAAAAFf////8BAf////8FAAAAFWCJCgIAAAAAAAIAAABJZAEAJCMALgBEJCMAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQAoIwAuAEQoIwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABcAAABFZmZlY3RpdmVUcmFuc2l0aW9uVGltZQEAKSMALgBEKSMAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQBmKwAuAERmKwAAABX/////AQH/////AAAAABVgiQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEAZysALgBEZysAAAAV/////wEB/////wAAAAA=";

	private PropertyState<DateTime> m_transitionTime;

	private PropertyState<DateTime> m_effectiveTransitionTime;

	private PropertyState<LocalizedText> m_trueState;

	private PropertyState<LocalizedText> m_falseState;

	public new PropertyState<bool> Id
	{
		get
		{
			return (PropertyState<bool>)base.Id;
		}
		set
		{
			base.Id = value;
		}
	}

	public PropertyState<DateTime> TransitionTime
	{
		get
		{
			return m_transitionTime;
		}
		set
		{
			if (m_transitionTime != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_transitionTime = value;
		}
	}

	public PropertyState<DateTime> EffectiveTransitionTime
	{
		get
		{
			return m_effectiveTransitionTime;
		}
		set
		{
			if (m_effectiveTransitionTime != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_effectiveTransitionTime = value;
		}
	}

	public PropertyState<LocalizedText> TrueState
	{
		get
		{
			return m_trueState;
		}
		set
		{
			if (m_trueState != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_trueState = value;
		}
	}

	public PropertyState<LocalizedText> FalseState
	{
		get
		{
			return m_falseState;
		}
		set
		{
			if (m_falseState != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_falseState = value;
		}
	}

	public TwoStateVariableState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(8995u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(21u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAHAAAAFR3b1N0YXRlVmFyaWFibGVUeXBlSW5zdGFuY2UBACMjAQAjIyMjAAAAFf////8BAf////8FAAAAFWCJCgIAAAAAAAIAAABJZAEAJCMALgBEJCMAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQAoIwAuAEQoIwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABcAAABFZmZlY3RpdmVUcmFuc2l0aW9uVGltZQEAKSMALgBEKSMAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQBmKwAuAERmKwAAABX/////AQH/////AAAAABVgiQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEAZysALgBEZysAAAAV/////wEB/////wAAAAA=");
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
		if (TransitionTime != null)
		{
			TransitionTime.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQAoIwAuAEQoIwAAAQAmAf////8BAf////8AAAAA");
		}
		if (EffectiveTransitionTime != null)
		{
			EffectiveTransitionTime.Initialize(context, "//////////8VYIkKAgAAAAAAFwAAAEVmZmVjdGl2ZVRyYW5zaXRpb25UaW1lAQApIwAuAEQpIwAAAQAmAf////8BAf////8AAAAA");
		}
		if (TrueState != null)
		{
			TrueState.Initialize(context, "//////////8VYIkKAgAAAAAACQAAAFRydWVTdGF0ZQEAZisALgBEZisAAAAV/////wEB/////wAAAAA=");
		}
		if (FalseState != null)
		{
			FalseState.Initialize(context, "//////////8VYIkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAGcrAC4ARGcrAAAAFf////8BAf////8AAAAA");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_transitionTime != null)
		{
			children.Add(m_transitionTime);
		}
		if (m_effectiveTransitionTime != null)
		{
			children.Add(m_effectiveTransitionTime);
		}
		if (m_trueState != null)
		{
			children.Add(m_trueState);
		}
		if (m_falseState != null)
		{
			children.Add(m_falseState);
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
		case "Id":
			if (createOrReplace && Id == null)
			{
				if (replacement == null)
				{
					Id = new PropertyState<bool>(this);
				}
				else
				{
					Id = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = Id;
			break;
		case "TransitionTime":
			if (createOrReplace && TransitionTime == null)
			{
				if (replacement == null)
				{
					TransitionTime = new PropertyState<DateTime>(this);
				}
				else
				{
					TransitionTime = (PropertyState<DateTime>)replacement;
				}
			}
			baseInstanceState = TransitionTime;
			break;
		case "EffectiveTransitionTime":
			if (createOrReplace && EffectiveTransitionTime == null)
			{
				if (replacement == null)
				{
					EffectiveTransitionTime = new PropertyState<DateTime>(this);
				}
				else
				{
					EffectiveTransitionTime = (PropertyState<DateTime>)replacement;
				}
			}
			baseInstanceState = EffectiveTransitionTime;
			break;
		case "TrueState":
			if (createOrReplace && TrueState == null)
			{
				if (replacement == null)
				{
					TrueState = new PropertyState<LocalizedText>(this);
				}
				else
				{
					TrueState = (PropertyState<LocalizedText>)replacement;
				}
			}
			baseInstanceState = TrueState;
			break;
		case "FalseState":
			if (createOrReplace && FalseState == null)
			{
				if (replacement == null)
				{
					FalseState = new PropertyState<LocalizedText>(this);
				}
				else
				{
					FalseState = (PropertyState<LocalizedText>)replacement;
				}
			}
			baseInstanceState = FalseState;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
