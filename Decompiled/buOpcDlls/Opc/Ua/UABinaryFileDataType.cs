using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class UABinaryFileDataType : DataTypeSchemaHeader
{
	private string m_schemaLocation;

	private KeyValuePairCollection m_fileHeader;

	private Variant m_body;

	[DataMember(Name = "SchemaLocation", IsRequired = false, Order = 1)]
	public string SchemaLocation
	{
		get
		{
			return m_schemaLocation;
		}
		set
		{
			m_schemaLocation = value;
		}
	}

	[DataMember(Name = "FileHeader", IsRequired = false, Order = 2)]
	public KeyValuePairCollection FileHeader
	{
		get
		{
			return m_fileHeader;
		}
		set
		{
			m_fileHeader = value;
			if (value == null)
			{
				m_fileHeader = new KeyValuePairCollection();
			}
		}
	}

	[DataMember(Name = "Body", IsRequired = false, Order = 3)]
	public Variant Body
	{
		get
		{
			return m_body;
		}
		set
		{
			m_body = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.UABinaryFileDataType;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.UABinaryFileDataType_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.UABinaryFileDataType_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.UABinaryFileDataType_Encoding_DefaultJson;

	public UABinaryFileDataType()
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
		m_schemaLocation = null;
		m_fileHeader = new KeyValuePairCollection();
		m_body = Variant.Null;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("SchemaLocation", SchemaLocation);
		encoder.WriteEncodeableArray("FileHeader", FileHeader.ToArray(), typeof(KeyValuePair));
		encoder.WriteVariant("Body", Body);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		SchemaLocation = decoder.ReadString("SchemaLocation");
		FileHeader = (KeyValuePair[])decoder.ReadEncodeableArray("FileHeader", typeof(KeyValuePair));
		Body = decoder.ReadVariant("Body");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is UABinaryFileDataType uABinaryFileDataType))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_schemaLocation, uABinaryFileDataType.m_schemaLocation))
		{
			return false;
		}
		if (!Utils.IsEqual(m_fileHeader, uABinaryFileDataType.m_fileHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_body, uABinaryFileDataType.m_body))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (UABinaryFileDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		UABinaryFileDataType obj = (UABinaryFileDataType)base.MemberwiseClone();
		obj.m_schemaLocation = (string)Utils.Clone(m_schemaLocation);
		obj.m_fileHeader = (KeyValuePairCollection)Utils.Clone(m_fileHeader);
		obj.m_body = (Variant)Utils.Clone(m_body);
		return obj;
	}
}
