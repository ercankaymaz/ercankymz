// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ConfigurationVersionDataType
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
public class ConfigurationVersionDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private uint m_majorVersion;
  private uint m_minorVersion;

  public ConfigurationVersionDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_majorVersion = 0U;
    this.m_minorVersion = 0U;
  }

  [DataMember(Name = "MajorVersion", IsRequired = false, Order = 1)]
  public uint MajorVersion
  {
    get => this.m_majorVersion;
    set => this.m_majorVersion = value;
  }

  [DataMember(Name = "MinorVersion", IsRequired = false, Order = 2)]
  public uint MinorVersion
  {
    get => this.m_minorVersion;
    set => this.m_minorVersion = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ConfigurationVersionDataType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ConfigurationVersionDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ConfigurationVersionDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ConfigurationVersionDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteUInt32("MajorVersion", this.MajorVersion);
    encoder.WriteUInt32("MinorVersion", this.MinorVersion);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.MajorVersion = decoder.ReadUInt32("MajorVersion");
    this.MinorVersion = decoder.ReadUInt32("MinorVersion");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ConfigurationVersionDataType configurationVersionDataType && Utils.IsEqual((object) this.m_majorVersion, (object) configurationVersionDataType.m_majorVersion) && Utils.IsEqual((object) this.m_minorVersion, (object) configurationVersionDataType.m_minorVersion);
  }

  public virtual object Clone() => (object) (ConfigurationVersionDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ConfigurationVersionDataType configurationVersionDataType = (ConfigurationVersionDataType) base.MemberwiseClone();
    configurationVersionDataType.m_majorVersion = (uint) Utils.Clone((object) this.m_majorVersion);
    configurationVersionDataType.m_minorVersion = (uint) Utils.Clone((object) this.m_minorVersion);
    return (object) configurationVersionDataType;
  }
}
