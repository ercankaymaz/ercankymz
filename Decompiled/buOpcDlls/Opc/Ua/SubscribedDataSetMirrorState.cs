using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SubscribedDataSetMirrorState : SubscribedDataSetState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIwAAAFN1YnNjcmliZWREYXRhU2V0TWlycm9yVHlwZUluc3RhbmNlAQAXOwEAFzsXOwAA/////wAAAAA=";

	public SubscribedDataSetMirrorState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(15127u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIwAAAFN1YnNjcmliZWREYXRhU2V0TWlycm9yVHlwZUluc3RhbmNlAQAXOwEAFzsXOwAA/////wAAAAA=");
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
