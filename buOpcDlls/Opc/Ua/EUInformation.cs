// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EUInformation
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
public class EUInformation : IEncodeable, ICloneable, IJsonEncodeable
{
  private string m_namespaceUri;
  private int m_unitId;
  private LocalizedText m_displayName;
  private LocalizedText m_description;

  public EUInformation() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_namespaceUri = (string) null;
    this.m_unitId = 0;
    this.m_displayName = (LocalizedText) null;
    this.m_description = (LocalizedText) null;
  }

  [DataMember(Name = "NamespaceUri", IsRequired = false, Order = 1)]
  public string NamespaceUri
  {
    get => this.m_namespaceUri;
    set => this.m_namespaceUri = value;
  }

  [DataMember(Name = "UnitId", IsRequired = false, Order = 2)]
  public int UnitId
  {
    get => this.m_unitId;
    set => this.m_unitId = value;
  }

  [DataMember(Name = "DisplayName", IsRequired = false, Order = 3)]
  public LocalizedText DisplayName
  {
    get => this.m_displayName;
    set => this.m_displayName = value;
  }

  [DataMember(Name = "Description", IsRequired = false, Order = 4)]
  public LocalizedText Description
  {
    get => this.m_description;
    set => this.m_description = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.EUInformation;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EUInformation_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EUInformation_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EUInformation_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("NamespaceUri", this.NamespaceUri);
    encoder.WriteInt32("UnitId", this.UnitId);
    encoder.WriteLocalizedText("DisplayName", this.DisplayName);
    encoder.WriteLocalizedText("Description", this.Description);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.NamespaceUri = decoder.ReadString("NamespaceUri");
    this.UnitId = decoder.ReadInt32("UnitId");
    this.DisplayName = decoder.ReadLocalizedText("DisplayName");
    this.Description = decoder.ReadLocalizedText("Description");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is EUInformation euInformation && Utils.IsEqual((object) this.m_namespaceUri, (object) euInformation.m_namespaceUri) && Utils.IsEqual((object) this.m_unitId, (object) euInformation.m_unitId) && Utils.IsEqual((object) this.m_displayName, (object) euInformation.m_displayName) && Utils.IsEqual((object) this.m_description, (object) euInformation.m_description);
  }

  public virtual object Clone() => (object) (EUInformation) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    EUInformation euInformation = (EUInformation) base.MemberwiseClone();
    euInformation.m_namespaceUri = (string) Utils.Clone((object) this.m_namespaceUri);
    euInformation.m_unitId = (int) Utils.Clone((object) this.m_unitId);
    euInformation.m_displayName = (LocalizedText) Utils.Clone((object) this.m_displayName);
    euInformation.m_description = (LocalizedText) Utils.Clone((object) this.m_description);
    return (object) euInformation;
  }

  public EUInformation(string unitName, string namespaceUri)
  {
    this.Initialize();
    this.m_displayName = new LocalizedText(unitName);
    this.m_description = new LocalizedText(unitName);
    this.m_namespaceUri = namespaceUri;
  }

  public EUInformation(string shortName, string longName, string namespaceUri)
  {
    this.Initialize();
    this.m_displayName = new LocalizedText(shortName);
    this.m_description = new LocalizedText(longName);
    this.m_namespaceUri = namespaceUri;
  }
}
