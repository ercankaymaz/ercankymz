using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class IIeeeAutoNegotiationStatusState : BaseInterfaceState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAJgAAAElJZWVlQXV0b05lZ290aWF0aW9uU3RhdHVzVHlwZUluc3RhbmNlAQCpXgEAqV6pXgAA/////wEAAAAVYIkKAgAAAAAAEQAAAE5lZ290aWF0aW9uU3RhdHVzAQCqXgAvAD+qXgAAAQCYXv////8BAf////8AAAAA";

	private BaseDataVariableState<NegotiationStatus> m_negotiationStatus;

	public BaseDataVariableState<NegotiationStatus> NegotiationStatus
	{
		get
		{
			return m_negotiationStatus;
		}
		set
		{
			if (m_negotiationStatus != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_negotiationStatus = value;
		}
	}

	public IIeeeAutoNegotiationStatusState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(24233u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJgAAAElJZWVlQXV0b05lZ290aWF0aW9uU3RhdHVzVHlwZUluc3RhbmNlAQCpXgEAqV6pXgAA/////wEAAAAVYIkKAgAAAAAAEQAAAE5lZ290aWF0aW9uU3RhdHVzAQCqXgAvAD+qXgAAAQCYXv////8BAf////8AAAAA");
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
		if (m_negotiationStatus != null)
		{
			children.Add(m_negotiationStatus);
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
		if (browseName.Name == "NegotiationStatus")
		{
			if (createOrReplace && NegotiationStatus == null)
			{
				if (replacement == null)
				{
					NegotiationStatus = new BaseDataVariableState<NegotiationStatus>(this);
				}
				else
				{
					NegotiationStatus = (BaseDataVariableState<NegotiationStatus>)replacement;
				}
			}
			baseInstanceState = NegotiationStatus;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
