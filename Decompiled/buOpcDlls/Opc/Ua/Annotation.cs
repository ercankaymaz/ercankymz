using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class Annotation : IEncodeable, ICloneable, IJsonEncodeable
{
	private string m_message;

	private string m_userName;

	private DateTime m_annotationTime;

	[DataMember(Name = "Message", IsRequired = false, Order = 1)]
	public string Message
	{
		get
		{
			return m_message;
		}
		set
		{
			m_message = value;
		}
	}

	[DataMember(Name = "UserName", IsRequired = false, Order = 2)]
	public string UserName
	{
		get
		{
			return m_userName;
		}
		set
		{
			m_userName = value;
		}
	}

	[DataMember(Name = "AnnotationTime", IsRequired = false, Order = 3)]
	public DateTime AnnotationTime
	{
		get
		{
			return m_annotationTime;
		}
		set
		{
			m_annotationTime = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.Annotation;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.Annotation_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.Annotation_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.Annotation_Encoding_DefaultJson;

	public Annotation()
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
		m_message = null;
		m_userName = null;
		m_annotationTime = DateTime.MinValue;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("Message", Message);
		encoder.WriteString("UserName", UserName);
		encoder.WriteDateTime("AnnotationTime", AnnotationTime);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Message = decoder.ReadString("Message");
		UserName = decoder.ReadString("UserName");
		AnnotationTime = decoder.ReadDateTime("AnnotationTime");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is Annotation annotation))
		{
			return false;
		}
		if (!Utils.IsEqual(m_message, annotation.m_message))
		{
			return false;
		}
		if (!Utils.IsEqual(m_userName, annotation.m_userName))
		{
			return false;
		}
		if (!Utils.IsEqual(m_annotationTime, annotation.m_annotationTime))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (Annotation)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		Annotation obj = (Annotation)base.MemberwiseClone();
		obj.m_message = (string)Utils.Clone(m_message);
		obj.m_userName = (string)Utils.Clone(m_userName);
		obj.m_annotationTime = (DateTime)Utils.Clone(m_annotationTime);
		return obj;
	}
}
