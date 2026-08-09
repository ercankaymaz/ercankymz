using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class Union : IEncodeable, ICloneable, IJsonEncodeable
{
	public virtual ExpandedNodeId TypeId => DataTypeIds.Union;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.Union_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.Union_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.Union_Encoding_DefaultJson;

	public Union()
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
		if (!(encodeable is Union))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (Union)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return (Union)base.MemberwiseClone();
	}
}
