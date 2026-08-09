using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class StructureDefinition : DataTypeDefinition
{
	private NodeId m_defaultEncodingId;

	private NodeId m_baseDataType;

	private StructureType m_structureType;

	private StructureFieldCollection m_fields;

	[DataMember(Name = "DefaultEncodingId", IsRequired = false, Order = 1)]
	public NodeId DefaultEncodingId
	{
		get
		{
			return m_defaultEncodingId;
		}
		set
		{
			m_defaultEncodingId = value;
		}
	}

	[DataMember(Name = "BaseDataType", IsRequired = false, Order = 2)]
	public NodeId BaseDataType
	{
		get
		{
			return m_baseDataType;
		}
		set
		{
			m_baseDataType = value;
		}
	}

	[DataMember(Name = "StructureType", IsRequired = false, Order = 3)]
	public StructureType StructureType
	{
		get
		{
			return m_structureType;
		}
		set
		{
			m_structureType = value;
		}
	}

	[DataMember(Name = "Fields", IsRequired = false, Order = 4)]
	public StructureFieldCollection Fields
	{
		get
		{
			return m_fields;
		}
		set
		{
			m_fields = value;
			if (value == null)
			{
				m_fields = new StructureFieldCollection();
			}
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.StructureDefinition;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.StructureDefinition_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.StructureDefinition_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.StructureDefinition_Encoding_DefaultJson;

	public int FirstExplicitFieldIndex { get; set; }

	public StructureDefinition()
	{
		Initialize();
	}

	[OnDeserializing]
	private void Initialize(StreamingContext context)
	{
		Initialize();
	}

	private void Initialize()
	{
		m_defaultEncodingId = null;
		m_baseDataType = null;
		m_structureType = StructureType.Structure;
		m_fields = new StructureFieldCollection();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("DefaultEncodingId", DefaultEncodingId);
		encoder.WriteNodeId("BaseDataType", BaseDataType);
		encoder.WriteEnumerated("StructureType", StructureType);
		encoder.WriteEncodeableArray("Fields", Fields.ToArray(), typeof(StructureField));
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		DefaultEncodingId = decoder.ReadNodeId("DefaultEncodingId");
		BaseDataType = decoder.ReadNodeId("BaseDataType");
		StructureType = (StructureType)(object)decoder.ReadEnumerated("StructureType", typeof(StructureType));
		Fields = (StructureField[])decoder.ReadEncodeableArray("Fields", typeof(StructureField));
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is StructureDefinition structureDefinition))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_defaultEncodingId, structureDefinition.m_defaultEncodingId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_baseDataType, structureDefinition.m_baseDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_structureType, structureDefinition.m_structureType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_fields, structureDefinition.m_fields))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (StructureDefinition)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		StructureDefinition obj = (StructureDefinition)base.MemberwiseClone();
		obj.m_defaultEncodingId = (NodeId)Utils.Clone(m_defaultEncodingId);
		obj.m_baseDataType = (NodeId)Utils.Clone(m_baseDataType);
		obj.m_structureType = (StructureType)Utils.Clone(m_structureType);
		obj.m_fields = (StructureFieldCollection)Utils.Clone(m_fields);
		return obj;
	}

	public void SetDefaultEncodingId(ISystemContext context, NodeId typeId, QualifiedName dataEncoding)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (dataEncoding?.Name == "Default JSON")
		{
			DefaultEncodingId = ExpandedNodeId.ToNodeId(typeId, context.NamespaceUris);
			return;
		}
		Type type = context.EncodeableFactory?.GetSystemType(NodeId.ToExpandedNodeId(typeId, context.NamespaceUris));
		if (type != null && Activator.CreateInstance(type) is IEncodeable encodeable)
		{
			if (dataEncoding == null || dataEncoding.Name == "Default Binary")
			{
				DefaultEncodingId = ExpandedNodeId.ToNodeId(encodeable.BinaryEncodingId, context.NamespaceUris);
			}
			else if (dataEncoding.Name == "Default XML")
			{
				DefaultEncodingId = ExpandedNodeId.ToNodeId(encodeable.XmlEncodingId, context.NamespaceUris);
			}
		}
	}
}
