using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditEventState : BaseEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAFgAAAEF1ZGl0RXZlbnRUeXBlSW5zdGFuY2UBAAQIAQAECAQIAAD/////DQAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAgAwALgBEgAwAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAgQwALgBEgQwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAIIMAC4ARIIMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQCDDAAuAESDDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAhAwALgBEhAwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAIUMAC4ARIUMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAIcMAC4ARIcMAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAiAwALgBEiAwAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEABQgALgBEBQgAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQAGCAAuAEQGCAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAAcIAC4ARAcIAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAAgIAC4ARAgIAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAAkIAC4ARAkIAAAADP////8BAf////8AAAAA";

	private PropertyState<DateTime> m_actionTimeStamp;

	private PropertyState<bool> m_status;

	private PropertyState<string> m_serverId;

	private PropertyState<string> m_clientAuditEntryId;

	private PropertyState<string> m_clientUserId;

	public PropertyState<DateTime> ActionTimeStamp
	{
		get
		{
			return m_actionTimeStamp;
		}
		set
		{
			if (m_actionTimeStamp != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_actionTimeStamp = value;
		}
	}

	public PropertyState<bool> Status
	{
		get
		{
			return m_status;
		}
		set
		{
			if (m_status != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_status = value;
		}
	}

	public PropertyState<string> ServerId
	{
		get
		{
			return m_serverId;
		}
		set
		{
			if (m_serverId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_serverId = value;
		}
	}

	public PropertyState<string> ClientAuditEntryId
	{
		get
		{
			return m_clientAuditEntryId;
		}
		set
		{
			if (m_clientAuditEntryId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_clientAuditEntryId = value;
		}
	}

	public PropertyState<string> ClientUserId
	{
		get
		{
			return m_clientUserId;
		}
		set
		{
			if (m_clientUserId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_clientUserId = value;
		}
	}

	public AuditEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2052u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAFgAAAEF1ZGl0RXZlbnRUeXBlSW5zdGFuY2UBAAQIAQAECAQIAAD/////DQAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAgAwALgBEgAwAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAgQwALgBEgQwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAIIMAC4ARIIMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQCDDAAuAESDDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAhAwALgBEhAwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAIUMAC4ARIUMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAIcMAC4ARIcMAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAiAwALgBEiAwAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEABQgALgBEBQgAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQAGCAAuAEQGCAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAAcIAC4ARAcIAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAAgIAC4ARAgIAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAAkIAC4ARAkIAAAADP////8BAf////8AAAAA");
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
		if (m_actionTimeStamp != null)
		{
			children.Add(m_actionTimeStamp);
		}
		if (m_status != null)
		{
			children.Add(m_status);
		}
		if (m_serverId != null)
		{
			children.Add(m_serverId);
		}
		if (m_clientAuditEntryId != null)
		{
			children.Add(m_clientAuditEntryId);
		}
		if (m_clientUserId != null)
		{
			children.Add(m_clientUserId);
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
		case "ActionTimeStamp":
			if (createOrReplace && ActionTimeStamp == null)
			{
				if (replacement == null)
				{
					ActionTimeStamp = new PropertyState<DateTime>(this);
				}
				else
				{
					ActionTimeStamp = (PropertyState<DateTime>)replacement;
				}
			}
			baseInstanceState = ActionTimeStamp;
			break;
		case "Status":
			if (createOrReplace && Status == null)
			{
				if (replacement == null)
				{
					Status = new PropertyState<bool>(this);
				}
				else
				{
					Status = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = Status;
			break;
		case "ServerId":
			if (createOrReplace && ServerId == null)
			{
				if (replacement == null)
				{
					ServerId = new PropertyState<string>(this);
				}
				else
				{
					ServerId = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = ServerId;
			break;
		case "ClientAuditEntryId":
			if (createOrReplace && ClientAuditEntryId == null)
			{
				if (replacement == null)
				{
					ClientAuditEntryId = new PropertyState<string>(this);
				}
				else
				{
					ClientAuditEntryId = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = ClientAuditEntryId;
			break;
		case "ClientUserId":
			if (createOrReplace && ClientUserId == null)
			{
				if (replacement == null)
				{
					ClientUserId = new PropertyState<string>(this);
				}
				else
				{
					ClientUserId = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = ClientUserId;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}

	public virtual void Initialize(ISystemContext context, NodeState source, EventSeverity severity, LocalizedText message, bool status, DateTime actionTimestamp)
	{
		base.Initialize(context, source, severity, message);
		m_status = new PropertyState<bool>(this);
		m_status.Value = status;
		if (actionTimestamp != DateTime.MinValue)
		{
			m_actionTimeStamp = new PropertyState<DateTime>(this);
			m_actionTimeStamp.Value = actionTimestamp;
		}
		if (context.NamespaceUris != null)
		{
			m_serverId = new PropertyState<string>(this);
			m_serverId.Value = context.NamespaceUris.GetString(1u);
		}
		if (context.AuditEntryId != null)
		{
			m_clientAuditEntryId = new PropertyState<string>(this);
			m_clientAuditEntryId.Value = context.AuditEntryId;
		}
		if (context.UserIdentity != null)
		{
			m_clientUserId = new PropertyState<string>(this);
			m_clientUserId.Value = context.UserIdentity.DisplayName;
		}
	}
}
