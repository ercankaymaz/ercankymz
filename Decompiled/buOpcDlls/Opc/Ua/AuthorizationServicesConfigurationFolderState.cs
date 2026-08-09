using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuthorizationServicesConfigurationFolderState : FolderState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAANAAAAEF1dGhvcml6YXRpb25TZXJ2aWNlc0NvbmZpZ3VyYXRpb25Gb2xkZXJUeXBlSW5zdGFuY2UBAARcAQAEXARcAAD/////AAAAAA==";

	public AuthorizationServicesConfigurationFolderState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(23556u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAANAAAAEF1dGhvcml6YXRpb25TZXJ2aWNlc0NvbmZpZ3VyYXRpb25Gb2xkZXJUeXBlSW5zdGFuY2UBAARcAQAEXARcAAD/////AAAAAA==");
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
