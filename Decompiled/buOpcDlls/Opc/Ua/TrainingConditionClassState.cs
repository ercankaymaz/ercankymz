using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class TrainingConditionClassState : BaseConditionClassState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIgAAAFRyYWluaW5nQ29uZGl0aW9uQ2xhc3NUeXBlSW5zdGFuY2UBAERDAQBEQ0RDAAD/////AAAAAA==";

	public TrainingConditionClassState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(17220u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIgAAAFRyYWluaW5nQ29uZGl0aW9uQ2xhc3NUeXBlSW5zdGFuY2UBAERDAQBEQ0RDAAD/////AAAAAA==");
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
