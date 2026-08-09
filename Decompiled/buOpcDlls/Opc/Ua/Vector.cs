using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class Vector : IEncodeable, ICloneable, IJsonEncodeable
{
	public virtual ExpandedNodeId TypeId => DataTypeIds.Vector;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.Vector_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.Vector_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.Vector_Encoding_DefaultJson;

	public Vector()
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
		if (!(encodeable is Vector))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (Vector)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return (Vector)base.MemberwiseClone();
	}
}
