using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RefreshEndEventState : SystemEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAGwAAAFJlZnJlc2hFbmRFdmVudFR5cGVJbnN0YW5jZQEA5AoBAOQK5AoAAP////8IAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQCKDwAuAESKDwAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCLDwAuAESLDwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAjA8ALgBEjA8AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAI0PAC4ARI0PAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCODwAuAESODwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAjw8ALgBEjw8AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAkQ8ALgBEkQ8AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQCSDwAuAESSDwAAAAX/////AQH/////AAAAAA==";

	public RefreshEndEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2788u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAGwAAAFJlZnJlc2hFbmRFdmVudFR5cGVJbnN0YW5jZQEA5AoBAOQK5AoAAP////8IAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQCKDwAuAESKDwAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCLDwAuAESLDwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAjA8ALgBEjA8AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAI0PAC4ARI0PAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCODwAuAESODwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAjw8ALgBEjw8AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAkQ8ALgBEkQ8AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQCSDwAuAESSDwAAAAX/////AQH/////AAAAAA==");
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
