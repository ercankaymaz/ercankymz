using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class EccCurve25519ApplicationCertificateState : EccApplicationCertificateState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAALwAAAEVjY0N1cnZlMjU1MTlBcHBsaWNhdGlvbkNlcnRpZmljYXRlVHlwZUluc3RhbmNlAQD2WwEA9lv2WwAA/////wAAAAA=";

	public EccCurve25519ApplicationCertificateState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(23542u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAALwAAAEVjY0N1cnZlMjU1MTlBcHBsaWNhdGlvbkNlcnRpZmljYXRlVHlwZUluc3RhbmNlAQD2WwEA9lv2WwAA/////wAAAAA=");
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
