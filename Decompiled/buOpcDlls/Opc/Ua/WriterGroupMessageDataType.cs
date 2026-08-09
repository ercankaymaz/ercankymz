using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class WriterGroupMessageDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	public virtual ExpandedNodeId TypeId => DataTypeIds.WriterGroupMessageDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.WriterGroupMessageDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.WriterGroupMessageDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.WriterGroupMessageDataType_Encoding_DefaultJson;

	public WriterGroupMessageDataType()
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
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is WriterGroupMessageDataType))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (WriterGroupMessageDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return (WriterGroupMessageDataType)base.MemberwiseClone();
	}
}
