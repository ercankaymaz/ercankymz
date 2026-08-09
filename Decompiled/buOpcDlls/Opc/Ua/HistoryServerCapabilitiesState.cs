using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class HistoryServerCapabilitiesState : BaseObjectState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAJQAAAEhpc3RvcnlTZXJ2ZXJDYXBhYmlsaXRpZXNUeXBlSW5zdGFuY2UBABoJAQAaCRoJAAD/////EAAAABVgiQoCAAAAAAAbAAAAQWNjZXNzSGlzdG9yeURhdGFDYXBhYmlsaXR5AQAbCQAuAEQbCQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAdAAAAQWNjZXNzSGlzdG9yeUV2ZW50c0NhcGFiaWxpdHkBABwJAC4ARBwJAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABNYXhSZXR1cm5EYXRhVmFsdWVzAQAELAAuAEQELAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAUAAAATWF4UmV0dXJuRXZlbnRWYWx1ZXMBAAUsAC4ARAUsAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABJbnNlcnREYXRhQ2FwYWJpbGl0eQEAHgkALgBEHgkAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFJlcGxhY2VEYXRhQ2FwYWJpbGl0eQEAHwkALgBEHwkAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAAFAAAAFVwZGF0ZURhdGFDYXBhYmlsaXR5AQAgCQAuAEQgCQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAATAAAARGVsZXRlUmF3Q2FwYWJpbGl0eQEAIQkALgBEIQkAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAAFgAAAERlbGV0ZUF0VGltZUNhcGFiaWxpdHkBACIJAC4ARCIJAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABJbnNlcnRFdmVudENhcGFiaWxpdHkBAA4sAC4ARA4sAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAABYAAABSZXBsYWNlRXZlbnRDYXBhYmlsaXR5AQAPLAAuAEQPLAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAVAAAAVXBkYXRlRXZlbnRDYXBhYmlsaXR5AQAQLAAuAEQQLAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAVAAAARGVsZXRlRXZlbnRDYXBhYmlsaXR5AQDtLAAuAETtLAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAaAAAASW5zZXJ0QW5ub3RhdGlvbkNhcGFiaWxpdHkBAAYsAC4ARAYsAAAAAf////8BAf////8AAAAABGCACgEAAAAAABIAAABBZ2dyZWdhdGVGdW5jdGlvbnMBAKQrAC8APaQrAAD/////AAAAABVgiQoCAAAAAAAYAAAAU2VydmVyVGltZXN0YW1wU3VwcG9ydGVkAQCWSgAuAESWSgAAAAH/////AQH/////AAAAAA==";

	private PropertyState<bool> m_accessHistoryDataCapability;

	private PropertyState<bool> m_accessHistoryEventsCapability;

	private PropertyState<uint> m_maxReturnDataValues;

	private PropertyState<uint> m_maxReturnEventValues;

	private PropertyState<bool> m_insertDataCapability;

	private PropertyState<bool> m_replaceDataCapability;

	private PropertyState<bool> m_updateDataCapability;

	private PropertyState<bool> m_deleteRawCapability;

	private PropertyState<bool> m_deleteAtTimeCapability;

	private PropertyState<bool> m_insertEventCapability;

	private PropertyState<bool> m_replaceEventCapability;

	private PropertyState<bool> m_updateEventCapability;

	private PropertyState<bool> m_deleteEventCapability;

	private PropertyState<bool> m_insertAnnotationCapability;

	private FolderState m_aggregateFunctions;

	private PropertyState<bool> m_serverTimestampSupported;

	public PropertyState<bool> AccessHistoryDataCapability
	{
		get
		{
			return m_accessHistoryDataCapability;
		}
		set
		{
			if (m_accessHistoryDataCapability != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_accessHistoryDataCapability = value;
		}
	}

	public PropertyState<bool> AccessHistoryEventsCapability
	{
		get
		{
			return m_accessHistoryEventsCapability;
		}
		set
		{
			if (m_accessHistoryEventsCapability != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_accessHistoryEventsCapability = value;
		}
	}

	public PropertyState<uint> MaxReturnDataValues
	{
		get
		{
			return m_maxReturnDataValues;
		}
		set
		{
			if (m_maxReturnDataValues != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxReturnDataValues = value;
		}
	}

	public PropertyState<uint> MaxReturnEventValues
	{
		get
		{
			return m_maxReturnEventValues;
		}
		set
		{
			if (m_maxReturnEventValues != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxReturnEventValues = value;
		}
	}

	public PropertyState<bool> InsertDataCapability
	{
		get
		{
			return m_insertDataCapability;
		}
		set
		{
			if (m_insertDataCapability != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_insertDataCapability = value;
		}
	}

	public PropertyState<bool> ReplaceDataCapability
	{
		get
		{
			return m_replaceDataCapability;
		}
		set
		{
			if (m_replaceDataCapability != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_replaceDataCapability = value;
		}
	}

	public PropertyState<bool> UpdateDataCapability
	{
		get
		{
			return m_updateDataCapability;
		}
		set
		{
			if (m_updateDataCapability != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_updateDataCapability = value;
		}
	}

	public PropertyState<bool> DeleteRawCapability
	{
		get
		{
			return m_deleteRawCapability;
		}
		set
		{
			if (m_deleteRawCapability != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_deleteRawCapability = value;
		}
	}

	public PropertyState<bool> DeleteAtTimeCapability
	{
		get
		{
			return m_deleteAtTimeCapability;
		}
		set
		{
			if (m_deleteAtTimeCapability != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_deleteAtTimeCapability = value;
		}
	}

	public PropertyState<bool> InsertEventCapability
	{
		get
		{
			return m_insertEventCapability;
		}
		set
		{
			if (m_insertEventCapability != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_insertEventCapability = value;
		}
	}

	public PropertyState<bool> ReplaceEventCapability
	{
		get
		{
			return m_replaceEventCapability;
		}
		set
		{
			if (m_replaceEventCapability != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_replaceEventCapability = value;
		}
	}

	public PropertyState<bool> UpdateEventCapability
	{
		get
		{
			return m_updateEventCapability;
		}
		set
		{
			if (m_updateEventCapability != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_updateEventCapability = value;
		}
	}

	public PropertyState<bool> DeleteEventCapability
	{
		get
		{
			return m_deleteEventCapability;
		}
		set
		{
			if (m_deleteEventCapability != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_deleteEventCapability = value;
		}
	}

	public PropertyState<bool> InsertAnnotationCapability
	{
		get
		{
			return m_insertAnnotationCapability;
		}
		set
		{
			if (m_insertAnnotationCapability != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_insertAnnotationCapability = value;
		}
	}

	public FolderState AggregateFunctions
	{
		get
		{
			return m_aggregateFunctions;
		}
		set
		{
			if (m_aggregateFunctions != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_aggregateFunctions = value;
		}
	}

	public PropertyState<bool> ServerTimestampSupported
	{
		get
		{
			return m_serverTimestampSupported;
		}
		set
		{
			if (m_serverTimestampSupported != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_serverTimestampSupported = value;
		}
	}

	public HistoryServerCapabilitiesState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2330u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJQAAAEhpc3RvcnlTZXJ2ZXJDYXBhYmlsaXRpZXNUeXBlSW5zdGFuY2UBABoJAQAaCRoJAAD/////EAAAABVgiQoCAAAAAAAbAAAAQWNjZXNzSGlzdG9yeURhdGFDYXBhYmlsaXR5AQAbCQAuAEQbCQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAdAAAAQWNjZXNzSGlzdG9yeUV2ZW50c0NhcGFiaWxpdHkBABwJAC4ARBwJAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABNYXhSZXR1cm5EYXRhVmFsdWVzAQAELAAuAEQELAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAUAAAATWF4UmV0dXJuRXZlbnRWYWx1ZXMBAAUsAC4ARAUsAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABJbnNlcnREYXRhQ2FwYWJpbGl0eQEAHgkALgBEHgkAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFJlcGxhY2VEYXRhQ2FwYWJpbGl0eQEAHwkALgBEHwkAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAAFAAAAFVwZGF0ZURhdGFDYXBhYmlsaXR5AQAgCQAuAEQgCQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAATAAAARGVsZXRlUmF3Q2FwYWJpbGl0eQEAIQkALgBEIQkAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAAFgAAAERlbGV0ZUF0VGltZUNhcGFiaWxpdHkBACIJAC4ARCIJAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABJbnNlcnRFdmVudENhcGFiaWxpdHkBAA4sAC4ARA4sAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAABYAAABSZXBsYWNlRXZlbnRDYXBhYmlsaXR5AQAPLAAuAEQPLAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAVAAAAVXBkYXRlRXZlbnRDYXBhYmlsaXR5AQAQLAAuAEQQLAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAVAAAARGVsZXRlRXZlbnRDYXBhYmlsaXR5AQDtLAAuAETtLAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAaAAAASW5zZXJ0QW5ub3RhdGlvbkNhcGFiaWxpdHkBAAYsAC4ARAYsAAAAAf////8BAf////8AAAAABGCACgEAAAAAABIAAABBZ2dyZWdhdGVGdW5jdGlvbnMBAKQrAC8APaQrAAD/////AAAAABVgiQoCAAAAAAAYAAAAU2VydmVyVGltZXN0YW1wU3VwcG9ydGVkAQCWSgAuAESWSgAAAAH/////AQH/////AAAAAA==");
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
		if (m_accessHistoryDataCapability != null)
		{
			children.Add(m_accessHistoryDataCapability);
		}
		if (m_accessHistoryEventsCapability != null)
		{
			children.Add(m_accessHistoryEventsCapability);
		}
		if (m_maxReturnDataValues != null)
		{
			children.Add(m_maxReturnDataValues);
		}
		if (m_maxReturnEventValues != null)
		{
			children.Add(m_maxReturnEventValues);
		}
		if (m_insertDataCapability != null)
		{
			children.Add(m_insertDataCapability);
		}
		if (m_replaceDataCapability != null)
		{
			children.Add(m_replaceDataCapability);
		}
		if (m_updateDataCapability != null)
		{
			children.Add(m_updateDataCapability);
		}
		if (m_deleteRawCapability != null)
		{
			children.Add(m_deleteRawCapability);
		}
		if (m_deleteAtTimeCapability != null)
		{
			children.Add(m_deleteAtTimeCapability);
		}
		if (m_insertEventCapability != null)
		{
			children.Add(m_insertEventCapability);
		}
		if (m_replaceEventCapability != null)
		{
			children.Add(m_replaceEventCapability);
		}
		if (m_updateEventCapability != null)
		{
			children.Add(m_updateEventCapability);
		}
		if (m_deleteEventCapability != null)
		{
			children.Add(m_deleteEventCapability);
		}
		if (m_insertAnnotationCapability != null)
		{
			children.Add(m_insertAnnotationCapability);
		}
		if (m_aggregateFunctions != null)
		{
			children.Add(m_aggregateFunctions);
		}
		if (m_serverTimestampSupported != null)
		{
			children.Add(m_serverTimestampSupported);
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
		case "AccessHistoryDataCapability":
			if (createOrReplace && AccessHistoryDataCapability == null)
			{
				if (replacement == null)
				{
					AccessHistoryDataCapability = new PropertyState<bool>(this);
				}
				else
				{
					AccessHistoryDataCapability = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = AccessHistoryDataCapability;
			break;
		case "AccessHistoryEventsCapability":
			if (createOrReplace && AccessHistoryEventsCapability == null)
			{
				if (replacement == null)
				{
					AccessHistoryEventsCapability = new PropertyState<bool>(this);
				}
				else
				{
					AccessHistoryEventsCapability = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = AccessHistoryEventsCapability;
			break;
		case "MaxReturnDataValues":
			if (createOrReplace && MaxReturnDataValues == null)
			{
				if (replacement == null)
				{
					MaxReturnDataValues = new PropertyState<uint>(this);
				}
				else
				{
					MaxReturnDataValues = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = MaxReturnDataValues;
			break;
		case "MaxReturnEventValues":
			if (createOrReplace && MaxReturnEventValues == null)
			{
				if (replacement == null)
				{
					MaxReturnEventValues = new PropertyState<uint>(this);
				}
				else
				{
					MaxReturnEventValues = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = MaxReturnEventValues;
			break;
		case "InsertDataCapability":
			if (createOrReplace && InsertDataCapability == null)
			{
				if (replacement == null)
				{
					InsertDataCapability = new PropertyState<bool>(this);
				}
				else
				{
					InsertDataCapability = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = InsertDataCapability;
			break;
		case "ReplaceDataCapability":
			if (createOrReplace && ReplaceDataCapability == null)
			{
				if (replacement == null)
				{
					ReplaceDataCapability = new PropertyState<bool>(this);
				}
				else
				{
					ReplaceDataCapability = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = ReplaceDataCapability;
			break;
		case "UpdateDataCapability":
			if (createOrReplace && UpdateDataCapability == null)
			{
				if (replacement == null)
				{
					UpdateDataCapability = new PropertyState<bool>(this);
				}
				else
				{
					UpdateDataCapability = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = UpdateDataCapability;
			break;
		case "DeleteRawCapability":
			if (createOrReplace && DeleteRawCapability == null)
			{
				if (replacement == null)
				{
					DeleteRawCapability = new PropertyState<bool>(this);
				}
				else
				{
					DeleteRawCapability = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = DeleteRawCapability;
			break;
		case "DeleteAtTimeCapability":
			if (createOrReplace && DeleteAtTimeCapability == null)
			{
				if (replacement == null)
				{
					DeleteAtTimeCapability = new PropertyState<bool>(this);
				}
				else
				{
					DeleteAtTimeCapability = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = DeleteAtTimeCapability;
			break;
		case "InsertEventCapability":
			if (createOrReplace && InsertEventCapability == null)
			{
				if (replacement == null)
				{
					InsertEventCapability = new PropertyState<bool>(this);
				}
				else
				{
					InsertEventCapability = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = InsertEventCapability;
			break;
		case "ReplaceEventCapability":
			if (createOrReplace && ReplaceEventCapability == null)
			{
				if (replacement == null)
				{
					ReplaceEventCapability = new PropertyState<bool>(this);
				}
				else
				{
					ReplaceEventCapability = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = ReplaceEventCapability;
			break;
		case "UpdateEventCapability":
			if (createOrReplace && UpdateEventCapability == null)
			{
				if (replacement == null)
				{
					UpdateEventCapability = new PropertyState<bool>(this);
				}
				else
				{
					UpdateEventCapability = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = UpdateEventCapability;
			break;
		case "DeleteEventCapability":
			if (createOrReplace && DeleteEventCapability == null)
			{
				if (replacement == null)
				{
					DeleteEventCapability = new PropertyState<bool>(this);
				}
				else
				{
					DeleteEventCapability = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = DeleteEventCapability;
			break;
		case "InsertAnnotationCapability":
			if (createOrReplace && InsertAnnotationCapability == null)
			{
				if (replacement == null)
				{
					InsertAnnotationCapability = new PropertyState<bool>(this);
				}
				else
				{
					InsertAnnotationCapability = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = InsertAnnotationCapability;
			break;
		case "AggregateFunctions":
			if (createOrReplace && AggregateFunctions == null)
			{
				if (replacement == null)
				{
					AggregateFunctions = new FolderState(this);
				}
				else
				{
					AggregateFunctions = (FolderState)replacement;
				}
			}
			baseInstanceState = AggregateFunctions;
			break;
		case "ServerTimestampSupported":
			if (createOrReplace && ServerTimestampSupported == null)
			{
				if (replacement == null)
				{
					ServerTimestampSupported = new PropertyState<bool>(this);
				}
				else
				{
					ServerTimestampSupported = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = ServerTimestampSupported;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
