using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditUpdateMethodEventState : AuditEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIgAAAEF1ZGl0VXBkYXRlTWV0aG9kRXZlbnRUeXBlSW5zdGFuY2UBAE8IAQBPCE8IAAD/////DwAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEANw4ALgBENw4AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAOA4ALgBEOA4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBADkOAC4ARDkOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQA6DgAuAEQ6DgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAOw4ALgBEOw4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBADwOAC4ARDwOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAD4OAC4ARD4OAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAPw4ALgBEPw4AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEAQA4ALgBEQA4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQBBDgAuAERBDgAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAEIOAC4AREIOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAEMOAC4AREMOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAEQOAC4AREQOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABNZXRob2RJZAEAUAgALgBEUAgAAAAR/////wEB/////wAAAAAXYIkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBRCAAuAERRCAAAABgBAAAAAQAAAAAAAAABAf////8AAAAA";

	private PropertyState<NodeId> m_methodId;

	private PropertyState<object[]> m_inputArguments;

	public PropertyState<NodeId> MethodId
	{
		get
		{
			return m_methodId;
		}
		set
		{
			if (m_methodId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_methodId = value;
		}
	}

	public PropertyState<object[]> InputArguments
	{
		get
		{
			return m_inputArguments;
		}
		set
		{
			if (m_inputArguments != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_inputArguments = value;
		}
	}

	public AuditUpdateMethodEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2127u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIgAAAEF1ZGl0VXBkYXRlTWV0aG9kRXZlbnRUeXBlSW5zdGFuY2UBAE8IAQBPCE8IAAD/////DwAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEANw4ALgBENw4AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAOA4ALgBEOA4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBADkOAC4ARDkOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQA6DgAuAEQ6DgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAOw4ALgBEOw4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBADwOAC4ARDwOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAD4OAC4ARD4OAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAPw4ALgBEPw4AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEAQA4ALgBEQA4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQBBDgAuAERBDgAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAEIOAC4AREIOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAEMOAC4AREMOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAEQOAC4AREQOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABNZXRob2RJZAEAUAgALgBEUAgAAAAR/////wEB/////wAAAAAXYIkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBRCAAuAERRCAAAABgBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		if (m_methodId != null)
		{
			children.Add(m_methodId);
		}
		if (m_inputArguments != null)
		{
			children.Add(m_inputArguments);
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
		if (!(name == "MethodId"))
		{
			if (name == "InputArguments")
			{
				if (createOrReplace && InputArguments == null)
				{
					if (replacement == null)
					{
						InputArguments = new PropertyState<object[]>(this);
					}
					else
					{
						InputArguments = (PropertyState<object[]>)replacement;
					}
				}
				baseInstanceState = InputArguments;
			}
		}
		else
		{
			if (createOrReplace && MethodId == null)
			{
				if (replacement == null)
				{
					MethodId = new PropertyState<NodeId>(this);
				}
				else
				{
					MethodId = (PropertyState<NodeId>)replacement;
				}
			}
			baseInstanceState = MethodId;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
