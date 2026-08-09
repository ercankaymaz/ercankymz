using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class TrustListOutOfDateAlarmState : SystemOffNormalAlarmState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIwAAAFRydXN0TGlzdE91dE9mRGF0ZUFsYXJtVHlwZUluc3RhbmNlAQBhSwEAYUthSwAA/////x4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAGJLAC4ARGJLAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAGNLAC4ARGNLAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQBkSwAuAERkSwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAZUsALgBEZUsAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAGZLAC4ARGZLAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQBnSwAuAERnSwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQBpSwAuAERpSwAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAGpLAC4ARGpLAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABDb25kaXRpb25DbGFzc0lkAQBrSwAuAERrSwAAABH/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ29uZGl0aW9uQ2xhc3NOYW1lAQBsSwAuAERsSwAAABX/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQ29uZGl0aW9uTmFtZQEAb0sALgBEb0sAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAEJyYW5jaElkAQBwSwAuAERwSwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAUmV0YWluAQBxSwAuAERxSwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAARW5hYmxlZFN0YXRlAQBySwAvAQAjI3JLAAAAFf////8BAQUAAAABACwjAAEAiksBACwjAAEAk0sBACwjAAEAoEsBACwjAAEAqksBACwjAAEAvEsBAAAAFWCJCgIAAAAAAAIAAABJZAEAc0sALgBEc0sAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAFF1YWxpdHkBAHtLAC8BACoje0sAAAAT/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEAfEsALgBEfEsAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAATGFzdFNldmVyaXR5AQB9SwAvAQAqI31LAAAABf////8BAf////8BAAAAFWCJCgIAAAAAAA8AAABTb3VyY2VUaW1lc3RhbXABAH5LAC4ARH5LAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAENvbW1lbnQBAH9LAC8BACojf0sAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEAgEsALgBEgEsAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQCBSwAuAESBSwAAAAz/////AQH/////AAAAAARhggoEAAAAAAAHAAAARGlzYWJsZQEAgksALwEARCOCSwAAAQEBAAAAAQD5CwABAPMKAAAAAARhggoEAAAAAAAGAAAARW5hYmxlAQCDSwAvAQBDI4NLAAABAQEAAAABAPkLAAEA8woAAAAABGGCCgQAAAAAAAoAAABBZGRDb21tZW50AQCESwAvAQBFI4RLAAABAQEAAAABAPkLAAEADQsBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAhUsALgBEhUsAAJYCAAAAAQAqAQFGAAAABwAAAEV2ZW50SWQAD/////8AAAAAAwAAAAAoAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0byBjb21tZW50LgEAKgEBQgAAAAcAAABDb21tZW50ABX/////AAAAAAMAAAAAJAAAAFRoZSBjb21tZW50IHRvIGFkZCB0byB0aGUgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAoAAABBY2tlZFN0YXRlAQCKSwAvAQAjI4pLAAAAFf////8BAQEAAAABACwjAQEAcksBAAAAFWCJCgIAAAAAAAIAAABJZAEAi0sALgBEi0sAAAAB/////wEB/////wAAAAAEYYIKBAAAAAAACwAAAEFja25vd2xlZGdlAQCcSwAvAQCXI5xLAAABAQEAAAABAPkLAAEA8CIBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAnUsALgBEnUsAAJYCAAAAAQAqAQFGAAAABwAAAEV2ZW50SWQAD/////8AAAAAAwAAAAAoAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0byBjb21tZW50LgEAKgEBQgAAAAcAAABDb21tZW50ABX/////AAAAAAMAAAAAJAAAAFRoZSBjb21tZW50IHRvIGFkZCB0byB0aGUgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAsAAABBY3RpdmVTdGF0ZQEAoEsALwEAIyOgSwAAABX/////AQEBAAAAAQAsIwEBAHJLAQAAABVgiQoCAAAAAAACAAAASWQBAKFLAC4ARKFLAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABJbnB1dE5vZGUBAKlLAC4ARKlLAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdXBwcmVzc2VkT3JTaGVsdmVkAQDPSwAuAETPSwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAALAAAATm9ybWFsU3RhdGUBAPVLAC4ARPVLAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABUcnVzdExpc3RJZAEA9ksALgBE9ksAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAExhc3RVcGRhdGVUaW1lAQD3SwAuAET3SwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABVcGRhdGVGcmVxdWVuY3kBAPhLAC4ARPhLAAABACIB/////wEB/////wAAAAA=";

	private PropertyState<NodeId> m_trustListId;

	private PropertyState<DateTime> m_lastUpdateTime;

	private PropertyState<double> m_updateFrequency;

	public PropertyState<NodeId> TrustListId
	{
		get
		{
			return m_trustListId;
		}
		set
		{
			if (m_trustListId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_trustListId = value;
		}
	}

	public PropertyState<DateTime> LastUpdateTime
	{
		get
		{
			return m_lastUpdateTime;
		}
		set
		{
			if (m_lastUpdateTime != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_lastUpdateTime = value;
		}
	}

	public PropertyState<double> UpdateFrequency
	{
		get
		{
			return m_updateFrequency;
		}
		set
		{
			if (m_updateFrequency != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_updateFrequency = value;
		}
	}

	public TrustListOutOfDateAlarmState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(19297u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIwAAAFRydXN0TGlzdE91dE9mRGF0ZUFsYXJtVHlwZUluc3RhbmNlAQBhSwEAYUthSwAA/////x4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAGJLAC4ARGJLAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAGNLAC4ARGNLAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQBkSwAuAERkSwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAZUsALgBEZUsAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAGZLAC4ARGZLAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQBnSwAuAERnSwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQBpSwAuAERpSwAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAGpLAC4ARGpLAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABDb25kaXRpb25DbGFzc0lkAQBrSwAuAERrSwAAABH/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ29uZGl0aW9uQ2xhc3NOYW1lAQBsSwAuAERsSwAAABX/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQ29uZGl0aW9uTmFtZQEAb0sALgBEb0sAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAEJyYW5jaElkAQBwSwAuAERwSwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAUmV0YWluAQBxSwAuAERxSwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAARW5hYmxlZFN0YXRlAQBySwAvAQAjI3JLAAAAFf////8BAQUAAAABACwjAAEAiksBACwjAAEAk0sBACwjAAEAoEsBACwjAAEAqksBACwjAAEAvEsBAAAAFWCJCgIAAAAAAAIAAABJZAEAc0sALgBEc0sAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAFF1YWxpdHkBAHtLAC8BACoje0sAAAAT/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEAfEsALgBEfEsAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAATGFzdFNldmVyaXR5AQB9SwAvAQAqI31LAAAABf////8BAf////8BAAAAFWCJCgIAAAAAAA8AAABTb3VyY2VUaW1lc3RhbXABAH5LAC4ARH5LAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAENvbW1lbnQBAH9LAC8BACojf0sAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEAgEsALgBEgEsAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQCBSwAuAESBSwAAAAz/////AQH/////AAAAAARhggoEAAAAAAAHAAAARGlzYWJsZQEAgksALwEARCOCSwAAAQEBAAAAAQD5CwABAPMKAAAAAARhggoEAAAAAAAGAAAARW5hYmxlAQCDSwAvAQBDI4NLAAABAQEAAAABAPkLAAEA8woAAAAABGGCCgQAAAAAAAoAAABBZGRDb21tZW50AQCESwAvAQBFI4RLAAABAQEAAAABAPkLAAEADQsBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAhUsALgBEhUsAAJYCAAAAAQAqAQFGAAAABwAAAEV2ZW50SWQAD/////8AAAAAAwAAAAAoAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0byBjb21tZW50LgEAKgEBQgAAAAcAAABDb21tZW50ABX/////AAAAAAMAAAAAJAAAAFRoZSBjb21tZW50IHRvIGFkZCB0byB0aGUgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAoAAABBY2tlZFN0YXRlAQCKSwAvAQAjI4pLAAAAFf////8BAQEAAAABACwjAQEAcksBAAAAFWCJCgIAAAAAAAIAAABJZAEAi0sALgBEi0sAAAAB/////wEB/////wAAAAAEYYIKBAAAAAAACwAAAEFja25vd2xlZGdlAQCcSwAvAQCXI5xLAAABAQEAAAABAPkLAAEA8CIBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAnUsALgBEnUsAAJYCAAAAAQAqAQFGAAAABwAAAEV2ZW50SWQAD/////8AAAAAAwAAAAAoAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0byBjb21tZW50LgEAKgEBQgAAAAcAAABDb21tZW50ABX/////AAAAAAMAAAAAJAAAAFRoZSBjb21tZW50IHRvIGFkZCB0byB0aGUgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAsAAABBY3RpdmVTdGF0ZQEAoEsALwEAIyOgSwAAABX/////AQEBAAAAAQAsIwEBAHJLAQAAABVgiQoCAAAAAAACAAAASWQBAKFLAC4ARKFLAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABJbnB1dE5vZGUBAKlLAC4ARKlLAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdXBwcmVzc2VkT3JTaGVsdmVkAQDPSwAuAETPSwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAALAAAATm9ybWFsU3RhdGUBAPVLAC4ARPVLAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABUcnVzdExpc3RJZAEA9ksALgBE9ksAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAExhc3RVcGRhdGVUaW1lAQD3SwAuAET3SwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABVcGRhdGVGcmVxdWVuY3kBAPhLAC4ARPhLAAABACIB/////wEB/////wAAAAA=");
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
		if (m_trustListId != null)
		{
			children.Add(m_trustListId);
		}
		if (m_lastUpdateTime != null)
		{
			children.Add(m_lastUpdateTime);
		}
		if (m_updateFrequency != null)
		{
			children.Add(m_updateFrequency);
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
		case "TrustListId":
			if (createOrReplace && TrustListId == null)
			{
				if (replacement == null)
				{
					TrustListId = new PropertyState<NodeId>(this);
				}
				else
				{
					TrustListId = (PropertyState<NodeId>)replacement;
				}
			}
			baseInstanceState = TrustListId;
			break;
		case "LastUpdateTime":
			if (createOrReplace && LastUpdateTime == null)
			{
				if (replacement == null)
				{
					LastUpdateTime = new PropertyState<DateTime>(this);
				}
				else
				{
					LastUpdateTime = (PropertyState<DateTime>)replacement;
				}
			}
			baseInstanceState = LastUpdateTime;
			break;
		case "UpdateFrequency":
			if (createOrReplace && UpdateFrequency == null)
			{
				if (replacement == null)
				{
					UpdateFrequency = new PropertyState<double>(this);
				}
				else
				{
					UpdateFrequency = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = UpdateFrequency;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
