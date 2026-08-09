using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class HttpsCertificateState : CertificateState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAHAAAAEh0dHBzQ2VydGlmaWNhdGVUeXBlSW5zdGFuY2UBAA4xAQAOMQ4xAAD/////AAAAAA==";

	public HttpsCertificateState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(12558u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHAAAAEh0dHBzQ2VydGlmaWNhdGVUeXBlSW5zdGFuY2UBAA4xAQAOMQ4xAAD/////AAAAAA==");
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
