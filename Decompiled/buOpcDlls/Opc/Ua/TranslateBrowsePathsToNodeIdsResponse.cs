using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class TranslateBrowsePathsToNodeIdsResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
	private ResponseHeader m_responseHeader;

	private BrowsePathResultCollection m_results;

	private DiagnosticInfoCollection m_diagnosticInfos;

	[DataMember(Name = "ResponseHeader", IsRequired = false, Order = 1)]
	public ResponseHeader ResponseHeader
	{
		get
		{
			return m_responseHeader;
		}
		set
		{
			m_responseHeader = value;
			if (value == null)
			{
				m_responseHeader = new ResponseHeader();
			}
		}
	}

	[DataMember(Name = "Results", IsRequired = false, Order = 2)]
	public BrowsePathResultCollection Results
	{
		get
		{
			return m_results;
		}
		set
		{
			m_results = value;
			if (value == null)
			{
				m_results = new BrowsePathResultCollection();
			}
		}
	}

	[DataMember(Name = "DiagnosticInfos", IsRequired = false, Order = 3)]
	public DiagnosticInfoCollection DiagnosticInfos
	{
		get
		{
			return m_diagnosticInfos;
		}
		set
		{
			m_diagnosticInfos = value;
			if (value == null)
			{
				m_diagnosticInfos = new DiagnosticInfoCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.TranslateBrowsePathsToNodeIdsResponse;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.TranslateBrowsePathsToNodeIdsResponse_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.TranslateBrowsePathsToNodeIdsResponse_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.TranslateBrowsePathsToNodeIdsResponse_Encoding_DefaultJson;

	public TranslateBrowsePathsToNodeIdsResponse()
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
		m_responseHeader = new ResponseHeader();
		m_results = new BrowsePathResultCollection();
		m_diagnosticInfos = new DiagnosticInfoCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("ResponseHeader", ResponseHeader, typeof(ResponseHeader));
		encoder.WriteEncodeableArray("Results", Results.ToArray(), typeof(BrowsePathResult));
		encoder.WriteDiagnosticInfoArray("DiagnosticInfos", DiagnosticInfos);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ResponseHeader = (ResponseHeader)decoder.ReadEncodeable("ResponseHeader", typeof(ResponseHeader));
		Results = (BrowsePathResult[])decoder.ReadEncodeableArray("Results", typeof(BrowsePathResult));
		DiagnosticInfos = decoder.ReadDiagnosticInfoArray("DiagnosticInfos");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is TranslateBrowsePathsToNodeIdsResponse translateBrowsePathsToNodeIdsResponse))
		{
			return false;
		}
		if (!Utils.IsEqual(m_responseHeader, translateBrowsePathsToNodeIdsResponse.m_responseHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_results, translateBrowsePathsToNodeIdsResponse.m_results))
		{
			return false;
		}
		if (!Utils.IsEqual(m_diagnosticInfos, translateBrowsePathsToNodeIdsResponse.m_diagnosticInfos))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (TranslateBrowsePathsToNodeIdsResponse)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		TranslateBrowsePathsToNodeIdsResponse obj = (TranslateBrowsePathsToNodeIdsResponse)base.MemberwiseClone();
		obj.m_responseHeader = (ResponseHeader)Utils.Clone(m_responseHeader);
		obj.m_results = (BrowsePathResultCollection)Utils.Clone(m_results);
		obj.m_diagnosticInfos = (DiagnosticInfoCollection)Utils.Clone(m_diagnosticInfos);
		return obj;
	}
}
