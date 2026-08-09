using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DatagramWriterGroupTransportState : WriterGroupTransportState
{
	private const string MessageRepeatCount_InitializationString = "//////////8VYIkKAgAAAAAAEgAAAE1lc3NhZ2VSZXBlYXRDb3VudAEAjlIALgBEjlIAAAAD/////wEB/////wAAAAA=";

	private const string MessageRepeatDelay_InitializationString = "//////////8VYIkKAgAAAAAAEgAAAE1lc3NhZ2VSZXBlYXREZWxheQEAj1IALgBEj1IAAAEAIgH/////AQH/////AAAAAA==";

	private const string InitializationString = "//////////8EYIACAQAAAAAAKAAAAERhdGFncmFtV3JpdGVyR3JvdXBUcmFuc3BvcnRUeXBlSW5zdGFuY2UBAI1SAQCNUo1SAAD/////AgAAABVgiQoCAAAAAAASAAAATWVzc2FnZVJlcGVhdENvdW50AQCOUgAuAESOUgAAAAP/////AQH/////AAAAABVgiQoCAAAAAAASAAAATWVzc2FnZVJlcGVhdERlbGF5AQCPUgAuAESPUgAAAQAiAf////8BAf////8AAAAA";

	private PropertyState<byte> m_messageRepeatCount;

	private PropertyState<double> m_messageRepeatDelay;

	public PropertyState<byte> MessageRepeatCount
	{
		get
		{
			return m_messageRepeatCount;
		}
		set
		{
			if (m_messageRepeatCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_messageRepeatCount = value;
		}
	}

	public PropertyState<double> MessageRepeatDelay
	{
		get
		{
			return m_messageRepeatDelay;
		}
		set
		{
			if (m_messageRepeatDelay != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_messageRepeatDelay = value;
		}
	}

	public DatagramWriterGroupTransportState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(21133u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAKAAAAERhdGFncmFtV3JpdGVyR3JvdXBUcmFuc3BvcnRUeXBlSW5zdGFuY2UBAI1SAQCNUo1SAAD/////AgAAABVgiQoCAAAAAAASAAAATWVzc2FnZVJlcGVhdENvdW50AQCOUgAuAESOUgAAAAP/////AQH/////AAAAABVgiQoCAAAAAAASAAAATWVzc2FnZVJlcGVhdERlbGF5AQCPUgAuAESPUgAAAQAiAf////8BAf////8AAAAA");
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
		if (MessageRepeatCount != null)
		{
			MessageRepeatCount.Initialize(context, "//////////8VYIkKAgAAAAAAEgAAAE1lc3NhZ2VSZXBlYXRDb3VudAEAjlIALgBEjlIAAAAD/////wEB/////wAAAAA=");
		}
		if (MessageRepeatDelay != null)
		{
			MessageRepeatDelay.Initialize(context, "//////////8VYIkKAgAAAAAAEgAAAE1lc3NhZ2VSZXBlYXREZWxheQEAj1IALgBEj1IAAAEAIgH/////AQH/////AAAAAA==");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_messageRepeatCount != null)
		{
			children.Add(m_messageRepeatCount);
		}
		if (m_messageRepeatDelay != null)
		{
			children.Add(m_messageRepeatDelay);
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
		if (!(name == "MessageRepeatCount"))
		{
			if (name == "MessageRepeatDelay")
			{
				if (createOrReplace && MessageRepeatDelay == null)
				{
					if (replacement == null)
					{
						MessageRepeatDelay = new PropertyState<double>(this);
					}
					else
					{
						MessageRepeatDelay = (PropertyState<double>)replacement;
					}
				}
				baseInstanceState = MessageRepeatDelay;
			}
		}
		else
		{
			if (createOrReplace && MessageRepeatCount == null)
			{
				if (replacement == null)
				{
					MessageRepeatCount = new PropertyState<byte>(this);
				}
				else
				{
					MessageRepeatCount = (PropertyState<byte>)replacement;
				}
			}
			baseInstanceState = MessageRepeatCount;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
