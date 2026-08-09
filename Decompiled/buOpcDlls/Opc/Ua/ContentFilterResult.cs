using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ContentFilterResult : IEncodeable, ICloneable, IJsonEncodeable
{
	private ContentFilterElementResultCollection m_elementResults;

	private DiagnosticInfoCollection m_elementDiagnosticInfos;

	[DataMember(Name = "ElementResults", IsRequired = false, Order = 1)]
	public ContentFilterElementResultCollection ElementResults
	{
		get
		{
			return m_elementResults;
		}
		set
		{
			m_elementResults = value;
			if (value == null)
			{
				m_elementResults = new ContentFilterElementResultCollection();
			}
		}
	}

	[DataMember(Name = "ElementDiagnosticInfos", IsRequired = false, Order = 2)]
	public DiagnosticInfoCollection ElementDiagnosticInfos
	{
		get
		{
			return m_elementDiagnosticInfos;
		}
		set
		{
			m_elementDiagnosticInfos = value;
			if (value == null)
			{
				m_elementDiagnosticInfos = new DiagnosticInfoCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ContentFilterResult;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ContentFilterResult_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ContentFilterResult_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ContentFilterResult_Encoding_DefaultJson;

	public ContentFilterResult()
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
		m_elementResults = new ContentFilterElementResultCollection();
		m_elementDiagnosticInfos = new DiagnosticInfoCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeableArray("ElementResults", ElementResults.ToArray(), typeof(ContentFilterElementResult));
		encoder.WriteDiagnosticInfoArray("ElementDiagnosticInfos", ElementDiagnosticInfos);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ElementResults = (ContentFilterElementResult[])decoder.ReadEncodeableArray("ElementResults", typeof(ContentFilterElementResult));
		ElementDiagnosticInfos = decoder.ReadDiagnosticInfoArray("ElementDiagnosticInfos");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ContentFilterResult contentFilterResult))
		{
			return false;
		}
		if (!Utils.IsEqual(m_elementResults, contentFilterResult.m_elementResults))
		{
			return false;
		}
		if (!Utils.IsEqual(m_elementDiagnosticInfos, contentFilterResult.m_elementDiagnosticInfos))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ContentFilterResult)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ContentFilterResult obj = (ContentFilterResult)base.MemberwiseClone();
		obj.m_elementResults = (ContentFilterElementResultCollection)Utils.Clone(m_elementResults);
		obj.m_elementDiagnosticInfos = (DiagnosticInfoCollection)Utils.Clone(m_elementDiagnosticInfos);
		return obj;
	}
}
