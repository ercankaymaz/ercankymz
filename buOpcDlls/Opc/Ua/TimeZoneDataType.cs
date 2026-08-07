// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TimeZoneDataType
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
public class TimeZoneDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private short m_offset;
  private bool m_daylightSavingInOffset;

  public TimeZoneDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_offset = (short) 0;
    this.m_daylightSavingInOffset = true;
  }

  [DataMember(Name = "Offset", IsRequired = false, Order = 1)]
  public short Offset
  {
    get => this.m_offset;
    set => this.m_offset = value;
  }

  [DataMember(Name = "DaylightSavingInOffset", IsRequired = false, Order = 2)]
  public bool DaylightSavingInOffset
  {
    get => this.m_daylightSavingInOffset;
    set => this.m_daylightSavingInOffset = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.TimeZoneDataType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.TimeZoneDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.TimeZoneDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.TimeZoneDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteInt16("Offset", this.Offset);
    encoder.WriteBoolean("DaylightSavingInOffset", this.DaylightSavingInOffset);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Offset = decoder.ReadInt16("Offset");
    this.DaylightSavingInOffset = decoder.ReadBoolean("DaylightSavingInOffset");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is TimeZoneDataType timeZoneDataType && Utils.IsEqual((object) this.m_offset, (object) timeZoneDataType.m_offset) && Utils.IsEqual((object) this.m_daylightSavingInOffset, (object) timeZoneDataType.m_daylightSavingInOffset);
  }

  public virtual object Clone() => (object) (TimeZoneDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    TimeZoneDataType timeZoneDataType = (TimeZoneDataType) base.MemberwiseClone();
    timeZoneDataType.m_offset = (short) Utils.Clone((object) this.m_offset);
    timeZoneDataType.m_daylightSavingInOffset = (bool) Utils.Clone((object) this.m_daylightSavingInOffset);
    return (object) timeZoneDataType;
  }
}
