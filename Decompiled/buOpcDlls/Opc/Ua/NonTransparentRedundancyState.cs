using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class NonTransparentRedundancyState : ServerRedundancyState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAJAAAAE5vblRyYW5zcGFyZW50UmVkdW5kYW5jeVR5cGVJbnN0YW5jZQEA9wcBAPcH9wcAAP////8CAAAAFWCJCgIAAAAAABEAAABSZWR1bmRhbmN5U3VwcG9ydAEAdQwALgBEdQwAAAEAUwP/////AQH/////AAAAABdgiQoCAAAAAAAOAAAAU2VydmVyVXJpQXJyYXkBAPgHAC4ARPgHAAAADAEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private PropertyState<string[]> m_serverUriArray;

	public PropertyState<string[]> ServerUriArray
	{
		get
		{
			return m_serverUriArray;
		}
		set
		{
			if (m_serverUriArray != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_serverUriArray = value;
		}
	}

	public NonTransparentRedundancyState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2039u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJAAAAE5vblRyYW5zcGFyZW50UmVkdW5kYW5jeVR5cGVJbnN0YW5jZQEA9wcBAPcH9wcAAP////8CAAAAFWCJCgIAAAAAABEAAABSZWR1bmRhbmN5U3VwcG9ydAEAdQwALgBEdQwAAAEAUwP/////AQH/////AAAAABdgiQoCAAAAAAAOAAAAU2VydmVyVXJpQXJyYXkBAPgHAC4ARPgHAAAADAEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		if (m_serverUriArray != null)
		{
			children.Add(m_serverUriArray);
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
		if (browseName.Name == "ServerUriArray")
		{
			if (createOrReplace && ServerUriArray == null)
			{
				if (replacement == null)
				{
					ServerUriArray = new PropertyState<string[]>(this);
				}
				else
				{
					ServerUriArray = (PropertyState<string[]>)replacement;
				}
			}
			baseInstanceState = ServerUriArray;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
