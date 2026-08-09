using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ReaderGroupTransportState : BaseObjectState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIAAAAFJlYWRlckdyb3VwVHJhbnNwb3J0VHlwZUluc3RhbmNlAQBiUgEAYlJiUgAA/////wAAAAA=";

	public ReaderGroupTransportState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(21090u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIAAAAFJlYWRlckdyb3VwVHJhbnNwb3J0VHlwZUluc3RhbmNlAQBiUgEAYlJiUgAA/////wAAAAA=");
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
