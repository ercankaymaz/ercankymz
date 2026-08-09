using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class BrowsePathResult : IEncodeable, ICloneable, IJsonEncodeable
{
	private StatusCode m_statusCode;

	private BrowsePathTargetCollection m_targets;

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

	[DataMember(Name = "Targets", IsRequired = false, Order = 2)]
	public BrowsePathTargetCollection Targets
	{
		get
		{
			return m_targets;
		}
		set
		{
			m_targets = value;
			if (value == null)
			{
				m_targets = new BrowsePathTargetCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.BrowsePathResult;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.BrowsePathResult_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.BrowsePathResult_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.BrowsePathResult_Encoding_DefaultJson;

	public BrowsePathResult()
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
		m_targets = new BrowsePathTargetCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteStatusCode("StatusCode", StatusCode);
		encoder.WriteEncodeableArray("Targets", Targets.ToArray(), typeof(BrowsePathTarget));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		StatusCode = decoder.ReadStatusCode("StatusCode");
		Targets = (BrowsePathTarget[])decoder.ReadEncodeableArray("Targets", typeof(BrowsePathTarget));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is BrowsePathResult browsePathResult))
		{
			return false;
		}
		if (!Utils.IsEqual(m_statusCode, browsePathResult.m_statusCode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_targets, browsePathResult.m_targets))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (BrowsePathResult)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BrowsePathResult obj = (BrowsePathResult)base.MemberwiseClone();
		obj.m_statusCode = (StatusCode)Utils.Clone(m_statusCode);
		obj.m_targets = (BrowsePathTargetCollection)Utils.Clone(m_targets);
		return obj;
	}
}
