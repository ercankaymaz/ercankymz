// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AggregateConfiguration
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
public class AggregateConfiguration : IEncodeable, ICloneable, IJsonEncodeable
{
  private bool m_useServerCapabilitiesDefaults;
  private bool m_treatUncertainAsBad;
  private byte m_percentDataBad;
  private byte m_percentDataGood;
  private bool m_useSlopedExtrapolation;

  public AggregateConfiguration() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_useServerCapabilitiesDefaults = true;
    this.m_treatUncertainAsBad = true;
    this.m_percentDataBad = (byte) 0;
    this.m_percentDataGood = (byte) 0;
    this.m_useSlopedExtrapolation = true;
  }

  [DataMember(Name = "UseServerCapabilitiesDefaults", IsRequired = false, Order = 1)]
  public bool UseServerCapabilitiesDefaults
  {
    get => this.m_useServerCapabilitiesDefaults;
    set => this.m_useServerCapabilitiesDefaults = value;
  }

  [DataMember(Name = "TreatUncertainAsBad", IsRequired = false, Order = 2)]
  public bool TreatUncertainAsBad
  {
    get => this.m_treatUncertainAsBad;
    set => this.m_treatUncertainAsBad = value;
  }

  [DataMember(Name = "PercentDataBad", IsRequired = false, Order = 3)]
  public byte PercentDataBad
  {
    get => this.m_percentDataBad;
    set => this.m_percentDataBad = value;
  }

  [DataMember(Name = "PercentDataGood", IsRequired = false, Order = 4)]
  public byte PercentDataGood
  {
    get => this.m_percentDataGood;
    set => this.m_percentDataGood = value;
  }

  [DataMember(Name = "UseSlopedExtrapolation", IsRequired = false, Order = 5)]
  public bool UseSlopedExtrapolation
  {
    get => this.m_useSlopedExtrapolation;
    set => this.m_useSlopedExtrapolation = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.AggregateConfiguration;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AggregateConfiguration_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AggregateConfiguration_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AggregateConfiguration_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteBoolean("UseServerCapabilitiesDefaults", this.UseServerCapabilitiesDefaults);
    encoder.WriteBoolean("TreatUncertainAsBad", this.TreatUncertainAsBad);
    encoder.WriteByte("PercentDataBad", this.PercentDataBad);
    encoder.WriteByte("PercentDataGood", this.PercentDataGood);
    encoder.WriteBoolean("UseSlopedExtrapolation", this.UseSlopedExtrapolation);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.UseServerCapabilitiesDefaults = decoder.ReadBoolean("UseServerCapabilitiesDefaults");
    this.TreatUncertainAsBad = decoder.ReadBoolean("TreatUncertainAsBad");
    this.PercentDataBad = decoder.ReadByte("PercentDataBad");
    this.PercentDataGood = decoder.ReadByte("PercentDataGood");
    this.UseSlopedExtrapolation = decoder.ReadBoolean("UseSlopedExtrapolation");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is AggregateConfiguration aggregateConfiguration && Utils.IsEqual((object) this.m_useServerCapabilitiesDefaults, (object) aggregateConfiguration.m_useServerCapabilitiesDefaults) && Utils.IsEqual((object) this.m_treatUncertainAsBad, (object) aggregateConfiguration.m_treatUncertainAsBad) && Utils.IsEqual((object) this.m_percentDataBad, (object) aggregateConfiguration.m_percentDataBad) && Utils.IsEqual((object) this.m_percentDataGood, (object) aggregateConfiguration.m_percentDataGood) && Utils.IsEqual((object) this.m_useSlopedExtrapolation, (object) aggregateConfiguration.m_useSlopedExtrapolation);
  }

  public virtual object Clone() => (object) (AggregateConfiguration) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    AggregateConfiguration aggregateConfiguration = (AggregateConfiguration) base.MemberwiseClone();
    aggregateConfiguration.m_useServerCapabilitiesDefaults = (bool) Utils.Clone((object) this.m_useServerCapabilitiesDefaults);
    aggregateConfiguration.m_treatUncertainAsBad = (bool) Utils.Clone((object) this.m_treatUncertainAsBad);
    aggregateConfiguration.m_percentDataBad = (byte) Utils.Clone((object) this.m_percentDataBad);
    aggregateConfiguration.m_percentDataGood = (byte) Utils.Clone((object) this.m_percentDataGood);
    aggregateConfiguration.m_useSlopedExtrapolation = (bool) Utils.Clone((object) this.m_useSlopedExtrapolation);
    return (object) aggregateConfiguration;
  }
}
