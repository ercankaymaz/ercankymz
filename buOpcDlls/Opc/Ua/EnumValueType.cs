// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EnumValueType
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
public class EnumValueType : IEncodeable, ICloneable, IJsonEncodeable
{
  private long m_value;
  private LocalizedText m_displayName;
  private LocalizedText m_description;

  public EnumValueType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_value = 0L;
    this.m_displayName = (LocalizedText) null;
    this.m_description = (LocalizedText) null;
  }

  [DataMember(Name = "Value", IsRequired = false, Order = 1)]
  public long Value
  {
    get => this.m_value;
    set => this.m_value = value;
  }

  [DataMember(Name = "DisplayName", IsRequired = false, Order = 2)]
  public LocalizedText DisplayName
  {
    get => this.m_displayName;
    set => this.m_displayName = value;
  }

  [DataMember(Name = "Description", IsRequired = false, Order = 3)]
  public LocalizedText Description
  {
    get => this.m_description;
    set => this.m_description = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.EnumValueType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EnumValueType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EnumValueType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EnumValueType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteInt64("Value", this.Value);
    encoder.WriteLocalizedText("DisplayName", this.DisplayName);
    encoder.WriteLocalizedText("Description", this.Description);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Value = decoder.ReadInt64("Value");
    this.DisplayName = decoder.ReadLocalizedText("DisplayName");
    this.Description = decoder.ReadLocalizedText("Description");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is EnumValueType enumValueType && Utils.IsEqual((object) this.m_value, (object) enumValueType.m_value) && Utils.IsEqual((object) this.m_displayName, (object) enumValueType.m_displayName) && Utils.IsEqual((object) this.m_description, (object) enumValueType.m_description);
  }

  public virtual object Clone() => (object) (EnumValueType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    EnumValueType enumValueType = (EnumValueType) base.MemberwiseClone();
    enumValueType.m_value = (long) Utils.Clone((object) this.m_value);
    enumValueType.m_displayName = (LocalizedText) Utils.Clone((object) this.m_displayName);
    enumValueType.m_description = (LocalizedText) Utils.Clone((object) this.m_description);
    return (object) enumValueType;
  }
}
