using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class IIeeeBaseEthernetPortState : BaseInterfaceState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIQAAAElJZWVlQmFzZUV0aGVybmV0UG9ydFR5cGVJbnN0YW5jZQEAXl4BAF5eXl4AAP////8DAAAAFWCJCgIAAAAAAAUAAABTcGVlZAEAX14ALwEAWURfXgAAAAn/////AQH/////AQAAABVgqQoCAAAAAAAQAAAARW5naW5lZXJpbmdVbml0cwEAZF4ALgBEZF4AABYBAHkDAWUAAAAvAAAAaHR0cDovL3d3dy5vcGNmb3VuZGF0aW9uLm9yZy9VQS91bml0cy91bi9jZWZhY3QwMkUAAwIAAABlbgYAAABNYml0L3MDAgAAAGVuEgAAAG1lZ2FiaXQgcGVyIHNlY29uZAEAdwP/////AQH/////AAAAABVgiQoCAAAAAAAGAAAARHVwbGV4AQBlXgAvAD9lXgAAAQCSXv////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABNYXhGcmFtZUxlbmd0aAEAZl4ALwA/Zl4AAAAF/////wEB/////wAAAAA=";

	private AnalogUnitState<ulong> m_speed;

	private BaseDataVariableState<Duplex> m_duplex;

	private BaseDataVariableState<ushort> m_maxFrameLength;

	public AnalogUnitState<ulong> Speed
	{
		get
		{
			return m_speed;
		}
		set
		{
			if (m_speed != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_speed = value;
		}
	}

	public BaseDataVariableState<Duplex> Duplex
	{
		get
		{
			return m_duplex;
		}
		set
		{
			if (m_duplex != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_duplex = value;
		}
	}

	public BaseDataVariableState<ushort> MaxFrameLength
	{
		get
		{
			return m_maxFrameLength;
		}
		set
		{
			if (m_maxFrameLength != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxFrameLength = value;
		}
	}

	public IIeeeBaseEthernetPortState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(24158u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIQAAAElJZWVlQmFzZUV0aGVybmV0UG9ydFR5cGVJbnN0YW5jZQEAXl4BAF5eXl4AAP////8DAAAAFWCJCgIAAAAAAAUAAABTcGVlZAEAX14ALwEAWURfXgAAAAn/////AQH/////AQAAABVgqQoCAAAAAAAQAAAARW5naW5lZXJpbmdVbml0cwEAZF4ALgBEZF4AABYBAHkDAWUAAAAvAAAAaHR0cDovL3d3dy5vcGNmb3VuZGF0aW9uLm9yZy9VQS91bml0cy91bi9jZWZhY3QwMkUAAwIAAABlbgYAAABNYml0L3MDAgAAAGVuEgAAAG1lZ2FiaXQgcGVyIHNlY29uZAEAdwP/////AQH/////AAAAABVgiQoCAAAAAAAGAAAARHVwbGV4AQBlXgAvAD9lXgAAAQCSXv////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABNYXhGcmFtZUxlbmd0aAEAZl4ALwA/Zl4AAAAF/////wEB/////wAAAAA=");
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
		if (m_speed != null)
		{
			children.Add(m_speed);
		}
		if (m_duplex != null)
		{
			children.Add(m_duplex);
		}
		if (m_maxFrameLength != null)
		{
			children.Add(m_maxFrameLength);
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
		switch (browseName.Name)
		{
		case "Speed":
			if (createOrReplace && Speed == null)
			{
				if (replacement == null)
				{
					Speed = new AnalogUnitState<ulong>(this);
				}
				else
				{
					Speed = (AnalogUnitState<ulong>)replacement;
				}
			}
			baseInstanceState = Speed;
			break;
		case "Duplex":
			if (createOrReplace && Duplex == null)
			{
				if (replacement == null)
				{
					Duplex = new BaseDataVariableState<Duplex>(this);
				}
				else
				{
					Duplex = (BaseDataVariableState<Duplex>)replacement;
				}
			}
			baseInstanceState = Duplex;
			break;
		case "MaxFrameLength":
			if (createOrReplace && MaxFrameLength == null)
			{
				if (replacement == null)
				{
					MaxFrameLength = new BaseDataVariableState<ushort>(this);
				}
				else
				{
					MaxFrameLength = (BaseDataVariableState<ushort>)replacement;
				}
			}
			baseInstanceState = MaxFrameLength;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
