// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NodeAttributes
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
public class NodeAttributes : IEncodeable, ICloneable, IJsonEncodeable
{
  private uint m_specifiedAttributes;
  private LocalizedText m_displayName;
  private LocalizedText m_description;
  private uint m_writeMask;
  private uint m_userWriteMask;

  public NodeAttributes() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_specifiedAttributes = 0U;
    this.m_displayName = (LocalizedText) null;
    this.m_description = (LocalizedText) null;
    this.m_writeMask = 0U;
    this.m_userWriteMask = 0U;
  }

  [DataMember(Name = "SpecifiedAttributes", IsRequired = false, Order = 1)]
  public uint SpecifiedAttributes
  {
    get => this.m_specifiedAttributes;
    set => this.m_specifiedAttributes = value;
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

  [DataMember(Name = "WriteMask", IsRequired = false, Order = 4)]
  public uint WriteMask
  {
    get => this.m_writeMask;
    set => this.m_writeMask = value;
  }

  [DataMember(Name = "UserWriteMask", IsRequired = false, Order = 5)]
  public uint UserWriteMask
  {
    get => this.m_userWriteMask;
    set => this.m_userWriteMask = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.NodeAttributes;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.NodeAttributes_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.NodeAttributes_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.NodeAttributes_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteUInt32("SpecifiedAttributes", this.SpecifiedAttributes);
    encoder.WriteLocalizedText("DisplayName", this.DisplayName);
    encoder.WriteLocalizedText("Description", this.Description);
    encoder.WriteUInt32("WriteMask", this.WriteMask);
    encoder.WriteUInt32("UserWriteMask", this.UserWriteMask);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.SpecifiedAttributes = decoder.ReadUInt32("SpecifiedAttributes");
    this.DisplayName = decoder.ReadLocalizedText("DisplayName");
    this.Description = decoder.ReadLocalizedText("Description");
    this.WriteMask = decoder.ReadUInt32("WriteMask");
    this.UserWriteMask = decoder.ReadUInt32("UserWriteMask");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is NodeAttributes nodeAttributes && Utils.IsEqual((object) this.m_specifiedAttributes, (object) nodeAttributes.m_specifiedAttributes) && Utils.IsEqual((object) this.m_displayName, (object) nodeAttributes.m_displayName) && Utils.IsEqual((object) this.m_description, (object) nodeAttributes.m_description) && Utils.IsEqual((object) this.m_writeMask, (object) nodeAttributes.m_writeMask) && Utils.IsEqual((object) this.m_userWriteMask, (object) nodeAttributes.m_userWriteMask);
  }

  public virtual object Clone() => (object) (NodeAttributes) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    NodeAttributes nodeAttributes = (NodeAttributes) base.MemberwiseClone();
    nodeAttributes.m_specifiedAttributes = (uint) Utils.Clone((object) this.m_specifiedAttributes);
    nodeAttributes.m_displayName = (LocalizedText) Utils.Clone((object) this.m_displayName);
    nodeAttributes.m_description = (LocalizedText) Utils.Clone((object) this.m_description);
    nodeAttributes.m_writeMask = (uint) Utils.Clone((object) this.m_writeMask);
    nodeAttributes.m_userWriteMask = (uint) Utils.Clone((object) this.m_userWriteMask);
    return (object) nodeAttributes;
  }
}
