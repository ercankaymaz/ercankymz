using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class EccCurve448ApplicationCertificateState : EccApplicationCertificateState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAALQAAAEVjY0N1cnZlNDQ4QXBwbGljYXRpb25DZXJ0aWZpY2F0ZVR5cGVJbnN0YW5jZQEA91sBAPdb91sAAP////8AAAAA";

	public EccCurve448ApplicationCertificateState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(23543u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAALQAAAEVjY0N1cnZlNDQ4QXBwbGljYXRpb25DZXJ0aWZpY2F0ZVR5cGVJbnN0YW5jZQEA91sBAPdb91sAAP////8AAAAA");
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
