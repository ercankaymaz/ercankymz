using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DataSetWriterMessageState : BaseObjectState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIAAAAERhdGFTZXRXcml0ZXJNZXNzYWdlVHlwZUluc3RhbmNlAQBoUgEAaFJoUgAA/////wAAAAA=";

	public DataSetWriterMessageState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(21096u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIAAAAERhdGFTZXRXcml0ZXJNZXNzYWdlVHlwZUluc3RhbmNlAQBoUgEAaFJoUgAA/////wAAAAA=");
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
