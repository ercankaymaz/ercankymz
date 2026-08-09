using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditCertificateDataMismatchEventState : AuditCertificateEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAALQAAAEF1ZGl0Q2VydGlmaWNhdGVEYXRhTWlzbWF0Y2hFdmVudFR5cGVJbnN0YW5jZQEAIggBACIIIggAAP////8QAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQAQDQAuAEQQDQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQARDQAuAEQRDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAEg0ALgBEEg0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBABMNAC4ARBMNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQAUDQAuAEQUDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAFQ0ALgBEFQ0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAFw0ALgBEFw0AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQAYDQAuAEQYDQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQAZDQAuAEQZDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBABoNAC4ARBoNAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAGw0ALgBEGw0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAHA0ALgBEHA0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAHQ0ALgBEHQ0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAENlcnRpZmljYXRlAQAeDQAuAEQeDQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAPAAAASW52YWxpZEhvc3RuYW1lAQAjCAAuAEQjCAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAKAAAASW52YWxpZFVyaQEAJAgALgBEJAgAAAAM/////wEB/////wAAAAA=";

	private PropertyState<string> m_invalidHostname;

	private PropertyState<string> m_invalidUri;

	public PropertyState<string> InvalidHostname
	{
		get
		{
			return m_invalidHostname;
		}
		set
		{
			if (m_invalidHostname != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_invalidHostname = value;
		}
	}

	public PropertyState<string> InvalidUri
	{
		get
		{
			return m_invalidUri;
		}
		set
		{
			if (m_invalidUri != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_invalidUri = value;
		}
	}

	public AuditCertificateDataMismatchEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2082u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAALQAAAEF1ZGl0Q2VydGlmaWNhdGVEYXRhTWlzbWF0Y2hFdmVudFR5cGVJbnN0YW5jZQEAIggBACIIIggAAP////8QAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQAQDQAuAEQQDQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQARDQAuAEQRDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAEg0ALgBEEg0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBABMNAC4ARBMNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQAUDQAuAEQUDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAFQ0ALgBEFQ0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAFw0ALgBEFw0AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQAYDQAuAEQYDQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQAZDQAuAEQZDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBABoNAC4ARBoNAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAGw0ALgBEGw0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAHA0ALgBEHA0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAHQ0ALgBEHQ0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAENlcnRpZmljYXRlAQAeDQAuAEQeDQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAPAAAASW52YWxpZEhvc3RuYW1lAQAjCAAuAEQjCAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAKAAAASW52YWxpZFVyaQEAJAgALgBEJAgAAAAM/////wEB/////wAAAAA=");
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
		if (m_invalidHostname != null)
		{
			children.Add(m_invalidHostname);
		}
		if (m_invalidUri != null)
		{
			children.Add(m_invalidUri);
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
		string name = browseName.Name;
		if (!(name == "InvalidHostname"))
		{
			if (name == "InvalidUri")
			{
				if (createOrReplace && InvalidUri == null)
				{
					if (replacement == null)
					{
						InvalidUri = new PropertyState<string>(this);
					}
					else
					{
						InvalidUri = (PropertyState<string>)replacement;
					}
				}
				baseInstanceState = InvalidUri;
			}
		}
		else
		{
			if (createOrReplace && InvalidHostname == null)
			{
				if (replacement == null)
				{
					InvalidHostname = new PropertyState<string>(this);
				}
				else
				{
					InvalidHostname = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = InvalidHostname;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
