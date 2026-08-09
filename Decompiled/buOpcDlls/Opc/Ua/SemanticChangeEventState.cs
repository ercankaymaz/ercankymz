using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SemanticChangeEventState : BaseEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAHwAAAFNlbWFudGljQ2hhbmdlRXZlbnRUeXBlSW5zdGFuY2UBALIKAQCyCrIKAAD/////CQAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAaQ4ALgBEaQ4AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAag4ALgBEag4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAGsOAC4ARGsOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQBsDgAuAERsDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAbQ4ALgBEbQ4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAG4OAC4ARG4OAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAHAOAC4ARHAOAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAcQ4ALgBEcQ4AAAAF/////wEB/////wAAAAAXYIkKAgAAAAAABwAAAENoYW5nZXMBALMKAC4ARLMKAAABAIEDAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	private PropertyState<SemanticChangeStructureDataType[]> m_changes;

	public PropertyState<SemanticChangeStructureDataType[]> Changes
	{
		get
		{
			return m_changes;
		}
		set
		{
			if (m_changes != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_changes = value;
		}
	}

	public SemanticChangeEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2738u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHwAAAFNlbWFudGljQ2hhbmdlRXZlbnRUeXBlSW5zdGFuY2UBALIKAQCyCrIKAAD/////CQAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAaQ4ALgBEaQ4AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAag4ALgBEag4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAGsOAC4ARGsOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQBsDgAuAERsDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAbQ4ALgBEbQ4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAG4OAC4ARG4OAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAHAOAC4ARHAOAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAcQ4ALgBEcQ4AAAAF/////wEB/////wAAAAAXYIkKAgAAAAAABwAAAENoYW5nZXMBALMKAC4ARLMKAAABAIEDAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		if (m_changes != null)
		{
			children.Add(m_changes);
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
		if (browseName.Name == "Changes")
		{
			if (createOrReplace && Changes == null)
			{
				if (replacement == null)
				{
					Changes = new PropertyState<SemanticChangeStructureDataType[]>(this);
				}
				else
				{
					Changes = (PropertyState<SemanticChangeStructureDataType[]>)replacement;
				}
			}
			baseInstanceState = Changes;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
