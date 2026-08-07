// Decompiled with JetBrains decompiler
// Type: Opc.Ua.QueryFirstResponse
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class QueryFirstResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
  private ResponseHeader m_responseHeader;
  private QueryDataSetCollection m_queryDataSets;
  private byte[] m_continuationPoint;
  private ParsingResultCollection m_parsingResults;
  private DiagnosticInfoCollection m_diagnosticInfos;
  private ContentFilterResult m_filterResult;

  public QueryFirstResponse() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_responseHeader = new ResponseHeader();
    this.m_queryDataSets = new QueryDataSetCollection();
    this.m_continuationPoint = (byte[]) null;
    this.m_parsingResults = new ParsingResultCollection();
    this.m_diagnosticInfos = new DiagnosticInfoCollection();
    this.m_filterResult = new ContentFilterResult();
  }

  [DataMember(Name = "ResponseHeader", IsRequired = false, Order = 1)]
  public ResponseHeader ResponseHeader
  {
    get => this.m_responseHeader;
    set
    {
      this.m_responseHeader = value;
      if (value != null)
        return;
      this.m_responseHeader = new ResponseHeader();
    }
  }

  [DataMember(Name = "QueryDataSets", IsRequired = false, Order = 2)]
  public QueryDataSetCollection QueryDataSets
  {
    get => this.m_queryDataSets;
    set
    {
      this.m_queryDataSets = value;
      if (value != null)
        return;
      this.m_queryDataSets = new QueryDataSetCollection();
    }
  }

  [DataMember(Name = "ContinuationPoint", IsRequired = false, Order = 3)]
  public byte[] ContinuationPoint
  {
    get => this.m_continuationPoint;
    set => this.m_continuationPoint = value;
  }

  [DataMember(Name = "ParsingResults", IsRequired = false, Order = 4)]
  public ParsingResultCollection ParsingResults
  {
    get => this.m_parsingResults;
    set
    {
      this.m_parsingResults = value;
      if (value != null)
        return;
      this.m_parsingResults = new ParsingResultCollection();
    }
  }

  [DataMember(Name = "DiagnosticInfos", IsRequired = false, Order = 5)]
  public DiagnosticInfoCollection DiagnosticInfos
  {
    get => this.m_diagnosticInfos;
    set
    {
      this.m_diagnosticInfos = value;
      if (value != null)
        return;
      this.m_diagnosticInfos = new DiagnosticInfoCollection();
    }
  }

  [DataMember(Name = "FilterResult", IsRequired = false, Order = 6)]
  public ContentFilterResult FilterResult
  {
    get => this.m_filterResult;
    set
    {
      this.m_filterResult = value;
      if (value != null)
        return;
      this.m_filterResult = new ContentFilterResult();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.QueryFirstResponse;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.QueryFirstResponse_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.QueryFirstResponse_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.QueryFirstResponse_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("ResponseHeader", (IEncodeable) this.ResponseHeader, typeof (ResponseHeader));
    encoder.WriteEncodeableArray("QueryDataSets", (IList<IEncodeable>) this.QueryDataSets.ToArray(), typeof (QueryDataSet));
    encoder.WriteByteString("ContinuationPoint", this.ContinuationPoint);
    encoder.WriteEncodeableArray("ParsingResults", (IList<IEncodeable>) this.ParsingResults.ToArray(), typeof (ParsingResult));
    encoder.WriteDiagnosticInfoArray("DiagnosticInfos", (IList<DiagnosticInfo>) this.DiagnosticInfos);
    encoder.WriteEncodeable("FilterResult", (IEncodeable) this.FilterResult, typeof (ContentFilterResult));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ResponseHeader = (ResponseHeader) decoder.ReadEncodeable("ResponseHeader", typeof (ResponseHeader));
    this.QueryDataSets = (QueryDataSetCollection) (QueryDataSet[]) decoder.ReadEncodeableArray("QueryDataSets", typeof (QueryDataSet));
    this.ContinuationPoint = decoder.ReadByteString("ContinuationPoint");
    this.ParsingResults = (ParsingResultCollection) (ParsingResult[]) decoder.ReadEncodeableArray("ParsingResults", typeof (ParsingResult));
    this.DiagnosticInfos = decoder.ReadDiagnosticInfoArray("DiagnosticInfos");
    this.FilterResult = (ContentFilterResult) decoder.ReadEncodeable("FilterResult", typeof (ContentFilterResult));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is QueryFirstResponse queryFirstResponse && Utils.IsEqual((object) this.m_responseHeader, (object) queryFirstResponse.m_responseHeader) && Utils.IsEqual((object) this.m_queryDataSets, (object) queryFirstResponse.m_queryDataSets) && Utils.IsEqual((object) this.m_continuationPoint, (object) queryFirstResponse.m_continuationPoint) && Utils.IsEqual((object) this.m_parsingResults, (object) queryFirstResponse.m_parsingResults) && Utils.IsEqual((object) this.m_diagnosticInfos, (object) queryFirstResponse.m_diagnosticInfos) && Utils.IsEqual((object) this.m_filterResult, (object) queryFirstResponse.m_filterResult);
  }

  public virtual object Clone() => (object) (QueryFirstResponse) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    QueryFirstResponse queryFirstResponse = (QueryFirstResponse) base.MemberwiseClone();
    queryFirstResponse.m_responseHeader = (ResponseHeader) Utils.Clone((object) this.m_responseHeader);
    queryFirstResponse.m_queryDataSets = (QueryDataSetCollection) Utils.Clone((object) this.m_queryDataSets);
    queryFirstResponse.m_continuationPoint = (byte[]) Utils.Clone((object) this.m_continuationPoint);
    queryFirstResponse.m_parsingResults = (ParsingResultCollection) Utils.Clone((object) this.m_parsingResults);
    queryFirstResponse.m_diagnosticInfos = (DiagnosticInfoCollection) Utils.Clone((object) this.m_diagnosticInfos);
    queryFirstResponse.m_filterResult = (ContentFilterResult) Utils.Clone((object) this.m_filterResult);
    return (object) queryFirstResponse;
  }
}
