using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class StateMachineTransitionState : BaseObjectState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAFgAAAFRyYW5zaXRpb25UeXBlSW5zdGFuY2UBAAYJAQAGCQYJAAD/////AQAAABVgiQoCAAAAAAAQAAAAVHJhbnNpdGlvbk51bWJlcgEACAkALgBECAkAAAAH/////wEB/////wAAAAA=";

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

	public StateMachineTransitionState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2310u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAFgAAAFRyYW5zaXRpb25UeXBlSW5zdGFuY2UBAAYJAQAGCQYJAAD/////AQAAABVgiQoCAAAAAAAQAAAAVHJhbnNpdGlvbk51bWJlcgEACAkALgBECAkAAAAH/////wEB/////wAAAAA=");
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
