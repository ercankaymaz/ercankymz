using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditHistoryAtTimeDeleteEventState : AuditHistoryDeleteEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAKQAAAEF1ZGl0SGlzdG9yeUF0VGltZURlbGV0ZUV2ZW50VHlwZUluc3RhbmNlAQDLCwEAywvLCwAA/////xEAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBABcOAC4ARBcOAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBABgOAC4ARBgOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQAZDgAuAEQZDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAGg4ALgBEGg4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBABsOAC4ARBsOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQAcDgAuAEQcDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQAeDgAuAEQeDgAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAB8OAC4ARB8OAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABACAOAC4ARCAOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAIQ4ALgBEIQ4AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQAiDgAuAEQiDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQAjDgAuAEQjDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQAkDgAuAEQkDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAATAAAAUGFyYW1ldGVyRGF0YVR5cGVJZAEAJQ4ALgBEJQ4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFVwZGF0ZWROb2RlAQAmDgAuAEQmDgAAABH/////AQH/////AAAAABdgiQoCAAAAAAAIAAAAUmVxVGltZXMBAMwLAC4ARMwLAAABACYBAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAJAAAAT2xkVmFsdWVzAQDNCwAuAETNCwAAABcBAAAAAQAAAAAAAAABAf////8AAAAA";

	private PropertyState<DateTime[]> m_reqTimes;

	private PropertyState<DataValue[]> m_oldValues;

	public PropertyState<DateTime[]> ReqTimes
	{
		get
		{
			return m_reqTimes;
		}
		set
		{
			if (m_reqTimes != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_reqTimes = value;
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

	public AuditHistoryAtTimeDeleteEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(3019u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAKQAAAEF1ZGl0SGlzdG9yeUF0VGltZURlbGV0ZUV2ZW50VHlwZUluc3RhbmNlAQDLCwEAywvLCwAA/////xEAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBABcOAC4ARBcOAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBABgOAC4ARBgOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQAZDgAuAEQZDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAGg4ALgBEGg4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBABsOAC4ARBsOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQAcDgAuAEQcDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQAeDgAuAEQeDgAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAB8OAC4ARB8OAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABACAOAC4ARCAOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAIQ4ALgBEIQ4AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQAiDgAuAEQiDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQAjDgAuAEQjDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQAkDgAuAEQkDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAATAAAAUGFyYW1ldGVyRGF0YVR5cGVJZAEAJQ4ALgBEJQ4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFVwZGF0ZWROb2RlAQAmDgAuAEQmDgAAABH/////AQH/////AAAAABdgiQoCAAAAAAAIAAAAUmVxVGltZXMBAMwLAC4ARMwLAAABACYBAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAJAAAAT2xkVmFsdWVzAQDNCwAuAETNCwAAABcBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		if (m_reqTimes != null)
		{
			children.Add(m_reqTimes);
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
		if (!(name == "ReqTimes"))
		{
			if (name == "OldValues")
			{
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
			}
		}
		else
		{
			if (createOrReplace && ReqTimes == null)
			{
				if (replacement == null)
				{
					ReqTimes = new PropertyState<DateTime[]>(this);
				}
				else
				{
					ReqTimes = (PropertyState<DateTime[]>)replacement;
				}
			}
			baseInstanceState = ReqTimes;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
