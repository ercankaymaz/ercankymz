using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditNodeManagementEventState : AuditEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAJAAAAEF1ZGl0Tm9kZU1hbmFnZW1lbnRFdmVudFR5cGVJbnN0YW5jZQEAKggBACoIKggAAP////8NAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQBqDQAuAERqDQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQBrDQAuAERrDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAbA0ALgBEbA0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAG0NAC4ARG0NAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQBuDQAuAERuDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAbw0ALgBEbw0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAcQ0ALgBEcQ0AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQByDQAuAERyDQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQBzDQAuAERzDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAHQNAC4ARHQNAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAdQ0ALgBEdQ0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAdg0ALgBEdg0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAdw0ALgBEdw0AAAAM/////wEB/////wAAAAA=";

	public AuditNodeManagementEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2090u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJAAAAEF1ZGl0Tm9kZU1hbmFnZW1lbnRFdmVudFR5cGVJbnN0YW5jZQEAKggBACoIKggAAP////8NAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQBqDQAuAERqDQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQBrDQAuAERrDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAbA0ALgBEbA0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAG0NAC4ARG0NAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQBuDQAuAERuDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAbw0ALgBEbw0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAcQ0ALgBEcQ0AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQByDQAuAERyDQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQBzDQAuAERzDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAHQNAC4ARHQNAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAdQ0ALgBEdQ0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAdg0ALgBEdg0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAdw0ALgBEdw0AAAAM/////wEB/////wAAAAA=");
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
