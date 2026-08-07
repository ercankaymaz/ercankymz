// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CurrencyUnitType
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
public class CurrencyUnitType : IEncodeable, ICloneable, IJsonEncodeable
{
  private short m_numericCode;
  private sbyte m_exponent;
  private string m_alphabeticCode;
  private LocalizedText m_currency;

  public CurrencyUnitType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_numericCode = (short) 0;
    this.m_exponent = (sbyte) 0;
    this.m_alphabeticCode = (string) null;
    this.m_currency = (LocalizedText) null;
  }

  [DataMember(Name = "NumericCode", IsRequired = false, Order = 1)]
  public short NumericCode
  {
    get => this.m_numericCode;
    set => this.m_numericCode = value;
  }

  [DataMember(Name = "Exponent", IsRequired = false, Order = 2)]
  public sbyte Exponent
  {
    get => this.m_exponent;
    set => this.m_exponent = value;
  }

  [DataMember(Name = "AlphabeticCode", IsRequired = false, Order = 3)]
  public string AlphabeticCode
  {
    get => this.m_alphabeticCode;
    set => this.m_alphabeticCode = value;
  }

  [DataMember(Name = "Currency", IsRequired = false, Order = 4)]
  public LocalizedText Currency
  {
    get => this.m_currency;
    set => this.m_currency = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.CurrencyUnitType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CurrencyUnitType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CurrencyUnitType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CurrencyUnitType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteInt16("NumericCode", this.NumericCode);
    encoder.WriteSByte("Exponent", this.Exponent);
    encoder.WriteString("AlphabeticCode", this.AlphabeticCode);
    encoder.WriteLocalizedText("Currency", this.Currency);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.NumericCode = decoder.ReadInt16("NumericCode");
    this.Exponent = decoder.ReadSByte("Exponent");
    this.AlphabeticCode = decoder.ReadString("AlphabeticCode");
    this.Currency = decoder.ReadLocalizedText("Currency");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is CurrencyUnitType currencyUnitType && Utils.IsEqual((object) this.m_numericCode, (object) currencyUnitType.m_numericCode) && Utils.IsEqual((object) this.m_exponent, (object) currencyUnitType.m_exponent) && Utils.IsEqual((object) this.m_alphabeticCode, (object) currencyUnitType.m_alphabeticCode) && Utils.IsEqual((object) this.m_currency, (object) currencyUnitType.m_currency);
  }

  public virtual object Clone() => (object) (CurrencyUnitType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    CurrencyUnitType currencyUnitType = (CurrencyUnitType) base.MemberwiseClone();
    currencyUnitType.m_numericCode = (short) Utils.Clone((object) this.m_numericCode);
    currencyUnitType.m_exponent = (sbyte) Utils.Clone((object) this.m_exponent);
    currencyUnitType.m_alphabeticCode = (string) Utils.Clone((object) this.m_alphabeticCode);
    currencyUnitType.m_currency = (LocalizedText) Utils.Clone((object) this.m_currency);
    return (object) currencyUnitType;
  }
}
