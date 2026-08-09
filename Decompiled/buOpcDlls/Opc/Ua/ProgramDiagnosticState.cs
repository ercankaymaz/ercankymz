using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ProgramDiagnosticState : BaseDataVariableState<ProgramDiagnosticDataType>
{
	private const string InitializationString = "//////////8VYIkCAgAAAAAAHQAAAFByb2dyYW1EaWFnbm9zdGljVHlwZUluc3RhbmNlAQBMCQEATAlMCQAAAQB+A/////8BAf////8KAAAAFWCJCgIAAAAAAA8AAABDcmVhdGVTZXNzaW9uSWQBAE0JAC4ARE0JAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABDcmVhdGVDbGllbnROYW1lAQBOCQAuAEROCQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAWAAAASW52b2NhdGlvbkNyZWF0aW9uVGltZQEATwkALgBETwkAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAASAAAATGFzdFRyYW5zaXRpb25UaW1lAQBQCQAuAERQCQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABMYXN0TWV0aG9kQ2FsbAEAUQkALgBEUQkAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAExhc3RNZXRob2RTZXNzaW9uSWQBAFIJAC4ARFIJAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAABgAAABMYXN0TWV0aG9kSW5wdXRBcmd1bWVudHMBAFMJAC4ARFMJAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAGQAAAExhc3RNZXRob2RPdXRwdXRBcmd1bWVudHMBAFQJAC4ARFQJAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAAEgAAAExhc3RNZXRob2RDYWxsVGltZQEAVQkALgBEVQkAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAWAAAATGFzdE1ldGhvZFJldHVyblN0YXR1cwEAVgkALgBEVgkAAAEAKwH/////AQH/////AAAAAA==";

	private PropertyState<NodeId> m_createSessionId;

	private PropertyState<string> m_createClientName;

	private PropertyState<DateTime> m_invocationCreationTime;

	private PropertyState<DateTime> m_lastTransitionTime;

	private PropertyState<string> m_lastMethodCall;

	private PropertyState<NodeId> m_lastMethodSessionId;

	private PropertyState<object[]> m_lastMethodInputArguments;

	private PropertyState<object[]> m_lastMethodOutputArguments;

	private PropertyState<DateTime> m_lastMethodCallTime;

	private PropertyState<StatusResult> m_lastMethodReturnStatus;

	public PropertyState<NodeId> CreateSessionId
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

	public PropertyState<string> CreateClientName
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

	public PropertyState<DateTime> InvocationCreationTime
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

	public PropertyState<string> LastMethodCall
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

	public PropertyState<NodeId> LastMethodSessionId
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

	public PropertyState<object[]> LastMethodInputArguments
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

	public PropertyState<object[]> LastMethodOutputArguments
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

	public PropertyState<DateTime> LastMethodCallTime
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

	public PropertyState<StatusResult> LastMethodReturnStatus
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

	public ProgramDiagnosticState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2380u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(894u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAHQAAAFByb2dyYW1EaWFnbm9zdGljVHlwZUluc3RhbmNlAQBMCQEATAlMCQAAAQB+A/////8BAf////8KAAAAFWCJCgIAAAAAAA8AAABDcmVhdGVTZXNzaW9uSWQBAE0JAC4ARE0JAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABDcmVhdGVDbGllbnROYW1lAQBOCQAuAEROCQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAWAAAASW52b2NhdGlvbkNyZWF0aW9uVGltZQEATwkALgBETwkAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAASAAAATGFzdFRyYW5zaXRpb25UaW1lAQBQCQAuAERQCQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABMYXN0TWV0aG9kQ2FsbAEAUQkALgBEUQkAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAExhc3RNZXRob2RTZXNzaW9uSWQBAFIJAC4ARFIJAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAABgAAABMYXN0TWV0aG9kSW5wdXRBcmd1bWVudHMBAFMJAC4ARFMJAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAGQAAAExhc3RNZXRob2RPdXRwdXRBcmd1bWVudHMBAFQJAC4ARFQJAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAAEgAAAExhc3RNZXRob2RDYWxsVGltZQEAVQkALgBEVQkAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAWAAAATGFzdE1ldGhvZFJldHVyblN0YXR1cwEAVgkALgBEVgkAAAEAKwH/////AQH/////AAAAAA==");
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
					CreateSessionId = new PropertyState<NodeId>(this);
				}
				else
				{
					CreateSessionId = (PropertyState<NodeId>)replacement;
				}
			}
			baseInstanceState = CreateSessionId;
			break;
		case "CreateClientName":
			if (createOrReplace && CreateClientName == null)
			{
				if (replacement == null)
				{
					CreateClientName = new PropertyState<string>(this);
				}
				else
				{
					CreateClientName = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = CreateClientName;
			break;
		case "InvocationCreationTime":
			if (createOrReplace && InvocationCreationTime == null)
			{
				if (replacement == null)
				{
					InvocationCreationTime = new PropertyState<DateTime>(this);
				}
				else
				{
					InvocationCreationTime = (PropertyState<DateTime>)replacement;
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
					LastMethodCall = new PropertyState<string>(this);
				}
				else
				{
					LastMethodCall = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = LastMethodCall;
			break;
		case "LastMethodSessionId":
			if (createOrReplace && LastMethodSessionId == null)
			{
				if (replacement == null)
				{
					LastMethodSessionId = new PropertyState<NodeId>(this);
				}
				else
				{
					LastMethodSessionId = (PropertyState<NodeId>)replacement;
				}
			}
			baseInstanceState = LastMethodSessionId;
			break;
		case "LastMethodInputArguments":
			if (createOrReplace && LastMethodInputArguments == null)
			{
				if (replacement == null)
				{
					LastMethodInputArguments = new PropertyState<object[]>(this);
				}
				else
				{
					LastMethodInputArguments = (PropertyState<object[]>)replacement;
				}
			}
			baseInstanceState = LastMethodInputArguments;
			break;
		case "LastMethodOutputArguments":
			if (createOrReplace && LastMethodOutputArguments == null)
			{
				if (replacement == null)
				{
					LastMethodOutputArguments = new PropertyState<object[]>(this);
				}
				else
				{
					LastMethodOutputArguments = (PropertyState<object[]>)replacement;
				}
			}
			baseInstanceState = LastMethodOutputArguments;
			break;
		case "LastMethodCallTime":
			if (createOrReplace && LastMethodCallTime == null)
			{
				if (replacement == null)
				{
					LastMethodCallTime = new PropertyState<DateTime>(this);
				}
				else
				{
					LastMethodCallTime = (PropertyState<DateTime>)replacement;
				}
			}
			baseInstanceState = LastMethodCallTime;
			break;
		case "LastMethodReturnStatus":
			if (createOrReplace && LastMethodReturnStatus == null)
			{
				if (replacement == null)
				{
					LastMethodReturnStatus = new PropertyState<StatusResult>(this);
				}
				else
				{
					LastMethodReturnStatus = (PropertyState<StatusResult>)replacement;
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
