// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EventFilterResult
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class EventFilterResult : MonitoringFilterResult
{
  private StatusCodeCollection m_selectClauseResults;
  private DiagnosticInfoCollection m_selectClauseDiagnosticInfos;
  private ContentFilterResult m_whereClauseResult;

  public EventFilterResult() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_selectClauseResults = new StatusCodeCollection();
    this.m_selectClauseDiagnosticInfos = new DiagnosticInfoCollection();
    this.m_whereClauseResult = new ContentFilterResult();
  }

  [DataMember(Name = "SelectClauseResults", IsRequired = false, Order = 1)]
  public StatusCodeCollection SelectClauseResults
  {
    get => this.m_selectClauseResults;
    set
    {
      this.m_selectClauseResults = value;
      if (value != null)
        return;
      this.m_selectClauseResults = new StatusCodeCollection();
    }
  }

  [DataMember(Name = "SelectClauseDiagnosticInfos", IsRequired = false, Order = 2)]
  public DiagnosticInfoCollection SelectClauseDiagnosticInfos
  {
    get => this.m_selectClauseDiagnosticInfos;
    set
    {
      this.m_selectClauseDiagnosticInfos = value;
      if (value != null)
        return;
      this.m_selectClauseDiagnosticInfos = new DiagnosticInfoCollection();
    }
  }

  [DataMember(Name = "WhereClauseResult", IsRequired = false, Order = 3)]
  public ContentFilterResult WhereClauseResult
  {
    get => this.m_whereClauseResult;
    set
    {
      this.m_whereClauseResult = value;
      if (value != null)
        return;
      this.m_whereClauseResult = new ContentFilterResult();
    }
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.EventFilterResult;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EventFilterResult_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EventFilterResult_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EventFilterResult_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteStatusCodeArray("SelectClauseResults", (IList<StatusCode>) this.SelectClauseResults);
    encoder.WriteDiagnosticInfoArray("SelectClauseDiagnosticInfos", (IList<DiagnosticInfo>) this.SelectClauseDiagnosticInfos);
    encoder.WriteEncodeable("WhereClauseResult", (IEncodeable) this.WhereClauseResult, typeof (ContentFilterResult));
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.SelectClauseResults = decoder.ReadStatusCodeArray("SelectClauseResults");
    this.SelectClauseDiagnosticInfos = decoder.ReadDiagnosticInfoArray("SelectClauseDiagnosticInfos");
    this.WhereClauseResult = (ContentFilterResult) decoder.ReadEncodeable("WhereClauseResult", typeof (ContentFilterResult));
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is EventFilterResult eventFilterResult && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_selectClauseResults, (object) eventFilterResult.m_selectClauseResults) && Utils.IsEqual((object) this.m_selectClauseDiagnosticInfos, (object) eventFilterResult.m_selectClauseDiagnosticInfos) && Utils.IsEqual((object) this.m_whereClauseResult, (object) eventFilterResult.m_whereClauseResult) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (EventFilterResult) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    EventFilterResult eventFilterResult = (EventFilterResult) base.MemberwiseClone();
    eventFilterResult.m_selectClauseResults = (StatusCodeCollection) Utils.Clone((object) this.m_selectClauseResults);
    eventFilterResult.m_selectClauseDiagnosticInfos = (DiagnosticInfoCollection) Utils.Clone((object) this.m_selectClauseDiagnosticInfos);
    eventFilterResult.m_whereClauseResult = (ContentFilterResult) Utils.Clone((object) this.m_whereClauseResult);
    return (object) eventFilterResult;
  }
}
