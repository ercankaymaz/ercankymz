using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditUrlMismatchEventState : AuditCreateSessionEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIQAAAEF1ZGl0VXJsTWlzbWF0Y2hFdmVudFR5cGVJbnN0YW5jZQEAvAoBALwKvAoAAP////8TAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQDRDAAuAETRDAAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQDSDAAuAETSDAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEA0wwALgBE0wwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBANQMAC4ARNQMAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQDVDAAuAETVDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEA1gwALgBE1gwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEA2AwALgBE2AwAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQDZDAAuAETZDAAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQDaDAAuAETaDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBANsMAC4ARNsMAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEA3AwALgBE3AwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEA3QwALgBE3QwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEA3gwALgBE3gwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAFNlc3Npb25JZAEATjgALgBETjgAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAFNlY3VyZUNoYW5uZWxJZAEA4AwALgBE4AwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAENsaWVudENlcnRpZmljYXRlAQDhDAAuAEThDAAAAA//////AQH/////AAAAABVgiQoCAAAAAAAbAAAAQ2xpZW50Q2VydGlmaWNhdGVUaHVtYnByaW50AQDiDAAuAETiDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAVAAAAUmV2aXNlZFNlc3Npb25UaW1lb3V0AQDjDAAuAETjDAAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABFbmRwb2ludFVybAEAvQoALgBEvQoAAAAM/////wEB/////wAAAAA=";

	private PropertyState<string> m_endpointUrl;

	public PropertyState<string> EndpointUrl
	{
		get
		{
			return m_endpointUrl;
		}
		set
		{
			if (m_endpointUrl != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_endpointUrl = value;
		}
	}

	public AuditUrlMismatchEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2748u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIQAAAEF1ZGl0VXJsTWlzbWF0Y2hFdmVudFR5cGVJbnN0YW5jZQEAvAoBALwKvAoAAP////8TAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQDRDAAuAETRDAAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQDSDAAuAETSDAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEA0wwALgBE0wwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBANQMAC4ARNQMAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQDVDAAuAETVDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEA1gwALgBE1gwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEA2AwALgBE2AwAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQDZDAAuAETZDAAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQDaDAAuAETaDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBANsMAC4ARNsMAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEA3AwALgBE3AwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEA3QwALgBE3QwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEA3gwALgBE3gwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAFNlc3Npb25JZAEATjgALgBETjgAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAFNlY3VyZUNoYW5uZWxJZAEA4AwALgBE4AwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAENsaWVudENlcnRpZmljYXRlAQDhDAAuAEThDAAAAA//////AQH/////AAAAABVgiQoCAAAAAAAbAAAAQ2xpZW50Q2VydGlmaWNhdGVUaHVtYnByaW50AQDiDAAuAETiDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAVAAAAUmV2aXNlZFNlc3Npb25UaW1lb3V0AQDjDAAuAETjDAAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABFbmRwb2ludFVybAEAvQoALgBEvQoAAAAM/////wEB/////wAAAAA=");
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

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_endpointUrl != null)
		{
			children.Add(m_endpointUrl);
		}
		base.GetChildren(context, children);
	}

	protected override BaseInstanceState FindChild(ISystemContext context, QualifiedName browseName, bool createOrReplace, BaseInstanceState replacement)
	{
		if (QualifiedName.IsNull(browseName))
		{
			return null;
		}
		BaseInstanceState baseInstanceState = null;
		if (browseName.Name == "EndpointUrl")
		{
			if (createOrReplace && EndpointUrl == null)
			{
				if (replacement == null)
				{
					EndpointUrl = new PropertyState<string>(this);
				}
				else
				{
					EndpointUrl = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = EndpointUrl;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
