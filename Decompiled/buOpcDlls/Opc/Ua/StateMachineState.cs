using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class StateMachineState : BaseObjectState
{
	private const string LastTransition_InitializationString = "//////////8VYIkKAgAAAAAADgAAAExhc3RUcmFuc2l0aW9uAQDSCgAvAQDKCtIKAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAAIAAABJZAEAjA4ALgBEjA4AAAAY/////wEB/////wAAAAA=";

	private const string InitializationString = "//////////8EYIACAQAAAAAAGAAAAFN0YXRlTWFjaGluZVR5cGVJbnN0YW5jZQEA+wgBAPsI+wgAAP////8CAAAAFWCJCgIAAAAAAAwAAABDdXJyZW50U3RhdGUBANEKAC8BAMMK0QoAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQCIDgAuAESIDgAAABj/////AQH/////AAAAABVgiQoCAAAAAAAOAAAATGFzdFRyYW5zaXRpb24BANIKAC8BAMoK0goAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQCMDgAuAESMDgAAABj/////AQH/////AAAAAA==";

	private StateVariableState m_currentState;

	private TransitionVariableState m_lastTransition;

	public StateVariableState CurrentState
	{
		get
		{
			return m_currentState;
		}
		set
		{
			if (m_currentState != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_currentState = value;
		}
	}

	public TransitionVariableState LastTransition
	{
		get
		{
			return m_lastTransition;
		}
		set
		{
			if (m_lastTransition != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_lastTransition = value;
		}
	}

	public StateMachineState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2299u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAGAAAAFN0YXRlTWFjaGluZVR5cGVJbnN0YW5jZQEA+wgBAPsI+wgAAP////8CAAAAFWCJCgIAAAAAAAwAAABDdXJyZW50U3RhdGUBANEKAC8BAMMK0QoAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQCIDgAuAESIDgAAABj/////AQH/////AAAAABVgiQoCAAAAAAAOAAAATGFzdFRyYW5zaXRpb24BANIKAC8BAMoK0goAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQCMDgAuAESMDgAAABj/////AQH/////AAAAAA==");
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
		if (LastTransition != null)
		{
			LastTransition.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAExhc3RUcmFuc2l0aW9uAQDSCgAvAQDKCtIKAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAAIAAABJZAEAjA4ALgBEjA4AAAAY/////wEB/////wAAAAA=");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_currentState != null)
		{
			children.Add(m_currentState);
		}
		if (m_lastTransition != null)
		{
			children.Add(m_lastTransition);
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
		if (!(name == "CurrentState"))
		{
			if (name == "LastTransition")
			{
				if (createOrReplace && LastTransition == null)
				{
					if (replacement == null)
					{
						LastTransition = new TransitionVariableState(this);
					}
					else
					{
						LastTransition = (TransitionVariableState)replacement;
					}
				}
				baseInstanceState = LastTransition;
			}
		}
		else
		{
			if (createOrReplace && CurrentState == null)
			{
				if (replacement == null)
				{
					CurrentState = new StateVariableState(this);
				}
				else
				{
					CurrentState = (StateVariableState)replacement;
				}
			}
			baseInstanceState = CurrentState;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
