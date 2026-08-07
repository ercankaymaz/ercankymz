// Decompiled with JetBrains decompiler
// Type: Opc.Ua.XVType
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
public class XVType : IEncodeable, ICloneable, IJsonEncodeable
{
  private double m_x;
  private float m_value;

  public XVType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_x = 0.0;
    this.m_value = 0.0f;
  }

  [DataMember(Name = "X", IsRequired = false, Order = 1)]
  public double X
  {
    get => this.m_x;
    set => this.m_x = value;
  }

  [DataMember(Name = "Value", IsRequired = false, Order = 2)]
  public float Value
  {
    get => this.m_value;
    set => this.m_value = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.XVType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.XVType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.XVType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.XVType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteDouble("X", this.X);
    encoder.WriteFloat("Value", this.Value);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.X = decoder.ReadDouble("X");
    this.Value = decoder.ReadFloat("Value");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is XVType xvType && Utils.IsEqual((object) this.m_x, (object) xvType.m_x) && Utils.IsEqual((object) this.m_value, (object) xvType.m_value);
  }

  public virtual object Clone() => (object) (XVType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    XVType xvType = (XVType) base.MemberwiseClone();
    xvType.m_x = (double) Utils.Clone((object) this.m_x);
    xvType.m_value = (float) Utils.Clone((object) this.m_value);
    return (object) xvType;
  }
}
