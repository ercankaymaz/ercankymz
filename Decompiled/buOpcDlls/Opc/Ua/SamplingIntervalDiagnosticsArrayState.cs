using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SamplingIntervalDiagnosticsArrayState : BaseDataVariableState<SamplingIntervalDiagnosticsDataType[]>
{
	private const string InitializationString = "//////////8XYIkCAgAAAAAALAAAAFNhbXBsaW5nSW50ZXJ2YWxEaWFnbm9zdGljc0FycmF5VHlwZUluc3RhbmNlAQB0CAEAdAh0CAAAAQBYAwEAAAABAAAAAAAAAAEB/////wAAAAA=";

	public SamplingIntervalDiagnosticsArrayState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2164u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(856u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return 1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8XYIkCAgAAAAAALAAAAFNhbXBsaW5nSW50ZXJ2YWxEaWFnbm9zdGljc0FycmF5VHlwZUluc3RhbmNlAQB0CAEAdAh0CAAAAQBYAwEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
