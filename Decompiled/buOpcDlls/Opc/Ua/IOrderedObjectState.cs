using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class IOrderedObjectState : BaseInterfaceState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAGgAAAElPcmRlcmVkT2JqZWN0VHlwZUluc3RhbmNlAQDZWwEA2VvZWwAA/////wEAAAAVYIkKAgAAAAAADAAAAE51bWJlckluTGlzdAEA3VsALgBE3VsAAAAa/////wEB/////wAAAAA=";

	private PropertyState m_numberInList;

	public PropertyState NumberInList
	{
		get
		{
			return m_numberInList;
		}
		set
		{
			if (m_numberInList != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_numberInList = value;
		}
	}

	public IOrderedObjectState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(23513u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAGgAAAElPcmRlcmVkT2JqZWN0VHlwZUluc3RhbmNlAQDZWwEA2VvZWwAA/////wEAAAAVYIkKAgAAAAAADAAAAE51bWJlckluTGlzdAEA3VsALgBE3VsAAAAa/////wEB/////wAAAAA=");
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
		if (m_numberInList != null)
		{
			children.Add(m_numberInList);
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
		if (browseName.Name == "NumberInList")
		{
			if (createOrReplace && NumberInList == null)
			{
				if (replacement == null)
				{
					NumberInList = new PropertyState(this);
				}
				else
				{
					NumberInList = (PropertyState)replacement;
				}
			}
			baseInstanceState = NumberInList;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
