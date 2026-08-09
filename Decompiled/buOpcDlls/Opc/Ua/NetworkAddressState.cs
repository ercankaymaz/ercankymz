using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class NetworkAddressState : BaseObjectState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAGgAAAE5ldHdvcmtBZGRyZXNzVHlwZUluc3RhbmNlAQCZUgEAmVKZUgAA/////wEAAAAVYIkKAgAAAAAAEAAAAE5ldHdvcmtJbnRlcmZhY2UBAJpSAC8BALU/mlIAAAAM/////wEB/////wEAAAAXYIkKAgAAAAAACgAAAFNlbGVjdGlvbnMBAK5EAC4ARK5EAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private SelectionListState<string> m_networkInterface;

	public SelectionListState<string> NetworkInterface
	{
		get
		{
			return m_networkInterface;
		}
		set
		{
			if (m_networkInterface != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_networkInterface = value;
		}
	}

	public NetworkAddressState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(21145u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAGgAAAE5ldHdvcmtBZGRyZXNzVHlwZUluc3RhbmNlAQCZUgEAmVKZUgAA/////wEAAAAVYIkKAgAAAAAAEAAAAE5ldHdvcmtJbnRlcmZhY2UBAJpSAC8BALU/mlIAAAAM/////wEB/////wEAAAAXYIkKAgAAAAAACgAAAFNlbGVjdGlvbnMBAK5EAC4ARK5EAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		if (m_networkInterface != null)
		{
			children.Add(m_networkInterface);
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
		if (browseName.Name == "NetworkInterface")
		{
			if (createOrReplace && NetworkInterface == null)
			{
				if (replacement == null)
				{
					NetworkInterface = new SelectionListState<string>(this);
				}
				else
				{
					NetworkInterface = (SelectionListState<string>)replacement;
				}
			}
			baseInstanceState = NetworkInterface;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
