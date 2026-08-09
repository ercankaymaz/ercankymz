using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DeviceFailureEventState : SystemEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAHgAAAERldmljZUZhaWx1cmVFdmVudFR5cGVJbnN0YW5jZQEAUwgBAFMIUwgAAP////8IAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQBODgAuAERODgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQBPDgAuAERPDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAUA4ALgBEUA4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAFEOAC4ARFEOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQBSDgAuAERSDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAUw4ALgBEUw4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAVQ4ALgBEVQ4AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQBWDgAuAERWDgAAAAX/////AQH/////AAAAAA==";

	public DeviceFailureEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2131u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHgAAAERldmljZUZhaWx1cmVFdmVudFR5cGVJbnN0YW5jZQEAUwgBAFMIUwgAAP////8IAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQBODgAuAERODgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQBPDgAuAERPDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAUA4ALgBEUA4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAFEOAC4ARFEOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQBSDgAuAERSDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAUw4ALgBEUw4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAVQ4ALgBEVQ4AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQBWDgAuAERWDgAAAAX/////AQH/////AAAAAA==");
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
