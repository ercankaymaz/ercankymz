// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EphemeralKeyType
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
public class EphemeralKeyType : IEncodeable, ICloneable, IJsonEncodeable
{
  private byte[] m_publicKey;
  private byte[] m_signature;

  public EphemeralKeyType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_publicKey = (byte[]) null;
    this.m_signature = (byte[]) null;
  }

  [DataMember(Name = "PublicKey", IsRequired = false, Order = 1)]
  public byte[] PublicKey
  {
    get => this.m_publicKey;
    set => this.m_publicKey = value;
  }

  [DataMember(Name = "Signature", IsRequired = false, Order = 2)]
  public byte[] Signature
  {
    get => this.m_signature;
    set => this.m_signature = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.EphemeralKeyType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EphemeralKeyType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EphemeralKeyType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EphemeralKeyType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteByteString("PublicKey", this.PublicKey);
    encoder.WriteByteString("Signature", this.Signature);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.PublicKey = decoder.ReadByteString("PublicKey");
    this.Signature = decoder.ReadByteString("Signature");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is EphemeralKeyType ephemeralKeyType && Utils.IsEqual((object) this.m_publicKey, (object) ephemeralKeyType.m_publicKey) && Utils.IsEqual((object) this.m_signature, (object) ephemeralKeyType.m_signature);
  }

  public virtual object Clone() => (object) (EphemeralKeyType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    EphemeralKeyType ephemeralKeyType = (EphemeralKeyType) base.MemberwiseClone();
    ephemeralKeyType.m_publicKey = (byte[]) Utils.Clone((object) this.m_publicKey);
    ephemeralKeyType.m_signature = (byte[]) Utils.Clone((object) this.m_signature);
    return (object) ephemeralKeyType;
  }
}
