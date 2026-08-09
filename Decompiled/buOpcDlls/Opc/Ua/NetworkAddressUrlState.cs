using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class NetworkAddressUrlState : NetworkAddressState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAHQAAAE5ldHdvcmtBZGRyZXNzVXJsVHlwZUluc3RhbmNlAQCbUgEAm1KbUgAA/////wIAAAAVYIkKAgAAAAAAEAAAAE5ldHdvcmtJbnRlcmZhY2UBAJxSAC8BALU/nFIAAAAM/////wEB/////wEAAAAXYIkKAgAAAAAACgAAAFNlbGVjdGlvbnMBALFEAC4ARLFEAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAAAwAAAFVybAEAnVIALwA/nVIAAAAM/////wEB/////wAAAAA=";

	private BaseDataVariableState<string> m_url;

	public BaseDataVariableState<string> Url
	{
		get
		{
			return m_url;
		}
		set
		{
			if (m_url != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_url = value;
		}
	}

	public NetworkAddressUrlState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(21147u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHQAAAE5ldHdvcmtBZGRyZXNzVXJsVHlwZUluc3RhbmNlAQCbUgEAm1KbUgAA/////wIAAAAVYIkKAgAAAAAAEAAAAE5ldHdvcmtJbnRlcmZhY2UBAJxSAC8BALU/nFIAAAAM/////wEB/////wEAAAAXYIkKAgAAAAAACgAAAFNlbGVjdGlvbnMBALFEAC4ARLFEAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAAAwAAAFVybAEAnVIALwA/nVIAAAAM/////wEB/////wAAAAA=");
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
		if (m_url != null)
		{
			children.Add(m_url);
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
		if (browseName.Name == "Url")
		{
			if (createOrReplace && Url == null)
			{
				if (replacement == null)
				{
					Url = new BaseDataVariableState<string>(this);
				}
				else
				{
					Url = (BaseDataVariableState<string>)replacement;
				}
			}
			baseInstanceState = Url;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
