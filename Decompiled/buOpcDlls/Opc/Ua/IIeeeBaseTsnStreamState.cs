using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class IIeeeBaseTsnStreamState : BaseInterfaceState
{
	private const string AccumulatedLatency_InitializationString = "//////////8VYIkKAgAAAAAAEgAAAEFjY3VtdWxhdGVkTGF0ZW5jeQEAcV4ALwA/cV4AAAAH/////wEB/////wAAAAA=";

	private const string SrClassId_InitializationString = "//////////8VYIkKAgAAAAAACQAAAFNyQ2xhc3NJZAEAcl4ALwA/cl4AAAAD/////wEB/////wAAAAA=";

	private const string InitializationString = "//////////8EYIACAQAAAAAAHgAAAElJZWVlQmFzZVRzblN0cmVhbVR5cGVJbnN0YW5jZQEAbV4BAG1ebV4AAP////8FAAAAF2CJCgIAAAAAAAgAAABTdHJlYW1JZAEAbl4ALwA/bl4AAAADAQAAAAEAAAAIAAAAAQH/////AAAAABVgiQoCAAAAAAAKAAAAU3RyZWFtTmFtZQEAb14ALwA/b14AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABQAAAFN0YXRlAQBwXgAvAD9wXgAAAQCcXv////8BAf////8AAAAAFWCJCgIAAAAAABIAAABBY2N1bXVsYXRlZExhdGVuY3kBAHFeAC8AP3FeAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABTckNsYXNzSWQBAHJeAC8AP3JeAAAAA/////8BAf////8AAAAA";

	private BaseDataVariableState<byte[]> m_streamId;

	private BaseDataVariableState<string> m_streamName;

	private BaseDataVariableState<TsnStreamState> m_state;

	private BaseDataVariableState<uint> m_accumulatedLatency;

	private BaseDataVariableState<byte> m_srClassId;

	public BaseDataVariableState<byte[]> StreamId
	{
		get
		{
			return m_streamId;
		}
		set
		{
			if (m_streamId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_streamId = value;
		}
	}

	public BaseDataVariableState<string> StreamName
	{
		get
		{
			return m_streamName;
		}
		set
		{
			if (m_streamName != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_streamName = value;
		}
	}

	public BaseDataVariableState<TsnStreamState> State
	{
		get
		{
			return m_state;
		}
		set
		{
			if (m_state != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_state = value;
		}
	}

	public BaseDataVariableState<uint> AccumulatedLatency
	{
		get
		{
			return m_accumulatedLatency;
		}
		set
		{
			if (m_accumulatedLatency != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_accumulatedLatency = value;
		}
	}

	public BaseDataVariableState<byte> SrClassId
	{
		get
		{
			return m_srClassId;
		}
		set
		{
			if (m_srClassId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_srClassId = value;
		}
	}

	public IIeeeBaseTsnStreamState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(24173u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHgAAAElJZWVlQmFzZVRzblN0cmVhbVR5cGVJbnN0YW5jZQEAbV4BAG1ebV4AAP////8FAAAAF2CJCgIAAAAAAAgAAABTdHJlYW1JZAEAbl4ALwA/bl4AAAADAQAAAAEAAAAIAAAAAQH/////AAAAABVgiQoCAAAAAAAKAAAAU3RyZWFtTmFtZQEAb14ALwA/b14AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABQAAAFN0YXRlAQBwXgAvAD9wXgAAAQCcXv////8BAf////8AAAAAFWCJCgIAAAAAABIAAABBY2N1bXVsYXRlZExhdGVuY3kBAHFeAC8AP3FeAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABTckNsYXNzSWQBAHJeAC8AP3JeAAAAA/////8BAf////8AAAAA");
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
		if (AccumulatedLatency != null)
		{
			AccumulatedLatency.Initialize(context, "//////////8VYIkKAgAAAAAAEgAAAEFjY3VtdWxhdGVkTGF0ZW5jeQEAcV4ALwA/cV4AAAAH/////wEB/////wAAAAA=");
		}
		if (SrClassId != null)
		{
			SrClassId.Initialize(context, "//////////8VYIkKAgAAAAAACQAAAFNyQ2xhc3NJZAEAcl4ALwA/cl4AAAAD/////wEB/////wAAAAA=");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_streamId != null)
		{
			children.Add(m_streamId);
		}
		if (m_streamName != null)
		{
			children.Add(m_streamName);
		}
		if (m_state != null)
		{
			children.Add(m_state);
		}
		if (m_accumulatedLatency != null)
		{
			children.Add(m_accumulatedLatency);
		}
		if (m_srClassId != null)
		{
			children.Add(m_srClassId);
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
		case "StreamId":
			if (createOrReplace && StreamId == null)
			{
				if (replacement == null)
				{
					StreamId = new BaseDataVariableState<byte[]>(this);
				}
				else
				{
					StreamId = (BaseDataVariableState<byte[]>)replacement;
				}
			}
			baseInstanceState = StreamId;
			break;
		case "StreamName":
			if (createOrReplace && StreamName == null)
			{
				if (replacement == null)
				{
					StreamName = new BaseDataVariableState<string>(this);
				}
				else
				{
					StreamName = (BaseDataVariableState<string>)replacement;
				}
			}
			baseInstanceState = StreamName;
			break;
		case "State":
			if (createOrReplace && State == null)
			{
				if (replacement == null)
				{
					State = new BaseDataVariableState<TsnStreamState>(this);
				}
				else
				{
					State = (BaseDataVariableState<TsnStreamState>)replacement;
				}
			}
			baseInstanceState = State;
			break;
		case "AccumulatedLatency":
			if (createOrReplace && AccumulatedLatency == null)
			{
				if (replacement == null)
				{
					AccumulatedLatency = new BaseDataVariableState<uint>(this);
				}
				else
				{
					AccumulatedLatency = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = AccumulatedLatency;
			break;
		case "SrClassId":
			if (createOrReplace && SrClassId == null)
			{
				if (replacement == null)
				{
					SrClassId = new BaseDataVariableState<byte>(this);
				}
				else
				{
					SrClassId = (BaseDataVariableState<byte>)replacement;
				}
			}
			baseInstanceState = SrClassId;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
