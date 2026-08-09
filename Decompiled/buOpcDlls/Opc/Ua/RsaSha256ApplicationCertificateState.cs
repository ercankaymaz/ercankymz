using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RsaSha256ApplicationCertificateState : ApplicationCertificateState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAKwAAAFJzYVNoYTI1NkFwcGxpY2F0aW9uQ2VydGlmaWNhdGVUeXBlSW5zdGFuY2UBABAxAQAQMRAxAAD/////AAAAAA==";

	public RsaSha256ApplicationCertificateState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(12560u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAKwAAAFJzYVNoYTI1NkFwcGxpY2F0aW9uQ2VydGlmaWNhdGVUeXBlSW5zdGFuY2UBABAxAQAQMRAxAAD/////AAAAAA==");
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
