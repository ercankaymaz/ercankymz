using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class StructureDescription : DataTypeDescription
{
	private StructureDefinition m_structureDefinition;

	[DataMember(Name = "StructureDefinition", IsRequired = false, Order = 1)]
	public StructureDefinition StructureDefinition
	{
		get
		{
			return m_structureDefinition;
		}
		set
		{
			m_structureDefinition = value;
			if (value == null)
			{
				m_structureDefinition = new StructureDefinition();
			}
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.StructureDescription;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.StructureDescription_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.StructureDescription_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.StructureDescription_Encoding_DefaultJson;

	public StructureDescription()
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
		m_structureDefinition = new StructureDefinition();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("StructureDefinition", StructureDefinition, typeof(StructureDefinition));
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		StructureDefinition = (StructureDefinition)decoder.ReadEncodeable("StructureDefinition", typeof(StructureDefinition));
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is StructureDescription structureDescription))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_structureDefinition, structureDescription.m_structureDefinition))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (StructureDescription)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		StructureDescription obj = (StructureDescription)base.MemberwiseClone();
		obj.m_structureDefinition = (StructureDefinition)Utils.Clone(m_structureDefinition);
		return obj;
	}
}
