using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditSecurityEventState : AuditEventState
{
	private const string StatusCodeId_InitializationString = "//////////8VYIkKAgAAAAAADAAAAFN0YXR1c0NvZGVJZAEAz0QALgBEz0QAAAAT/////wEB/////wAAAAA=";

	private const string InitializationString = "//////////8EYIACAQAAAAAAHgAAAEF1ZGl0U2VjdXJpdHlFdmVudFR5cGVJbnN0YW5jZQEACggBAAoICggAAP////8OAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQCJDAAuAESJDAAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCKDAAuAESKDAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAiwwALgBEiwwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAIwMAC4ARIwMAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCNDAAuAESNDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAjgwALgBEjgwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAkAwALgBEkAwAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQCRDAAuAESRDAAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQCSDAAuAESSDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAJMMAC4ARJMMAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAlAwALgBElAwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAlQwALgBElQwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAlgwALgBElgwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFN0YXR1c0NvZGVJZAEAz0QALgBEz0QAAAAT/////wEB/////wAAAAA=";

	private PropertyState<StatusCode> m_statusCodeId;

	public PropertyState<StatusCode> StatusCodeId
	{
		get
		{
			return m_statusCodeId;
		}
		set
		{
			if (m_statusCodeId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_statusCodeId = value;
		}
	}

	public AuditSecurityEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2058u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHgAAAEF1ZGl0U2VjdXJpdHlFdmVudFR5cGVJbnN0YW5jZQEACggBAAoICggAAP////8OAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQCJDAAuAESJDAAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCKDAAuAESKDAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAiwwALgBEiwwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAIwMAC4ARIwMAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCNDAAuAESNDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAjgwALgBEjgwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAkAwALgBEkAwAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQCRDAAuAESRDAAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQCSDAAuAESSDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAJMMAC4ARJMMAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAlAwALgBElAwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAlQwALgBElQwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAlgwALgBElgwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFN0YXR1c0NvZGVJZAEAz0QALgBEz0QAAAAT/////wEB/////wAAAAA=");
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
		if (StatusCodeId != null)
		{
			StatusCodeId.Initialize(context, "//////////8VYIkKAgAAAAAADAAAAFN0YXR1c0NvZGVJZAEAz0QALgBEz0QAAAAT/////wEB/////wAAAAA=");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_statusCodeId != null)
		{
			children.Add(m_statusCodeId);
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
		if (browseName.Name == "StatusCodeId")
		{
			if (createOrReplace && StatusCodeId == null)
			{
				if (replacement == null)
				{
					StatusCodeId = new PropertyState<StatusCode>(this);
				}
				else
				{
					StatusCodeId = (PropertyState<StatusCode>)replacement;
				}
			}
			baseInstanceState = StatusCodeId;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
