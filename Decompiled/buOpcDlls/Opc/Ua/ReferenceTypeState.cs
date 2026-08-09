using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class ReferenceTypeState : BaseTypeState
{
	public NodeAttributeEventHandler<LocalizedText> OnReadInverseName;

	public NodeAttributeEventHandler<LocalizedText> OnWriteInverseName;

	public NodeAttributeEventHandler<bool> OnReadSymmetric;

	public NodeAttributeEventHandler<bool> OnWriteSymmetric;

	private LocalizedText m_inverseName;

	private bool m_symmetric;

	public LocalizedText InverseName
	{
		get
		{
			return m_inverseName;
		}
		set
		{
			if ((object)m_inverseName != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.NonValue;
			}
			m_inverseName = value;
		}
	}

	public bool Symmetric
	{
		get
		{
			return m_symmetric;
		}
		set
		{
			if (m_symmetric != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.NonValue;
			}
			m_symmetric = value;
		}
	}

	public ReferenceTypeState()
		: base(NodeClass.ReferenceType)
	{
		m_inverseName = null;
		m_symmetric = false;
	}

	public static NodeState Construct(NodeState parent)
	{
		return new ReferenceTypeState();
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		InverseName = null;
		Symmetric = false;
	}

	protected override void Initialize(ISystemContext context, NodeState source)
	{
		if (source is ReferenceTypeState referenceTypeState)
		{
			m_inverseName = referenceTypeState.m_inverseName;
			m_symmetric = referenceTypeState.m_symmetric;
		}
		base.Initialize(context, source);
	}

	public override object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ReferenceTypeState clone = (ReferenceTypeState)Activator.CreateInstance(GetType());
		return CloneChildren(clone);
	}

	protected override void Export(ISystemContext context, Node node)
	{
		base.Export(context, node);
		if (node is ReferenceTypeNode referenceTypeNode)
		{
			referenceTypeNode.InverseName = InverseName;
			referenceTypeNode.Symmetric = Symmetric;
		}
	}

	public override void Save(ISystemContext context, XmlEncoder encoder)
	{
		base.Save(context, encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (!LocalizedText.IsNullOrEmpty(m_inverseName))
		{
			encoder.WriteLocalizedText("InverseName", m_inverseName);
		}
		if (m_symmetric)
		{
			encoder.WriteBoolean("Symmetric", m_symmetric);
		}
		encoder.PopNamespace();
	}

	public override void Update(ISystemContext context, XmlDecoder decoder)
	{
		base.Update(context, decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (decoder.Peek("InverseName"))
		{
			InverseName = decoder.ReadLocalizedText("InverseName");
		}
		if (decoder.Peek("Symmetric"))
		{
			Symmetric = decoder.ReadBoolean("Symmetric");
		}
		decoder.PopNamespace();
	}

	public override AttributesToSave GetAttributesToSave(ISystemContext context)
	{
		AttributesToSave attributesToSave = base.GetAttributesToSave(context);
		if (!LocalizedText.IsNullOrEmpty(m_inverseName))
		{
			attributesToSave |= AttributesToSave.InverseName;
		}
		if (m_symmetric)
		{
			attributesToSave |= AttributesToSave.Symmetric;
		}
		return attributesToSave;
	}

	public override void Save(ISystemContext context, BinaryEncoder encoder, AttributesToSave attributesToSave)
	{
		base.Save(context, encoder, attributesToSave);
		if ((attributesToSave & AttributesToSave.InverseName) != AttributesToSave.None)
		{
			encoder.WriteLocalizedText(null, m_inverseName);
		}
		if ((attributesToSave & AttributesToSave.Symmetric) != AttributesToSave.None)
		{
			encoder.WriteBoolean(null, m_symmetric);
		}
	}

	public override void Update(ISystemContext context, BinaryDecoder decoder, AttributesToSave attibutesToLoad)
	{
		base.Update(context, decoder, attibutesToLoad);
		if ((attibutesToLoad & AttributesToSave.InverseName) != AttributesToSave.None)
		{
			m_inverseName = decoder.ReadLocalizedText(null);
		}
		if ((attibutesToLoad & AttributesToSave.Symmetric) != AttributesToSave.None)
		{
			m_symmetric = decoder.ReadBoolean(null);
		}
	}

	protected override ServiceResult ReadNonValueAttribute(ISystemContext context, uint attributeId, ref object value)
	{
		ServiceResult serviceResult = null;
		switch (attributeId)
		{
		case 10u:
		{
			LocalizedText value3 = m_inverseName;
			if (OnReadInverseName != null)
			{
				serviceResult = OnReadInverseName(context, this, ref value3);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				if (value3 == null)
				{
					serviceResult = 2150957056u;
				}
				else
				{
					value = value3;
				}
			}
			return serviceResult;
		}
		case 9u:
		{
			bool value2 = m_symmetric;
			if (OnReadSymmetric != null)
			{
				serviceResult = OnReadSymmetric(context, this, ref value2);
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
		case 10u:
		{
			LocalizedText value3 = value as LocalizedText;
			if (value3 == null && value != null)
			{
				return 2155085824u;
			}
			if ((base.WriteMask & AttributeWriteMask.InverseName) == 0)
			{
				return 2151350272u;
			}
			if (OnWriteInverseName != null)
			{
				serviceResult = OnWriteInverseName(context, this, ref value3);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				InverseName = value3;
			}
			return serviceResult;
		}
		case 9u:
		{
			bool? flag = value as bool?;
			if (!flag.HasValue)
			{
				return 2155085824u;
			}
			if ((base.WriteMask & AttributeWriteMask.Symmetric) == 0)
			{
				return 2151350272u;
			}
			bool value2 = flag.Value;
			if (OnWriteSymmetric != null)
			{
				serviceResult = OnWriteSymmetric(context, this, ref value2);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				Symmetric = value2;
			}
			return serviceResult;
		}
		default:
			return base.WriteNonValueAttribute(context, attributeId, value);
		}
	}
}
