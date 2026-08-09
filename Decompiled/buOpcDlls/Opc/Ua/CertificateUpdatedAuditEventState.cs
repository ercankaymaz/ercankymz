using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CertificateUpdatedAuditEventState : AuditUpdateMethodEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAKAAAAENlcnRpZmljYXRlVXBkYXRlZEF1ZGl0RXZlbnRUeXBlSW5zdGFuY2UBAEwxAQBMMUwxAAD/////EQAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEATTEALgBETTEAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEATjEALgBETjEAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAE8xAC4ARE8xAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQBQMQAuAERQMQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAUTEALgBEUTEAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAFIxAC4ARFIxAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAFQxAC4ARFQxAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAVTEALgBEVTEAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEAVjEALgBEVjEAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQBXMQAuAERXMQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAFgxAC4ARFgxAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAFkxAC4ARFkxAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAFoxAC4ARFoxAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABNZXRob2RJZAEAWzEALgBEWzEAAAAR/////wEB/////wAAAAAXYIkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBcMQAuAERcMQAAABgBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABAAAABDZXJ0aWZpY2F0ZUdyb3VwAQCnNQAuAESnNQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQ2VydGlmaWNhdGVUeXBlAQCoNQAuAESoNQAAABH/////AQH/////AAAAAA==";

	private PropertyState<NodeId> m_certificateGroup;

	private PropertyState<NodeId> m_certificateType;

	public PropertyState<NodeId> CertificateGroup
	{
		get
		{
			return m_certificateGroup;
		}
		set
		{
			if (m_certificateGroup != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_certificateGroup = value;
		}
	}

	public PropertyState<NodeId> CertificateType
	{
		get
		{
			return m_certificateType;
		}
		set
		{
			if (m_certificateType != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_certificateType = value;
		}
	}

	public CertificateUpdatedAuditEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(12620u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAKAAAAENlcnRpZmljYXRlVXBkYXRlZEF1ZGl0RXZlbnRUeXBlSW5zdGFuY2UBAEwxAQBMMUwxAAD/////EQAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEATTEALgBETTEAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEATjEALgBETjEAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAE8xAC4ARE8xAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQBQMQAuAERQMQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAUTEALgBEUTEAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAFIxAC4ARFIxAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAFQxAC4ARFQxAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAVTEALgBEVTEAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEAVjEALgBEVjEAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQBXMQAuAERXMQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAFgxAC4ARFgxAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAFkxAC4ARFkxAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAFoxAC4ARFoxAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABNZXRob2RJZAEAWzEALgBEWzEAAAAR/////wEB/////wAAAAAXYIkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBcMQAuAERcMQAAABgBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABAAAABDZXJ0aWZpY2F0ZUdyb3VwAQCnNQAuAESnNQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQ2VydGlmaWNhdGVUeXBlAQCoNQAuAESoNQAAABH/////AQH/////AAAAAA==");
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
		if (m_certificateGroup != null)
		{
			children.Add(m_certificateGroup);
		}
		if (m_certificateType != null)
		{
			children.Add(m_certificateType);
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
		if (!(name == "CertificateGroup"))
		{
			if (name == "CertificateType")
			{
				if (createOrReplace && CertificateType == null)
				{
					if (replacement == null)
					{
						CertificateType = new PropertyState<NodeId>(this);
					}
					else
					{
						CertificateType = (PropertyState<NodeId>)replacement;
					}
				}
				baseInstanceState = CertificateType;
			}
		}
		else
		{
			if (createOrReplace && CertificateGroup == null)
			{
				if (replacement == null)
				{
					CertificateGroup = new PropertyState<NodeId>(this);
				}
				else
				{
					CertificateGroup = (PropertyState<NodeId>)replacement;
				}
			}
			baseInstanceState = CertificateGroup;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
