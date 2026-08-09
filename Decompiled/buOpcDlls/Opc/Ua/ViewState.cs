using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class ViewState : NodeState
{
	public NodeAttributeEventHandler<byte> OnReadEventNotifier;

	public NodeAttributeEventHandler<byte> OnWriteEventNotifier;

	public NodeAttributeEventHandler<bool> OnReadContainsNoLoops;

	public NodeAttributeEventHandler<bool> OnWriteContainsNoLoops;

	private byte m_eventNotifier;

	private bool m_containsNoLoops;

	public byte EventNotifier
	{
		get
		{
			return m_eventNotifier;
		}
		set
		{
			if (m_eventNotifier != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.NonValue;
			}
			m_eventNotifier = value;
		}
	}

	public bool ContainsNoLoops
	{
		get
		{
			return m_containsNoLoops;
		}
		set
		{
			if (m_containsNoLoops != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.NonValue;
			}
			m_containsNoLoops = value;
		}
	}

	public ViewState()
		: base(NodeClass.View)
	{
	}

	public static NodeState Construct(NodeState parent)
	{
		return new ViewState();
	}

	protected override void Initialize(ISystemContext context)
	{
		base.SymbolicName = "View1";
		base.NodeId = null;
		base.BrowseName = new QualifiedName(base.SymbolicName, 1);
		base.DisplayName = base.SymbolicName;
		base.Description = null;
		base.WriteMask = AttributeWriteMask.None;
		base.UserWriteMask = AttributeWriteMask.None;
		EventNotifier = 0;
		ContainsNoLoops = false;
	}

	protected override void Initialize(ISystemContext context, NodeState source)
	{
		if (source is ViewState viewState)
		{
			m_eventNotifier = viewState.m_eventNotifier;
			m_containsNoLoops = viewState.m_containsNoLoops;
		}
		base.Initialize(context, source);
	}

	public override object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ViewState clone = (ViewState)Activator.CreateInstance(GetType());
		return CloneChildren(clone);
	}

	protected override void Export(ISystemContext context, Node node)
	{
		base.Export(context, node);
		if (node is ViewNode viewNode)
		{
			viewNode.EventNotifier = EventNotifier;
			viewNode.ContainsNoLoops = ContainsNoLoops;
		}
	}

	public override void Save(ISystemContext context, XmlEncoder encoder)
	{
		base.Save(context, encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (m_eventNotifier != 0)
		{
			encoder.WriteByte("EventNotifier", m_eventNotifier);
		}
		if (m_containsNoLoops)
		{
			encoder.WriteBoolean("ContainsNoLoops", m_containsNoLoops);
		}
		encoder.PopNamespace();
	}

	public override void Update(ISystemContext context, XmlDecoder decoder)
	{
		base.Update(context, decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (decoder.Peek("EventNotifier"))
		{
			EventNotifier = decoder.ReadByte("EventNotifier");
		}
		if (decoder.Peek("ContainsNoLoops"))
		{
			ContainsNoLoops = decoder.ReadBoolean("ContainsNoLoops");
		}
		decoder.PopNamespace();
	}

	public override AttributesToSave GetAttributesToSave(ISystemContext context)
	{
		AttributesToSave attributesToSave = base.GetAttributesToSave(context);
		if (m_eventNotifier != 0)
		{
			attributesToSave |= AttributesToSave.EventNotifier;
		}
		if (m_containsNoLoops)
		{
			attributesToSave |= AttributesToSave.ContainsNoLoops;
		}
		return attributesToSave;
	}

	public override void Save(ISystemContext context, BinaryEncoder encoder, AttributesToSave attributesToSave)
	{
		base.Save(context, encoder, attributesToSave);
		if ((attributesToSave & AttributesToSave.EventNotifier) != AttributesToSave.None)
		{
			encoder.WriteByte(null, m_eventNotifier);
		}
		if ((attributesToSave & AttributesToSave.ContainsNoLoops) != AttributesToSave.None)
		{
			encoder.WriteBoolean(null, m_containsNoLoops);
		}
	}

	public override void Update(ISystemContext context, BinaryDecoder decoder, AttributesToSave attributesToLoad)
	{
		base.Update(context, decoder, attributesToLoad);
		if ((attributesToLoad & AttributesToSave.EventNotifier) != AttributesToSave.None)
		{
			m_eventNotifier = decoder.ReadByte(null);
		}
		if ((attributesToLoad & AttributesToSave.ContainsNoLoops) != AttributesToSave.None)
		{
			m_containsNoLoops = decoder.ReadBoolean(null);
		}
	}

	protected override ServiceResult ReadNonValueAttribute(ISystemContext context, uint attributeId, ref object value)
	{
		ServiceResult serviceResult = null;
		switch (attributeId)
		{
		case 12u:
		{
			byte value3 = m_eventNotifier;
			if (OnReadEventNotifier != null)
			{
				serviceResult = OnReadEventNotifier(context, this, ref value3);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				value = value3;
			}
			return serviceResult;
		}
		case 11u:
		{
			bool value2 = m_containsNoLoops;
			if (OnReadContainsNoLoops != null)
			{
				serviceResult = OnReadContainsNoLoops(context, this, ref value2);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				value = value2;
			}
			return serviceResult;
		}
		default:
			return base.ReadNonValueAttribute(context, attributeId, ref value);
		}
	}

	protected override ServiceResult WriteNonValueAttribute(ISystemContext context, uint attributeId, object value)
	{
		ServiceResult serviceResult = null;
		switch (attributeId)
		{
		case 12u:
		{
			byte? b = value as byte?;
			if (!b.HasValue)
			{
				return 2155085824u;
			}
			if ((base.WriteMask & AttributeWriteMask.EventNotifier) == 0)
			{
				return 2151350272u;
			}
			byte value3 = b.Value;
			if (OnWriteEventNotifier != null)
			{
				serviceResult = OnWriteEventNotifier(context, this, ref value3);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				EventNotifier = value3;
			}
			return serviceResult;
		}
		case 11u:
		{
			bool? flag = value as bool?;
			if (!flag.HasValue)
			{
				return 2155085824u;
			}
			if ((base.WriteMask & AttributeWriteMask.ContainsNoLoops) == 0)
			{
				return 2151350272u;
			}
			bool value2 = flag.Value;
			if (OnWriteContainsNoLoops != null)
			{
				serviceResult = OnWriteContainsNoLoops(context, this, ref value2);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				ContainsNoLoops = value2;
			}
			return serviceResult;
		}
		default:
			return base.WriteNonValueAttribute(context, attributeId, value);
		}
	}
}
