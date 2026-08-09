using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class JsonWriterGroupMessageState : WriterGroupMessageState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIgAAAEpzb25Xcml0ZXJHcm91cE1lc3NhZ2VUeXBlSW5zdGFuY2UBAIZSAQCGUoZSAAD/////AQAAABVgiQoCAAAAAAAZAAAATmV0d29ya01lc3NhZ2VDb250ZW50TWFzawEAh1IALgBEh1IAAAEAJj3/////AQH/////AAAAAA==";

	private PropertyState<uint> m_networkMessageContentMask;

	public PropertyState<uint> NetworkMessageContentMask
	{
		get
		{
			return m_networkMessageContentMask;
		}
		set
		{
			if (m_networkMessageContentMask != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_networkMessageContentMask = value;
		}
	}

	public JsonWriterGroupMessageState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(21126u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIgAAAEpzb25Xcml0ZXJHcm91cE1lc3NhZ2VUeXBlSW5zdGFuY2UBAIZSAQCGUoZSAAD/////AQAAABVgiQoCAAAAAAAZAAAATmV0d29ya01lc3NhZ2VDb250ZW50TWFzawEAh1IALgBEh1IAAAEAJj3/////AQH/////AAAAAA==");
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
		if (m_networkMessageContentMask != null)
		{
			children.Add(m_networkMessageContentMask);
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
		if (browseName.Name == "NetworkMessageContentMask")
		{
			if (createOrReplace && NetworkMessageContentMask == null)
			{
				if (replacement == null)
				{
					NetworkMessageContentMask = new PropertyState<uint>(this);
				}
				else
				{
					NetworkMessageContentMask = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = NetworkMessageContentMask;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
