using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SessionSecurityDiagnosticsArrayState : BaseDataVariableState<SessionSecurityDiagnosticsDataType[]>
{
	private const string InitializationString = "//////////8XYIkCAgAAAAAAKwAAAFNlc3Npb25TZWN1cml0eURpYWdub3N0aWNzQXJyYXlUeXBlSW5zdGFuY2UBAMMIAQDDCMMIAAABAGQDAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	public SessionSecurityDiagnosticsArrayState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2243u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(868u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return 1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8XYIkCAgAAAAAAKwAAAFNlc3Npb25TZWN1cml0eURpYWdub3N0aWNzQXJyYXlUeXBlSW5zdGFuY2UBAMMIAQDDCMMIAAABAGQDAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
