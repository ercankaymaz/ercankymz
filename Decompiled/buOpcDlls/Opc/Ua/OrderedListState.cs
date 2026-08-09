using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class OrderedListState : BaseObjectState
{
	private const string NodeVersion_InitializationString = "//////////8VYIkKAgAAAAAACwAAAE5vZGVWZXJzaW9uAQDlWwAuAETlWwAAAAz/////AQH/////AAAAAA==";

	private const string InitializationString = "//////////8EYIACAQAAAAAAFwAAAE9yZGVyZWRMaXN0VHlwZUluc3RhbmNlAQDeWwEA3lveWwAAAQAAAAApAAEAVQgBAAAAFWCJCgIAAAAAAAsAAABOb2RlVmVyc2lvbgEA5VsALgBE5VsAAAAM/////wEB/////wAAAAA=";

	private PropertyState<string> m_nodeVersion;

	public PropertyState<string> NodeVersion
	{
		get
		{
			return m_nodeVersion;
		}
		set
		{
			if (m_nodeVersion != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_nodeVersion = value;
		}
	}

	public OrderedListState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(23518u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAFwAAAE9yZGVyZWRMaXN0VHlwZUluc3RhbmNlAQDeWwEA3lveWwAAAQAAAAApAAEAVQgBAAAAFWCJCgIAAAAAAAsAAABOb2RlVmVyc2lvbgEA5VsALgBE5VsAAAAM/////wEB/////wAAAAA=");
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
		if (NodeVersion != null)
		{
			NodeVersion.Initialize(context, "//////////8VYIkKAgAAAAAACwAAAE5vZGVWZXJzaW9uAQDlWwAuAETlWwAAAAz/////AQH/////AAAAAA==");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_nodeVersion != null)
		{
			children.Add(m_nodeVersion);
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
		if (browseName.Name == "NodeVersion")
		{
			if (createOrReplace && NodeVersion == null)
			{
				if (replacement == null)
				{
					NodeVersion = new PropertyState<string>(this);
				}
				else
				{
					NodeVersion = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = NodeVersion;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
