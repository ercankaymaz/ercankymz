// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SetTriggeringResponse
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
public class SetTriggeringResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
  private ResponseHeader m_responseHeader;
  private StatusCodeCollection m_addResults;
  private DiagnosticInfoCollection m_addDiagnosticInfos;
  private StatusCodeCollection m_removeResults;
  private DiagnosticInfoCollection m_removeDiagnosticInfos;

  public SetTriggeringResponse() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_responseHeader = new ResponseHeader();
    this.m_addResults = new StatusCodeCollection();
    this.m_addDiagnosticInfos = new DiagnosticInfoCollection();
    this.m_removeResults = new StatusCodeCollection();
    this.m_removeDiagnosticInfos = new DiagnosticInfoCollection();
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

  [DataMember(Name = "AddResults", IsRequired = false, Order = 2)]
  public StatusCodeCollection AddResults
  {
    get => this.m_addResults;
    set
    {
      this.m_addResults = value;
      if (value != null)
        return;
      this.m_addResults = new StatusCodeCollection();
    }
  }

  [DataMember(Name = "AddDiagnosticInfos", IsRequired = false, Order = 3)]
  public DiagnosticInfoCollection AddDiagnosticInfos
  {
    get => this.m_addDiagnosticInfos;
    set
    {
      this.m_addDiagnosticInfos = value;
      if (value != null)
        return;
      this.m_addDiagnosticInfos = new DiagnosticInfoCollection();
    }
  }

  [DataMember(Name = "RemoveResults", IsRequired = false, Order = 4)]
  public StatusCodeCollection RemoveResults
  {
    get => this.m_removeResults;
    set
    {
      this.m_removeResults = value;
      if (value != null)
        return;
      this.m_removeResults = new StatusCodeCollection();
    }
  }

  [DataMember(Name = "RemoveDiagnosticInfos", IsRequired = false, Order = 5)]
  public DiagnosticInfoCollection RemoveDiagnosticInfos
  {
    get => this.m_removeDiagnosticInfos;
    set
    {
      this.m_removeDiagnosticInfos = value;
      if (value != null)
        return;
      this.m_removeDiagnosticInfos = new DiagnosticInfoCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.SetTriggeringResponse;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SetTriggeringResponse_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SetTriggeringResponse_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SetTriggeringResponse_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("ResponseHeader", (IEncodeable) this.ResponseHeader, typeof (ResponseHeader));
    encoder.WriteStatusCodeArray("AddResults", (IList<StatusCode>) this.AddResults);
    encoder.WriteDiagnosticInfoArray("AddDiagnosticInfos", (IList<DiagnosticInfo>) this.AddDiagnosticInfos);
    encoder.WriteStatusCodeArray("RemoveResults", (IList<StatusCode>) this.RemoveResults);
    encoder.WriteDiagnosticInfoArray("RemoveDiagnosticInfos", (IList<DiagnosticInfo>) this.RemoveDiagnosticInfos);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ResponseHeader = (ResponseHeader) decoder.ReadEncodeable("ResponseHeader", typeof (ResponseHeader));
    this.AddResults = decoder.ReadStatusCodeArray("AddResults");
    this.AddDiagnosticInfos = decoder.ReadDiagnosticInfoArray("AddDiagnosticInfos");
    this.RemoveResults = decoder.ReadStatusCodeArray("RemoveResults");
    this.RemoveDiagnosticInfos = decoder.ReadDiagnosticInfoArray("RemoveDiagnosticInfos");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is SetTriggeringResponse triggeringResponse && Utils.IsEqual((object) this.m_responseHeader, (object) triggeringResponse.m_responseHeader) && Utils.IsEqual((object) this.m_addResults, (object) triggeringResponse.m_addResults) && Utils.IsEqual((object) this.m_addDiagnosticInfos, (object) triggeringResponse.m_addDiagnosticInfos) && Utils.IsEqual((object) this.m_removeResults, (object) triggeringResponse.m_removeResults) && Utils.IsEqual((object) this.m_removeDiagnosticInfos, (object) triggeringResponse.m_removeDiagnosticInfos);
  }

  public virtual object Clone() => (object) (SetTriggeringResponse) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    SetTriggeringResponse triggeringResponse = (SetTriggeringResponse) base.MemberwiseClone();
    triggeringResponse.m_responseHeader = (ResponseHeader) Utils.Clone((object) this.m_responseHeader);
    triggeringResponse.m_addResults = (StatusCodeCollection) Utils.Clone((object) this.m_addResults);
    triggeringResponse.m_addDiagnosticInfos = (DiagnosticInfoCollection) Utils.Clone((object) this.m_addDiagnosticInfos);
    triggeringResponse.m_removeResults = (StatusCodeCollection) Utils.Clone((object) this.m_removeResults);
    triggeringResponse.m_removeDiagnosticInfos = (DiagnosticInfoCollection) Utils.Clone((object) this.m_removeDiagnosticInfos);
    return (object) triggeringResponse;
  }
}
