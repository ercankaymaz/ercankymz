using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class EccBrainpoolP256r1ApplicationCertificateState : EccApplicationCertificateState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAANAAAAEVjY0JyYWlucG9vbFAyNTZyMUFwcGxpY2F0aW9uQ2VydGlmaWNhdGVUeXBlSW5zdGFuY2UBAPRbAQD0W/RbAAD/////AAAAAA==";

	public EccBrainpoolP256r1ApplicationCertificateState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(23540u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAANAAAAEVjY0JyYWlucG9vbFAyNTZyMUFwcGxpY2F0aW9uQ2VydGlmaWNhdGVUeXBlSW5zdGFuY2UBAPRbAQD0W/RbAAD/////AAAAAA==");
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
