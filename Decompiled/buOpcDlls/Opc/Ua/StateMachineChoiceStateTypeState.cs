using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class StateMachineChoiceStateTypeState : StateMachineStateState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAFwAAAENob2ljZVN0YXRlVHlwZUluc3RhbmNlAQAFOwEABTsFOwAA/////wEAAAAVYIkKAgAAAAAACwAAAFN0YXRlTnVtYmVyAQAGOwAuAEQGOwAAAAf/////AQH/////AAAAAA==";

	public StateMachineChoiceStateTypeState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(15109u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAFwAAAENob2ljZVN0YXRlVHlwZUluc3RhbmNlAQAFOwEABTsFOwAA/////wEAAAAVYIkKAgAAAAAACwAAAFN0YXRlTnVtYmVyAQAGOwAuAEQGOwAAAAf/////AQH/////AAAAAA==");
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
}
