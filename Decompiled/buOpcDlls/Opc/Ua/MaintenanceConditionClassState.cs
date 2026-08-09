using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class MaintenanceConditionClassState : BaseConditionClassState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAJQAAAE1haW50ZW5hbmNlQ29uZGl0aW9uQ2xhc3NUeXBlSW5zdGFuY2UBAJ0rAQCdK50rAAD/////AAAAAA==";

	public MaintenanceConditionClassState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(11165u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJQAAAE1haW50ZW5hbmNlQ29uZGl0aW9uQ2xhc3NUeXBlSW5zdGFuY2UBAJ0rAQCdK50rAAD/////AAAAAA==");
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
