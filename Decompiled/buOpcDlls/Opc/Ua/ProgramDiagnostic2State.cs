using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ProgramDiagnostic2State : BaseDataVariableState<ProgramDiagnostic2DataType>
{
	private const string InitializationString = "//////////8VYIkCAgAAAAAAHgAAAFByb2dyYW1EaWFnbm9zdGljMlR5cGVJbnN0YW5jZQEAFzwBABc8FzwAAAEA4V3/////AQH/////DAAAABVgiQoCAAAAAAAPAAAAQ3JlYXRlU2Vzc2lvbklkAQAYPAAvAD8YPAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQ3JlYXRlQ2xpZW50TmFtZQEAGTwALwA/GTwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAFgAAAEludm9jYXRpb25DcmVhdGlvblRpbWUBABo8AC8APxo8AAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAExhc3RUcmFuc2l0aW9uVGltZQEAGzwALgBEGzwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAATGFzdE1ldGhvZENhbGwBABw8AC8APxw8AAAADP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABMYXN0TWV0aG9kU2Vzc2lvbklkAQAdPAAvAD8dPAAAABH/////AQH/////AAAAABdgiQoCAAAAAAAYAAAATGFzdE1ldGhvZElucHV0QXJndW1lbnRzAQAePAAvAD8ePAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAGQAAAExhc3RNZXRob2RPdXRwdXRBcmd1bWVudHMBAB88AC8APx88AAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAVAAAATGFzdE1ldGhvZElucHV0VmFsdWVzAQAgPAAvAD8gPAAAABgBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABYAAABMYXN0TWV0aG9kT3V0cHV0VmFsdWVzAQAhPAAvAD8hPAAAABgBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABIAAABMYXN0TWV0aG9kQ2FsbFRpbWUBACI8AC8APyI8AAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAAFgAAAExhc3RNZXRob2RSZXR1cm5TdGF0dXMBACM8AC8APyM8AAAAE/////8BAf////8AAAAA";

	private BaseDataVariableState<NodeId> m_createSessionId;

	private BaseDataVariableState<string> m_createClientName;

	private BaseDataVariableState<DateTime> m_invocationCreationTime;

	private PropertyState<DateTime> m_lastTransitionTime;

	private BaseDataVariableState<string> m_lastMethodCall;

	private BaseDataVariableState<NodeId> m_lastMethodSessionId;

	private BaseDataVariableState<Argument[]> m_lastMethodInputArguments;

	private BaseDataVariableState<Argument[]> m_lastMethodOutputArguments;

	private BaseDataVariableState<object[]> m_lastMethodInputValues;

	private BaseDataVariableState<object[]> m_lastMethodOutputValues;

	private BaseDataVariableState<DateTime> m_lastMethodCallTime;

	private BaseDataVariableState<StatusCode> m_lastMethodReturnStatus;

	public BaseDataVariableState<NodeId> CreateSessionId
	{
		get
		{
			return m_createSessionId;
		}
		set
		{
			if (m_createSessionId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_createSessionId = value;
		}
	}

	public BaseDataVariableState<string> CreateClientName
	{
		get
		{
			return m_createClientName;
		}
		set
		{
			if (m_createClientName != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_createClientName = value;
		}
	}

	public BaseDataVariableState<DateTime> InvocationCreationTime
	{
		get
		{
			return m_invocationCreationTime;
		}
		set
		{
			if (m_invocationCreationTime != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_invocationCreationTime = value;
		}
	}

	public PropertyState<DateTime> LastTransitionTime
	{
		get
		{
			return m_lastTransitionTime;
		}
		set
		{
			if (m_lastTransitionTime != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_lastTransitionTime = value;
		}
	}

	public BaseDataVariableState<string> LastMethodCall
	{
		get
		{
			return m_lastMethodCall;
		}
		set
		{
			if (m_lastMethodCall != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_lastMethodCall = value;
		}
	}

	public BaseDataVariableState<NodeId> LastMethodSessionId
	{
		get
		{
			return m_lastMethodSessionId;
		}
		set
		{
			if (m_lastMethodSessionId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_lastMethodSessionId = value;
		}
	}

	public BaseDataVariableState<Argument[]> LastMethodInputArguments
	{
		get
		{
			return m_lastMethodInputArguments;
		}
		set
		{
			if (m_lastMethodInputArguments != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_lastMethodInputArguments = value;
		}
	}

	public BaseDataVariableState<Argument[]> LastMethodOutputArguments
	{
		get
		{
			return m_lastMethodOutputArguments;
		}
		set
		{
			if (m_lastMethodOutputArguments != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_lastMethodOutputArguments = value;
		}
	}

	public BaseDataVariableState<object[]> LastMethodInputValues
	{
		get
		{
			return m_lastMethodInputValues;
		}
		set
		{
			if (m_lastMethodInputValues != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_lastMethodInputValues = value;
		}
	}

	public BaseDataVariableState<object[]> LastMethodOutputValues
	{
		get
		{
			return m_lastMethodOutputValues;
		}
		set
		{
			if (m_lastMethodOutputValues != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_lastMethodOutputValues = value;
		}
	}

	public BaseDataVariableState<DateTime> LastMethodCallTime
	{
		get
		{
			return m_lastMethodCallTime;
		}
		set
		{
			if (m_lastMethodCallTime != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_lastMethodCallTime = value;
		}
	}

	public BaseDataVariableState<StatusCode> LastMethodReturnStatus
	{
		get
		{
			return m_lastMethodReturnStatus;
		}
		set
		{
			if (m_lastMethodReturnStatus != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_lastMethodReturnStatus = value;
		}
	}

	public ProgramDiagnostic2State(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(15383u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(24033u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAHgAAAFByb2dyYW1EaWFnbm9zdGljMlR5cGVJbnN0YW5jZQEAFzwBABc8FzwAAAEA4V3/////AQH/////DAAAABVgiQoCAAAAAAAPAAAAQ3JlYXRlU2Vzc2lvbklkAQAYPAAvAD8YPAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQ3JlYXRlQ2xpZW50TmFtZQEAGTwALwA/GTwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAFgAAAEludm9jYXRpb25DcmVhdGlvblRpbWUBABo8AC8APxo8AAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAExhc3RUcmFuc2l0aW9uVGltZQEAGzwALgBEGzwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAATGFzdE1ldGhvZENhbGwBABw8AC8APxw8AAAADP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABMYXN0TWV0aG9kU2Vzc2lvbklkAQAdPAAvAD8dPAAAABH/////AQH/////AAAAABdgiQoCAAAAAAAYAAAATGFzdE1ldGhvZElucHV0QXJndW1lbnRzAQAePAAvAD8ePAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAGQAAAExhc3RNZXRob2RPdXRwdXRBcmd1bWVudHMBAB88AC8APx88AAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAVAAAATGFzdE1ldGhvZElucHV0VmFsdWVzAQAgPAAvAD8gPAAAABgBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABYAAABMYXN0TWV0aG9kT3V0cHV0VmFsdWVzAQAhPAAvAD8hPAAAABgBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABIAAABMYXN0TWV0aG9kQ2FsbFRpbWUBACI8AC8APyI8AAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAAFgAAAExhc3RNZXRob2RSZXR1cm5TdGF0dXMBACM8AC8APyM8AAAAE/////8BAf////8AAAAA");
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
		if (m_createSessionId != null)
		{
			children.Add(m_createSessionId);
		}
		if (m_createClientName != null)
		{
			children.Add(m_createClientName);
		}
		if (m_invocationCreationTime != null)
		{
			children.Add(m_invocationCreationTime);
		}
		if (m_lastTransitionTime != null)
		{
			children.Add(m_lastTransitionTime);
		}
		if (m_lastMethodCall != null)
		{
			children.Add(m_lastMethodCall);
		}
		if (m_lastMethodSessionId != null)
		{
			children.Add(m_lastMethodSessionId);
		}
		if (m_lastMethodInputArguments != null)
		{
			children.Add(m_lastMethodInputArguments);
		}
		if (m_lastMethodOutputArguments != null)
		{
			children.Add(m_lastMethodOutputArguments);
		}
		if (m_lastMethodInputValues != null)
		{
			children.Add(m_lastMethodInputValues);
		}
		if (m_lastMethodOutputValues != null)
		{
			children.Add(m_lastMethodOutputValues);
		}
		if (m_lastMethodCallTime != null)
		{
			children.Add(m_lastMethodCallTime);
		}
		if (m_lastMethodReturnStatus != null)
		{
			children.Add(m_lastMethodReturnStatus);
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
		case "CreateSessionId":
			if (createOrReplace && CreateSessionId == null)
			{
				if (replacement == null)
				{
					CreateSessionId = new BaseDataVariableState<NodeId>(this);
				}
				else
				{
					CreateSessionId = (BaseDataVariableState<NodeId>)replacement;
				}
			}
			baseInstanceState = CreateSessionId;
			break;
		case "CreateClientName":
			if (createOrReplace && CreateClientName == null)
			{
				if (replacement == null)
				{
					CreateClientName = new BaseDataVariableState<string>(this);
				}
				else
				{
					CreateClientName = (BaseDataVariableState<string>)replacement;
				}
			}
			baseInstanceState = CreateClientName;
			break;
		case "InvocationCreationTime":
			if (createOrReplace && InvocationCreationTime == null)
			{
				if (replacement == null)
				{
					InvocationCreationTime = new BaseDataVariableState<DateTime>(this);
				}
				else
				{
					InvocationCreationTime = (BaseDataVariableState<DateTime>)replacement;
				}
			}
			baseInstanceState = InvocationCreationTime;
			break;
		case "LastTransitionTime":
			if (createOrReplace && LastTransitionTime == null)
			{
				if (replacement == null)
				{
					LastTransitionTime = new PropertyState<DateTime>(this);
				}
				else
				{
					LastTransitionTime = (PropertyState<DateTime>)replacement;
				}
			}
			baseInstanceState = LastTransitionTime;
			break;
		case "LastMethodCall":
			if (createOrReplace && LastMethodCall == null)
			{
				if (replacement == null)
				{
					LastMethodCall = new BaseDataVariableState<string>(this);
				}
				else
				{
					LastMethodCall = (BaseDataVariableState<string>)replacement;
				}
			}
			baseInstanceState = LastMethodCall;
			break;
		case "LastMethodSessionId":
			if (createOrReplace && LastMethodSessionId == null)
			{
				if (replacement == null)
				{
					LastMethodSessionId = new BaseDataVariableState<NodeId>(this);
				}
				else
				{
					LastMethodSessionId = (BaseDataVariableState<NodeId>)replacement;
				}
			}
			baseInstanceState = LastMethodSessionId;
			break;
		case "LastMethodInputArguments":
			if (createOrReplace && LastMethodInputArguments == null)
			{
				if (replacement == null)
				{
					LastMethodInputArguments = new BaseDataVariableState<Argument[]>(this);
				}
				else
				{
					LastMethodInputArguments = (BaseDataVariableState<Argument[]>)replacement;
				}
			}
			baseInstanceState = LastMethodInputArguments;
			break;
		case "LastMethodOutputArguments":
			if (createOrReplace && LastMethodOutputArguments == null)
			{
				if (replacement == null)
				{
					LastMethodOutputArguments = new BaseDataVariableState<Argument[]>(this);
				}
				else
				{
					LastMethodOutputArguments = (BaseDataVariableState<Argument[]>)replacement;
				}
			}
			baseInstanceState = LastMethodOutputArguments;
			break;
		case "LastMethodInputValues":
			if (createOrReplace && LastMethodInputValues == null)
			{
				if (replacement == null)
				{
					LastMethodInputValues = new BaseDataVariableState<object[]>(this);
				}
				else
				{
					LastMethodInputValues = (BaseDataVariableState<object[]>)replacement;
				}
			}
			baseInstanceState = LastMethodInputValues;
			break;
		case "LastMethodOutputValues":
			if (createOrReplace && LastMethodOutputValues == null)
			{
				if (replacement == null)
				{
					LastMethodOutputValues = new BaseDataVariableState<object[]>(this);
				}
				else
				{
					LastMethodOutputValues = (BaseDataVariableState<object[]>)replacement;
				}
			}
			baseInstanceState = LastMethodOutputValues;
			break;
		case "LastMethodCallTime":
			if (createOrReplace && LastMethodCallTime == null)
			{
				if (replacement == null)
				{
					LastMethodCallTime = new BaseDataVariableState<DateTime>(this);
				}
				else
				{
					LastMethodCallTime = (BaseDataVariableState<DateTime>)replacement;
				}
			}
			baseInstanceState = LastMethodCallTime;
			break;
		case "LastMethodReturnStatus":
			if (createOrReplace && LastMethodReturnStatus == null)
			{
				if (replacement == null)
				{
					LastMethodReturnStatus = new BaseDataVariableState<StatusCode>(this);
				}
				else
				{
					LastMethodReturnStatus = (BaseDataVariableState<StatusCode>)replacement;
				}
			}
			baseInstanceState = LastMethodReturnStatus;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
