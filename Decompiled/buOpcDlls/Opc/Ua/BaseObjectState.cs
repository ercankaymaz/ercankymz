using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class BaseObjectState : BaseInstanceState
{
	public NodeAttributeEventHandler<byte> OnReadEventNotifier;

	public NodeAttributeEventHandler<byte> OnWriteEventNotifier;

	private byte m_eventNotifier;

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

	public BaseObjectState(NodeState parent)
		: base(NodeClass.Object, parent)
	{
		m_eventNotifier = 0;
		if (parent != null)
		{
			base.ReferenceTypeId = ReferenceTypeIds.HasComponent;
		}
	}

	public static NodeState Construct(NodeState parent)
	{
		return new BaseObjectState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.SymbolicName = Utils.Format("{0}_Instance1", "BaseObjectType");
		base.NodeId = null;
		base.BrowseName = new QualifiedName(base.SymbolicName, 1);
		base.DisplayName = base.SymbolicName;
		base.Description = null;
		base.WriteMask = AttributeWriteMask.None;
		base.UserWriteMask = AttributeWriteMask.None;
		base.TypeDefinitionId = GetDefaultTypeDefinitionId(context.NamespaceUris);
		base.NumericId = 58u;
		EventNotifier = 0;
	}

	protected override void Initialize(ISystemContext context, NodeState source)
	{
		if (source is BaseObjectState baseObjectState)
		{
			m_eventNotifier = baseObjectState.m_eventNotifier;
		}
		base.Initialize(context, source);
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return 58u;
	}

	public override object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BaseObjectState clone = (BaseObjectState)Activator.CreateInstance(GetType(), base.Parent);
		return CloneChildren(clone);
	}

	protected override void Export(ISystemContext context, Node node)
	{
		base.Export(context, node);
		if (node is ObjectNode objectNode)
		{
			objectNode.EventNotifier = EventNotifier;
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
		decoder.PopNamespace();
	}

	public override AttributesToSave GetAttributesToSave(ISystemContext context)
	{
		AttributesToSave attributesToSave = base.GetAttributesToSave(context);
		if (m_eventNotifier != 0)
		{
			attributesToSave |= AttributesToSave.EventNotifier;
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
	}

	public override void Update(ISystemContext context, BinaryDecoder decoder, AttributesToSave attibutesToLoad)
	{
		base.Update(context, decoder, attibutesToLoad);
		if ((attibutesToLoad & AttributesToSave.EventNotifier) != AttributesToSave.None)
		{
			m_eventNotifier = decoder.ReadByte(null);
		}
	}

	protected override ServiceResult ReadNonValueAttribute(ISystemContext context, uint attributeId, ref object value)
	{
		ServiceResult serviceResult = null;
		if (attributeId == 12)
		{
			byte value2 = m_eventNotifier;
			if (OnReadEventNotifier != null)
			{
				serviceResult = OnReadEventNotifier(context, this, ref value2);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				value = value2;
			}
			return serviceResult;
		}
		return base.ReadNonValueAttribute(context, attributeId, ref value);
	}

	protected override ServiceResult WriteNonValueAttribute(ISystemContext context, uint attributeId, object value)
	{
		ServiceResult serviceResult = null;
		if (attributeId == 12)
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
			byte value2 = b.Value;
			if (OnWriteEventNotifier != null)
			{
				serviceResult = OnWriteEventNotifier(context, this, ref value2);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				EventNotifier = value2;
			}
			return serviceResult;
		}
		return base.WriteNonValueAttribute(context, attributeId, value);
	}
}
