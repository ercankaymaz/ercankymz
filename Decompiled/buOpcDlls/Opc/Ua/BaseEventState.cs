using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class BaseEventState : BaseObjectState
{
	private const string LocalTime_InitializationString = "//////////8VYIkKAgAAAAAACQAAAExvY2FsVGltZQEAdgwALgBEdgwAAAEA0CL/////AQH/////AAAAAA==";

	private const string InitializationString = "//////////8EYIACAQAAAAAAFQAAAEJhc2VFdmVudFR5cGVJbnN0YW5jZQEA+QcBAPkH+QcAAP////8JAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQD6BwAuAET6BwAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQD7BwAuAET7BwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEA/AcALgBE/AcAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAP0HAC4ARP0HAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQD+BwAuAET+BwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEA/wcALgBE/wcAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAJAAAATG9jYWxUaW1lAQB2DAAuAER2DAAAAQDQIv////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQACCAAuAEQCCAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAAMIAC4ARAMIAAAABf////8BAf////8AAAAA";

	private PropertyState<byte[]> m_eventId;

	private PropertyState<NodeId> m_eventType;

	private PropertyState<NodeId> m_sourceNode;

	private PropertyState<string> m_sourceName;

	private PropertyState<DateTime> m_time;

	private PropertyState<DateTime> m_receiveTime;

	private PropertyState<TimeZoneDataType> m_localTime;

	private PropertyState<LocalizedText> m_message;

	private PropertyState<ushort> m_severity;

	public PropertyState<byte[]> EventId
	{
		get
		{
			return m_eventId;
		}
		set
		{
			if (m_eventId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_eventId = value;
		}
	}

	public PropertyState<NodeId> EventType
	{
		get
		{
			return m_eventType;
		}
		set
		{
			if (m_eventType != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_eventType = value;
		}
	}

	public PropertyState<NodeId> SourceNode
	{
		get
		{
			return m_sourceNode;
		}
		set
		{
			if (m_sourceNode != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_sourceNode = value;
		}
	}

	public PropertyState<string> SourceName
	{
		get
		{
			return m_sourceName;
		}
		set
		{
			if (m_sourceName != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_sourceName = value;
		}
	}

	public PropertyState<DateTime> Time
	{
		get
		{
			return m_time;
		}
		set
		{
			if (m_time != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_time = value;
		}
	}

	public PropertyState<DateTime> ReceiveTime
	{
		get
		{
			return m_receiveTime;
		}
		set
		{
			if (m_receiveTime != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_receiveTime = value;
		}
	}

	public PropertyState<TimeZoneDataType> LocalTime
	{
		get
		{
			return m_localTime;
		}
		set
		{
			if (m_localTime != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_localTime = value;
		}
	}

	public PropertyState<LocalizedText> Message
	{
		get
		{
			return m_message;
		}
		set
		{
			if (m_message != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_message = value;
		}
	}

	public PropertyState<ushort> Severity
	{
		get
		{
			return m_severity;
		}
		set
		{
			if (m_severity != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_severity = value;
		}
	}

	public BaseEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2041u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAFQAAAEJhc2VFdmVudFR5cGVJbnN0YW5jZQEA+QcBAPkH+QcAAP////8JAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQD6BwAuAET6BwAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQD7BwAuAET7BwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEA/AcALgBE/AcAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAP0HAC4ARP0HAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQD+BwAuAET+BwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEA/wcALgBE/wcAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAJAAAATG9jYWxUaW1lAQB2DAAuAER2DAAAAQDQIv////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQACCAAuAEQCCAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAAMIAC4ARAMIAAAABf////8BAf////8AAAAA");
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
		if (LocalTime != null)
		{
			LocalTime.Initialize(context, "//////////8VYIkKAgAAAAAACQAAAExvY2FsVGltZQEAdgwALgBEdgwAAAEA0CL/////AQH/////AAAAAA==");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_eventId != null)
		{
			children.Add(m_eventId);
		}
		if (m_eventType != null)
		{
			children.Add(m_eventType);
		}
		if (m_sourceNode != null)
		{
			children.Add(m_sourceNode);
		}
		if (m_sourceName != null)
		{
			children.Add(m_sourceName);
		}
		if (m_time != null)
		{
			children.Add(m_time);
		}
		if (m_receiveTime != null)
		{
			children.Add(m_receiveTime);
		}
		if (m_localTime != null)
		{
			children.Add(m_localTime);
		}
		if (m_message != null)
		{
			children.Add(m_message);
		}
		if (m_severity != null)
		{
			children.Add(m_severity);
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
		case "EventId":
			if (createOrReplace && EventId == null)
			{
				if (replacement == null)
				{
					EventId = new PropertyState<byte[]>(this);
				}
				else
				{
					EventId = (PropertyState<byte[]>)replacement;
				}
			}
			baseInstanceState = EventId;
			break;
		case "EventType":
			if (createOrReplace && EventType == null)
			{
				if (replacement == null)
				{
					EventType = new PropertyState<NodeId>(this);
				}
				else
				{
					EventType = (PropertyState<NodeId>)replacement;
				}
			}
			baseInstanceState = EventType;
			break;
		case "SourceNode":
			if (createOrReplace && SourceNode == null)
			{
				if (replacement == null)
				{
					SourceNode = new PropertyState<NodeId>(this);
				}
				else
				{
					SourceNode = (PropertyState<NodeId>)replacement;
				}
			}
			baseInstanceState = SourceNode;
			break;
		case "SourceName":
			if (createOrReplace && SourceName == null)
			{
				if (replacement == null)
				{
					SourceName = new PropertyState<string>(this);
				}
				else
				{
					SourceName = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = SourceName;
			break;
		case "Time":
			if (createOrReplace && Time == null)
			{
				if (replacement == null)
				{
					Time = new PropertyState<DateTime>(this);
				}
				else
				{
					Time = (PropertyState<DateTime>)replacement;
				}
			}
			baseInstanceState = Time;
			break;
		case "ReceiveTime":
			if (createOrReplace && ReceiveTime == null)
			{
				if (replacement == null)
				{
					ReceiveTime = new PropertyState<DateTime>(this);
				}
				else
				{
					ReceiveTime = (PropertyState<DateTime>)replacement;
				}
			}
			baseInstanceState = ReceiveTime;
			break;
		case "LocalTime":
			if (createOrReplace && LocalTime == null)
			{
				if (replacement == null)
				{
					LocalTime = new PropertyState<TimeZoneDataType>(this);
				}
				else
				{
					LocalTime = (PropertyState<TimeZoneDataType>)replacement;
				}
			}
			baseInstanceState = LocalTime;
			break;
		case "Message":
			if (createOrReplace && Message == null)
			{
				if (replacement == null)
				{
					Message = new PropertyState<LocalizedText>(this);
				}
				else
				{
					Message = (PropertyState<LocalizedText>)replacement;
				}
			}
			baseInstanceState = Message;
			break;
		case "Severity":
			if (createOrReplace && Severity == null)
			{
				if (replacement == null)
				{
					Severity = new PropertyState<ushort>(this);
				}
				else
				{
					Severity = (PropertyState<ushort>)replacement;
				}
			}
			baseInstanceState = Severity;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}

	public virtual void Initialize(ISystemContext context, NodeState source, EventSeverity severity, LocalizedText message)
	{
		m_eventId = new PropertyState<byte[]>(this);
		m_eventId.Value = Guid.NewGuid().ToByteArray();
		m_eventType = new PropertyState<NodeId>(this);
		m_eventType.Value = GetDefaultTypeDefinitionId(context.NamespaceUris);
		base.TypeDefinitionId = m_eventType.Value;
		if (source != null)
		{
			if (!NodeId.IsNull(source.NodeId))
			{
				m_sourceNode = new PropertyState<NodeId>(this);
				m_sourceNode.Value = source.NodeId;
				m_sourceNode.RolePermissions = source.RolePermissions;
				m_sourceNode.UserRolePermissions = source.UserRolePermissions;
				m_sourceNode.NodeId = source.NodeId;
			}
			if (!QualifiedName.IsNull(source.BrowseName))
			{
				m_sourceName = new PropertyState<string>(this);
				m_sourceName.Value = source.BrowseName.Name;
			}
		}
		m_time = new PropertyState<DateTime>(this);
		m_time.Value = DateTime.UtcNow;
		m_receiveTime = new PropertyState<DateTime>(this);
		m_receiveTime.Value = DateTime.UtcNow;
		m_severity = new PropertyState<ushort>(this);
		m_severity.Value = (ushort)severity;
		m_message = new PropertyState<LocalizedText>(this);
		m_message.Value = message;
	}

	public override object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BaseEventState clone = (BaseEventState)Activator.CreateInstance(GetType());
		return CloneChildren(clone);
	}
}
