// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RequestHeader
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class RequestHeader : IEncodeable, ICloneable, IJsonEncodeable
{
  private NodeId m_authenticationToken;
  private DateTime m_timestamp;
  private uint m_requestHandle;
  private uint m_returnDiagnostics;
  private string m_auditEntryId;
  private uint m_timeoutHint;
  private ExtensionObject m_additionalHeader;

  public RequestHeader() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_authenticationToken = (NodeId) null;
    this.m_timestamp = DateTime.MinValue;
    this.m_requestHandle = 0U;
    this.m_returnDiagnostics = 0U;
    this.m_auditEntryId = (string) null;
    this.m_timeoutHint = 0U;
    this.m_additionalHeader = (ExtensionObject) null;
  }

  [DataMember(Name = "AuthenticationToken", IsRequired = false, Order = 1)]
  public NodeId AuthenticationToken
  {
    get => this.m_authenticationToken;
    set => this.m_authenticationToken = value;
  }

  [DataMember(Name = "Timestamp", IsRequired = false, Order = 2)]
  public DateTime Timestamp
  {
    get => this.m_timestamp;
    set => this.m_timestamp = value;
  }

  [DataMember(Name = "RequestHandle", IsRequired = false, Order = 3)]
  public uint RequestHandle
  {
    get => this.m_requestHandle;
    set => this.m_requestHandle = value;
  }

  [DataMember(Name = "ReturnDiagnostics", IsRequired = false, Order = 4)]
  public uint ReturnDiagnostics
  {
    get => this.m_returnDiagnostics;
    set => this.m_returnDiagnostics = value;
  }

  [DataMember(Name = "AuditEntryId", IsRequired = false, Order = 5)]
  public string AuditEntryId
  {
    get => this.m_auditEntryId;
    set => this.m_auditEntryId = value;
  }

  [DataMember(Name = "TimeoutHint", IsRequired = false, Order = 6)]
  public uint TimeoutHint
  {
    get => this.m_timeoutHint;
    set => this.m_timeoutHint = value;
  }

  [DataMember(Name = "AdditionalHeader", IsRequired = false, Order = 7)]
  public ExtensionObject AdditionalHeader
  {
    get => this.m_additionalHeader;
    set => this.m_additionalHeader = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.RequestHeader;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RequestHeader_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RequestHeader_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RequestHeader_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("AuthenticationToken", this.AuthenticationToken);
    encoder.WriteDateTime("Timestamp", this.Timestamp);
    encoder.WriteUInt32("RequestHandle", this.RequestHandle);
    encoder.WriteUInt32("ReturnDiagnostics", this.ReturnDiagnostics);
    encoder.WriteString("AuditEntryId", this.AuditEntryId);
    encoder.WriteUInt32("TimeoutHint", this.TimeoutHint);
    encoder.WriteExtensionObject("AdditionalHeader", this.AdditionalHeader);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.AuthenticationToken = decoder.ReadNodeId("AuthenticationToken");
    this.Timestamp = decoder.ReadDateTime("Timestamp");
    this.RequestHandle = decoder.ReadUInt32("RequestHandle");
    this.ReturnDiagnostics = decoder.ReadUInt32("ReturnDiagnostics");
    this.AuditEntryId = decoder.ReadString("AuditEntryId");
    this.TimeoutHint = decoder.ReadUInt32("TimeoutHint");
    this.AdditionalHeader = decoder.ReadExtensionObject("AdditionalHeader");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is RequestHeader requestHeader && Utils.IsEqual((object) this.m_authenticationToken, (object) requestHeader.m_authenticationToken) && Utils.IsEqual(this.m_timestamp, requestHeader.m_timestamp) && Utils.IsEqual((object) this.m_requestHandle, (object) requestHeader.m_requestHandle) && Utils.IsEqual((object) this.m_returnDiagnostics, (object) requestHeader.m_returnDiagnostics) && Utils.IsEqual((object) this.m_auditEntryId, (object) requestHeader.m_auditEntryId) && Utils.IsEqual((object) this.m_timeoutHint, (object) requestHeader.m_timeoutHint) && Utils.IsEqual((object) this.m_additionalHeader, (object) requestHeader.m_additionalHeader);
  }

  public virtual object Clone() => (object) (RequestHeader) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    RequestHeader requestHeader = (RequestHeader) base.MemberwiseClone();
    requestHeader.m_authenticationToken = (NodeId) Utils.Clone((object) this.m_authenticationToken);
    requestHeader.m_timestamp = (DateTime) Utils.Clone((object) this.m_timestamp);
    requestHeader.m_requestHandle = (uint) Utils.Clone((object) this.m_requestHandle);
    requestHeader.m_returnDiagnostics = (uint) Utils.Clone((object) this.m_returnDiagnostics);
    requestHeader.m_auditEntryId = (string) Utils.Clone((object) this.m_auditEntryId);
    requestHeader.m_timeoutHint = (uint) Utils.Clone((object) this.m_timeoutHint);
    requestHeader.m_additionalHeader = (ExtensionObject) Utils.Clone((object) this.m_additionalHeader);
    return (object) requestHeader;
  }
}
