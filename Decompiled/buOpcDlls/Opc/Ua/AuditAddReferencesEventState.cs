using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditAddReferencesEventState : AuditNodeManagementEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIwAAAEF1ZGl0QWRkUmVmZXJlbmNlc0V2ZW50VHlwZUluc3RhbmNlAQAvCAEALwgvCAAA/////w4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAJQNAC4ARJQNAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAJUNAC4ARJUNAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCWDQAuAESWDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAlw0ALgBElw0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAJgNAC4ARJgNAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQCZDQAuAESZDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQCbDQAuAESbDQAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAJwNAC4ARJwNAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAJ0NAC4ARJ0NAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAng0ALgBEng0AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQCfDQAuAESfDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQCgDQAuAESgDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQChDQAuAEShDQAAAAz/////AQH/////AAAAABdgiQoCAAAAAAAPAAAAUmVmZXJlbmNlc1RvQWRkAQAwCAAuAEQwCAAAAQB7AQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private PropertyState<AddReferencesItem[]> m_referencesToAdd;

	public PropertyState<AddReferencesItem[]> ReferencesToAdd
	{
		get
		{
			return m_referencesToAdd;
		}
		set
		{
			if (m_referencesToAdd != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_referencesToAdd = value;
		}
	}

	public AuditAddReferencesEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2095u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIwAAAEF1ZGl0QWRkUmVmZXJlbmNlc0V2ZW50VHlwZUluc3RhbmNlAQAvCAEALwgvCAAA/////w4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAJQNAC4ARJQNAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAJUNAC4ARJUNAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCWDQAuAESWDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAlw0ALgBElw0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAJgNAC4ARJgNAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQCZDQAuAESZDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQCbDQAuAESbDQAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAJwNAC4ARJwNAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAJ0NAC4ARJ0NAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAng0ALgBEng0AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQCfDQAuAESfDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQCgDQAuAESgDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQChDQAuAEShDQAAAAz/////AQH/////AAAAABdgiQoCAAAAAAAPAAAAUmVmZXJlbmNlc1RvQWRkAQAwCAAuAEQwCAAAAQB7AQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		if (m_referencesToAdd != null)
		{
			children.Add(m_referencesToAdd);
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
		if (browseName.Name == "ReferencesToAdd")
		{
			if (createOrReplace && ReferencesToAdd == null)
			{
				if (replacement == null)
				{
					ReferencesToAdd = new PropertyState<AddReferencesItem[]>(this);
				}
				else
				{
					ReferencesToAdd = (PropertyState<AddReferencesItem[]>)replacement;
				}
			}
			baseInstanceState = ReferencesToAdd;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
