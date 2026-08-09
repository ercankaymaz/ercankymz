using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditCertificateEventState : AuditSecurityEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIQAAAEF1ZGl0Q2VydGlmaWNhdGVFdmVudFR5cGVJbnN0YW5jZQEAIAgBACAIIAgAAP////8OAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQACDQAuAEQCDQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQADDQAuAEQDDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEABA0ALgBEBA0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAAUNAC4ARAUNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQAGDQAuAEQGDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEABw0ALgBEBw0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEACQ0ALgBECQ0AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQAKDQAuAEQKDQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQALDQAuAEQLDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAAwNAC4ARAwNAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEADQ0ALgBEDQ0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEADg0ALgBEDg0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEADw0ALgBEDw0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAENlcnRpZmljYXRlAQAhCAAuAEQhCAAAAA//////AQH/////AAAAAA==";

	private PropertyState<byte[]> m_certificate;

	public PropertyState<byte[]> Certificate
	{
		get
		{
			return m_certificate;
		}
		set
		{
			if (m_certificate != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_certificate = value;
		}
	}

	public AuditCertificateEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2080u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIQAAAEF1ZGl0Q2VydGlmaWNhdGVFdmVudFR5cGVJbnN0YW5jZQEAIAgBACAIIAgAAP////8OAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQACDQAuAEQCDQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQADDQAuAEQDDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEABA0ALgBEBA0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAAUNAC4ARAUNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQAGDQAuAEQGDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEABw0ALgBEBw0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEACQ0ALgBECQ0AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQAKDQAuAEQKDQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQALDQAuAEQLDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAAwNAC4ARAwNAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEADQ0ALgBEDQ0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEADg0ALgBEDg0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEADw0ALgBEDw0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAENlcnRpZmljYXRlAQAhCAAuAEQhCAAAAA//////AQH/////AAAAAA==");
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
		if (m_certificate != null)
		{
			children.Add(m_certificate);
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
		if (browseName.Name == "Certificate")
		{
			if (createOrReplace && Certificate == null)
			{
				if (replacement == null)
				{
					Certificate = new PropertyState<byte[]>(this);
				}
				else
				{
					Certificate = (PropertyState<byte[]>)replacement;
				}
			}
			baseInstanceState = Certificate;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
