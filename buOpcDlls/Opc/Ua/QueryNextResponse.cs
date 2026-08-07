// Decompiled with JetBrains decompiler
// Type: Opc.Ua.QueryNextResponse
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
public class QueryNextResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
  private ResponseHeader m_responseHeader;
  private QueryDataSetCollection m_queryDataSets;
  private byte[] m_revisedContinuationPoint;

  public QueryNextResponse() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_responseHeader = new ResponseHeader();
    this.m_queryDataSets = new QueryDataSetCollection();
    this.m_revisedContinuationPoint = (byte[]) null;
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

  [DataMember(Name = "RevisedContinuationPoint", IsRequired = false, Order = 3)]
  public byte[] RevisedContinuationPoint
  {
    get => this.m_revisedContinuationPoint;
    set => this.m_revisedContinuationPoint = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.QueryNextResponse;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.QueryNextResponse_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.QueryNextResponse_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.QueryNextResponse_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("ResponseHeader", (IEncodeable) this.ResponseHeader, typeof (ResponseHeader));
    encoder.WriteEncodeableArray("QueryDataSets", (IList<IEncodeable>) this.QueryDataSets.ToArray(), typeof (QueryDataSet));
    encoder.WriteByteString("RevisedContinuationPoint", this.RevisedContinuationPoint);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ResponseHeader = (ResponseHeader) decoder.ReadEncodeable("ResponseHeader", typeof (ResponseHeader));
    this.QueryDataSets = (QueryDataSetCollection) (QueryDataSet[]) decoder.ReadEncodeableArray("QueryDataSets", typeof (QueryDataSet));
    this.RevisedContinuationPoint = decoder.ReadByteString("RevisedContinuationPoint");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is QueryNextResponse queryNextResponse && Utils.IsEqual((object) this.m_responseHeader, (object) queryNextResponse.m_responseHeader) && Utils.IsEqual((object) this.m_queryDataSets, (object) queryNextResponse.m_queryDataSets) && Utils.IsEqual((object) this.m_revisedContinuationPoint, (object) queryNextResponse.m_revisedContinuationPoint);
  }

  public virtual object Clone() => (object) (QueryNextResponse) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    QueryNextResponse queryNextResponse = (QueryNextResponse) base.MemberwiseClone();
    queryNextResponse.m_responseHeader = (ResponseHeader) Utils.Clone((object) this.m_responseHeader);
    queryNextResponse.m_queryDataSets = (QueryDataSetCollection) Utils.Clone((object) this.m_queryDataSets);
    queryNextResponse.m_revisedContinuationPoint = (byte[]) Utils.Clone((object) this.m_revisedContinuationPoint);
    return (object) queryNextResponse;
  }
}
