using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditDeleteReferencesEventState : AuditNodeManagementEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAJgAAAEF1ZGl0RGVsZXRlUmVmZXJlbmNlc0V2ZW50VHlwZUluc3RhbmNlAQAxCAEAMQgxCAAA/////w4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAKINAC4ARKINAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAKMNAC4ARKMNAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCkDQAuAESkDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEApQ0ALgBEpQ0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAKYNAC4ARKYNAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQCnDQAuAESnDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQCpDQAuAESpDQAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAKoNAC4ARKoNAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAKsNAC4ARKsNAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEArA0ALgBErA0AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQCtDQAuAEStDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQCuDQAuAESuDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQCvDQAuAESvDQAAAAz/////AQH/////AAAAABdgiQoCAAAAAAASAAAAUmVmZXJlbmNlc1RvRGVsZXRlAQAyCAAuAEQyCAAAAQCBAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private PropertyState<DeleteReferencesItem[]> m_referencesToDelete;

	public PropertyState<DeleteReferencesItem[]> ReferencesToDelete
	{
		get
		{
			return m_referencesToDelete;
		}
		set
		{
			if (m_referencesToDelete != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_referencesToDelete = value;
		}
	}

	public AuditDeleteReferencesEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2097u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJgAAAEF1ZGl0RGVsZXRlUmVmZXJlbmNlc0V2ZW50VHlwZUluc3RhbmNlAQAxCAEAMQgxCAAA/////w4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAKINAC4ARKINAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAKMNAC4ARKMNAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCkDQAuAESkDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEApQ0ALgBEpQ0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAKYNAC4ARKYNAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQCnDQAuAESnDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQCpDQAuAESpDQAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAKoNAC4ARKoNAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAKsNAC4ARKsNAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEArA0ALgBErA0AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQCtDQAuAEStDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQCuDQAuAESuDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQCvDQAuAESvDQAAAAz/////AQH/////AAAAABdgiQoCAAAAAAASAAAAUmVmZXJlbmNlc1RvRGVsZXRlAQAyCAAuAEQyCAAAAQCBAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		if (m_referencesToDelete != null)
		{
			children.Add(m_referencesToDelete);
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
		if (browseName.Name == "ReferencesToDelete")
		{
			if (createOrReplace && ReferencesToDelete == null)
			{
				if (replacement == null)
				{
					ReferencesToDelete = new PropertyState<DeleteReferencesItem[]>(this);
				}
				else
				{
					ReferencesToDelete = (PropertyState<DeleteReferencesItem[]>)replacement;
				}
			}
			baseInstanceState = ReferencesToDelete;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
