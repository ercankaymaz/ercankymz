using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditSessionEventState : AuditSecurityEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAHQAAAEF1ZGl0U2Vzc2lvbkV2ZW50VHlwZUluc3RhbmNlAQAVCAEAFQgVCAAA/////w4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBALQMAC4ARLQMAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBALUMAC4ARLUMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQC2DAAuAES2DAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAtwwALgBEtwwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBALgMAC4ARLgMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQC5DAAuAES5DAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQC7DAAuAES7DAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBALwMAC4ARLwMAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAL0MAC4ARL0MAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAvgwALgBEvgwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQC/DAAuAES/DAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQDADAAuAETADAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQDBDAAuAETBDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAU2Vzc2lvbklkAQAWCAAuAEQWCAAAABH/////AQH/////AAAAAA==";

	private PropertyState<NodeId> m_sessionId;

	public PropertyState<NodeId> SessionId
	{
		get
		{
			return m_sessionId;
		}
		set
		{
			if (m_sessionId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_sessionId = value;
		}
	}

	public AuditSessionEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2069u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHQAAAEF1ZGl0U2Vzc2lvbkV2ZW50VHlwZUluc3RhbmNlAQAVCAEAFQgVCAAA/////w4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBALQMAC4ARLQMAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBALUMAC4ARLUMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQC2DAAuAES2DAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAtwwALgBEtwwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBALgMAC4ARLgMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQC5DAAuAES5DAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQC7DAAuAES7DAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBALwMAC4ARLwMAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAL0MAC4ARL0MAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAvgwALgBEvgwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQC/DAAuAES/DAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQDADAAuAETADAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQDBDAAuAETBDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAU2Vzc2lvbklkAQAWCAAuAEQWCAAAABH/////AQH/////AAAAAA==");
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
		if (m_sessionId != null)
		{
			children.Add(m_sessionId);
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
		if (browseName.Name == "SessionId")
		{
			if (createOrReplace && SessionId == null)
			{
				if (replacement == null)
				{
					SessionId = new PropertyState<NodeId>(this);
				}
				else
				{
					SessionId = (PropertyState<NodeId>)replacement;
				}
			}
			baseInstanceState = SessionId;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
