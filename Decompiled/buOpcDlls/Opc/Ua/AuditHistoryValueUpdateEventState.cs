using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditHistoryValueUpdateEventState : AuditHistoryUpdateEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAKAAAAEF1ZGl0SGlzdG9yeVZhbHVlVXBkYXRlRXZlbnRUeXBlSW5zdGFuY2UBAL4LAQC+C74LAAD/////EgAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEA6Q0ALgBE6Q0AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEA6g0ALgBE6g0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAOsNAC4AROsNAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQDsDQAuAETsDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEA7Q0ALgBE7Q0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAO4NAC4ARO4NAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAPANAC4ARPANAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEA8Q0ALgBE8Q0AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEA8g0ALgBE8g0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQDzDQAuAETzDQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAPQNAC4ARPQNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAPUNAC4ARPUNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAPYNAC4ARPYNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABQYXJhbWV0ZXJEYXRhVHlwZUlkAQD3DQAuAET3DQAAABH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAVXBkYXRlZE5vZGUBANILAC4ARNILAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABQAAABQZXJmb3JtSW5zZXJ0UmVwbGFjZQEA1wsALgBE1wsAAAEAHSz/////AQH/////AAAAABdgiQoCAAAAAAAJAAAATmV3VmFsdWVzAQDYCwAuAETYCwAAABcBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAAAkAAABPbGRWYWx1ZXMBANkLAC4ARNkLAAAAFwEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private PropertyState<NodeId> m_updatedNode;

	private PropertyState<PerformUpdateType> m_performInsertReplace;

	private PropertyState<DataValue[]> m_newValues;

	private PropertyState<DataValue[]> m_oldValues;

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

	public PropertyState<DataValue[]> NewValues
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

	public PropertyState<DataValue[]> OldValues
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

	public AuditHistoryValueUpdateEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(3006u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAKAAAAEF1ZGl0SGlzdG9yeVZhbHVlVXBkYXRlRXZlbnRUeXBlSW5zdGFuY2UBAL4LAQC+C74LAAD/////EgAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEA6Q0ALgBE6Q0AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEA6g0ALgBE6g0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAOsNAC4AROsNAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQDsDQAuAETsDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEA7Q0ALgBE7Q0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAO4NAC4ARO4NAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAPANAC4ARPANAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEA8Q0ALgBE8Q0AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEA8g0ALgBE8g0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQDzDQAuAETzDQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAPQNAC4ARPQNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAPUNAC4ARPUNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAPYNAC4ARPYNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABQYXJhbWV0ZXJEYXRhVHlwZUlkAQD3DQAuAET3DQAAABH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAVXBkYXRlZE5vZGUBANILAC4ARNILAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABQAAABQZXJmb3JtSW5zZXJ0UmVwbGFjZQEA1wsALgBE1wsAAAEAHSz/////AQH/////AAAAABdgiQoCAAAAAAAJAAAATmV3VmFsdWVzAQDYCwAuAETYCwAAABcBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAAAkAAABPbGRWYWx1ZXMBANkLAC4ARNkLAAAAFwEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		case "NewValues":
			if (createOrReplace && NewValues == null)
			{
				if (replacement == null)
				{
					NewValues = new PropertyState<DataValue[]>(this);
				}
				else
				{
					NewValues = (PropertyState<DataValue[]>)replacement;
				}
			}
			baseInstanceState = NewValues;
			break;
		case "OldValues":
			if (createOrReplace && OldValues == null)
			{
				if (replacement == null)
				{
					OldValues = new PropertyState<DataValue[]>(this);
				}
				else
				{
					OldValues = (PropertyState<DataValue[]>)replacement;
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
