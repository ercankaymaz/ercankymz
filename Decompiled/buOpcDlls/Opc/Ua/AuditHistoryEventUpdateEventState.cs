using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditHistoryEventUpdateEventState : AuditHistoryUpdateEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAKAAAAEF1ZGl0SGlzdG9yeUV2ZW50VXBkYXRlRXZlbnRUeXBlSW5zdGFuY2UBALcLAQC3C7cLAAD/////EwAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEA2g0ALgBE2g0AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEA2w0ALgBE2w0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBANwNAC4ARNwNAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQDdDQAuAETdDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEA3g0ALgBE3g0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAN8NAC4ARN8NAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAOENAC4AROENAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEA4g0ALgBE4g0AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEA4w0ALgBE4w0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQDkDQAuAETkDQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAOUNAC4AROUNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAOYNAC4AROYNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAOcNAC4AROcNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABQYXJhbWV0ZXJEYXRhVHlwZUlkAQDoDQAuAEToDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAVXBkYXRlZE5vZGUBANELAC4ARNELAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABQAAABQZXJmb3JtSW5zZXJ0UmVwbGFjZQEA1AsALgBE1AsAAAEAHSz/////AQH/////AAAAABVgiQoCAAAAAAAGAAAARmlsdGVyAQC7CwAuAES7CwAAAQDVAv////8BAf////8AAAAAF2CJCgIAAAAAAAkAAABOZXdWYWx1ZXMBANULAC4ARNULAAABAJgDAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAJAAAAT2xkVmFsdWVzAQDWCwAuAETWCwAAAQCYAwEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private PropertyState<NodeId> m_updatedNode;

	private PropertyState<PerformUpdateType> m_performInsertReplace;

	private PropertyState<EventFilter> m_filter;

	private PropertyState<HistoryEventFieldList[]> m_newValues;

	private PropertyState<HistoryEventFieldList[]> m_oldValues;

	public PropertyState<NodeId> UpdatedNode
	{
		get
		{
			return m_updatedNode;
		}
		set
		{
			if (m_updatedNode != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_updatedNode = value;
		}
	}

	public PropertyState<PerformUpdateType> PerformInsertReplace
	{
		get
		{
			return m_performInsertReplace;
		}
		set
		{
			if (m_performInsertReplace != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_performInsertReplace = value;
		}
	}

	public PropertyState<EventFilter> Filter
	{
		get
		{
			return m_filter;
		}
		set
		{
			if (m_filter != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_filter = value;
		}
	}

	public PropertyState<HistoryEventFieldList[]> NewValues
	{
		get
		{
			return m_newValues;
		}
		set
		{
			if (m_newValues != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_newValues = value;
		}
	}

	public PropertyState<HistoryEventFieldList[]> OldValues
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

	public AuditHistoryEventUpdateEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2999u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAKAAAAEF1ZGl0SGlzdG9yeUV2ZW50VXBkYXRlRXZlbnRUeXBlSW5zdGFuY2UBALcLAQC3C7cLAAD/////EwAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEA2g0ALgBE2g0AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEA2w0ALgBE2w0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBANwNAC4ARNwNAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQDdDQAuAETdDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEA3g0ALgBE3g0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAN8NAC4ARN8NAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAOENAC4AROENAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEA4g0ALgBE4g0AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEA4w0ALgBE4w0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQDkDQAuAETkDQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAOUNAC4AROUNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAOYNAC4AROYNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAOcNAC4AROcNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABQYXJhbWV0ZXJEYXRhVHlwZUlkAQDoDQAuAEToDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAVXBkYXRlZE5vZGUBANELAC4ARNELAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABQAAABQZXJmb3JtSW5zZXJ0UmVwbGFjZQEA1AsALgBE1AsAAAEAHSz/////AQH/////AAAAABVgiQoCAAAAAAAGAAAARmlsdGVyAQC7CwAuAES7CwAAAQDVAv////8BAf////8AAAAAF2CJCgIAAAAAAAkAAABOZXdWYWx1ZXMBANULAC4ARNULAAABAJgDAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAJAAAAT2xkVmFsdWVzAQDWCwAuAETWCwAAAQCYAwEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		if (m_updatedNode != null)
		{
			children.Add(m_updatedNode);
		}
		if (m_performInsertReplace != null)
		{
			children.Add(m_performInsertReplace);
		}
		if (m_filter != null)
		{
			children.Add(m_filter);
		}
		if (m_newValues != null)
		{
			children.Add(m_newValues);
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
		switch (browseName.Name)
		{
		case "UpdatedNode":
			if (createOrReplace && UpdatedNode == null)
			{
				if (replacement == null)
				{
					UpdatedNode = new PropertyState<NodeId>(this);
				}
				else
				{
					UpdatedNode = (PropertyState<NodeId>)replacement;
				}
			}
			baseInstanceState = UpdatedNode;
			break;
		case "PerformInsertReplace":
			if (createOrReplace && PerformInsertReplace == null)
			{
				if (replacement == null)
				{
					PerformInsertReplace = new PropertyState<PerformUpdateType>(this);
				}
				else
				{
					PerformInsertReplace = (PropertyState<PerformUpdateType>)replacement;
				}
			}
			baseInstanceState = PerformInsertReplace;
			break;
		case "Filter":
			if (createOrReplace && Filter == null)
			{
				if (replacement == null)
				{
					Filter = new PropertyState<EventFilter>(this);
				}
				else
				{
					Filter = (PropertyState<EventFilter>)replacement;
				}
			}
			baseInstanceState = Filter;
			break;
		case "NewValues":
			if (createOrReplace && NewValues == null)
			{
				if (replacement == null)
				{
					NewValues = new PropertyState<HistoryEventFieldList[]>(this);
				}
				else
				{
					NewValues = (PropertyState<HistoryEventFieldList[]>)replacement;
				}
			}
			baseInstanceState = NewValues;
			break;
		case "OldValues":
			if (createOrReplace && OldValues == null)
			{
				if (replacement == null)
				{
					OldValues = new PropertyState<HistoryEventFieldList[]>(this);
				}
				else
				{
					OldValues = (PropertyState<HistoryEventFieldList[]>)replacement;
				}
			}
			baseInstanceState = OldValues;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
