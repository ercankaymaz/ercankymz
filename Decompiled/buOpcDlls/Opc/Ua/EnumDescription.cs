using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class EnumDescription : DataTypeDescription
{
	private EnumDefinition m_enumDefinition;

	private byte m_builtInType;

	[DataMember(Name = "EnumDefinition", IsRequired = false, Order = 1)]
	public EnumDefinition EnumDefinition
	{
		get
		{
			return m_enumDefinition;
		}
		set
		{
			m_enumDefinition = value;
			if (value == null)
			{
				m_enumDefinition = new EnumDefinition();
			}
		}
	}

	[DataMember(Name = "BuiltInType", IsRequired = false, Order = 2)]
	public byte BuiltInType
	{
		get
		{
			return m_builtInType;
		}
		set
		{
			m_builtInType = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.EnumDescription;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.EnumDescription_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.EnumDescription_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.EnumDescription_Encoding_DefaultJson;

	public EnumDescription()
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
		m_enumDefinition = new EnumDefinition();
		m_builtInType = 0;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("EnumDefinition", EnumDefinition, typeof(EnumDefinition));
		encoder.WriteByte("BuiltInType", BuiltInType);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		EnumDefinition = (EnumDefinition)decoder.ReadEncodeable("EnumDefinition", typeof(EnumDefinition));
		BuiltInType = decoder.ReadByte("BuiltInType");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is EnumDescription enumDescription))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_enumDefinition, enumDescription.m_enumDefinition))
		{
			return false;
		}
		if (!Utils.IsEqual(m_builtInType, enumDescription.m_builtInType))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (EnumDescription)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		EnumDescription obj = (EnumDescription)base.MemberwiseClone();
		obj.m_enumDefinition = (EnumDefinition)Utils.Clone(m_enumDefinition);
		obj.m_builtInType = (byte)Utils.Clone(m_builtInType);
		return obj;
	}
}
