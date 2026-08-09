using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DataSetReaderTransportState : BaseObjectState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIgAAAERhdGFTZXRSZWFkZXJUcmFuc3BvcnRUeXBlSW5zdGFuY2UBANc7AQDXO9c7AAD/////AAAAAA==";

	public DataSetReaderTransportState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(15319u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIgAAAERhdGFTZXRSZWFkZXJUcmFuc3BvcnRUeXBlSW5zdGFuY2UBANc7AQDXO9c7AAD/////AAAAAA==");
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
