using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class BaseModelChangeEventState : BaseEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIAAAAEJhc2VNb2RlbENoYW5nZUV2ZW50VHlwZUluc3RhbmNlAQBUCAEAVAhUCAAA/////wgAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAFcOAC4ARFcOAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAFgOAC4ARFgOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQBZDgAuAERZDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAWg4ALgBEWg4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAFsOAC4ARFsOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQBcDgAuAERcDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQBeDgAuAEReDgAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAF8OAC4ARF8OAAAABf////8BAf////8AAAAA";

	public BaseModelChangeEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2132u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIAAAAEJhc2VNb2RlbENoYW5nZUV2ZW50VHlwZUluc3RhbmNlAQBUCAEAVAhUCAAA/////wgAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAFcOAC4ARFcOAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAFgOAC4ARFgOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQBZDgAuAERZDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAWg4ALgBEWg4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAFsOAC4ARFsOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQBcDgAuAERcDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQBeDgAuAEReDgAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAF8OAC4ARF8OAAAABf////8BAf////8AAAAA");
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
