using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class BrowseResult : IEncodeable, ICloneable, IJsonEncodeable
{
	private StatusCode m_statusCode;

	private byte[] m_continuationPoint;

	private ReferenceDescriptionCollection m_references;

	[DataMember(Name = "StatusCode", IsRequired = false, Order = 1)]
	public StatusCode StatusCode
	{
		get
		{
			return m_statusCode;
		}
		set
		{
			m_statusCode = value;
		}
	}

	[DataMember(Name = "ContinuationPoint", IsRequired = false, Order = 2)]
	public byte[] ContinuationPoint
	{
		get
		{
			return m_continuationPoint;
		}
		set
		{
			m_continuationPoint = value;
		}
	}

	[DataMember(Name = "References", IsRequired = false, Order = 3)]
	public ReferenceDescriptionCollection References
	{
		get
		{
			return m_references;
		}
		set
		{
			m_references = value;
			if (value == null)
			{
				m_references = new ReferenceDescriptionCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.BrowseResult;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.BrowseResult_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.BrowseResult_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.BrowseResult_Encoding_DefaultJson;

	public BrowseResult()
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
		m_statusCode = 0u;
		m_continuationPoint = null;
		m_references = new ReferenceDescriptionCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteStatusCode("StatusCode", StatusCode);
		encoder.WriteByteString("ContinuationPoint", ContinuationPoint);
		encoder.WriteEncodeableArray("References", References.ToArray(), typeof(ReferenceDescription));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		StatusCode = decoder.ReadStatusCode("StatusCode");
		ContinuationPoint = decoder.ReadByteString("ContinuationPoint");
		References = (ReferenceDescription[])decoder.ReadEncodeableArray("References", typeof(ReferenceDescription));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is BrowseResult browseResult))
		{
			return false;
		}
		if (!Utils.IsEqual(m_statusCode, browseResult.m_statusCode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_continuationPoint, browseResult.m_continuationPoint))
		{
			return false;
		}
		if (!Utils.IsEqual(m_references, browseResult.m_references))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (BrowseResult)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BrowseResult obj = (BrowseResult)base.MemberwiseClone();
		obj.m_statusCode = (StatusCode)Utils.Clone(m_statusCode);
		obj.m_continuationPoint = (byte[])Utils.Clone(m_continuationPoint);
		obj.m_references = (ReferenceDescriptionCollection)Utils.Clone(m_references);
		return obj;
	}
}
