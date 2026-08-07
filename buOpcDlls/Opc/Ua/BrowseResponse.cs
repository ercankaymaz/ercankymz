// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BrowseResponse
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
public class BrowseResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
  private ResponseHeader m_responseHeader;
  private BrowseResultCollection m_results;
  private DiagnosticInfoCollection m_diagnosticInfos;

  public BrowseResponse() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_responseHeader = new ResponseHeader();
    this.m_results = new BrowseResultCollection();
    this.m_diagnosticInfos = new DiagnosticInfoCollection();
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

  [DataMember(Name = "Results", IsRequired = false, Order = 2)]
  public BrowseResultCollection Results
  {
    get => this.m_results;
    set
    {
      this.m_results = value;
      if (value != null)
        return;
      this.m_results = new BrowseResultCollection();
    }
  }

  [DataMember(Name = "DiagnosticInfos", IsRequired = false, Order = 3)]
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

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.BrowseResponse;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrowseResponse_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrowseResponse_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrowseResponse_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("ResponseHeader", (IEncodeable) this.ResponseHeader, typeof (ResponseHeader));
    encoder.WriteEncodeableArray("Results", (IList<IEncodeable>) this.Results.ToArray(), typeof (BrowseResult));
    encoder.WriteDiagnosticInfoArray("DiagnosticInfos", (IList<DiagnosticInfo>) this.DiagnosticInfos);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ResponseHeader = (ResponseHeader) decoder.ReadEncodeable("ResponseHeader", typeof (ResponseHeader));
    this.Results = (BrowseResultCollection) (BrowseResult[]) decoder.ReadEncodeableArray("Results", typeof (BrowseResult));
    this.DiagnosticInfos = decoder.ReadDiagnosticInfoArray("DiagnosticInfos");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is BrowseResponse browseResponse && Utils.IsEqual((object) this.m_responseHeader, (object) browseResponse.m_responseHeader) && Utils.IsEqual((object) this.m_results, (object) browseResponse.m_results) && Utils.IsEqual((object) this.m_diagnosticInfos, (object) browseResponse.m_diagnosticInfos);
  }

  public virtual object Clone() => (object) (BrowseResponse) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    BrowseResponse browseResponse = (BrowseResponse) base.MemberwiseClone();
    browseResponse.m_responseHeader = (ResponseHeader) Utils.Clone((object) this.m_responseHeader);
    browseResponse.m_results = (BrowseResultCollection) Utils.Clone((object) this.m_results);
    browseResponse.m_diagnosticInfos = (DiagnosticInfoCollection) Utils.Clone((object) this.m_diagnosticInfos);
    return (object) browseResponse;
  }
}
