using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ServerRedundancyState : BaseObjectState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAHAAAAFNlcnZlclJlZHVuZGFuY3lUeXBlSW5zdGFuY2UBAPIHAQDyB/IHAAD/////AQAAABVgiQoCAAAAAAARAAAAUmVkdW5kYW5jeVN1cHBvcnQBAPMHAC4ARPMHAAABAFMD/////wEB/////wAAAAA=";

	private PropertyState<RedundancySupport> m_redundancySupport;

	public PropertyState<RedundancySupport> RedundancySupport
	{
		get
		{
			return m_redundancySupport;
		}
		set
		{
			if (m_redundancySupport != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_redundancySupport = value;
		}
	}

	public ServerRedundancyState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2034u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHAAAAFNlcnZlclJlZHVuZGFuY3lUeXBlSW5zdGFuY2UBAPIHAQDyB/IHAAD/////AQAAABVgiQoCAAAAAAARAAAAUmVkdW5kYW5jeVN1cHBvcnQBAPMHAC4ARPMHAAABAFMD/////wEB/////wAAAAA=");
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
		if (m_redundancySupport != null)
		{
			children.Add(m_redundancySupport);
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
		if (browseName.Name == "RedundancySupport")
		{
			if (createOrReplace && RedundancySupport == null)
			{
				if (replacement == null)
				{
					RedundancySupport = new PropertyState<RedundancySupport>(this);
				}
				else
				{
					RedundancySupport = (PropertyState<RedundancySupport>)replacement;
				}
			}
			baseInstanceState = RedundancySupport;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
