using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RefreshStartEventState : SystemEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAHQAAAFJlZnJlc2hTdGFydEV2ZW50VHlwZUluc3RhbmNlAQDjCgEA4wrjCgAA/////wgAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAIEPAC4ARIEPAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAIIPAC4ARIIPAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCDDwAuAESDDwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAhA8ALgBEhA8AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAIUPAC4ARIUPAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQCGDwAuAESGDwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQCIDwAuAESIDwAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAIkPAC4ARIkPAAAABf////8BAf////8AAAAA";

	public RefreshStartEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2787u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHQAAAFJlZnJlc2hTdGFydEV2ZW50VHlwZUluc3RhbmNlAQDjCgEA4wrjCgAA/////wgAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAIEPAC4ARIEPAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAIIPAC4ARIIPAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCDDwAuAESDDwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAhA8ALgBEhA8AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAIUPAC4ARIUPAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQCGDwAuAESGDwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQCIDwAuAESIDwAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAIkPAC4ARIkPAAAABf////8BAf////8AAAAA");
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
