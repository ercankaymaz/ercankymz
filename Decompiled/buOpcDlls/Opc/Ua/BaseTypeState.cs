using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class BaseTypeState : NodeState
{
	public NodeAttributeEventHandler<bool> OnReadIsAbstract;

	public NodeAttributeEventHandler<bool> OnWriteIsAbstract;

	private NodeId m_superTypeId;

	private bool m_isAbstract;

	public NodeId SuperTypeId
	{
		get
		{
			return m_superTypeId;
		}
		set
		{
			if ((object)m_superTypeId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.References;
			}
			m_superTypeId = value;
		}
	}

	public bool IsAbstract
	{
		get
		{
			return m_isAbstract;
		}
		set
		{
			if (m_isAbstract != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.NonValue;
			}
			m_isAbstract = value;
		}
	}

	protected BaseTypeState(NodeClass nodeClass)
		: base(nodeClass)
	{
		m_isAbstract = false;
	}

	protected override void Initialize(ISystemContext context, NodeState source)
	{
		if (source is BaseTypeState baseTypeState)
		{
			m_superTypeId = baseTypeState.m_superTypeId;
			m_isAbstract = baseTypeState.m_isAbstract;
		}
		base.Initialize(context, source);
	}

	public override object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BaseTypeState clone = new BaseTypeState(base.NodeClass);
		return CloneChildren(clone);
	}

	protected override void Export(ISystemContext context, Node node)
	{
		base.Export(context, node);
		if (!NodeId.IsNull(SuperTypeId))
		{
			node.ReferenceTable.Add(ReferenceTypeIds.HasSubtype, isInverse: true, SuperTypeId);
		}
		switch (base.NodeClass)
		{
		case NodeClass.ObjectType:
			((ObjectTypeNode)node).IsAbstract = IsAbstract;
			break;
		case NodeClass.VariableType:
			((VariableTypeNode)node).IsAbstract = IsAbstract;
			break;
		case NodeClass.DataType:
			((DataTypeNode)node).IsAbstract = IsAbstract;
			break;
		case NodeClass.ReferenceType:
			((ReferenceTypeNode)node).IsAbstract = IsAbstract;
			break;
		}
	}

	public override void Save(ISystemContext context, XmlEncoder encoder)
	{
		base.Save(context, encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (!NodeId.IsNull(m_superTypeId))
		{
			encoder.WriteNodeId("SuperTypeId", m_superTypeId);
		}
		if (m_isAbstract)
		{
			encoder.WriteBoolean("IsAbstract", m_isAbstract);
		}
		encoder.PopNamespace();
	}

	public override void Update(ISystemContext context, XmlDecoder decoder)
	{
		base.Update(context, decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (decoder.Peek("SuperTypeId"))
		{
			SuperTypeId = decoder.ReadNodeId("SuperTypeId");
		}
		if (decoder.Peek("IsAbstract"))
		{
			IsAbstract = decoder.ReadBoolean("IsAbstract");
		}
		decoder.PopNamespace();
	}

	public override AttributesToSave GetAttributesToSave(ISystemContext context)
	{
		AttributesToSave attributesToSave = base.GetAttributesToSave(context);
		if (!NodeId.IsNull(m_superTypeId))
		{
			attributesToSave |= AttributesToSave.SuperTypeId;
		}
		if (m_isAbstract)
		{
			attributesToSave |= AttributesToSave.IsAbstract;
		}
		return attributesToSave;
	}

	public override void Save(ISystemContext context, BinaryEncoder encoder, AttributesToSave attributesToSave)
	{
		base.Save(context, encoder, attributesToSave);
		if ((attributesToSave & AttributesToSave.SuperTypeId) != AttributesToSave.None)
		{
			encoder.WriteNodeId(null, m_superTypeId);
		}
		if ((attributesToSave & AttributesToSave.IsAbstract) != AttributesToSave.None)
		{
			encoder.WriteBoolean(null, m_isAbstract);
		}
	}

	public override void Update(ISystemContext context, BinaryDecoder decoder, AttributesToSave attributesToLoad)
	{
		base.Update(context, decoder, attributesToLoad);
		if ((attributesToLoad & AttributesToSave.SuperTypeId) != AttributesToSave.None)
		{
			m_superTypeId = decoder.ReadNodeId(null);
		}
		if ((attributesToLoad & AttributesToSave.IsAbstract) != AttributesToSave.None)
		{
			m_isAbstract = decoder.ReadBoolean(null);
		}
	}

	protected override ServiceResult ReadNonValueAttribute(ISystemContext context, uint attributeId, ref object value)
	{
		ServiceResult serviceResult = null;
		if (attributeId == 8)
		{
			bool value2 = m_isAbstract;
			if (OnReadIsAbstract != null)
			{
				serviceResult = OnReadIsAbstract(context, this, ref value2);
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
		if (attributeId == 8)
		{
			bool? flag = value as bool?;
			if (!flag.HasValue)
			{
				return 2155085824u;
			}
			if ((base.WriteMask & AttributeWriteMask.IsAbstract) == 0)
			{
				return 2151350272u;
			}
			bool value2 = flag.Value;
			if (OnWriteIsAbstract != null)
			{
				serviceResult = OnWriteIsAbstract(context, this, ref value2);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				IsAbstract = value2;
			}
			return serviceResult;
		}
		return base.WriteNonValueAttribute(context, attributeId, value);
	}

	protected override void PopulateBrowser(ISystemContext context, NodeBrowser browser)
	{
		base.PopulateBrowser(context, browser);
		if (!NodeId.IsNull(m_superTypeId) && browser.IsRequired(ReferenceTypeIds.HasSubtype, isInverse: true))
		{
			browser.Add(ReferenceTypeIds.HasSubtype, isInverse: true, m_superTypeId);
		}
		if (context.TypeTable != null && base.NodeId != null && browser.IsRequired(ReferenceTypeIds.HasSubtype, isInverse: false))
		{
			IList<NodeId> list = context.TypeTable.FindSubTypes(base.NodeId);
			for (int i = 0; i < list.Count; i++)
			{
				browser.Add(ReferenceTypeIds.HasSubtype, isInverse: false, list[i]);
			}
		}
	}
}
