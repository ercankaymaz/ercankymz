using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditUpdateStateEventState : AuditUpdateMethodEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIQAAAEF1ZGl0VXBkYXRlU3RhdGVFdmVudFR5cGVJbnN0YW5jZQEACwkBAAsJCwkAAP////8RAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQCuDgAuAESuDgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCvDgAuAESvDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAsA4ALgBEsA4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBALEOAC4ARLEOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCyDgAuAESyDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAsw4ALgBEsw4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAtQ4ALgBEtQ4AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQC2DgAuAES2DgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQC3DgAuAES3DgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBALgOAC4ARLgOAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAuQ4ALgBEuQ4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAug4ALgBEug4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAuw4ALgBEuw4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAE1ldGhvZElkAQC8DgAuAES8DgAAABH/////AQH/////AAAAABdgiQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAL0OAC4ARL0OAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACgAAAE9sZFN0YXRlSWQBANkKAC4ARNkKAAAAGP////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABOZXdTdGF0ZUlkAQDaCgAuAETaCgAAABj/////AQH/////AAAAAA==";

	private PropertyState m_oldStateId;

	private PropertyState m_newStateId;

	public PropertyState OldStateId
	{
		get
		{
			return m_oldStateId;
		}
		set
		{
			if (m_oldStateId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_oldStateId = value;
		}
	}

	public PropertyState NewStateId
	{
		get
		{
			return m_newStateId;
		}
		set
		{
			if (m_newStateId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_newStateId = value;
		}
	}

	public AuditUpdateStateEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2315u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIQAAAEF1ZGl0VXBkYXRlU3RhdGVFdmVudFR5cGVJbnN0YW5jZQEACwkBAAsJCwkAAP////8RAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQCuDgAuAESuDgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCvDgAuAESvDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAsA4ALgBEsA4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBALEOAC4ARLEOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCyDgAuAESyDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAsw4ALgBEsw4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAtQ4ALgBEtQ4AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQC2DgAuAES2DgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQC3DgAuAES3DgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBALgOAC4ARLgOAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAuQ4ALgBEuQ4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAug4ALgBEug4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAuw4ALgBEuw4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAE1ldGhvZElkAQC8DgAuAES8DgAAABH/////AQH/////AAAAABdgiQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAL0OAC4ARL0OAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACgAAAE9sZFN0YXRlSWQBANkKAC4ARNkKAAAAGP////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABOZXdTdGF0ZUlkAQDaCgAuAETaCgAAABj/////AQH/////AAAAAA==");
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
		if (m_oldStateId != null)
		{
			children.Add(m_oldStateId);
		}
		if (m_newStateId != null)
		{
			children.Add(m_newStateId);
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
		if (!(name == "OldStateId"))
		{
			if (name == "NewStateId")
			{
				if (createOrReplace && NewStateId == null)
				{
					if (replacement == null)
					{
						NewStateId = new PropertyState(this);
					}
					else
					{
						NewStateId = (PropertyState)replacement;
					}
				}
				baseInstanceState = NewStateId;
			}
		}
		else
		{
			if (createOrReplace && OldStateId == null)
			{
				if (replacement == null)
				{
					OldStateId = new PropertyState(this);
				}
				else
				{
					OldStateId = (PropertyState)replacement;
				}
			}
			baseInstanceState = OldStateId;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
