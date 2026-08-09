using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class IrdiDictionaryEntryState : DictionaryEntryState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAHwAAAElyZGlEaWN0aW9uYXJ5RW50cnlUeXBlSW5zdGFuY2UBAL5EAQC+RL5EAAD/////AAAAAA==";

	public IrdiDictionaryEntryState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(17598u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHwAAAElyZGlEaWN0aW9uYXJ5RW50cnlUeXBlSW5zdGFuY2UBAL5EAQC+RL5EAAD/////AAAAAA==");
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
