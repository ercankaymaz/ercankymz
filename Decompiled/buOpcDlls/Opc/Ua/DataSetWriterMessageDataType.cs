using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DataSetWriterMessageDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	public virtual ExpandedNodeId TypeId => DataTypeIds.DataSetWriterMessageDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.DataSetWriterMessageDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.DataSetWriterMessageDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.DataSetWriterMessageDataType_Encoding_DefaultJson;

	public DataSetWriterMessageDataType()
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
		if (!(encodeable is DataSetWriterMessageDataType))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (DataSetWriterMessageDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return (DataSetWriterMessageDataType)base.MemberwiseClone();
	}
}
