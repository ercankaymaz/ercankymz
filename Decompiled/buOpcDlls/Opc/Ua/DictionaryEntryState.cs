using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DictionaryEntryState : BaseObjectState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAGwAAAERpY3Rpb25hcnlFbnRyeVR5cGVJbnN0YW5jZQEAtUQBALVEtUQAAP////8AAAAA";

	public DictionaryEntryState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(17589u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAGwAAAERpY3Rpb25hcnlFbnRyeVR5cGVJbnN0YW5jZQEAtUQBALVEtUQAAP////8AAAAA");
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
