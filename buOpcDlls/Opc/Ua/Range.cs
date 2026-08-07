// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Range
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
public class Range : IEncodeable, ICloneable, IJsonEncodeable
{
  private double m_low;
  private double m_high;

  public Range() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_low = 0.0;
    this.m_high = 0.0;
  }

  [DataMember(Name = "Low", IsRequired = false, Order = 1)]
  public double Low
  {
    get => this.m_low;
    set => this.m_low = value;
  }

  [DataMember(Name = "High", IsRequired = false, Order = 2)]
  public double High
  {
    get => this.m_high;
    set => this.m_high = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.Range;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.Range_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.Range_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.Range_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteDouble("Low", this.Low);
    encoder.WriteDouble("High", this.High);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Low = decoder.ReadDouble("Low");
    this.High = decoder.ReadDouble("High");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is Range range && Utils.IsEqual((object) this.m_low, (object) range.m_low) && Utils.IsEqual((object) this.m_high, (object) range.m_high);
  }

  public virtual object Clone() => (object) (Range) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    Range range = (Range) base.MemberwiseClone();
    range.m_low = (double) Utils.Clone((object) this.m_low);
    range.m_high = (double) Utils.Clone((object) this.m_high);
    return (object) range;
  }

  public Range(double high, double low)
  {
    this.m_low = low;
    this.m_high = high;
    if (low <= high)
      return;
    this.m_high = low;
    this.m_low = high;
  }

  public double Magnitude => Math.Abs(this.m_high - this.m_low);
}
