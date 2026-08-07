// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DecimalDataType
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
public class DecimalDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private short m_scale;
  private byte[] m_value;

  public DecimalDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_scale = (short) 0;
    this.m_value = (byte[]) null;
  }

  [DataMember(Name = "Scale", IsRequired = false, Order = 1)]
  public short Scale
  {
    get => this.m_scale;
    set => this.m_scale = value;
  }

  [DataMember(Name = "Value", IsRequired = false, Order = 2)]
  public byte[] Value
  {
    get => this.m_value;
    set => this.m_value = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.DecimalDataType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DecimalDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DecimalDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DecimalDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteInt16("Scale", this.Scale);
    encoder.WriteByteString("Value", this.Value);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Scale = decoder.ReadInt16("Scale");
    this.Value = decoder.ReadByteString("Value");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is DecimalDataType decimalDataType && Utils.IsEqual((object) this.m_scale, (object) decimalDataType.m_scale) && Utils.IsEqual((object) this.m_value, (object) decimalDataType.m_value);
  }

  public virtual object Clone() => (object) (DecimalDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DecimalDataType decimalDataType = (DecimalDataType) base.MemberwiseClone();
    decimalDataType.m_scale = (short) Utils.Clone((object) this.m_scale);
    decimalDataType.m_value = (byte[]) Utils.Clone((object) this.m_value);
    return (object) decimalDataType;
  }
}
