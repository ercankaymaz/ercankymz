using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ReaderGroupMessageState : BaseObjectState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAHgAAAFJlYWRlckdyb3VwTWVzc2FnZVR5cGVJbnN0YW5jZQEAY1IBAGNSY1IAAP////8AAAAA";

	public ReaderGroupMessageState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(21091u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHgAAAFJlYWRlckdyb3VwTWVzc2FnZVR5cGVJbnN0YW5jZQEAY1IBAGNSY1IAAP////8AAAAA");
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
