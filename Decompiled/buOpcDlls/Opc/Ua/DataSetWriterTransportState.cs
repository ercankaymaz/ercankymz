using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DataSetWriterTransportState : BaseObjectState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIgAAAERhdGFTZXRXcml0ZXJUcmFuc3BvcnRUeXBlSW5zdGFuY2UBAMk7AQDJO8k7AAD/////AAAAAA==";

	public DataSetWriterTransportState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(15305u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIgAAAERhdGFTZXRXcml0ZXJUcmFuc3BvcnRUeXBlSW5zdGFuY2UBAMk7AQDJO8k7AAD/////AAAAAA==");
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
