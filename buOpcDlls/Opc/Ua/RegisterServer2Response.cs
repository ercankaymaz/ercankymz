// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RegisterServer2Response
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
public class RegisterServer2Response : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
  private ResponseHeader m_responseHeader;
  private StatusCodeCollection m_configurationResults;
  private DiagnosticInfoCollection m_diagnosticInfos;

  public RegisterServer2Response() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_responseHeader = new ResponseHeader();
    this.m_configurationResults = new StatusCodeCollection();
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

  [DataMember(Name = "ConfigurationResults", IsRequired = false, Order = 2)]
  public StatusCodeCollection ConfigurationResults
  {
    get => this.m_configurationResults;
    set
    {
      this.m_configurationResults = value;
      if (value != null)
        return;
      this.m_configurationResults = new StatusCodeCollection();
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

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.RegisterServer2Response;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RegisterServer2Response_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RegisterServer2Response_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RegisterServer2Response_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("ResponseHeader", (IEncodeable) this.ResponseHeader, typeof (ResponseHeader));
    encoder.WriteStatusCodeArray("ConfigurationResults", (IList<StatusCode>) this.ConfigurationResults);
    encoder.WriteDiagnosticInfoArray("DiagnosticInfos", (IList<DiagnosticInfo>) this.DiagnosticInfos);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ResponseHeader = (ResponseHeader) decoder.ReadEncodeable("ResponseHeader", typeof (ResponseHeader));
    this.ConfigurationResults = decoder.ReadStatusCodeArray("ConfigurationResults");
    this.DiagnosticInfos = decoder.ReadDiagnosticInfoArray("DiagnosticInfos");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is RegisterServer2Response registerServer2Response && Utils.IsEqual((object) this.m_responseHeader, (object) registerServer2Response.m_responseHeader) && Utils.IsEqual((object) this.m_configurationResults, (object) registerServer2Response.m_configurationResults) && Utils.IsEqual((object) this.m_diagnosticInfos, (object) registerServer2Response.m_diagnosticInfos);
  }

  public virtual object Clone() => (object) (RegisterServer2Response) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    RegisterServer2Response registerServer2Response = (RegisterServer2Response) base.MemberwiseClone();
    registerServer2Response.m_responseHeader = (ResponseHeader) Utils.Clone((object) this.m_responseHeader);
    registerServer2Response.m_configurationResults = (StatusCodeCollection) Utils.Clone((object) this.m_configurationResults);
    registerServer2Response.m_diagnosticInfos = (DiagnosticInfoCollection) Utils.Clone((object) this.m_diagnosticInfos);
    return (object) registerServer2Response;
  }
}
