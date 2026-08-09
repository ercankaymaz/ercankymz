using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class PubSubStatusState : BaseObjectState
{
	private const string Enable_InitializationString = "//////////8EYYIKBAAAAAAABgAAAEVuYWJsZQEANTkALwEANTk1OQAAAQH/////AAAAAA==";

	private const string Disable_InitializationString = "//////////8EYYIKBAAAAAAABwAAAERpc2FibGUBADY5AC8BADY5NjkAAAEB/////wAAAAA=";

	private const string InitializationString = "//////////8EYIACAQAAAAAAGAAAAFB1YlN1YlN0YXR1c1R5cGVJbnN0YW5jZQEAMzkBADM5MzkAAP////8DAAAAFWCJCgIAAAAAAAUAAABTdGF0ZQEANDkALwA/NDkAAAEANzn/////AQH/////AAAAAARhggoEAAAAAAAGAAAARW5hYmxlAQA1OQAvAQA1OTU5AAABAf////8AAAAABGGCCgQAAAAAAAcAAABEaXNhYmxlAQA2OQAvAQA2OTY5AAABAf////8AAAAA";

	private BaseDataVariableState<PubSubState> m_state;

	private MethodState m_enableMethod;

	private MethodState m_disableMethod;

	public BaseDataVariableState<PubSubState> State
	{
		get
		{
			return m_state;
		}
		set
		{
			if (m_state != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_state = value;
		}
	}

	public MethodState Enable
	{
		get
		{
			return m_enableMethod;
		}
		set
		{
			if (m_enableMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_enableMethod = value;
		}
	}

	public MethodState Disable
	{
		get
		{
			return m_disableMethod;
		}
		set
		{
			if (m_disableMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_disableMethod = value;
		}
	}

	public PubSubStatusState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(14643u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAGAAAAFB1YlN1YlN0YXR1c1R5cGVJbnN0YW5jZQEAMzkBADM5MzkAAP////8DAAAAFWCJCgIAAAAAAAUAAABTdGF0ZQEANDkALwA/NDkAAAEANzn/////AQH/////AAAAAARhggoEAAAAAAAGAAAARW5hYmxlAQA1OQAvAQA1OTU5AAABAf////8AAAAABGGCCgQAAAAAAAcAAABEaXNhYmxlAQA2OQAvAQA2OTY5AAABAf////8AAAAA");
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
		if (Enable != null)
		{
			Enable.Initialize(context, "//////////8EYYIKBAAAAAAABgAAAEVuYWJsZQEANTkALwEANTk1OQAAAQH/////AAAAAA==");
		}
		if (Disable != null)
		{
			Disable.Initialize(context, "//////////8EYYIKBAAAAAAABwAAAERpc2FibGUBADY5AC8BADY5NjkAAAEB/////wAAAAA=");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_state != null)
		{
			children.Add(m_state);
		}
		if (m_enableMethod != null)
		{
			children.Add(m_enableMethod);
		}
		if (m_disableMethod != null)
		{
			children.Add(m_disableMethod);
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
		case "State":
			if (createOrReplace && State == null)
			{
				if (replacement == null)
				{
					State = new BaseDataVariableState<PubSubState>(this);
				}
				else
				{
					State = (BaseDataVariableState<PubSubState>)replacement;
				}
			}
			baseInstanceState = State;
			break;
		case "Enable":
			if (createOrReplace && Enable == null)
			{
				if (replacement == null)
				{
					Enable = new MethodState(this);
				}
				else
				{
					Enable = (MethodState)replacement;
				}
			}
			baseInstanceState = Enable;
			break;
		case "Disable":
			if (createOrReplace && Disable == null)
			{
				if (replacement == null)
				{
					Disable = new MethodState(this);
				}
				else
				{
					Disable = (MethodState)replacement;
				}
			}
			baseInstanceState = Disable;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
