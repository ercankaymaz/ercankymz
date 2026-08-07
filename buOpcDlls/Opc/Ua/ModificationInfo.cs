// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ModificationInfo
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
public class ModificationInfo : IEncodeable, ICloneable, IJsonEncodeable
{
  private DateTime m_modificationTime;
  private HistoryUpdateType m_updateType;
  private string m_userName;

  public ModificationInfo() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_modificationTime = DateTime.MinValue;
    this.m_updateType = HistoryUpdateType.Insert;
    this.m_userName = (string) null;
  }

  [DataMember(Name = "ModificationTime", IsRequired = false, Order = 1)]
  public DateTime ModificationTime
  {
    get => this.m_modificationTime;
    set => this.m_modificationTime = value;
  }

  [DataMember(Name = "UpdateType", IsRequired = false, Order = 2)]
  public HistoryUpdateType UpdateType
  {
    get => this.m_updateType;
    set => this.m_updateType = value;
  }

  [DataMember(Name = "UserName", IsRequired = false, Order = 3)]
  public string UserName
  {
    get => this.m_userName;
    set => this.m_userName = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ModificationInfo;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ModificationInfo_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ModificationInfo_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ModificationInfo_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteDateTime("ModificationTime", this.ModificationTime);
    encoder.WriteEnumerated("UpdateType", (Enum) this.UpdateType);
    encoder.WriteString("UserName", this.UserName);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ModificationTime = decoder.ReadDateTime("ModificationTime");
    this.UpdateType = (HistoryUpdateType) decoder.ReadEnumerated("UpdateType", typeof (HistoryUpdateType));
    this.UserName = decoder.ReadString("UserName");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ModificationInfo modificationInfo && Utils.IsEqual(this.m_modificationTime, modificationInfo.m_modificationTime) && Utils.IsEqual((object) this.m_updateType, (object) modificationInfo.m_updateType) && Utils.IsEqual((object) this.m_userName, (object) modificationInfo.m_userName);
  }

  public virtual object Clone() => (object) (ModificationInfo) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ModificationInfo modificationInfo = (ModificationInfo) base.MemberwiseClone();
    modificationInfo.m_modificationTime = (DateTime) Utils.Clone((object) this.m_modificationTime);
    modificationInfo.m_updateType = (HistoryUpdateType) Utils.Clone((object) this.m_updateType);
    modificationInfo.m_userName = (string) Utils.Clone((object) this.m_userName);
    return (object) modificationInfo;
  }
}
