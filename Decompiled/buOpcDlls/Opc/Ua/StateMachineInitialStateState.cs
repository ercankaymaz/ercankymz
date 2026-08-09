using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class StateMachineInitialStateState : StateMachineStateState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAGAAAAEluaXRpYWxTdGF0ZVR5cGVJbnN0YW5jZQEABQkBAAUJBQkAAP////8BAAAAFWCJCgIAAAAAAAsAAABTdGF0ZU51bWJlcgEAmA4ALgBEmA4AAAAH/////wEB/////wAAAAA=";

	public StateMachineInitialStateState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2309u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAGAAAAEluaXRpYWxTdGF0ZVR5cGVJbnN0YW5jZQEABQkBAAUJBQkAAP////8BAAAAFWCJCgIAAAAAAAsAAABTdGF0ZU51bWJlcgEAmA4ALgBEmA4AAAAH/////wEB/////wAAAAA=");
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
