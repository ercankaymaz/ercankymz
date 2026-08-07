// Decompiled with JetBrains decompiler
// Type: Opc.Ua.OptionSet
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
public class OptionSet : IEncodeable, ICloneable, IJsonEncodeable
{
  private byte[] m_value;
  private byte[] m_validBits;

  public OptionSet() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_value = (byte[]) null;
    this.m_validBits = (byte[]) null;
  }

  [DataMember(Name = "Value", IsRequired = false, Order = 1)]
  public byte[] Value
  {
    get => this.m_value;
    set => this.m_value = value;
  }

  [DataMember(Name = "ValidBits", IsRequired = false, Order = 2)]
  public byte[] ValidBits
  {
    get => this.m_validBits;
    set => this.m_validBits = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.OptionSet;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.OptionSet_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.OptionSet_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.OptionSet_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteByteString("Value", this.Value);
    encoder.WriteByteString("ValidBits", this.ValidBits);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Value = decoder.ReadByteString("Value");
    this.ValidBits = decoder.ReadByteString("ValidBits");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is OptionSet optionSet && Utils.IsEqual((object) this.m_value, (object) optionSet.m_value) && Utils.IsEqual((object) this.m_validBits, (object) optionSet.m_validBits);
  }

  public virtual object Clone() => (object) (OptionSet) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    OptionSet optionSet = (OptionSet) base.MemberwiseClone();
    optionSet.m_value = (byte[]) Utils.Clone((object) this.m_value);
    optionSet.m_validBits = (byte[]) Utils.Clone((object) this.m_validBits);
    return (object) optionSet;
  }
}
