using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SubscriptionDiagnosticsArrayState : BaseDataVariableState<SubscriptionDiagnosticsDataType[]>
{
	private const string InitializationString = "//////////8XYIkCAgAAAAAAKAAAAFN1YnNjcmlwdGlvbkRpYWdub3N0aWNzQXJyYXlUeXBlSW5zdGFuY2UBAHsIAQB7CHsIAAABAGoDAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	public SubscriptionDiagnosticsArrayState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2171u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(874u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return 1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8XYIkCAgAAAAAAKAAAAFN1YnNjcmlwdGlvbkRpYWdub3N0aWNzQXJyYXlUeXBlSW5zdGFuY2UBAHsIAQB7CHsIAAABAGoDAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
