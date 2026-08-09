using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class TwoStateDiscreteState : DiscreteItemState<bool>
{
	private const string InitializationString = "//////////8VYIECAgAAAAAAHAAAAFR3b1N0YXRlRGlzY3JldGVUeXBlSW5zdGFuY2UBAEUJAQBFCUUJAAAAAQEB/////wIAAAAVYIkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAEYJAC4AREYJAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABUcnVlU3RhdGUBAEcJAC4AREcJAAAAFf////8BAf////8AAAAA";

	private PropertyState<LocalizedText> m_falseState;

	private PropertyState<LocalizedText> m_trueState;

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

	public TwoStateDiscreteState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2373u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(1u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIECAgAAAAAAHAAAAFR3b1N0YXRlRGlzY3JldGVUeXBlSW5zdGFuY2UBAEUJAQBFCUUJAAAAAQEB/////wIAAAAVYIkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAEYJAC4AREYJAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABUcnVlU3RhdGUBAEcJAC4AREcJAAAAFf////8BAf////8AAAAA");
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
		if (m_falseState != null)
		{
			children.Add(m_falseState);
		}
		if (m_trueState != null)
		{
			children.Add(m_trueState);
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
		string name = browseName.Name;
		if (!(name == "FalseState"))
		{
			if (name == "TrueState")
			{
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
			}
		}
		else
		{
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
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
