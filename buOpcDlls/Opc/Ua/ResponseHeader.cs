// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ResponseHeader
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
public class ResponseHeader : IEncodeable, ICloneable, IJsonEncodeable
{
  private DateTime m_timestamp;
  private uint m_requestHandle;
  private StatusCode m_serviceResult;
  private DiagnosticInfo m_serviceDiagnostics;
  private StringCollection m_stringTable;
  private ExtensionObject m_additionalHeader;

  public ResponseHeader() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_timestamp = DateTime.MinValue;
    this.m_requestHandle = 0U;
    this.m_serviceResult = (StatusCode) 0U;
    this.m_serviceDiagnostics = (DiagnosticInfo) null;
    this.m_stringTable = new StringCollection();
    this.m_additionalHeader = (ExtensionObject) null;
  }

  [DataMember(Name = "Timestamp", IsRequired = false, Order = 1)]
  public DateTime Timestamp
  {
    get => this.m_timestamp;
    set => this.m_timestamp = value;
  }

  [DataMember(Name = "RequestHandle", IsRequired = false, Order = 2)]
  public uint RequestHandle
  {
    get => this.m_requestHandle;
    set => this.m_requestHandle = value;
  }

  [DataMember(Name = "ServiceResult", IsRequired = false, Order = 3)]
  public StatusCode ServiceResult
  {
    get => this.m_serviceResult;
    set => this.m_serviceResult = value;
  }

  [DataMember(Name = "ServiceDiagnostics", IsRequired = false, Order = 4)]
  public DiagnosticInfo ServiceDiagnostics
  {
    get => this.m_serviceDiagnostics;
    set => this.m_serviceDiagnostics = value;
  }

  [DataMember(Name = "StringTable", IsRequired = false, Order = 5)]
  public StringCollection StringTable
  {
    get => this.m_stringTable;
    set
    {
      this.m_stringTable = value;
      if (value != null)
        return;
      this.m_stringTable = new StringCollection();
    }
  }

  [DataMember(Name = "AdditionalHeader", IsRequired = false, Order = 6)]
  public ExtensionObject AdditionalHeader
  {
    get => this.m_additionalHeader;
    set => this.m_additionalHeader = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ResponseHeader;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ResponseHeader_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ResponseHeader_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ResponseHeader_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteDateTime("Timestamp", this.Timestamp);
    encoder.WriteUInt32("RequestHandle", this.RequestHandle);
    encoder.WriteStatusCode("ServiceResult", this.ServiceResult);
    encoder.WriteDiagnosticInfo("ServiceDiagnostics", this.ServiceDiagnostics);
    encoder.WriteStringArray("StringTable", (IList<string>) this.StringTable);
    encoder.WriteExtensionObject("AdditionalHeader", this.AdditionalHeader);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Timestamp = decoder.ReadDateTime("Timestamp");
    this.RequestHandle = decoder.ReadUInt32("RequestHandle");
    this.ServiceResult = decoder.ReadStatusCode("ServiceResult");
    this.ServiceDiagnostics = decoder.ReadDiagnosticInfo("ServiceDiagnostics");
    this.StringTable = decoder.ReadStringArray("StringTable");
    this.AdditionalHeader = decoder.ReadExtensionObject("AdditionalHeader");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ResponseHeader responseHeader && Utils.IsEqual(this.m_timestamp, responseHeader.m_timestamp) && Utils.IsEqual((object) this.m_requestHandle, (object) responseHeader.m_requestHandle) && Utils.IsEqual((object) this.m_serviceResult, (object) responseHeader.m_serviceResult) && Utils.IsEqual((object) this.m_serviceDiagnostics, (object) responseHeader.m_serviceDiagnostics) && Utils.IsEqual((object) this.m_stringTable, (object) responseHeader.m_stringTable) && Utils.IsEqual((object) this.m_additionalHeader, (object) responseHeader.m_additionalHeader);
  }

  public virtual object Clone() => (object) (ResponseHeader) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ResponseHeader responseHeader = (ResponseHeader) base.MemberwiseClone();
    responseHeader.m_timestamp = (DateTime) Utils.Clone((object) this.m_timestamp);
    responseHeader.m_requestHandle = (uint) Utils.Clone((object) this.m_requestHandle);
    responseHeader.m_serviceResult = (StatusCode) Utils.Clone((object) this.m_serviceResult);
    responseHeader.m_serviceDiagnostics = (DiagnosticInfo) Utils.Clone((object) this.m_serviceDiagnostics);
    responseHeader.m_stringTable = (StringCollection) Utils.Clone((object) this.m_stringTable);
    responseHeader.m_additionalHeader = (ExtensionObject) Utils.Clone((object) this.m_additionalHeader);
    return (object) responseHeader;
  }
}
