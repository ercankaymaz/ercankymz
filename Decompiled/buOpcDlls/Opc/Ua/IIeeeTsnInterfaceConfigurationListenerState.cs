using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class IIeeeTsnInterfaceConfigurationListenerState : IIeeeTsnInterfaceConfigurationState
{
	private const string ReceiveOffset_InitializationString = "//////////8VYIkKAgAAAAAADQAAAFJlY2VpdmVPZmZzZXQBAIZeAC8AP4ZeAAAAB/////8BAf////8AAAAA";

	private const string InitializationString = "//////////8EYIACAQAAAAAAMgAAAElJZWVlVHNuSW50ZXJmYWNlQ29uZmlndXJhdGlvbkxpc3RlbmVyVHlwZUluc3RhbmNlAQCDXgEAg16DXgAA/////wIAAAAVYIkKAgAAAAAACgAAAE1hY0FkZHJlc3MBAIReAC8AP4ReAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABSZWNlaXZlT2Zmc2V0AQCGXgAvAD+GXgAAAAf/////AQH/////AAAAAA==";

	private BaseDataVariableState<uint> m_receiveOffset;

	public BaseDataVariableState<uint> ReceiveOffset
	{
		get
		{
			return m_receiveOffset;
		}
		set
		{
			if (m_receiveOffset != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_receiveOffset = value;
		}
	}

	public IIeeeTsnInterfaceConfigurationListenerState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(24195u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAMgAAAElJZWVlVHNuSW50ZXJmYWNlQ29uZmlndXJhdGlvbkxpc3RlbmVyVHlwZUluc3RhbmNlAQCDXgEAg16DXgAA/////wIAAAAVYIkKAgAAAAAACgAAAE1hY0FkZHJlc3MBAIReAC8AP4ReAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABSZWNlaXZlT2Zmc2V0AQCGXgAvAD+GXgAAAAf/////AQH/////AAAAAA==");
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
		if (ReceiveOffset != null)
		{
			ReceiveOffset.Initialize(context, "//////////8VYIkKAgAAAAAADQAAAFJlY2VpdmVPZmZzZXQBAIZeAC8AP4ZeAAAAB/////8BAf////8AAAAA");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_receiveOffset != null)
		{
			children.Add(m_receiveOffset);
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
		if (browseName.Name == "ReceiveOffset")
		{
			if (createOrReplace && ReceiveOffset == null)
			{
				if (replacement == null)
				{
					ReceiveOffset = new BaseDataVariableState<uint>(this);
				}
				else
				{
					ReceiveOffset = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = ReceiveOffset;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
