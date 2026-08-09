using System;
using System.Runtime.InteropServices;
using Opc.Ua.Export;

namespace Opc.Ua;

[ComVisible(true)]
public class DataTypeState : BaseTypeState
{
	public NodeAttributeEventHandler<ExtensionObject> OnReadDataTypeDefinition;

	public NodeAttributeEventHandler<ExtensionObject> OnWriteDataTypeDefinition;

	private ExtensionObject m_dataTypeDefinition;

	public ExtensionObject DataTypeDefinition
	{
		get
		{
			return m_dataTypeDefinition;
		}
		set
		{
			if (m_dataTypeDefinition != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.NonValue;
			}
			m_dataTypeDefinition = value;
		}
	}

	public DataTypePurpose Purpose { get; set; }

	public DataTypeState()
		: base(NodeClass.DataType)
	{
	}

	public static NodeState Construct(NodeState parent)
	{
		return new DataTypeState();
	}

	public override object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DataTypeState clone = (DataTypeState)Activator.CreateInstance(GetType());
		return CloneChildren(clone);
	}

	public override void Save(ISystemContext context, XmlEncoder encoder)
	{
		base.Save(context, encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (m_dataTypeDefinition != null)
		{
			encoder.WriteExtensionObject("DataTypeDefinition", m_dataTypeDefinition);
		}
		encoder.PopNamespace();
	}

	public override void Update(ISystemContext context, XmlDecoder decoder)
	{
		base.Update(context, decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (decoder.Peek("DataTypeDefinition"))
		{
			DataTypeDefinition = decoder.ReadExtensionObject("DataTypeDefinition");
		}
		decoder.PopNamespace();
	}

	public override AttributesToSave GetAttributesToSave(ISystemContext context)
	{
		AttributesToSave attributesToSave = base.GetAttributesToSave(context);
		if (m_dataTypeDefinition != null)
		{
			attributesToSave |= AttributesToSave.DataTypeDefinition;
		}
		return attributesToSave;
	}

	public override void Save(ISystemContext context, BinaryEncoder encoder, AttributesToSave attributesToSave)
	{
		base.Save(context, encoder, attributesToSave);
		if ((attributesToSave & AttributesToSave.DataTypeDefinition) != AttributesToSave.None)
		{
			encoder.WriteExtensionObject(null, DataTypeDefinition);
		}
	}

	public override void Update(ISystemContext context, BinaryDecoder decoder, AttributesToSave attributesToLoad)
	{
		base.Update(context, decoder, attributesToLoad);
		if ((attributesToLoad & AttributesToSave.DataTypeDefinition) != AttributesToSave.None)
		{
			DataTypeDefinition = decoder.ReadExtensionObject(null);
		}
	}

	protected override ServiceResult ReadNonValueAttribute(ISystemContext context, uint attributeId, ref object value)
	{
		ServiceResult serviceResult = null;
		if (attributeId == 23)
		{
			ExtensionObject value2 = m_dataTypeDefinition;
			if (OnReadDataTypeDefinition != null)
			{
				serviceResult = OnReadDataTypeDefinition(context, this, ref value2);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				if (value2?.Body is StructureDefinition structureDefinition && (structureDefinition.DefaultEncodingId == null || structureDefinition.DefaultEncodingId.IsNullNodeId))
				{
					structureDefinition.SetDefaultEncodingId(context, base.NodeId, null);
				}
				value = value2;
			}
			if (value == null && serviceResult == null)
			{
				return 2150957056u;
			}
			return serviceResult;
		}
		return base.ReadNonValueAttribute(context, attributeId, ref value);
	}

	protected override ServiceResult WriteNonValueAttribute(ISystemContext context, uint attributeId, object value)
	{
		ServiceResult serviceResult = null;
		if (attributeId == 23)
		{
			ExtensionObject value2 = value as ExtensionObject;
			if ((base.WriteMask & AttributeWriteMask.DataTypeDefinition) == 0)
			{
				return 2151350272u;
			}
			if (OnWriteDataTypeDefinition != null)
			{
				serviceResult = OnWriteDataTypeDefinition(context, this, ref value2);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				m_dataTypeDefinition = value2;
			}
			return serviceResult;
		}
		return base.WriteNonValueAttribute(context, attributeId, value);
	}
}
