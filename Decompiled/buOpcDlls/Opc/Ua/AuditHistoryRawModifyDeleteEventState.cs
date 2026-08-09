using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditHistoryRawModifyDeleteEventState : AuditHistoryDeleteEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAALAAAAEF1ZGl0SGlzdG9yeVJhd01vZGlmeURlbGV0ZUV2ZW50VHlwZUluc3RhbmNlAQDGCwEAxgvGCwAA/////xMAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAAcOAC4ARAcOAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAAgOAC4ARAgOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQAJDgAuAEQJDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEACg4ALgBECg4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAAsOAC4ARAsOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQAMDgAuAEQMDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQAODgAuAEQODgAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAA8OAC4ARA8OAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABABAOAC4ARBAOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAEQ4ALgBEEQ4AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQASDgAuAEQSDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQATDgAuAEQTDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQAUDgAuAEQUDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAATAAAAUGFyYW1ldGVyRGF0YVR5cGVJZAEAFQ4ALgBEFQ4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFVwZGF0ZWROb2RlAQAWDgAuAEQWDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAQAAAASXNEZWxldGVNb2RpZmllZAEAxwsALgBExwsAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAFN0YXJ0VGltZQEAyAsALgBEyAsAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAARW5kVGltZQEAyQsALgBEyQsAAAEAJgH/////AQH/////AAAAABdgiQoCAAAAAAAJAAAAT2xkVmFsdWVzAQDaCwAuAETaCwAAABcBAAAAAQAAAAAAAAABAf////8AAAAA";

	private PropertyState<bool> m_isDeleteModified;

	private PropertyState<DateTime> m_startTime;

	private PropertyState<DateTime> m_endTime;

	private PropertyState<DataValue[]> m_oldValues;

	public PropertyState<bool> IsDeleteModified
	{
		get
		{
			return m_isDeleteModified;
		}
		set
		{
			if (m_isDeleteModified != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_isDeleteModified = value;
		}
	}

	public PropertyState<DateTime> StartTime
	{
		get
		{
			return m_startTime;
		}
		set
		{
			if (m_startTime != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_startTime = value;
		}
	}

	public PropertyState<DateTime> EndTime
	{
		get
		{
			return m_endTime;
		}
		set
		{
			if (m_endTime != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_endTime = value;
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

	public AuditHistoryRawModifyDeleteEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(3014u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAALAAAAEF1ZGl0SGlzdG9yeVJhd01vZGlmeURlbGV0ZUV2ZW50VHlwZUluc3RhbmNlAQDGCwEAxgvGCwAA/////xMAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAAcOAC4ARAcOAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAAgOAC4ARAgOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQAJDgAuAEQJDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEACg4ALgBECg4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAAsOAC4ARAsOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQAMDgAuAEQMDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQAODgAuAEQODgAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAA8OAC4ARA8OAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABABAOAC4ARBAOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAEQ4ALgBEEQ4AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQASDgAuAEQSDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQATDgAuAEQTDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQAUDgAuAEQUDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAATAAAAUGFyYW1ldGVyRGF0YVR5cGVJZAEAFQ4ALgBEFQ4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFVwZGF0ZWROb2RlAQAWDgAuAEQWDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAQAAAASXNEZWxldGVNb2RpZmllZAEAxwsALgBExwsAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAFN0YXJ0VGltZQEAyAsALgBEyAsAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAARW5kVGltZQEAyQsALgBEyQsAAAEAJgH/////AQH/////AAAAABdgiQoCAAAAAAAJAAAAT2xkVmFsdWVzAQDaCwAuAETaCwAAABcBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		if (m_isDeleteModified != null)
		{
			children.Add(m_isDeleteModified);
		}
		if (m_startTime != null)
		{
			children.Add(m_startTime);
		}
		if (m_endTime != null)
		{
			children.Add(m_endTime);
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
		case "IsDeleteModified":
			if (createOrReplace && IsDeleteModified == null)
			{
				if (replacement == null)
				{
					IsDeleteModified = new PropertyState<bool>(this);
				}
				else
				{
					IsDeleteModified = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = IsDeleteModified;
			break;
		case "StartTime":
			if (createOrReplace && StartTime == null)
			{
				if (replacement == null)
				{
					StartTime = new PropertyState<DateTime>(this);
				}
				else
				{
					StartTime = (PropertyState<DateTime>)replacement;
				}
			}
			baseInstanceState = StartTime;
			break;
		case "EndTime":
			if (createOrReplace && EndTime == null)
			{
				if (replacement == null)
				{
					EndTime = new PropertyState<DateTime>(this);
				}
				else
				{
					EndTime = (PropertyState<DateTime>)replacement;
				}
			}
			baseInstanceState = EndTime;
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
