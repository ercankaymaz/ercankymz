using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class NotificationData : IEncodeable, ICloneable, IJsonEncodeable
{
	public virtual ExpandedNodeId TypeId => DataTypeIds.NotificationData;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.NotificationData_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.NotificationData_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.NotificationData_Encoding_DefaultJson;

	public uint SequenceNumber { get; set; }

	public DateTime PublishTime { get; set; }

	public NotificationData()
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
		if (!(encodeable is NotificationData))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (NotificationData)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return (NotificationData)base.MemberwiseClone();
	}
}
