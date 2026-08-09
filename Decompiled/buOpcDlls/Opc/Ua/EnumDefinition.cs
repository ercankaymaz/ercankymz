using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class EnumDefinition : DataTypeDefinition
{
	private EnumFieldCollection m_fields;

	[DataMember(Name = "Fields", IsRequired = false, Order = 1)]
	public EnumFieldCollection Fields
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
				m_fields = new EnumFieldCollection();
			}
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.EnumDefinition;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.EnumDefinition_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.EnumDefinition_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.EnumDefinition_Encoding_DefaultJson;

	public bool IsOptionSet { get; set; }

	public EnumDefinition()
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
		m_fields = new EnumFieldCollection();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeableArray("Fields", Fields.ToArray(), typeof(EnumField));
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Fields = (EnumField[])decoder.ReadEncodeableArray("Fields", typeof(EnumField));
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is EnumDefinition enumDefinition))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_fields, enumDefinition.m_fields))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (EnumDefinition)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		EnumDefinition obj = (EnumDefinition)base.MemberwiseClone();
		obj.m_fields = (EnumFieldCollection)Utils.Clone(m_fields);
		return obj;
	}
}
