// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataChangeNotification
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
public class DataChangeNotification : NotificationData
{
  private MonitoredItemNotificationCollection m_monitoredItems;
  private DiagnosticInfoCollection m_diagnosticInfos;

  public DataChangeNotification() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_monitoredItems = new MonitoredItemNotificationCollection();
    this.m_diagnosticInfos = new DiagnosticInfoCollection();
  }

  [DataMember(Name = "MonitoredItems", IsRequired = false, Order = 1)]
  public MonitoredItemNotificationCollection MonitoredItems
  {
    get => this.m_monitoredItems;
    set
    {
      this.m_monitoredItems = value;
      if (value != null)
        return;
      this.m_monitoredItems = new MonitoredItemNotificationCollection();
    }
  }

  [DataMember(Name = "DiagnosticInfos", IsRequired = false, Order = 2)]
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

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.DataChangeNotification;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DataChangeNotification_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DataChangeNotification_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DataChangeNotification_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeableArray("MonitoredItems", (IList<IEncodeable>) this.MonitoredItems.ToArray(), typeof (MonitoredItemNotification));
    encoder.WriteDiagnosticInfoArray("DiagnosticInfos", (IList<DiagnosticInfo>) this.DiagnosticInfos);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.MonitoredItems = (MonitoredItemNotificationCollection) (MonitoredItemNotification[]) decoder.ReadEncodeableArray("MonitoredItems", typeof (MonitoredItemNotification));
    this.DiagnosticInfos = decoder.ReadDiagnosticInfoArray("DiagnosticInfos");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is DataChangeNotification changeNotification && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_monitoredItems, (object) changeNotification.m_monitoredItems) && Utils.IsEqual((object) this.m_diagnosticInfos, (object) changeNotification.m_diagnosticInfos) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (DataChangeNotification) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DataChangeNotification changeNotification = (DataChangeNotification) base.MemberwiseClone();
    changeNotification.m_monitoredItems = (MonitoredItemNotificationCollection) Utils.Clone((object) this.m_monitoredItems);
    changeNotification.m_diagnosticInfos = (DiagnosticInfoCollection) Utils.Clone((object) this.m_diagnosticInfos);
    return (object) changeNotification;
  }
}
