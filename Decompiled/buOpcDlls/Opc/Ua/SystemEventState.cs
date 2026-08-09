using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SystemEventState : BaseEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAFwAAAFN5c3RlbUV2ZW50VHlwZUluc3RhbmNlAQBSCAEAUghSCAAA/////wgAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAEUOAC4AREUOAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAEYOAC4AREYOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQBHDgAuAERHDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEASA4ALgBESA4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAEkOAC4AREkOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQBKDgAuAERKDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQBMDgAuAERMDgAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAE0OAC4ARE0OAAAABf////8BAf////8AAAAA";

	public SystemEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2130u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAFwAAAFN5c3RlbUV2ZW50VHlwZUluc3RhbmNlAQBSCAEAUghSCAAA/////wgAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAEUOAC4AREUOAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAEYOAC4AREYOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQBHDgAuAERHDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEASA4ALgBESA4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAEkOAC4AREkOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQBKDgAuAERKDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQBMDgAuAERMDgAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAE0OAC4ARE0OAAAABf////8BAf////8AAAAA");
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
