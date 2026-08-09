using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SessionDiagnosticsArrayState : BaseDataVariableState<SessionDiagnosticsDataType[]>
{
	private const string InitializationString = "//////////8XYIkCAgAAAAAAIwAAAFNlc3Npb25EaWFnbm9zdGljc0FycmF5VHlwZUluc3RhbmNlAQCUCAEAlAiUCAAAAQBhAwEAAAABAAAAAAAAAAEB/////wAAAAA=";

	public SessionDiagnosticsArrayState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2196u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(865u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return 1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8XYIkCAgAAAAAAIwAAAFNlc3Npb25EaWFnbm9zdGljc0FycmF5VHlwZUluc3RhbmNlAQCUCAEAlAiUCAAAAQBhAwEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
