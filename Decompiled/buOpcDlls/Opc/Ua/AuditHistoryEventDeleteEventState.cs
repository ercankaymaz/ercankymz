using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditHistoryEventDeleteEventState : AuditHistoryDeleteEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAKAAAAEF1ZGl0SGlzdG9yeUV2ZW50RGVsZXRlRXZlbnRUeXBlSW5zdGFuY2UBAM4LAQDOC84LAAD/////EQAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAJw4ALgBEJw4AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAKA4ALgBEKA4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBACkOAC4ARCkOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQAqDgAuAEQqDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAKw4ALgBEKw4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBACwOAC4ARCwOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAC4OAC4ARC4OAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEALw4ALgBELw4AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEAMA4ALgBEMA4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQAxDgAuAEQxDgAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBADIOAC4ARDIOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBADMOAC4ARDMOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBADQOAC4ARDQOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABQYXJhbWV0ZXJEYXRhVHlwZUlkAQA1DgAuAEQ1DgAAABH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAVXBkYXRlZE5vZGUBADYOAC4ARDYOAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAAAgAAABFdmVudElkcwEAzwsALgBEzwsAAAAPAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAJAAAAT2xkVmFsdWVzAQDQCwAuAETQCwAAAQCYA/////8BAf////8AAAAA";

	private PropertyState<byte[][]> m_eventIds;

	private PropertyState<HistoryEventFieldList> m_oldValues;

	public PropertyState<byte[][]> EventIds
	{
		get
		{
			return m_eventIds;
		}
		set
		{
			if (m_eventIds != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_eventIds = value;
		}
	}

	public PropertyState<HistoryEventFieldList> OldValues
	{
		get
		{
			return m_oldValues;
		}
		set
		{
			if (m_oldValues != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_oldValues = value;
		}
	}

	public AuditHistoryEventDeleteEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(3022u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAKAAAAEF1ZGl0SGlzdG9yeUV2ZW50RGVsZXRlRXZlbnRUeXBlSW5zdGFuY2UBAM4LAQDOC84LAAD/////EQAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAJw4ALgBEJw4AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAKA4ALgBEKA4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBACkOAC4ARCkOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQAqDgAuAEQqDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAKw4ALgBEKw4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBACwOAC4ARCwOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAC4OAC4ARC4OAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEALw4ALgBELw4AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEAMA4ALgBEMA4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQAxDgAuAEQxDgAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBADIOAC4ARDIOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBADMOAC4ARDMOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBADQOAC4ARDQOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABQYXJhbWV0ZXJEYXRhVHlwZUlkAQA1DgAuAEQ1DgAAABH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAVXBkYXRlZE5vZGUBADYOAC4ARDYOAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAAAgAAABFdmVudElkcwEAzwsALgBEzwsAAAAPAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAJAAAAT2xkVmFsdWVzAQDQCwAuAETQCwAAAQCYA/////8BAf////8AAAAA");
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
		if (m_eventIds != null)
		{
			children.Add(m_eventIds);
		}
		if (m_oldValues != null)
		{
			children.Add(m_oldValues);
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
		if (!(name == "EventIds"))
		{
			if (name == "OldValues")
			{
				if (createOrReplace && OldValues == null)
				{
					if (replacement == null)
					{
						OldValues = new PropertyState<HistoryEventFieldList>(this);
					}
					else
					{
						OldValues = (PropertyState<HistoryEventFieldList>)replacement;
					}
				}
				baseInstanceState = OldValues;
			}
		}
		else
		{
			if (createOrReplace && EventIds == null)
			{
				if (replacement == null)
				{
					EventIds = new PropertyState<byte[][]>(this);
				}
				else
				{
					EventIds = (PropertyState<byte[][]>)replacement;
				}
			}
			baseInstanceState = EventIds;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
