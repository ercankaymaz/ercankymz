using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class BaseConditionClassState : BaseObjectState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAHgAAAEJhc2VDb25kaXRpb25DbGFzc1R5cGVJbnN0YW5jZQEAmysBAJsrmysAAP////8AAAAA";

	public BaseConditionClassState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(11163u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHgAAAEJhc2VDb25kaXRpb25DbGFzc1R5cGVJbnN0YW5jZQEAmysBAJsrmysAAP////8AAAAA");
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
