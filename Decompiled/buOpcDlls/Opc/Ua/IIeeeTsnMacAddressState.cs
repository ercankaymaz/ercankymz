using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class IIeeeTsnMacAddressState : BaseInterfaceState
{
	private const string SourceAddress_InitializationString = "//////////8XYIkKAgAAAAAADQAAAFNvdXJjZUFkZHJlc3MBAIleAC8AP4leAAAAAwEAAAABAAAABgAAAAEB/////wAAAAA=";

	private const string InitializationString = "//////////8EYIACAQAAAAAAHgAAAElJZWVlVHNuTWFjQWRkcmVzc1R5cGVJbnN0YW5jZQEAh14BAIdeh14AAP////8CAAAAF2CJCgIAAAAAABIAAABEZXN0aW5hdGlvbkFkZHJlc3MBAIheAC8AP4heAAAAAwEAAAABAAAABgAAAAEB/////wAAAAAXYIkKAgAAAAAADQAAAFNvdXJjZUFkZHJlc3MBAIleAC8AP4leAAAAAwEAAAABAAAABgAAAAEB/////wAAAAA=";

	private BaseDataVariableState<byte[]> m_destinationAddress;

	private BaseDataVariableState<byte[]> m_sourceAddress;

	public BaseDataVariableState<byte[]> DestinationAddress
	{
		get
		{
			return m_destinationAddress;
		}
		set
		{
			if (m_destinationAddress != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_destinationAddress = value;
		}
	}

	public BaseDataVariableState<byte[]> SourceAddress
	{
		get
		{
			return m_sourceAddress;
		}
		set
		{
			if (m_sourceAddress != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_sourceAddress = value;
		}
	}

	public IIeeeTsnMacAddressState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(24199u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHgAAAElJZWVlVHNuTWFjQWRkcmVzc1R5cGVJbnN0YW5jZQEAh14BAIdeh14AAP////8CAAAAF2CJCgIAAAAAABIAAABEZXN0aW5hdGlvbkFkZHJlc3MBAIheAC8AP4heAAAAAwEAAAABAAAABgAAAAEB/////wAAAAAXYIkKAgAAAAAADQAAAFNvdXJjZUFkZHJlc3MBAIleAC8AP4leAAAAAwEAAAABAAAABgAAAAEB/////wAAAAA=");
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
		if (SourceAddress != null)
		{
			SourceAddress.Initialize(context, "//////////8XYIkKAgAAAAAADQAAAFNvdXJjZUFkZHJlc3MBAIleAC8AP4leAAAAAwEAAAABAAAABgAAAAEB/////wAAAAA=");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_destinationAddress != null)
		{
			children.Add(m_destinationAddress);
		}
		if (m_sourceAddress != null)
		{
			children.Add(m_sourceAddress);
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
		if (!(name == "DestinationAddress"))
		{
			if (name == "SourceAddress")
			{
				if (createOrReplace && SourceAddress == null)
				{
					if (replacement == null)
					{
						SourceAddress = new BaseDataVariableState<byte[]>(this);
					}
					else
					{
						SourceAddress = (BaseDataVariableState<byte[]>)replacement;
					}
				}
				baseInstanceState = SourceAddress;
			}
		}
		else
		{
			if (createOrReplace && DestinationAddress == null)
			{
				if (replacement == null)
				{
					DestinationAddress = new BaseDataVariableState<byte[]>(this);
				}
				else
				{
					DestinationAddress = (BaseDataVariableState<byte[]>)replacement;
				}
			}
			baseInstanceState = DestinationAddress;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
