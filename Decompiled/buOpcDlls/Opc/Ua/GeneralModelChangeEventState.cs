using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class GeneralModelChangeEventState : BaseModelChangeEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIwAAAEdlbmVyYWxNb2RlbENoYW5nZUV2ZW50VHlwZUluc3RhbmNlAQBVCAEAVQhVCAAA/////wkAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAGAOAC4ARGAOAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAGEOAC4ARGEOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQBiDgAuAERiDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAYw4ALgBEYw4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAGQOAC4ARGQOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQBlDgAuAERlDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQBnDgAuAERnDgAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAGgOAC4ARGgOAAAABf////8BAf////8AAAAAF2CJCgIAAAAAAAcAAABDaGFuZ2VzAQBWCAAuAERWCAAAAQBtAwEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private PropertyState<ModelChangeStructureDataType[]> m_changes;

	public PropertyState<ModelChangeStructureDataType[]> Changes
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

	public GeneralModelChangeEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2133u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIwAAAEdlbmVyYWxNb2RlbENoYW5nZUV2ZW50VHlwZUluc3RhbmNlAQBVCAEAVQhVCAAA/////wkAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAGAOAC4ARGAOAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAGEOAC4ARGEOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQBiDgAuAERiDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAYw4ALgBEYw4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAGQOAC4ARGQOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQBlDgAuAERlDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQBnDgAuAERnDgAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAGgOAC4ARGgOAAAABf////8BAf////8AAAAAF2CJCgIAAAAAAAcAAABDaGFuZ2VzAQBWCAAuAERWCAAAAQBtAwEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
					Changes = new PropertyState<ModelChangeStructureDataType[]>(this);
				}
				else
				{
					Changes = (PropertyState<ModelChangeStructureDataType[]>)replacement;
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
