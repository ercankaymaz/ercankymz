// Decompiled with JetBrains decompiler
// Type: Opc.Ua.MonitoredItemNotification
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
public class MonitoredItemNotification : IEncodeable, ICloneable, IJsonEncodeable
{
  private uint m_clientHandle;
  private DataValue m_value;
  private NotificationMessage m_message;
  private DiagnosticInfo m_diagnosticInfo;

  public MonitoredItemNotification() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_clientHandle = 0U;
    this.m_value = new DataValue();
  }

  [DataMember(Name = "ClientHandle", IsRequired = false, Order = 1)]
  public uint ClientHandle
  {
    get => this.m_clientHandle;
    set => this.m_clientHandle = value;
  }

  [DataMember(Name = "Value", IsRequired = false, Order = 2)]
  public DataValue Value
  {
    get => this.m_value;
    set => this.m_value = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.MonitoredItemNotification;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.MonitoredItemNotification_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.MonitoredItemNotification_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.MonitoredItemNotification_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteUInt32("ClientHandle", this.ClientHandle);
    encoder.WriteDataValue("Value", this.Value);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ClientHandle = decoder.ReadUInt32("ClientHandle");
    this.Value = decoder.ReadDataValue("Value");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is MonitoredItemNotification itemNotification && Utils.IsEqual((object) this.m_clientHandle, (object) itemNotification.m_clientHandle) && Utils.IsEqual((object) this.m_value, (object) itemNotification.m_value);
  }

  public virtual object Clone() => (object) (MonitoredItemNotification) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    MonitoredItemNotification itemNotification = (MonitoredItemNotification) base.MemberwiseClone();
    itemNotification.m_clientHandle = (uint) Utils.Clone((object) this.m_clientHandle);
    itemNotification.m_value = (DataValue) Utils.Clone((object) this.m_value);
    return (object) itemNotification;
  }

  public NotificationMessage Message
  {
    get => this.m_message;
    set => this.m_message = value;
  }

  public DiagnosticInfo DiagnosticInfo
  {
    get => this.m_diagnosticInfo;
    set => this.m_diagnosticInfo = value;
  }
}
