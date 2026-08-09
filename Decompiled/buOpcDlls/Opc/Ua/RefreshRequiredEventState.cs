using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RefreshRequiredEventState : SystemEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIAAAAFJlZnJlc2hSZXF1aXJlZEV2ZW50VHlwZUluc3RhbmNlAQDlCgEA5QrlCgAA/////wgAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAJMPAC4ARJMPAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAJQPAC4ARJQPAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCVDwAuAESVDwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAlg8ALgBElg8AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAJcPAC4ARJcPAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQCYDwAuAESYDwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQCaDwAuAESaDwAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAJsPAC4ARJsPAAAABf////8BAf////8AAAAA";

	public RefreshRequiredEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2789u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIAAAAFJlZnJlc2hSZXF1aXJlZEV2ZW50VHlwZUluc3RhbmNlAQDlCgEA5QrlCgAA/////wgAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAJMPAC4ARJMPAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAJQPAC4ARJQPAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCVDwAuAESVDwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAlg8ALgBElg8AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAJcPAC4ARJcPAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQCYDwAuAESYDwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQCaDwAuAESaDwAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAJsPAC4ARJsPAAAABf////8BAf////8AAAAA");
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
