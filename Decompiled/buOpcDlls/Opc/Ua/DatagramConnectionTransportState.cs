using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DatagramConnectionTransportState : ConnectionTransportState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAJwAAAERhdGFncmFtQ29ubmVjdGlvblRyYW5zcG9ydFR5cGVJbnN0YW5jZQEA2DoBANg62DoAAP////8BAAAABGCACgEAAAAAABAAAABEaXNjb3ZlcnlBZGRyZXNzAQDgOgAvAQCZUuA6AAD/////AQAAABVgiQoCAAAAAAAQAAAATmV0d29ya0ludGVyZmFjZQEAMjsALwEAtT8yOwAAAAz/////AQH/////AQAAABdgiQoCAAAAAAAKAAAAU2VsZWN0aW9ucwEAq0QALgBEq0QAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	private NetworkAddressState m_discoveryAddress;

	public NetworkAddressState DiscoveryAddress
	{
		get
		{
			return m_discoveryAddress;
		}
		set
		{
			if (m_discoveryAddress != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_discoveryAddress = value;
		}
	}

	public DatagramConnectionTransportState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(15064u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJwAAAERhdGFncmFtQ29ubmVjdGlvblRyYW5zcG9ydFR5cGVJbnN0YW5jZQEA2DoBANg62DoAAP////8BAAAABGCACgEAAAAAABAAAABEaXNjb3ZlcnlBZGRyZXNzAQDgOgAvAQCZUuA6AAD/////AQAAABVgiQoCAAAAAAAQAAAATmV0d29ya0ludGVyZmFjZQEAMjsALwEAtT8yOwAAAAz/////AQH/////AQAAABdgiQoCAAAAAAAKAAAAU2VsZWN0aW9ucwEAq0QALgBEq0QAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		if (m_discoveryAddress != null)
		{
			children.Add(m_discoveryAddress);
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
		if (browseName.Name == "DiscoveryAddress")
		{
			if (createOrReplace && DiscoveryAddress == null)
			{
				if (replacement == null)
				{
					DiscoveryAddress = new NetworkAddressState(this);
				}
				else
				{
					DiscoveryAddress = (NetworkAddressState)replacement;
				}
			}
			baseInstanceState = DiscoveryAddress;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
