using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class EventQueueOverflowEventState : BaseEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIwAAAEV2ZW50UXVldWVPdmVyZmxvd0V2ZW50VHlwZUluc3RhbmNlAQDbCwEA2wvbCwAA/////wgAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAHcMAC4ARHcMAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAHgMAC4ARHgMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQB5DAAuAER5DAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAegwALgBEegwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAHsMAC4ARHsMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQB8DAAuAER8DAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQB+DAAuAER+DAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAH8MAC4ARH8MAAAABf////8BAf////8AAAAA";

	public EventQueueOverflowEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(3035u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIwAAAEV2ZW50UXVldWVPdmVyZmxvd0V2ZW50VHlwZUluc3RhbmNlAQDbCwEA2wvbCwAA/////wgAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAHcMAC4ARHcMAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAHgMAC4ARHgMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQB5DAAuAER5DAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAegwALgBEegwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAHsMAC4ARHsMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQB8DAAuAER8DAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQB+DAAuAER+DAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAH8MAC4ARH8MAAAABf////8BAf////8AAAAA");
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
