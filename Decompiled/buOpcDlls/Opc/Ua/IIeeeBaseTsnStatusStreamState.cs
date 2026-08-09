using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class IIeeeBaseTsnStatusStreamState : BaseInterfaceState
{
	private const string TalkerStatus_InitializationString = "//////////8VYIkKAgAAAAAADAAAAFRhbGtlclN0YXR1cwEAeF4ALwA/eF4AAAEAnl7/////AQH/////AAAAAA==";

	private const string ListenerStatus_InitializationString = "//////////8VYIkKAgAAAAAADgAAAExpc3RlbmVyU3RhdHVzAQB5XgAvAD95XgAAAQCgXv////8BAf////8AAAAA";

	private const string InitializationString = "//////////8EYIACAQAAAAAAJAAAAElJZWVlQmFzZVRzblN0YXR1c1N0cmVhbVR5cGVJbnN0YW5jZQEAd14BAHded14AAP////8EAAAAFWCJCgIAAAAAAAwAAABUYWxrZXJTdGF0dXMBAHheAC8AP3heAAABAJ5e/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAExpc3RlbmVyU3RhdHVzAQB5XgAvAD95XgAAAQCgXv////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABGYWlsdXJlQ29kZQEAel4ALwA/el4AAAEAml7/////AQH/////AAAAABdgiQoCAAAAAAAXAAAARmFpbHVyZVN5c3RlbUlkZW50aWZpZXIBAHteAC8AP3teAAAAAwIAAAACAAAAAAAAAAgAAAABAf////8AAAAA";

	private BaseDataVariableState<TsnTalkerStatus> m_talkerStatus;

	private BaseDataVariableState<TsnListenerStatus> m_listenerStatus;

	private BaseDataVariableState<TsnFailureCode> m_failureCode;

	private BaseDataVariableState m_failureSystemIdentifier;

	public BaseDataVariableState<TsnTalkerStatus> TalkerStatus
	{
		get
		{
			return m_talkerStatus;
		}
		set
		{
			if (m_talkerStatus != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_talkerStatus = value;
		}
	}

	public BaseDataVariableState<TsnListenerStatus> ListenerStatus
	{
		get
		{
			return m_listenerStatus;
		}
		set
		{
			if (m_listenerStatus != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_listenerStatus = value;
		}
	}

	public BaseDataVariableState<TsnFailureCode> FailureCode
	{
		get
		{
			return m_failureCode;
		}
		set
		{
			if (m_failureCode != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_failureCode = value;
		}
	}

	public BaseDataVariableState FailureSystemIdentifier
	{
		get
		{
			return m_failureSystemIdentifier;
		}
		set
		{
			if (m_failureSystemIdentifier != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_failureSystemIdentifier = value;
		}
	}

	public IIeeeBaseTsnStatusStreamState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(24183u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJAAAAElJZWVlQmFzZVRzblN0YXR1c1N0cmVhbVR5cGVJbnN0YW5jZQEAd14BAHded14AAP////8EAAAAFWCJCgIAAAAAAAwAAABUYWxrZXJTdGF0dXMBAHheAC8AP3heAAABAJ5e/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAExpc3RlbmVyU3RhdHVzAQB5XgAvAD95XgAAAQCgXv////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABGYWlsdXJlQ29kZQEAel4ALwA/el4AAAEAml7/////AQH/////AAAAABdgiQoCAAAAAAAXAAAARmFpbHVyZVN5c3RlbUlkZW50aWZpZXIBAHteAC8AP3teAAAAAwIAAAACAAAAAAAAAAgAAAABAf////8AAAAA");
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
		if (TalkerStatus != null)
		{
			TalkerStatus.Initialize(context, "//////////8VYIkKAgAAAAAADAAAAFRhbGtlclN0YXR1cwEAeF4ALwA/eF4AAAEAnl7/////AQH/////AAAAAA==");
		}
		if (ListenerStatus != null)
		{
			ListenerStatus.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAExpc3RlbmVyU3RhdHVzAQB5XgAvAD95XgAAAQCgXv////8BAf////8AAAAA");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_talkerStatus != null)
		{
			children.Add(m_talkerStatus);
		}
		if (m_listenerStatus != null)
		{
			children.Add(m_listenerStatus);
		}
		if (m_failureCode != null)
		{
			children.Add(m_failureCode);
		}
		if (m_failureSystemIdentifier != null)
		{
			children.Add(m_failureSystemIdentifier);
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
		case "TalkerStatus":
			if (createOrReplace && TalkerStatus == null)
			{
				if (replacement == null)
				{
					TalkerStatus = new BaseDataVariableState<TsnTalkerStatus>(this);
				}
				else
				{
					TalkerStatus = (BaseDataVariableState<TsnTalkerStatus>)replacement;
				}
			}
			baseInstanceState = TalkerStatus;
			break;
		case "ListenerStatus":
			if (createOrReplace && ListenerStatus == null)
			{
				if (replacement == null)
				{
					ListenerStatus = new BaseDataVariableState<TsnListenerStatus>(this);
				}
				else
				{
					ListenerStatus = (BaseDataVariableState<TsnListenerStatus>)replacement;
				}
			}
			baseInstanceState = ListenerStatus;
			break;
		case "FailureCode":
			if (createOrReplace && FailureCode == null)
			{
				if (replacement == null)
				{
					FailureCode = new BaseDataVariableState<TsnFailureCode>(this);
				}
				else
				{
					FailureCode = (BaseDataVariableState<TsnFailureCode>)replacement;
				}
			}
			baseInstanceState = FailureCode;
			break;
		case "FailureSystemIdentifier":
			if (createOrReplace && FailureSystemIdentifier == null)
			{
				if (replacement == null)
				{
					FailureSystemIdentifier = new BaseDataVariableState(this);
				}
				else
				{
					FailureSystemIdentifier = (BaseDataVariableState)replacement;
				}
			}
			baseInstanceState = FailureSystemIdentifier;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
