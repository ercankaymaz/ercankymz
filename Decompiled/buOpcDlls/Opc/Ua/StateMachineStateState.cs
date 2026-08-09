using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class StateMachineStateState : BaseObjectState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAEQAAAFN0YXRlVHlwZUluc3RhbmNlAQADCQEAAwkDCQAA/////wEAAAAVYIkKAgAAAAAACwAAAFN0YXRlTnVtYmVyAQAECQAuAEQECQAAAAf/////AQH/////AAAAAA==";

	private PropertyState<uint> m_stateNumber;

	public PropertyState<uint> StateNumber
	{
		get
		{
			return m_stateNumber;
		}
		set
		{
			if (m_stateNumber != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_stateNumber = value;
		}
	}

	public StateMachineStateState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2307u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAEQAAAFN0YXRlVHlwZUluc3RhbmNlAQADCQEAAwkDCQAA/////wEAAAAVYIkKAgAAAAAACwAAAFN0YXRlTnVtYmVyAQAECQAuAEQECQAAAAf/////AQH/////AAAAAA==");
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
		if (m_stateNumber != null)
		{
			children.Add(m_stateNumber);
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
		if (browseName.Name == "StateNumber")
		{
			if (createOrReplace && StateNumber == null)
			{
				if (replacement == null)
				{
					StateNumber = new PropertyState<uint>(this);
				}
				else
				{
					StateNumber = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = StateNumber;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
