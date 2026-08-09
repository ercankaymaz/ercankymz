using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class TransparentRedundancyState : ServerRedundancyState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIQAAAFRyYW5zcGFyZW50UmVkdW5kYW5jeVR5cGVJbnN0YW5jZQEA9AcBAPQH9AcAAP////8DAAAAFWCJCgIAAAAAABEAAABSZWR1bmRhbmN5U3VwcG9ydAEAdAwALgBEdAwAAAEAUwP/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQ3VycmVudFNlcnZlcklkAQD1BwAuAET1BwAAAAz/////AQH/////AAAAABdgiQoCAAAAAAAUAAAAUmVkdW5kYW50U2VydmVyQXJyYXkBAPYHAC4ARPYHAAABAFUDAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	private PropertyState<string> m_currentServerId;

	private PropertyState<RedundantServerDataType[]> m_redundantServerArray;

	public PropertyState<string> CurrentServerId
	{
		get
		{
			return m_currentServerId;
		}
		set
		{
			if (m_currentServerId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_currentServerId = value;
		}
	}

	public PropertyState<RedundantServerDataType[]> RedundantServerArray
	{
		get
		{
			return m_redundantServerArray;
		}
		set
		{
			if (m_redundantServerArray != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_redundantServerArray = value;
		}
	}

	public TransparentRedundancyState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2036u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIQAAAFRyYW5zcGFyZW50UmVkdW5kYW5jeVR5cGVJbnN0YW5jZQEA9AcBAPQH9AcAAP////8DAAAAFWCJCgIAAAAAABEAAABSZWR1bmRhbmN5U3VwcG9ydAEAdAwALgBEdAwAAAEAUwP/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQ3VycmVudFNlcnZlcklkAQD1BwAuAET1BwAAAAz/////AQH/////AAAAABdgiQoCAAAAAAAUAAAAUmVkdW5kYW50U2VydmVyQXJyYXkBAPYHAC4ARPYHAAABAFUDAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		if (m_currentServerId != null)
		{
			children.Add(m_currentServerId);
		}
		if (m_redundantServerArray != null)
		{
			children.Add(m_redundantServerArray);
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
		if (!(name == "CurrentServerId"))
		{
			if (name == "RedundantServerArray")
			{
				if (createOrReplace && RedundantServerArray == null)
				{
					if (replacement == null)
					{
						RedundantServerArray = new PropertyState<RedundantServerDataType[]>(this);
					}
					else
					{
						RedundantServerArray = (PropertyState<RedundantServerDataType[]>)replacement;
					}
				}
				baseInstanceState = RedundantServerArray;
			}
		}
		else
		{
			if (createOrReplace && CurrentServerId == null)
			{
				if (replacement == null)
				{
					CurrentServerId = new PropertyState<string>(this);
				}
				else
				{
					CurrentServerId = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = CurrentServerId;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
