// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UnsignedRationalNumber
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
public class UnsignedRationalNumber : IEncodeable, ICloneable, IJsonEncodeable
{
  private uint m_numerator;
  private uint m_denominator;

  public UnsignedRationalNumber() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_numerator = 0U;
    this.m_denominator = 0U;
  }

  [DataMember(Name = "Numerator", IsRequired = false, Order = 1)]
  public uint Numerator
  {
    get => this.m_numerator;
    set => this.m_numerator = value;
  }

  [DataMember(Name = "Denominator", IsRequired = false, Order = 2)]
  public uint Denominator
  {
    get => this.m_denominator;
    set => this.m_denominator = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.UnsignedRationalNumber;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UnsignedRationalNumber_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UnsignedRationalNumber_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UnsignedRationalNumber_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteUInt32("Numerator", this.Numerator);
    encoder.WriteUInt32("Denominator", this.Denominator);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Numerator = decoder.ReadUInt32("Numerator");
    this.Denominator = decoder.ReadUInt32("Denominator");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is UnsignedRationalNumber unsignedRationalNumber && Utils.IsEqual((object) this.m_numerator, (object) unsignedRationalNumber.m_numerator) && Utils.IsEqual((object) this.m_denominator, (object) unsignedRationalNumber.m_denominator);
  }

  public virtual object Clone() => (object) (UnsignedRationalNumber) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    UnsignedRationalNumber unsignedRationalNumber = (UnsignedRationalNumber) base.MemberwiseClone();
    unsignedRationalNumber.m_numerator = (uint) Utils.Clone((object) this.m_numerator);
    unsignedRationalNumber.m_denominator = (uint) Utils.Clone((object) this.m_denominator);
    return (object) unsignedRationalNumber;
  }
}
