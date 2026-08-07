// Decompiled with JetBrains decompiler
// Type: Opc.Ua.KeyValuePair
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
public class KeyValuePair : IEncodeable, ICloneable, IJsonEncodeable
{
  private QualifiedName m_key;
  private Variant m_value;

  public KeyValuePair() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_key = (QualifiedName) null;
    this.m_value = Variant.Null;
  }

  [DataMember(Name = "Key", IsRequired = false, Order = 1)]
  public QualifiedName Key
  {
    get => this.m_key;
    set => this.m_key = value;
  }

  [DataMember(Name = "Value", IsRequired = false, Order = 2)]
  public Variant Value
  {
    get => this.m_value;
    set => this.m_value = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.KeyValuePair;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.KeyValuePair_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.KeyValuePair_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.KeyValuePair_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteQualifiedName("Key", this.Key);
    encoder.WriteVariant("Value", this.Value);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Key = decoder.ReadQualifiedName("Key");
    this.Value = decoder.ReadVariant("Value");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is KeyValuePair keyValuePair && Utils.IsEqual((object) this.m_key, (object) keyValuePair.m_key) && Utils.IsEqual((object) this.m_value, (object) keyValuePair.m_value);
  }

  public virtual object Clone() => (object) (KeyValuePair) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    KeyValuePair keyValuePair = (KeyValuePair) base.MemberwiseClone();
    keyValuePair.m_key = (QualifiedName) Utils.Clone((object) this.m_key);
    keyValuePair.m_value = (Variant) Utils.Clone((object) this.m_value);
    return (object) keyValuePair;
  }
}
