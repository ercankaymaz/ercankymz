using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class EnumField : EnumValueType
{
	private string m_name;

	[DataMember(Name = "Name", IsRequired = false, Order = 1)]
	public string Name
	{
		get
		{
			return m_name;
		}
		set
		{
			m_name = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.EnumField;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.EnumField_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.EnumField_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.EnumField_Encoding_DefaultJson;

	public EnumField()
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
		m_name = null;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("Name", Name);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Name = decoder.ReadString("Name");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is EnumField enumField))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_name, enumField.m_name))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (EnumField)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		EnumField obj = (EnumField)base.MemberwiseClone();
		obj.m_name = (string)Utils.Clone(m_name);
		return obj;
	}
}
